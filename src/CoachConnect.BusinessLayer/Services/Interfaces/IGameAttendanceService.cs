﻿using CoachConnect.BusinessLayer.DTOs;
using CoachConnect.DataAccess.Entities;
using CoachConnect.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachConnect.BusinessLayer.Services.Interfaces;
public interface IGameAttendanceService
{
    Task<ICollection<GameAttendanceDTO>> GetAllAsync(GameAttendanceQuery gameAttendanceQuery);
    Task<GameAttendanceDTO?> GetByIdAsync(GameAttendanceId id);
    Task<GameAttendanceDTO?> UpdateAsync(GameAttendanceId id, GameAttendanceDTO dto);
    Task<GameAttendanceDTO?> DeleteAsync(GameAttendanceId id);
    Task<GameAttendanceDTO?> RegisterGameAttendanceAsync(GameAttendanceDTO dto);
}