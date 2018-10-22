using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Core
{
    /// <summary>
    /// Indicates validation issue
    /// </summary>
    public class ValidatorIssue
    {
        /// <summary>
        /// Field that is causing validation issue
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Message describing the validation issue
        /// </summary>
        public string Message { get; set; }
    }
}
