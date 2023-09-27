using System;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateEmployeeDto> _createEmployeeValidator;
        private readonly IValidator<EditEmployeeDto> _editEmployeeValidator;
        private readonly IEmployeeFactory _employee;
        public EmployeesController(IEmployeeService employeeService, 
                                   IMapper mapper, 
                                   IValidator<CreateEmployeeDto> createEmployeeValidator,
                                   IValidator<EditEmployeeDto> editEmployeeValidator,
                                   IEmployeeFactory employeeFactory)
        {
            this._employeeService = employeeService;
            this._mapper = mapper;
            this._createEmployeeValidator = createEmployeeValidator;
            this._editEmployeeValidator = editEmployeeValidator;
            this._employee = employeeFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var fromDb = await this._employeeService.GetEmployees();

            var result = this._mapper.Map<List<EmployeeDto>>(fromDb);
          
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var fromDb = await this._employeeService.GetByIdAsync(id);

            var result = this._mapper.Map<EmployeeDto>(fromDb);
            
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditEmployeeDto input)
        {
            var valid = this._editEmployeeValidator.Validate(input);

            if (!valid.IsValid)

                return BadRequest(valid.Errors);

            var fromDb = await this._employeeService.GetByIdAsync(input.Id);
            
            if (fromDb == null) return NotFound();

            var item = this._mapper.Map<Employee>(input);

            await this._employeeService.UpdateEmployee(item);
           
            return Ok(input);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeDto input)
        {
            var valid = this._createEmployeeValidator.Validate(input);

            if (!valid.IsValid)

                return BadRequest(valid.Errors);

            var toDb = this._mapper.Map<Employee>(input);

            var id = await this._employeeService.CreateEmployee(toDb);

            return Created($"/api/employees/{id}", id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var fromDb = await this._employeeService.GetByIdAsync(id);

            var result = await this._employeeService.DeleteEmployee(fromDb); 

            if (!result.Item1) return NotFound();
           
            return Ok(result.Item2);
        }

        [HttpPost("{id}/calculate")]
        public async Task<IActionResult> Calculate(EmployeeCalculateInput employeeCalculate)
        {

            var fromDb = await this._employeeService.GetByIdAsync(employeeCalculate.Id);

            if (fromDb == null) return NotFound();

            var result = this._mapper.Map<EmployeeDto>(fromDb);

            return Ok ( this._employee.Calculate(employeeCalculate).ToString("F"));
           
        }

    }
}
