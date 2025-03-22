using System.ComponentModel.DataAnnotations;

namespace Firma.Intranet.Models.Shop
{
    public class TypeOf
    {
        [Key]
        public int IdTypeOf { get; set; }

        [Required(ErrorMessage = "Wpisz rodzaj towaru")]
        [MaxLength(30, ErrorMessage = "Rodzaj towaru może zawierać max 30 znaków")]
        public required string Name { get; set; }

        public string Description { get; set; } = string.Empty; //string.Empty jeśli pole nie jest wymagane

        //to jest obsługa relacji jeden-do-wielu (towar ma jeden rodzaj, rodzaj ma wiele towarów danego rodzaju)

        //po stronie wiele - rodzaj ma wiele towarów danego rodzaju
        public ICollection<Goods> Goods { get; } = new List<Goods>(); //należy od razu inicjalizować
    }
}
