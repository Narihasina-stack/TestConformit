
using Microsoft.AspNetCore.Mvc;
using TestProgrammationConformit.Commons.Service.Commentaire;
using TestProgrammationConformit.Datas.Dtos;
using TestProgrammationConformit.Datas.Params;

namespace TestProgrammationConformit.Controllers.Commentaire
{
    [ApiController]
    [Route("[controller]")]
    public class CommentaireController : ControllerBase
    {
        private readonly ICommentaireService _commentaireService;

        public CommentaireController(ICommentaireService commentaireService)
        {
            _commentaireService = commentaireService;
        }

        [HttpPost]
        public IActionResult Post(CommentaireDto commentaireDto)
        {
            _commentaireService.Add(commentaireDto);

            return Ok(true);
        }

        [HttpPut]
        public IActionResult Update(CommentaireDto commentaireDto)
        {
            _commentaireService.Update(commentaireDto);
            return Ok(true);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _commentaireService.Delete(id);
            return Ok(true);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] CommentaireParams param)
        {
            var res = _commentaireService.GetAll(param);
            return Ok(res);
        }

        [HttpGet]
        [Route("api/GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var res = _commentaireService.GetById(id);
            return Ok(res);
        }

        [HttpGet]
        [Route("api/GetAllByPagination")]
        public IActionResult GetAllByPagination([FromQuery]CommentaireParams param,
            string sortField = "Id",
            int page = 1,
            int rowPerPage = 10,
            bool orderAsc = true)
        {

            var res = _commentaireService.GetAllWithPagination(param, sortField, page, rowPerPage, orderAsc);
            return Ok(res);
        }
    }
}
