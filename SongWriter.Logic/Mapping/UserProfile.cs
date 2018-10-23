using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using data = SongWriter.Data.Models;
using SongWriter.Logic.Models;


namespace SongWriter.Logic.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<data.User, User>();
            this.CreateMap<User, data.User>()
                    .ForMember(m => m.Documents, o => o.Ignore())
                    .ForMember(m => m.Password, o => o.Ignore());
        }
    }
}
