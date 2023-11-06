using RepositoryLayer.Entity;

namespace RepositoryLayer.Interfaces
{
    public interface ICollaboratorRepo
    {
        CollaboratEntity addCollaborator(int noteid, string collaboratEmailId,int Id);
        bool removeCollaborator(int noteid, string collabotareEmailId);
    }
}