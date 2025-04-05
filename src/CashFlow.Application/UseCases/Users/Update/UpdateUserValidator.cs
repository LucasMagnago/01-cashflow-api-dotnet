using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Users.Update;
public class UpdateUserValidator : AbstractValidator<RequestUpdateUserJson>
{
    public UpdateUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("Obrigatório informar o nome do usuário");
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("Obrigatório informar o e-mail do usuário")
            .EmailAddress()
            .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage("E-mail inválido");
    }
}