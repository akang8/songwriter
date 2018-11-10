using System;
using System.Collections.Generic;
using System.Text;
using SongWriter.Logic.Models;

namespace SongWriter.Logic.Services.Abstractions
{
    public interface IFolderService
    {
        int Add(Folder model);

        IEnumerable<Folder> GetAll();

        Folder GetItem(int id);

        void Save(Folder model);

        void Remove(int id);
    }
}
