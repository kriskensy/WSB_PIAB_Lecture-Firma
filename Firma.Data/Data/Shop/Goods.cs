using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.Shop
{
    public class Goods
    {
        [Key]
        public int IdGoods { get; set; }

        [Required(ErrorMessage = "Wpisz kod")]
        public required string Code { get; set; }

        [Required(ErrorMessage = "Wpisz nazwę towaru")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Wpisz cenę towaru")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Dodaj zdjęcie")]
        [Display(Name = "Wybierz zdjęcie")]
        public required string FotoURL { get; set; }
        public string Description { get; set; } = string.Empty;

        //to jest obsługa relacji jeden-do-wielu (towar ma jeden rodzaj, rodzaj ma wiele towarów danego rodzaju)

        //kod po stronie jeden - towar ma jeden rodzaj
        [ForeignKey("TypeOf")]
        public int IdTypeOf { get; set; }
        public TypeOf? TypeOf { get; set; }
    }
}
