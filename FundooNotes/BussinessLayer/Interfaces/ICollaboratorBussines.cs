using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface ICollaboratorBussines
    {
         public CollaboratEntity addCollaborator(int noteid, string collaboratEmailId, int Id);
        public bool removeCollaborator(int noteid, string collabotareEmailId);
    }
}
