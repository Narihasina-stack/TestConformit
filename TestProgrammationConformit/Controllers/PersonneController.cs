
using Microsoft.AspNetCore.Mvc;
using TestProgrammationConformit.Commons.Service.Personne;
using TestProgrammationConformit.Datas.Dtos;
using TestProgrammationConformit.Datas.Params;
using TestProgrammationConformit.Repositories.Personne;

namespace TestProgrammationConformit.Controllers.Personne
{
    [ApiController]
    [Route("[controller]")]
    public class PersonneController : ControllerBase
    {
        private readonly IPersonneService _personneService;

        public PersonneController( IPersonneService personneService)
        {
           _personneService = personneService; 
        }

        [HttpPost]
        public IActionResult Post(PersonneDto personneDto)
        {
            _personneService.Add(personneDto);

            return Ok(true);
        }

        [HttpPut]
        public IActionResult Update(PersonneDto personneDto)
        {
            _personneService.Update(personneDto);
            return Ok(true);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _personneService.Delete(id);
            return Ok(true);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] PersonneParams param)
        {
            var res = _personneService.GetAll(param);
            return Ok(res);
        }

        [HttpGet]
        [Route("api/GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var res = _personneService.GetById(id);
            return Ok(res);
        }


        [HttpGet]
        [Route("api/GetAllByPagination")]
        public IActionResult GetAllByPagination([FromQuery]PersonneParams param,
            string sortField = "Id",
            int page = 1,
            int rowPerPage = 10,
            bool orderAsc = true)
        {

            var res = _personneService.GetAllWithPagination(param, sortField, page, rowPerPage, orderAsc);
            return Ok(res);
        }
    }
}
