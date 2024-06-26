﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachConnect.Shared.Helpers;
public class GameAttendanceQuery 
{
    public string? PlayerLastName { get; set; } = null;
    public Guid? GameId { get; set; } = null;
    public Guid? TeamId { get; set; }
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
