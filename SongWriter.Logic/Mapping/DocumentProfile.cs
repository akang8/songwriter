using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using data = SongWriter.Data.Models;
using SongWriter.Logic.Models;


namespace SongWriter.Logic.Mapping
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            this.CreateMap<data.Document, Document>();
            this.CreateMap<Document, data.Document>()
                            .ForMember(m => m.Folder, o => o.Ignore());
        }
    }
}
