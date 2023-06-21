// ViewModels/QuestionViewModel.cs
using System.ComponentModel.DataAnnotations;

public class QuestionViewModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "V�nligen svara p� fr�ga 1.")]
    public bool? IsInSweden { get; set; }

    [Required(ErrorMessage = "V�nligen beskriv en bra dag.")]
    public string GoodDayDescription { get; set; }

    public string FavoriteIceCream { get; set; }
}