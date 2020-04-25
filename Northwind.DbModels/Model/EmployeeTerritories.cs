using System;
using System.Collections.Generic;

namespace Northwind.DbModels.Model
{
    public partial class EmployeeTerritories : Entity
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Territories Territory { get; set; }
    }
}
