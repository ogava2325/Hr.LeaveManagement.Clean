using FluentValidation;
using Hr.LeaveManagement.Application.Contracts.Persistence;

namespace Hr.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

        RuleFor(p => p.DefaultDays)
            .GreaterThan(100).WithMessage("{PropertyName} cannot exceed 100")
            .LessThan(1).WithMessage("{PropertyName} cannot be less than 1");

        RuleFor(q => q)
            .MustAsync(IsLeaveTypeNameUnique)
            .WithMessage("Leave type already exists");

        _leaveTypeRepository = leaveTypeRepository;
    }

    private Task<bool> IsLeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
    {
        return _leaveTypeRepository.IsUnique(command.Name);
    }
}