﻿using Domain.Common;
using Domain.Users;
using Domain.Utility;
using FluentValidation;
using Shared.Projecten;
using System.ComponentModel.DataAnnotations;

namespace Shared.Users;

public static class KlantDto
{

    public class Index
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class Detail : Index
    {
        public string? Bedrijf { get; set; }
        public Course? Opleiding { get; set; }
        public List<ProjectenDto.Index> Projects { get; set; }
        public ContactDetails? ContactPersoon { get; set; }
        public ContactDetails? ReserveContactPersoon { get; set; }
    }

    public class Mutate
    {
        [Required(ErrorMessage = "Je moet een voornaam ingeven.")]
        [StringLength(20, ErrorMessage = "Naam is te lang")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Je moet een naam ingeven.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Je moet een gsm-nummer ingeven.")]
        [BelgianPhoneNumber]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Je moet een email ingeven.")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public Course? Opleiding { get; set; }
        public string? Bedrijf { get; set; }
        public BedrijfType Type { get; set; }
        public ContactDetails? Contactpersoon { get; set; }
        public ContactDetails? ReserveContactpersoon { get; set; }

        public class Validator : AbstractValidator<Mutate>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotNull().NotEmpty().Length(1, 250).Matches("^[a-z ,.'éèëàçù-]+$");
                RuleFor(x => x.Name).NotNull().NotEmpty().Length(1, 250);
                RuleFor(x => PropertyValidator.IsValidEmail(x.Email));
                RuleFor(x => PropertyValidator.IsPhoneNumberValid(x.PhoneNumber));
                RuleFor(x => x.Opleiding).NotEmpty();
                RuleFor(x => x.Bedrijf).NotEmpty();
                RuleFor(x => x.Type).NotEmpty();
            }
        }
    }
    public class Create : Mutate
    {
        public string Password { get; set; }

        public new class Validator : AbstractValidator<Create>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotNull().NotEmpty().Length(1, 250).Matches("^[a-z ,.'éèëàçù-]+$");
                RuleFor(x => x.Name).NotNull().NotEmpty().Length(1, 250).Matches("^[a-z ,.'éèëàçù-]+$");
                RuleFor(x => PropertyValidator.IsValidEmail(x.Email));
                RuleFor(x => PropertyValidator.IsPhoneNumberValid(x.PhoneNumber));
                RuleFor(x => x.Opleiding).NotEmpty();
                RuleFor(x => x.Bedrijf).NotEmpty();
                RuleFor(x => x.Type).NotEmpty();
                RuleFor(x => x.Password).Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$");
            }
        }

    }
}