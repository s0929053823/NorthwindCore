﻿using System;
using System.Collections.Generic;

namespace Northwind.DbModels.Model
{
    public partial class Shippers : Entity
    {
        public Shippers()
        {
            Orders = new HashSet<Orders>();
        }

        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
