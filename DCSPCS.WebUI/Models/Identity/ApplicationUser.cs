using Microsoft.AspNet.Identity.EntityFramework;

namespace DCSPCS.WebUI.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; }
        public ApplicationUser()
        {
        }
    }
}