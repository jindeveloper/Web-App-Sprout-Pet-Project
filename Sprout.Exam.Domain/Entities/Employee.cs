namespace Sprout.Exam.Domain.Entities
{
    public class Employee 
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public string TIN { get; set; }

        public bool IsDeleted { get; set; }

        public SEmployeeType EmployeeType { get; set; }

        public int EmployeeTypeId { get; set; }

    }
}
