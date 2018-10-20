using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Core
{
    /// <summary>
    /// Object representing the appsettings.json
    /// </summary>
    public class AppConfiguration
    {
        public bool ResetData { get; set; }
        public string ConnectionString { get; set; }
    }
}
