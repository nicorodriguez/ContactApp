using ContactApp.Model;
using ContactApp.Repository.ContactRepository;
using ContactApp.Repository.ProfileRepository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ContactApp.Domain.ContactDomain
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IProfileRepository _profileRepository;

        public ContactValidator(IContactRepository contactRepository, IProfileRepository profileRepository)
        {
            _contactRepository = contactRepository;
            _profileRepository = profileRepository;

            RuleFor(contact => contact.Name).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("{PropertyName} is null")
                    .NotEmpty().WithMessage("{PropertyName} is empty")
                    .MaximumLength(255).WithMessage("{PropertyName} Length: ({TotalLength}) is greater than 255");

            RuleFor(contact => contact.Company).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("{PropertyName} is null")
                    .NotEmpty().WithMessage("{PropertyName} is empty")
                    .MaximumLength(255).WithMessage("{PropertyName} Length: ({TotalLength}) is greater than 255");

            RuleFor(contact => contact.Image).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("{PropertyName} is null")
                    .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(contact => contact.Email).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("{PropertyName} is null")
                    .NotEmpty().WithMessage("{PropertyName} is empty")
                    .MaximumLength(255).WithMessage("{PropertyName} Length: ({TotalLength}) is greater than 255");

            RuleFor(contact => contact.Birthdate).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(contact => contact.WorkNumber).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("{PropertyName} is null")
                    .NotEmpty().WithMessage("{PropertyName} is empty")
                    .MaximumLength(15).WithMessage("{PropertyName} Length: ({TotalLength}) is greater than 15");

            RuleFor(contact => contact.PersonalNumber).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("{PropertyName} is null")
                    .NotEmpty().WithMessage("{PropertyName} is empty")
                    .MaximumLength(15).WithMessage("{PropertyName} Length: ({TotalLength}) is greater than 15");

            RuleFor(contact => contact.Address).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("{PropertyName} is null")
                    .NotEmpty().WithMessage("{PropertyName} is empty")
                    .MaximumLength(255).WithMessage("{PropertyName} Length: ({TotalLength}) is greater than 255");

            RuleFor(contact => contact.City).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("{PropertyName} is null")
                    .NotEmpty().WithMessage("{PropertyName} is empty")
                    .MaximumLength(255).WithMessage("{PropertyName} Length: ({TotalLength}) is greater than 255");

            RuleFor(contact => contact.State).Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("{PropertyName} is null")
                    .NotEmpty().WithMessage("{PropertyName} is empty")
                    .MaximumLength(255).WithMessage("{PropertyName} Length: ({TotalLength}) is greater than 255");

            // Create
            When(contact => contact.ContactId == 0, () =>
            {
                RuleFor(contact => contact.Name).Must(ExistName).WithMessage("A Contact has already been created with that Name");

                RuleFor(contact => contact.ProfileId).Must(ExistsProfileId).WithMessage("Profile Id was not found or was deleted");
            });

            // Edit
            When(contact => contact.ContactId != 0, () => 
            {
                RuleFor(contact => contact.ContactId).Must(ExistId).WithMessage("Contact was not found or was deleted");
                
                RuleFor(contact => contact).Must(ExistNameWithAnotherId).WithMessage("A Contact with that Name already exists");

                RuleFor(contact => contact.ProfileId).Must(ExistsProfileId).WithMessage("Profile Id was not found or was deleted");
            });
        }

        private bool ExistId(int id)
        {
            return _contactRepository.Exists(e => e.ContactId.Equals(id));
        }

        private bool ExistName(string name)
        {
            return !(_contactRepository.Exists(e => e.Name.Equals(name)));
        }

        private bool ExistsProfileId(int profileId)
        {
            return _profileRepository.Exists(e => e.ProfileId.Equals(profileId));
        }

        private bool ExistNameWithAnotherId(Contact contact)
        {
            return !(_contactRepository.Exists(e => e.Name.Equals(contact.Name) && !(e.ContactId.Equals(contact.ContactId))));
        }
    }
}
