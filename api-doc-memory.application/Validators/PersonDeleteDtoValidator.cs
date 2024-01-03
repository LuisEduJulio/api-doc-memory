using api_doc_memory.domain.Dtos;
using FluentValidation;

namespace api_doc_memory.application.Validators
{
    public class PersonDeleteDtoValidator : AbstractValidator<PersonDeleteByIdDto>
    {
        public PersonDeleteDtoValidator()
        {
            RuleFor(bank => bank.Id)
                    .NotEmpty()
                    .WithMessage("Inform the id!");
        }
    }
}