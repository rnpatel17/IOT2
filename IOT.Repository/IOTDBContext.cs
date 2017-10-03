using IOT.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Repository
{
   public class IOTDBContext:DbContext
    {
        public IOTDBContext() 
            : base("IOTDb")
        {

        }
        public DbSet<Light> Light { get; set; }
        public DbSet<State> State { get; set; }
    }
}
