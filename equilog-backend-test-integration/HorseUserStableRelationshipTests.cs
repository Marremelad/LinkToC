﻿using equilog_backend.Data;
using equilog_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace equilog_backend_test_integration
{
    public class HorseUserStableRelationshipTests : IDisposable
    {
        private readonly EquilogDbContext _context;

        public HorseUserStableRelationshipTests()
        {
            // Setup in-memory database for testing.
            var options = new DbContextOptionsBuilder<EquilogDbContext>()
                .UseInMemoryDatabase(databaseName: $"EquilogTestDb_{Guid.NewGuid()}")
                .Options;

            _context = new EquilogDbContext(options);
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            // Add test data.
            var user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PasswordHash = "hashedpassword",
            };

            var stable = new Stable
            {
                Name = "Test Stable",
                Type = "Test Type",
                County = "Test County"
            };

            var horse = new Horse
            {
                Name = "Thunder",
                Age = new DateOnly(2015, 5, 15),
                Color = "Bay",
                Breed = "Thoroughbred"
            };

            _context.Users.Add(user);
            _context.Stables.Add(stable);
            _context.Horses.Add(horse);
            _context.SaveChanges();
        }

        [Fact]
        public async Task Horse_CanBeCreated_AndRetrieved()
        {
            // Arrange
            var newHorse = new Horse
            {
                Name = "Lightning",
                Age = new DateOnly(2018, 3, 10),
                Color = "Chestnut",
                Breed = "Arabian"
            };

            // Act
            _context.Horses.Add(newHorse);
            await _context.SaveChangesAsync();
            var retrievedHorse = await _context.Horses.FindAsync(newHorse.Id);

            // Assert
            Assert.NotNull(retrievedHorse);
            Assert.Equal("Lightning", retrievedHorse.Name);
            Assert.Equal(new DateOnly(2018, 3, 10), retrievedHorse.Age);
            Assert.Equal("Chestnut", retrievedHorse.Color);
            Assert.Equal("Arabian", retrievedHorse.Breed);
        }


        [Fact]
        public async Task Create_UserHorse_Relationship()
        {
            // Arrange
            var user = await _context.Users.FirstAsync();
            var horse = await _context.Horses.FirstAsync();

            var userHorse = new UserHorse
            {
                UserIdFk = user.Id,
                HorseIdFk = horse.Id,
                UserRole = 0
            };

            // Act
            _context.UserHorses.Add(userHorse);
            await _context.SaveChangesAsync();

            // Assert
            var result = await _context.UserHorses
                .Include(uh => uh.User)
                .Include(uh => uh.Horse)
                .FirstOrDefaultAsync(uh => uh.UserIdFk == user.Id && uh.HorseIdFk == horse.Id);

            Assert.NotNull(result);
            Assert.Equal(user.Id, result.User?.Id);
            Assert.Equal(horse.Id, result.Horse?.Id);
            Assert.Equal(0, result.UserRole);
        }

        [Fact]
        public async Task Horse_CreateStableHorse_Relationship()
        {
            // Arrange
            var stable = await _context.Stables.FirstAsync();
            var horse = await _context.Horses.FirstAsync();

            var stableHorse = new StableHorse
            {
                StableIdFk = stable.Id,
                HorseIdFk = horse.Id,
            };

            // Act
            _context.StableHorses.Add(stableHorse);
            await _context.SaveChangesAsync();

            // Assert
            var result = await _context.StableHorses
                .Include(sh => sh.Stable)
                .Include(sh => sh.Horse)
                .FirstOrDefaultAsync(sh => sh.StableIdFk == stable.Id && sh.HorseIdFk == horse.Id);

            Assert.NotNull(result);
            Assert.Equal(stable.Id, result.Stable?.Id);
            Assert.Equal(horse.Id, result.Horse?.Id);
        }

        [Fact]
        public async Task Horse_LoadUserAndStable_Properties()
        {
            // Arrange
            var user = await _context.Users.FirstAsync();
            var stable = await _context.Stables.FirstAsync();
            var horse = await _context.Horses.FirstAsync();

            var userHorse = new UserHorse
            {
                UserIdFk = user.Id,
                HorseIdFk = horse.Id,
                UserRole = 2
            };

            var stableHorse = new StableHorse
            {
                StableIdFk = stable.Id,
                HorseIdFk = horse.Id,
                Stable = stable
            };

            // Act
            _context.UserHorses.Add(userHorse);
            _context.StableHorses.Add(stableHorse);
            await _context.SaveChangesAsync();

            // Get horse with navigation properties loaded.
            var loadedHorse = await _context.Horses
                .Include(h => h.UserHorses)
                .Include(h => h.StableHorses)
                .FirstOrDefaultAsync(h => h.Id == horse.Id);

            // Assert
            Assert.NotNull(loadedHorse);
            Assert.NotNull(loadedHorse.UserHorses);
            Assert.NotNull(loadedHorse.StableHorses);
            Assert.Single(loadedHorse.UserHorses);
            Assert.Single(loadedHorse.StableHorses);
            Assert.Equal(user.Id, loadedHorse.UserHorses.First().UserIdFk);
            Assert.Equal(stable.Id, loadedHorse.StableHorses.First().StableIdFk);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}