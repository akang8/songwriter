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

        [HttpPost]
        public IActionResult Add([FromBody]Document document)
        {
            var id = this.context.Documents.Add(document);

            return Ok(id);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = this.context.Documents.GetAll().ToList();

            return Ok(items);
        }
    }
}
