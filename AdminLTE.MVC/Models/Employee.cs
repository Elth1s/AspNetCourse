using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Image { get; set; }
        [Display(Name = "Local Community")]
        public int LocalCommunityId { get; set; }
        [ForeignKey("LocalCommunityId")]
        public virtual LocalCommunity LocalCommunity { get; set; }
    }
}
