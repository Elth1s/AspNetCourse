using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.Models
{
    public class LocalCommunity
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Local Community")]
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
