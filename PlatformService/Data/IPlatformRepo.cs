using PlatformService.Models;

namespace PlatformService.Data {

    /// <summary>
    /// First public interface
    /// </summary>
    public interface IPlatformRepo {

        /// <summary>
        /// Save all pending changes
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();

        /// <summary>
        /// All platforms in system
        /// </summary>
        /// <returns></returns>
        IEnumerable<Platform> GetAllPaltforms();

        /// <summary>
        /// Get Platform from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Platform GetPlatform(int id);

        /// <summary>
        /// Create new platform
        /// </summary>
        /// <param name="plat"></param>
        void CreatePlatform(Platform plat);
    }
}