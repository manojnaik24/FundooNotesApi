using CommonLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IlabelRepo
    {
        public LabelEntity Addlabel(int noteId,string name,int id);
        public List<LabelEntity> PrintAllDetail();
        public bool UpdateLabel(int noteId, string label);
        public bool deleteLabel(int noteId, string label);

        public List<LabelEntity> getlabel( string label);
    }
}
