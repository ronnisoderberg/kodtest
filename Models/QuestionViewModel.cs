// ViewModels/QuestionViewModel.cs
using System.ComponentModel.DataAnnotations;

public class QuestionViewModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Vänligen svara på fråga 1.")]
    public bool? IsInSweden { get; set; }

    [Required(ErrorMessage = "Vänligen beskriv en bra dag.")]
    public string GoodDayDescription { get; set; }

    public string FavoriteIceCream { get; set; }
}