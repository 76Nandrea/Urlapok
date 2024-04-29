using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Components.Model
{
    public class Customer
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Ezt a mezőt kötelező kitölteni!")]
        public string? Fname { get; set; }

        [Required(ErrorMessage = "Ezt a mezőt kötelező kitölteni!")]
        public string? Lname { get; set; }

        [Required]
        [RegularExpression(@"^((?!\.)[\w-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W]{2,})$", ErrorMessage = "Rossz e-mail.")]
        public string? Email { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Range(typeof(DateTime),"1950-01-01","2024-02-01", ErrorMessage ="A születési év 1950.01.01-2024.02.01 között adható meg")]
        public DateTime BirthDay { get; set; } = new DateTime(2024,01,01); //DateTime.Now;

        [Required]
        [Range(0,100000, ErrorMessage ="Az ár 0-ra és 100.000 között lehet")]
        public int Price { get; set; }



        public string GetFullName()
        {
            if (string.IsNullOrWhiteSpace(Fname) && !string.IsNullOrWhiteSpace(Lname))
            {
                return $"{Fname} {Lname}";
            }

            return "Név nélkül";
        }
    }
}
