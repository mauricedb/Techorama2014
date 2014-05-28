using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Techorama2014.Models
{
    public class Book : IValidatableObject
    {
        [ReadOnly(true)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Title")]
        public string BookTitle { get; set; }

        [Required]
        public string Author { get; set; }

        public string ExtraText { get; set; }

        [DisplayName("Image")]
        public string ImageName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Author == "me")
            {
                yield return new ValidationResult("You are not the author!");
            }
        }
    }
}