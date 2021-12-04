using System;
using System.Collections.Generic;

#nullable disable

namespace Module3_Assignment_3.DbModels
{
    public partial class Privilege
    {
        public Privilege()
        {
            EmployeePrivileges = new HashSet<EmployeePrivilege>();
        }

        public int Id { get; set; }
        public string PrivilegeName { get; set; }

        public virtual ICollection<EmployeePrivilege> EmployeePrivileges { get; set; }
    }
}
