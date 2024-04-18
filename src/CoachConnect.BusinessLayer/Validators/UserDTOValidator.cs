﻿using CoachConnect.BusinessLayer.DTOs.Users;
using CoachConnect.DataAccess.Entities;
using FluentValidation;

namespace CoachConnect.BusinessLayer.Validators;

public class UserDTOValidator : AbstractValidator<UserDTO>
{
    public UserDTOValidator() // må endres ettterhvert som vi oppdaterer DTO
    {    
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("FirstName can not be null")
            .MaximumLength(16).WithMessage("FirstName limit exceeded (max 16 characters)");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("LastName can not be null")
            .MaximumLength(16).WithMessage("LastName limit exceeded (max 16 characters)");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phonenumber can not be null")
            .Length(8).WithMessage("Phonenumber must be 8 digits");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email must be included")
            .EmailAddress().WithMessage("Email must be valid");    
    }
}