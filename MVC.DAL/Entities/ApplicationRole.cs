using Microsoft.AspNetCore.Identity;

namespace MVC.DAL.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
