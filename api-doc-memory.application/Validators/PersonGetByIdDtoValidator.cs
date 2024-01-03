using api_doc_memory.domain.Dtos;
using FluentValidation;

namespace api_doc_memory.application.Validators
{
    public class PersonGetByIdDtoValidator : AbstractValidator<PersonGetByIdDto>
    {
        public PersonGetByIdDtoValidator()
        {
            RuleFor(bank => bank.Id)
                    .NotEmpty()
                    .WithMessage("Inform the id!");
        }
    }
}