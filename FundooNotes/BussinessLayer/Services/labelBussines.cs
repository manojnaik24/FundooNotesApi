using BussinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class labelBussines : IlabelBussines
    {
        public readonly IlabelRepo labelRepo;
        public labelBussines(IlabelRepo labelRepo)
        {
            this.labelRepo = labelRepo;
        }

        public LabelEntity Addlabel(int noteId, string name,int id)
        {
            return labelRepo.Addlabel(noteId, name,id);
        }
        public List<LabelEntity> PrintAllDetail()
        {
           return labelRepo.PrintAllDetail();
        }
        public bool UpdateLabel(int noteId,string label)
        {
            return labelRepo.UpdateLabel(noteId, label);
        }
        public bool deleteLabel( int noteId,string label)
        {
            return labelRepo.deleteLabel(noteId,label );
        }

        public List<LabelEntity> getlabel(string label )
        {
            return labelRepo.getlabel(label );
        }
    }
}
