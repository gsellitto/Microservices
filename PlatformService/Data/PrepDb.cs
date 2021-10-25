namespace PlatformService.Data
{
    /// <summary>
    /// Init db
    /// </summary>
    public static class PrepDb {

        public static void PrepPopulation(IApplicationBuilder app){
            using  (var servicesScope=app.ApplicationServices.CreateScope())
            {
                SeedDate(servicesScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
    
    private static void SeedDate(AppDbContext context)
    {
        if(!context.Platforms.Any() ) {
            Console.WriteLine("seed data ...");
            context.Platforms.AddRange(
                new Models.Platform(){Name="DN1", Publisher="M1",Cost="Free"},
                new Models.Platform(){Name="DN2", Publisher="M2",Cost="Free3"},
                new Models.Platform(){Name="DN3", Publisher="M3",Cost="Free3"},
                new Models.Platform(){Name="DN4", Publisher="M4",Cost="Free3"});

            context.SaveChanges();
        } else {Console.WriteLine("Data already present");}
    }
    }//class

    
}