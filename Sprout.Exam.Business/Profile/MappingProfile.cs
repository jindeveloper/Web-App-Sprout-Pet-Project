namespace Sprout.Exam.Business.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Tin, opt => opt.MapFrom(src => src.TIN))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.BirthDate.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.EmployeeTypeId));


            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.TIN, opt => opt.MapFrom(src => src.Tin))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Birthdate))
                .ForMember(dest => dest.EmployeeTypeId, opt => opt.MapFrom(src => src.TypeId));



            CreateMap<EditEmployeeDto, Employee>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                  .ForMember(dest => dest.TIN, opt => opt.MapFrom(src => src.Tin))
                  .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Birthdate))
                  .ForMember(dest => dest.EmployeeTypeId, opt => opt.MapFrom(src => src.TypeId))
                  .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => new SEmployeeType { Id = src.TypeId, EmployeeType =  (Domain.Enums.SproutEmployeeType) src.TypeId }));




        }
    }
}
