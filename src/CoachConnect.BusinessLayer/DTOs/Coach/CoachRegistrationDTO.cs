﻿using CoachConnect.DataAccess.Entities;

namespace CoachConnect.BusinessLayer.DTOs.Coach;

public record CoachRegistrationDTO(
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Password,
    string Email
    );