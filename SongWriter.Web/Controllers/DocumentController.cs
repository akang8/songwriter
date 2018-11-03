using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SongWriter.Logic;
using SongWriter.Logic.Models;
using SongWriter.Web.Infrastructure;

namespace SongWriter.Web.Controllers
{
    [Route("api/[controller]")]
    public class DocumentController : AppControllerBase
    {
        public DocumentController(AppLogicContext context)
            : base(context) { }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = this.context.Documents.GetSummaries().ToList();

            return Ok(items);
        }

        [HttpGet("Latest")]
        public IActionResult GetLatest()
        {
            var items = this.context.Documents.GetLatestSummaries().ToList();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var model = this.context.Documents.GetItem(id);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Document document)
        {
            var id = this.context.Documents.Add(document);

            return Ok(id);
        }

        [HttpPut]
        public IActionResult Save([FromBody]Document document)
        {
            this.context.Documents.Save(document);

            return Ok();
        }


    }
}
