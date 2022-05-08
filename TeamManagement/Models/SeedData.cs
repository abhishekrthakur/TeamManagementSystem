using Microsoft.EntityFrameworkCore;
using TeamManagement.Data;

namespace TeamManagement.Models
{

    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TeamManagementContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TeamManagementContext>>()))
            {
                // Look for any movies.
                if (context.Role.Any())
                {
                    return;   // DB has been seeded
                }

                context.Role.AddRange(
                    new Role
                    {
                     RoleName = "Developer"
                    },

                     new Role
                     {
                       RoleName = "Testing", 
                     },


                    new Role
                    {
                        RoleName = "Senior Developer"
                    },


                    new Role
                    {
                        RoleName = "System Designer"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}


