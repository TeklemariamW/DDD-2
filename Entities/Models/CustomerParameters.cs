namespace Entities.Models
{
    public class CustomerParameters : QueryStringParameters
    {
        public DateTime MinBirthDate { get; set; }
        public DateTime MaxBirthDate { get; set; } = DateTime.UtcNow;
        public bool ValidNameRange => MaxBirthDate > MinBirthDate;
    }
}
