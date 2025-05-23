﻿using System.Net;
using AutoMapper;
using equilog_backend.Common;
using equilog_backend.Data;
using equilog_backend.DTOs.CalendarEventDTOs;
using equilog_backend.Interfaces;
using equilog_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace equilog_backend.Services;

public class CalendarEventService(EquilogDbContext context, IMapper mapper) : ICalendarEventService
{
    public async Task<ApiResponse<List<CalendarEventDto>?>> GetCalendarEventsByStableIdAsync(int stableId)
    {
        try
        {
            var calendarEventDtos = mapper.Map<List<CalendarEventDto>>(await context.CalendarEvents
                .Where(ce => ce.StableIdFk == stableId)
                .ToListAsync());
            
            if (calendarEventDtos.Count == 0)
                return ApiResponse<List<CalendarEventDto>?>.Success(HttpStatusCode.OK,
                    calendarEventDtos,
                    "Operation was successful but stable has no stored calendar events.");

            return ApiResponse<List<CalendarEventDto>>.Success(HttpStatusCode.OK,
                calendarEventDtos,
                "Calendar events fetched successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<List<CalendarEventDto>?>.Failure(HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }
    
    public async Task<ApiResponse<CalendarEventDto?>> GetCalendarEventAsync(int calendarEventId)
    {
        try
        {
            var calendarEvent = await context.CalendarEvents
                .Where(ce => ce.Id == calendarEventId)
                .FirstOrDefaultAsync();

            if (calendarEvent == null) return ApiResponse<CalendarEventDto>.Failure(HttpStatusCode.NotFound,
                    "Error: Calendar event not found.");

            return ApiResponse<CalendarEventDto>.Success(HttpStatusCode.OK,
                mapper.Map<CalendarEventDto>(calendarEvent),
                "Calendar event fetched successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<CalendarEventDto>.Failure(HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }

    public async Task<ApiResponse<CalendarEventDto?>> CreateCalendarEventAsync(CalendarEventCreateDto calendarEventCreateDto)
    {
        try
        {
            var calendarEvent = mapper.Map<CalendarEvent>(calendarEventCreateDto);
            
            context.CalendarEvents.Add(calendarEvent);
            await context.SaveChangesAsync();

            return ApiResponse<CalendarEventDto>.Success(HttpStatusCode.Created,
                mapper.Map<CalendarEventDto>(calendarEvent),
                "New calendar event created successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<CalendarEventDto>.Failure(HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }

    public async Task<ApiResponse<Unit>> UpdateCalendarEventAsync(CalendarEventUpdateDto calendarEventUpdateDto)
    {
        try
        {
            var calendarEvent = await context.CalendarEvents
                .Where(ce => ce.Id == calendarEventUpdateDto.Id)
                .FirstOrDefaultAsync();

            if (calendarEvent == null)
                return ApiResponse<Unit>.Failure(HttpStatusCode.NotFound,
                    "Error: Calendar event not found.");

            mapper.Map(calendarEventUpdateDto, calendarEvent);
            await context.SaveChangesAsync();

            return ApiResponse<Unit>.Success(HttpStatusCode.OK,
                Unit.Value,
                "Calendar event updated successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<Unit>.Failure(HttpStatusCode.InternalServerError,
                ex.Message);
        }
    } 
    
    public async Task<ApiResponse<Unit>> DeleteCalendarEventAsync(int calendarEventId)
    {
        try
        {
            var calendarEvent = await context.CalendarEvents
                .Where(ce => ce.Id == calendarEventId)
                .FirstOrDefaultAsync();

            if (calendarEvent == null)
                return ApiResponse<Unit>.Failure(HttpStatusCode.NotFound,
                    "Error: Calendar event not found.");

            context.CalendarEvents.Remove(calendarEvent);
            await context.SaveChangesAsync();

            return ApiResponse<Unit>.Success(HttpStatusCode.OK,
                Unit.Value,
                $"Calendar event with id '{calendarEventId}' was deleted successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<Unit>.Failure(HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }
    
    // Used for testing.
    public async Task<ApiResponse<List<CalendarEventDto>?>> GetCalendarEventsAsync()
    {
        try
        {
            var calendarEventDtos = mapper.Map<List<CalendarEventDto>>(await context.CalendarEvents.ToListAsync());
    
            return ApiResponse<List<CalendarEventDto>>.Success(HttpStatusCode.OK,
                calendarEventDtos,
                null);
        }
        catch (Exception ex)
        {
            return ApiResponse<List<CalendarEventDto>>.Failure(HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }
}
