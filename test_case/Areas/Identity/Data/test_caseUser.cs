using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace test_case.Areas.Identity.Data;

// Add profile data for application users by adding properties to the test_caseUser class
public class test_caseUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string? Role { get; set; }
    public byte[]? ProfilePicture { get; set; }
}

