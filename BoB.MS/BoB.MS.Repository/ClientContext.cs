using BoB.MS.Repository.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoB.MS.Repository
{
    public class ClientContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ClientContext() : base("Server=192.168.1.137;Database=Clients;User Id=sa;Password=yourStrong(!)Password;")
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}
