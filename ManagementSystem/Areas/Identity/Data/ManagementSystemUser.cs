using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;


namespace ManagementSystem.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ManagementSystemUser class
public class ManagementSystemUser : IdentityUser
{

    [PersonalData]
    [Column(TypeName = "nvarchar(150)")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(150)")]
    public string LastName { get; set; }

}

