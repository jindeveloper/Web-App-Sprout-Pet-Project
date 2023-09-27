namespace Sprout.Exam.Business.ModelValidation
{
    public class EditEmployeeDtoValidator : AbstractValidator<EditEmployeeDto>
    {
        public EditEmployeeDtoValidator()
        {
            RuleFor(editEmp => editEmp.Id).NotEmpty().WithMessage("Id is missing");
            RuleFor(editEmp => editEmp.FullName).NotEmpty().WithMessage("Fullname is required");
            RuleFor(editEmp => editEmp.Tin).NotEmpty().WithMessage("Tin is required");
        }
      
    }
}
