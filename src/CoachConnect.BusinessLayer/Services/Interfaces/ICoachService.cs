﻿using CoachConnect.BusinessLayer.DTOs.Coach;
using CoachConnect.BusinessLayer.DTOs.Users;
using CoachConnect.DataAccess.Entities;
using CoachConnect.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachConnect.BusinessLayer.Services.Interfaces;
public interface ICoachService
{
    Task<ICollection<CoachDTO>> GetAllAsync(CoachQuery query);
    Task<CoachDTO?> GetByIdAsync(Guid id);
    Task<UserCoachUpdateDTO?> UpdateAsync(Guid id, UserCoachUpdateDTO dto);
    Task<CoachDTO?> DeleteAsync(Guid id);
    Task<CoachDTO?> RegisterCoachAsync(CoachRegistrationDTO dto);
}