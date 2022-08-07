using CustomerWork_Erhan.Models.Customer;
using CustomerWork_Erhan.Models.Location;
using CustomerWork_Erhan.Models.Login;
using Microsoft.EntityFrameworkCore;

namespace CustomerWork_Erhan.Context
{
    public class DataContext : DbContext
    {
        #region Constructor
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
          

        }
        #endregion

        #region DbSet
        public DbSet<Login> login { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<CustomerRep> CustomerRep { get; set; }

        public DbSet<CustomerType> CustomerType { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<Country> Country { get; set; }

        #endregion


        

    }

}
