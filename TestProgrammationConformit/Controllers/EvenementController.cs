
using System;
using Microsoft.AspNetCore.Mvc;
using TestProgrammationConformit.Commons.Service.Evenement;
using TestProgrammationConformit.Datas.Params;
using TestProgrammationConformit.Datas.Dtos;

namespace TestProgrammationConformit.Controllers.Evenement
{
    [ApiController]
    [Route("[controller]")]
    public class EvenementController : ControllerBase
    {
        private readonly IEvenementService _evenementService;

        public EvenementController(IEvenementService evenementService)
        {
            _evenementService = evenementService;
        }

        [HttpPost]
        public IActionResult Post(EvenementDto evenementDto)
        {
            _evenementService.Add(evenementDto);

            return Ok(true);
        }

        [HttpPut]
        public IActionResult Update(EvenementDto evenementDto)
        {
            _evenementService.Update(evenementDto);
            return Ok(true);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _evenementService.Delete(id);
            return Ok(true);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] EvenementParams param)
        {
            var res = _evenementService.GetAll(param);
            return Ok(res);
        }

        [HttpGet]
        [Route("api/GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var res = _evenementService.GetById(id);
            return Ok(res);
        }

        [HttpGet]
        [Route("api/GetAllByPagination")]
        public IActionResult GetAllByPagination([FromQuery]EvenementParams param,
            string sortField = "Id",
            int page = 1,
            int rowPerPage = 10,
            bool orderAsc = true)
        {

            var res = _evenementService.GetAllWithPagination(param, sortField, page, rowPerPage, orderAsc);
            return Ok(res);
        }
    }
}
