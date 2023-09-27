namespace Sprout.Exam.Domain.Entities
{
    public class SEmployeeType 
    {
        [Key]
        public int Id { get; set; }
        public SproutEmployeeType EmployeeType { get; set; }
    }
}
