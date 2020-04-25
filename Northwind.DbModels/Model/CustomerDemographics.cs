﻿using System;
using System.Collections.Generic;

namespace Northwind.DbModels.Model
{
    public partial class CustomerDemographics : Entity
    {
        public CustomerDemographics()
        {
            CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
        }

        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }

        public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
    }
}
