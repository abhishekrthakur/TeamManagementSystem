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
                if (context.Projects.Any())
                {
                    return;   // DB has been seeded
                }

                context.Projects.AddRange(
                    new Projects
                    {
                     ProjectName = "Project1",
                     Description = "This is Description",
                     StartDate = DateTime.Parse("01-05-2001"),
                     EndDate  = DateTime.Parse("15-05-2005"),
                     ProjectHead = "JatinderKumar",
                     Status = "Pending",
                     Technology = ".Net"
                    },

                     new Projects
                     {
                         ProjectName = "Project2",
                         Description = "This is Description",
                         StartDate = DateTime.Parse("27-12-1991"),
                         EndDate = DateTime.Parse("15-05-1997"),
                         ProjectHead = "JatinderKumar",
                         Status = "Completed",
                         Technology = "PHP"
                     }

                    
                );
                context.SaveChanges();
            }
        }
    }
}


