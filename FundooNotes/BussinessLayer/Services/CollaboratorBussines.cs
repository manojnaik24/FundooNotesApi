using BussinessLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class CollaboratorBussines:ICollaboratorBussines
    {
        private readonly ICollaboratorRepo collaboratorRepo;

        public CollaboratorBussines(ICollaboratorRepo collaboratorRepo)
        {
            this.collaboratorRepo = collaboratorRepo;
        }
       public  CollaboratEntity addCollaborator(int noteid, string collaboratEmailId, int Id)
        {
            return collaboratorRepo.addCollaborator(noteid, collaboratEmailId,Id);
        }
        public bool removeCollaborator(int noteid, string collabotareEmailId)
        {
            return collaboratorRepo.removeCollaborator(noteid,collabotareEmailId);
        }
    }
}
