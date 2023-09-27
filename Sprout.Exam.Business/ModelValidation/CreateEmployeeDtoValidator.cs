

namespace Sprout.Exam.Business.ModelValidation
{
    public class CreateEmployeeDtoValidator :  AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeDtoValidator()
        {
            RuleFor(createEmp => createEmp.FullName).NotEmpty().WithMessage("Fullname is required");
            RuleFor(createEmp => createEmp.Tin).NotEmpty().WithMessage("Tin is required");

                                               
        }
    }
}
