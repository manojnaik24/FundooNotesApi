using CommonLayer.Models;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class labelRepo:IlabelRepo
    {
        public readonly FundoDbContext fundoDb;
         
        public labelRepo(FundoDbContext fundoDb)
        {
            this.fundoDb = fundoDb;
        }


        public LabelEntity Addlabel(string labelName,int noteId,int id)
        {

            LabelEntity label = new LabelEntity();
            label.labelName=labelName;
            label.Id = id;
            label.NoteId = noteId;

            fundoDb.Label.Add(label);
            var re = fundoDb.SaveChanges();

            if (re >0)
            {
                return label;
            }
            else
            {
                return null;
            }

            
        }

        public List<LabelEntity> PrintAllDetail()
        {
            List<LabelEntity> result = (List<LabelEntity>)fundoDb.Label.ToList();
            return result;
        }

        public bool UpdateLabel(string label,int noteId,int Id)
        {
            var result=fundoDb.Label.FirstOrDefault(v=>v.labelName==label && v.Id==Id && v.NoteId==noteId );
            if (result.labelName != null)
            {
                result.labelName=label;
                return true;
            }
            fundoDb.SaveChanges();
            return false;

        }
        public bool deleteLabel(string label,int noteId,int Id) {

            var result = fundoDb.Label.FirstOrDefault(v => v.labelName == label && v.Id == Id && v.NoteId == noteId);
            if (result.labelName != null) {
            fundoDb.Remove(result.labelName);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public List<LabelEntity> getlabel(int columnsid)
        {
            List<LabelEntity> result = (List<LabelEntity>)fundoDb.Label.Where(m=>m.columnsid==columnsid);
            return result;
        }

    }
}
