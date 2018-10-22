using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using data = SongWriter.Data.Models;
using SongWriter.Logic.Models;


namespace SongWriter.Logic.Mapping
{
    public class DocumentSummaryProfile : Profile
    {
        public DocumentSummaryProfile()
        {
            // Creates map to document summary
            // Doesn't need a reciprocal mapping, this is a one-way mapping
            this.CreateMap<data.Document, DocumentSummary>();
        }
    }
}
