namespace Sprout.Exam.Test.EmployeeControllerTest
{
    public class EmployeeControllerTest
    {
        private readonly Mock<IEmployeeService> _mockEmployeeService;
        private readonly Mock<IValidator<CreateEmployeeDto>> _createEmloyeeDtoValidator;
        private readonly Mock<IValidator<EditEmployeeDto>> _editEmployeeValidator;
        private readonly Mock<IEmployeeFactory> _mockEmployeeFactory;
        private Mapper _mapper;
        private EmployeesController _employeesController;

        public EmployeeControllerTest()
        {
            this._mockEmployeeService = new Mock<IEmployeeService>();
            this._createEmloyeeDtoValidator = new Mock<IValidator<CreateEmployeeDto>>();
            this._editEmployeeValidator =   new Mock<IValidator<EditEmployeeDto>>();
            this._mockEmployeeFactory = new Mock<IEmployeeFactory>();
            MapperConfig();
        }

        private void MapperConfig()
        {

            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            this._mapper = new Mapper(configuration);

        }

        [Fact]
        public async void Get_ReturnsEmployeeList()
        {
            this._mockEmployeeService.Setup(rep => rep.GetEmployees())
                    .ReturnsAsync(new List<Employee>() { new Employee() {
                                                            BirthDate = DateTime.Parse("1993-03-25"),
                                                            FullName = "Jane Doe",
                                                            Id = 1,
                                                            TIN = "123215413",
                                                            EmployeeTypeId = 1

                                                        }, new Employee() {
                                                            BirthDate = DateTime.Parse("1983-03-25"),
                                                            FullName = "John Doe",
                                                            Id = 2,
                                                            TIN = "123215414",
                                                            EmployeeTypeId = 2

                                                        } });
           

            this._employeesController = 
                    new EmployeesController(this._mockEmployeeService.Object,
                                            this._mapper, 
                                            this._createEmloyeeDtoValidator.Object, 
                                            this._editEmployeeValidator.Object, 
                                            this._mockEmployeeFactory.Object);

            var response = await this._employeesController.Get();

            var result = response as OkObjectResult;

            Assert.IsType<List<EmployeeDto>>(result.Value);
            Assert.True(((List<EmployeeDto>)result.Value).Count == 2);
             
        }

        [Fact]
        public async void GetById_ReturnsEmployeeObject()
        {
            this._mockEmployeeService.Setup(rep => rep.GetByIdAsync(It.IsAny<int>()))
                   .ReturnsAsync(new Employee());


            this._employeesController =
                  new EmployeesController(this._mockEmployeeService.Object,
                                          this._mapper,
                                          this._createEmloyeeDtoValidator.Object,
                                          this._editEmployeeValidator.Object,
                                          this._mockEmployeeFactory.Object);
           

            var response = await this._employeesController.GetById(1);

            var result = response as OkObjectResult;

            Assert.IsType<EmployeeDto>(result.Value);
           
        }

        [Fact]
        public async void Delete_ReturnsTrue()
        {
            this._mockEmployeeService.Setup(rep => rep.GetByIdAsync(It.IsAny<int>()))
                   .ReturnsAsync(new Employee());

            this._mockEmployeeService.Setup(rep => rep.DeleteEmployee(It.IsAny<Employee>()))
                   .ReturnsAsync((true, 1));

            this._employeesController =
                  new EmployeesController(this._mockEmployeeService.Object,
                                          this._mapper,
                                          this._createEmloyeeDtoValidator.Object,
                                          this._editEmployeeValidator.Object, 
                                          this._mockEmployeeFactory.Object);

            var response = await this._employeesController.Delete(1);

            var result = response as OkObjectResult;

            Assert.IsType<int>(result.Value);
            
        }

        [Fact]
        public async void Put_ReturnEmployee()
        {

            this._mockEmployeeService.Setup(rep => rep.GetByIdAsync(It.IsAny<int>()))
                  .ReturnsAsync(new Employee());

            var validationResult = new FluentValidation.Results.ValidationResult();

            this._editEmployeeValidator.Setup(valid => valid.Validate(It.IsAny<EditEmployeeDto>()))
                        .Returns(validationResult);

            this._mockEmployeeService.Setup(rep => rep.UpdateEmployee(It.IsAny<Employee>()));

            this._employeesController =
                 new EmployeesController(this._mockEmployeeService.Object,
                                         this._mapper,
                                         this._createEmloyeeDtoValidator.Object,
                                         this._editEmployeeValidator.Object, 
                                         this._mockEmployeeFactory.Object);

            var response = await this._employeesController.Put(new EditEmployeeDto { });

            var result = response as OkObjectResult;

            Assert.IsType<EditEmployeeDto>(result.Value);
        }
    }
}
