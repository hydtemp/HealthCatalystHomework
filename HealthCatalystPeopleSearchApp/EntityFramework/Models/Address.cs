using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCatalystPeopleSearchApp.EntityFramework.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Country { get; set; }

        [NotMapped]
        public string DisplayFormat {
            get
            {
                return this.ToString();
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} {2} {3} {4}", StreetAddress, City, State, ZipCode, Country);
        }
    }
}