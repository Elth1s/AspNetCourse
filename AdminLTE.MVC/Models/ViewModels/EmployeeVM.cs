using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.Models.ViewModels
{
    public class EmployeeVM
    {
        public Employee Employee { get; set; }
        public IEnumerable<LocalCommunity> LocalCommunitySelectList { get; set; }
    }
}
