using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModuleCore.Models;


namespace ModuleCore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ModuleContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
            else 
            {

                var Users = new User[]
                {
                    new User{Name="Alexander",BTH =DateTime.Parse("2005-09-01")},
                    new User{Name="Alonso",BTH=DateTime.Parse("2002-09-01")},
                    new User{Name="Anand",BTH=DateTime.Parse("2003-09-01")}

                };

                foreach (User s in Users)
                {
                    context.Users.Add(s);
                }

                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.DestuffedContainer ON");
                context.SaveChanges();
            }

            
        }
    }
}
