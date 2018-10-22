using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Core
{
    /// <summary>
    /// Validates a model 
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    public interface IModelValidator<T>
    {
        IEnumerable<ValidatorIssue> Validate(T model);
    }
}
