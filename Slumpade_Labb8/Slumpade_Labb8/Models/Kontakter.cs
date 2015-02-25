using Slumpade_Labb8.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Slumpade_Labb8.Models
{
    public class Kontakter
 {
        public Guid KontakterId { get; set; }

        [Required(ErrorMessage = "Förnamn måste anges")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Namnet måste vara 2-50 täcken långt.")]
        [DisplayName("Förnamn")]
        public string Fornamn { get; set; }

        [Required(ErrorMessage = "Efternamn måste anges")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Namnet måste vara 2-50 täcken långt.")]
        [DisplayName("Efternamn")]
        public string Efternamn { get; set; }

        [Required(ErrorMessage = "Du måste ange en giltig e-post.")]
        [DisplayName("E-post")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Ange en giltig E-post")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Namnet måste vara 2-50 täcken långt.")]
        public string Epost { get; set; }

        public Kontakter()
        {
            //Måste alltid ange ett id med Guid. 
            KontakterId = Guid.NewGuid();
        }
    }
}