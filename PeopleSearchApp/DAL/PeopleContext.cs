using PeopleSearchApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PeopleSearchApp.DAL
{
    public class PeopleContext : DbContext
    {
        public PeopleContext() : base("PeopleContext")
        {

        }
        public DbSet<Person> People { get; set; }
    }
}