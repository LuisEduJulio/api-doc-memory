using api_doc_memory.domain.Dtos;
using FluentValidation;

namespace api_doc_memory.application.Validators
{
    public class PersonAddDtoValidator : AbstractValidator<PersonAddDto>
    {
        public PersonAddDtoValidator()
        {
            RuleFor(customer => customer.Name)
                .NotEmpty()
                .WithMessage("The name is required!");

            RuleFor(customer => customer.Age)
                .NotEmpty()
                .WithMessage("The last name is required!");
        }
    }
}