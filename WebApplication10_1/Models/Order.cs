using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10_1.Models
{
    public class Order
    {

        public int OrderId { get; set; }
        public string? User { get; set; }
        public string? Address { get; set; }
        public string? ContactPhone { get; set; }
        public int BookId { get; set; } 
        public Book? Book { get; set; }
    }
}
