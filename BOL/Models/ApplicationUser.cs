using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BOL.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string UserIdNumber { get; set; }
        public string UserIdType { get; set; }
    }
}
