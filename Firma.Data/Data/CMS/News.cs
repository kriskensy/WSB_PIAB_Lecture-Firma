using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.CMS
{
    public class News
    {
        [Key]
        public int IdNews { get; set; }

        [Required(ErrorMessage = "Tytuł odnośnika jest wymagany")]
        [MaxLength(10, ErrorMessage = "Link może zawierać max 10 znaków")]
        [Display(Name = "Tytuł odnośnika")]
        public required string LinkTitle { get; set; }

        [Required(ErrorMessage = "Tytuł aktualności jest wymagany")]
        [MaxLength(50, ErrorMessage = "Tytuł może zawierać max 50 znaków")]
        [Display(Name = "Tytuł aktualności")]
        public required string Title { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        public required string TextContent { get; set; }

        [Display(Name = "Pozycja wyświetlania")]
        [Required(ErrorMessage = "Wpisz pozycję wyświetlania")]
        public int Position { get; set; }
    }
}
