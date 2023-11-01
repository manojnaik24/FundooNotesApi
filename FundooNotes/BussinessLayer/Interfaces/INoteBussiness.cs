using CommonLayer.Models;
using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace BussinessLayer.Interfaces
{
    public interface INoteBussiness
    {
        NoteEntity noteInput(NoteModel model, int Id);

        public List<NoteEntity> PrintAllDetail();
    }
}