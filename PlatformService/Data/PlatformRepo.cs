using PlatformService.Models;


namespace  PlatformService.Data {

    public class PlatformRepo : IPlatformRepo
    {
        private AppDbContext _context;

        /// <summary>
        /// Injection of context
        /// </summary>
        /// <param name="context"></param>
        public PlatformRepo(AppDbContext context)
        {
            _context =context;
        }
        void IPlatformRepo.CreatePlatform(Platform plat)
        {
            if (plat == null) { throw new ArgumentNullException(nameof(plat));}

            _context.Platforms.Add(plat);
        }

        IEnumerable<Platform> IPlatformRepo.GetAllPaltforms()
        {
            return _context.Platforms.ToList();
        }

        Platform IPlatformRepo.GetPlatform(int id)
        {
            return _context.Platforms.FirstOrDefault(p=> p.Id==id);
        }

        bool IPlatformRepo.SaveChanges()
        {
            return _context.SaveChanges()>=0;
        }
    }
}