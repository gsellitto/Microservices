
using PlatformService.Dtos;

namespace PaltformService.SyncDataServices.Http
{
    public interface ICommandDataClients
    {
        Task SendPlatformToCommand(PlatformReadDto plat);

            
    }

}