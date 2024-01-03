using api_doc_memory.domain.Dtos;
using FluentValidation;

namespace api_doc_memory.application.Validators
{
    public class PersonFilterDtoValidator : AbstractValidator<PersonFilterDto>
    {
        public PersonFilterDtoValidator()
        {
            RuleFor(bank => bank.Name)
                    .NotEmpty()
                    .WithMessage("Inform the name!");
        }
    }
}