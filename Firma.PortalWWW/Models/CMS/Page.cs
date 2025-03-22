﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.PortalWWW.Models.CMS
{
    public class Page
    {
        [Key] //to co poniżej będzie kluczem podstawowym tabeli
        public int IdPage { get; set; }

        [Required(ErrorMessage = "Tytuł odnośnika jest wymagany")]//to co niżej jest wymagane
        [MaxLength(10, ErrorMessage ="Link może zawierać max 10 znaków")]//max długość
        [Display(Name="Tytuł odnośnika")]//tak ma nazywać się pole widoczne na interfejsie
        public required string LinkTitle { get; set; }

        [Required(ErrorMessage ="Tytuł strony jest wymagany")]
        [MaxLength(50, ErrorMessage ="Tytuł może zawierać max 50 znaków")]
        [Display(Name ="Tytuł strony")]
        public required string Title { get; set; }

        [Display(Name ="Treść")]
        [Column(TypeName ="nvarchar(MAX)")]//tu decydujemy jaki jest typ tego pola w DB
        public required string TextContent { get; set; }
    }
}
