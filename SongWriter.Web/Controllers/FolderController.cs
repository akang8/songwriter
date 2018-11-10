using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SongWriter.Logic;
using SongWriter.Logic.Models;
using SongWriter.Web.Infrastructure;

namespace SongWriter.Web.Controllers
{
    [Route("api/[controller]")]
    public class FolderController : AppControllerBase
    {
        public FolderController(AppLogicContext context)
            : base(context) { }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var model = this.context.Folders.GetItem(id);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Folder folder)
        {
            var id = this.context.Folders.Add(folder);

            return Ok(id);
        }

        [HttpPut]
        public IActionResult Save([FromBody]Folder folder)
        {
            this.context.Folders.Save(folder);

            return Ok();
        }


    }
}
