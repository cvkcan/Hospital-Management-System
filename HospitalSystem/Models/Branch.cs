using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public Branch(int branchid,string branchname)
        {
            this.BranchName = branchname;
            this.BranchId = branchid;
        }
    }
}
