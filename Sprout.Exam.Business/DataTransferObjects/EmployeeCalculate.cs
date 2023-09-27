using System.Text.Json.Serialization;

namespace Sprout.Exam.Business.DataTransferObjects
{
    public class EmployeeCalculateInput
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("absentDays")]
        public decimal AbsentDays { get; set; }

        [JsonPropertyName("workedDays")]
        public decimal WorkedDays { get; set; }

        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }
    }
}
