using Microsoft.EntityFrameworkCore;

namespace Northwind.DbModels.Model
{
    public interface INorthwindContext
    {
        DbSet<Categories> Categories { get; set; }
        DbSet<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        DbSet<CustomerDemographics> CustomerDemographics { get; set; }
        DbSet<Customers> Customers { get; set; }
        DbSet<Employees> Employees { get; set; }
        DbSet<EmployeeTerritories> EmployeeTerritories { get; set; }
        DbSet<OrderDetails> OrderDetails { get; set; }
        DbSet<Orders> Orders { get; set; }
        DbSet<Products> Products { get; set; }
        DbSet<Region> Region { get; set; }
        DbSet<Shippers> Shippers { get; set; }
        DbSet<Suppliers> Suppliers { get; set; }
        DbSet<Territories> Territories { get; set; }
    }
}