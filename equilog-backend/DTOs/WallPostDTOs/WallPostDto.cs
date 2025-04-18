﻿using System.ComponentModel.DataAnnotations;

namespace equilog_backend.DTOs.WallPostDTOs
{
    public class WallPostDto
    {
        [Required]
        public int StableIdFk { get; set; }

        public string? Title { get; set; }

        public string? Body { get; set; }

        public DateTime? PostDate { get; set; }

        public DateTime? LastEdited { get; set; }
    }
}
