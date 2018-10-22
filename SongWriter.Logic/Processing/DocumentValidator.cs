using SongWriter.Core;
using SongWriter.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Processing
{
    public class DocumentValidator : IModelValidator<Document>
    {
        public IEnumerable<ValidatorIssue> Validate(Document model)
        {
            if(model == null)
            {
                // Model binding failed, need better message?
                yield return new ValidatorIssue()
                {
                    Field = "",
                    Message = "Please ensure that correct values are set for this form."
                };
            }
        }
    }
}
