using CommonLayer.Models;
using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace BussinessLayer.Interfaces
{
    public interface IlabelBussines
    {
        LabelEntity Addlabel(int notId,string label,int id);

        public List<LabelEntity> PrintAllDetail();
        public bool UpdateLabel(int noteId, string label);
        public bool deleteLabel(int noteId, string label);

        public List<LabelEntity> getlabel( string label);
    }
}