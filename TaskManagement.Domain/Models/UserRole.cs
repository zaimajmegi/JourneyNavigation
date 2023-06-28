using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Models
{
    public class UserRole : IdentityRole
    {
        public UserRole()
        {

        }

        public UserRole(string roleName) : base(roleName)
        {

        }

        public UserRole(string roleName, string description) : base(roleName)
        {
            Description = description;
        }
        public string? Description { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<IdentityUserRole<string>> Users { get; set; }
    }
}
