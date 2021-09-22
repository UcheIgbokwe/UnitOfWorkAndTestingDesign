using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class User : EntityBase<int>
    {
        public string Email { get; set; }

        [Required, StringLength(100)]
        public override string Name { get; set; }
        
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
        
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }

    public class Team : EntityBase<int>
    {
        public virtual IEnumerable<User> Users { get; set; }
    }

    public class Role : EntityBase<int>
    {
        public virtual IEnumerable<User> Users { get; set; }
    }
}