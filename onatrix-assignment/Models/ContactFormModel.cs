namespace onatrix_assignment.Models;

public class ContactFormModel
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    //public string Message { get; set; } = null!;
    public string Dropdown { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateTime SubmittedDate { get; set; }
}
