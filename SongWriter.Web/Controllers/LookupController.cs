using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SongWriter.Logic;
using SongWriter.Web.Infrastructure;

namespace SongWriter.Web.Controllers
{
    [Route("api/[controller]")]
    public class LookupController : AppControllerBase
    {
        public LookupController(AppLogicContext context)
            : base(context) { }

        [HttpGet("Folders")]
        public IActionResult GetFolders()
        {
            var folders = this.context.Folders.GetAll();

            return Ok(folders);
        }
    }
}
