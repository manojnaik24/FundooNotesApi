using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NoteRepo : INoteRepo
    {
        private readonly FundoDbContext fundooContext;

        public NoteRepo(FundoDbContext fundooContext)
        {
           this.fundooContext = fundooContext;
        }

        public NoteEntity noteInput(NoteModel model,int Id)
        {

        NoteEntity entity = new NoteEntity();
            entity.Title = model.Title;
            entity.Note = model.Note;
            entity.UpdatedAt = model.UpdateAt;
            entity.CreatedAt = model.CreatedAt;
            entity.Color = model.Color;
            entity.Image = model.Image;
            entity.IsArchieve = model.IsArchieve;
            entity.IsPin = model.IsPin;
            entity.IsTrash = model.IsTrash;
            entity.Reminder= model.Reminder;
            entity.Id = Id; 
           fundooContext.Note.Add(entity);
            var result = fundooContext.SaveChanges();
            if (result > 0)
            {
                return entity;
            }
            else
            {
                return null;
            }
            
        }
        public List<NoteEntity> PrintAllDetail()
        {
            List<NoteEntity> result = (List<NoteEntity>)fundooContext.Note.ToList();
            return result;
        }


    }
}
