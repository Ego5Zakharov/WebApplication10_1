using WebApplication10_1.Data;

namespace WebApplication10_1.Models
{
    public class User
    {
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? Path { get; set; } // ПУТЬ ДО КАРТИНКИ
    public List<Book> Books { get; set; }
    }
}
