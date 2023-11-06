using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Octokit;
using RepositoryLayer.Entity;
using System;
using System.Linq;

namespace FundooNotes.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class CollaboratorController:ControllerBase
    {
        private readonly ICollaboratorBussines collaboratorBussines;
        private readonly ILogger<LabelController> logger;

        public CollaboratorController(ICollaboratorBussines collaboratorBussines, ILogger<LabelController> logger)
        {
            this.collaboratorBussines = collaboratorBussines;
            this.logger = logger;
        }
        [HttpPost]
        [Route("Add Collaborator")]
        public IActionResult Addcollaborator(int NoteId,string Collaborator)
        {
            var id = Convert.ToInt32(User.Claims.FirstOrDefault(m => m.Type == "Id").Value);
            var collaboratEntity=collaboratorBussines.addCollaborator(NoteId, Collaborator,id);

            if(collaboratEntity != null)
            {
                    logger.LogInformation("Collaborator is add successfull");
                    return Ok(new ResponseModel<CollaboratEntity> { status = true, message = "Collaborator Add SuccessFull" });
                }
                else
                {
                    logger.LogError("failed to add Collaborator");
                    return BadRequest(new ResponseModel<CollaboratEntity> { status = false, message = " Faild to add Collaborator" });
                }

        }

        [HttpDelete]
        [Route("deleting Collaborator")]
        public IActionResult deletingCollaborator(int NoteId, string Collaborator)
        {
            var collaboratEntity = collaboratorBussines.removeCollaborator(NoteId, Collaborator);

            if (collaboratEntity != null)
            {
                logger.LogInformation("deleting is add successfull");
                return Ok(new ResponseModel<string> { status = true, message = "deleting Add SuccessFull" });
            }
            else
            {
                logger.LogError("failed to add deleting");
                return BadRequest(new ResponseModel<string> { status = false, message = " Faild to add deleting" });
            }

        }




    }
}
