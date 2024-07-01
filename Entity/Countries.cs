using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace test3.Entity
{
    
    public class Countries
    {
        [Key]
        public int Id { get; set; }
        public string CountryNames { get; set; } = null!;
    }
}
