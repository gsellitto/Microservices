using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController: ControllerBase
    {
        private IPlatformRepo _repository;
        private IMapper _mapper;

        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper =mapper;   
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatForms(){

            Console.WriteLine("--> Getting platforms ....");
        
            var platformitems =_repository.GetAllPaltforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformitems ));
        }

        [HttpGet("{id}", Name="GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var platfromitem=_repository.GetPlatform(id);
            if (platfromitem!=null){
                return Ok(_mapper.Map<PlatformReadDto>(platfromitem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto )
        {
            var p=_mapper.Map<Platform>(platformCreateDto);            
            _repository.CreatePlatform(p);
            _repository.SaveChanges();            
            var platres=_mapper.Map<PlatformReadDto>(p);
            return CreatedAtRoute(nameof(GetPlatformById),new {Id=platres.Id },platres );
        }
     }
}