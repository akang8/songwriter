using SongWriter.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Services.Abstractions
{
    /// <summary>
    /// Facade to interact with document-related functionality
    /// </summary>
    public interface IDocumentService
    {
        int Add(Document model);

        IEnumerable<DocumentSummary> GetSummaries();

        IEnumerable<DocumentSummary> GetLatestSummaries();

        /// <summary>
        /// Get all document summaries in a specific folder
        /// </summary>
        IEnumerable<DocumentSummary> GetSummaries(int folderId);

        Document GetItem(int id);

        void Save(Document model);

        void Remove(int id);
    }
}
