using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SongWriter.Logic;
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
            var items = this.context.Documents.GetAll().ToList();

            return Ok(items);
        }
    }
}
