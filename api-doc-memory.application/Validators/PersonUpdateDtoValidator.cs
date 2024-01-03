using api_doc_memory.domain.Dtos;
using FluentValidation;

namespace api_doc_memory.application.Validators
{
    public class PersonUpdateDtoValidator : AbstractValidator<PersonUpdateDto>
    {
        public PersonUpdateDtoValidator()
        {
            RuleFor(customer => customer.Id)
               .NotEmpty()
               .WithMessage("The Id is required!");

            RuleFor(customer => customer.Name)
                .NotEmpty()
                .WithMessage("The name is required!");

            RuleFor(customer => customer.Age)
                .NotEmpty()
                .WithMessage("The age is required!");
        }
    }
}