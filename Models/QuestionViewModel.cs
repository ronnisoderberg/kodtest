using kodtest.Models;
using System.ComponentModel.DataAnnotations;

public class QuestionViewModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Vänligen svara på fråga 1.")]
    public bool? IsInSweden { get; set; }

    [Required(ErrorMessage = "Vänligen beskriv en bra dag.")]
    public string GoodDayDescription { get; set; }
    public List<string> Flavours { get; set; }

    public List<CheckBoxItem>? CheckBoxes { get; set; }

    public QuestionViewModel()
    {
        CheckBoxes = new List<CheckBoxItem>();
        Flavours = new List<string>();
    }
}