using Microsoft.AspNetCore.Mvc;
using SongWriter.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongWriter.Web.Infrastructure
{
    public class AppControllerBase : Controller
    {
        protected readonly AppLogicContext appContext;
        public AppControllerBase(AppLogicContext context)
        {
            this.appContext = context;
        }
    }
}
