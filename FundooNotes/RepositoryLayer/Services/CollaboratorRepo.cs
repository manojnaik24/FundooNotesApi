using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class CollaboratorRepo : ICollaboratorRepo
    {
        public readonly FundoDbContext fundoDbContext;


        public CollaboratorRepo(FundoDbContext fundoDbContext)
        {
            this.fundoDbContext = fundoDbContext;
        }

        public CollaboratEntity addCollaborator(int noteid, string collaboratEmailId,int Id)
        {
            CollaboratEntity co = new CollaboratEntity();
            co.collaboratEmail = collaboratEmailId;
            co.NoteId = noteid;
            co.Id = Id;

            fundoDbContext.collaborat.Add(co);
            var result = fundoDbContext.SaveChanges();
            if (result > 0)
            {

                return co;
            }
            else
            {
                return null;
            }
        }

        public bool removeCollaborator(int noteid, string collabotareEmailId)
        {
            var srting = fundoDbContext.collaborat.FirstOrDefault(m => m.NoteId == noteid && m.collaboratEmail == collabotareEmailId);
            if (srting != null)
            {
                fundoDbContext.collaborat.Remove(srting);
                fundoDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
