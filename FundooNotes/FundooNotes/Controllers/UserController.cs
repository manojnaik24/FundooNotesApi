using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBussines userBuissnes;

        public UserController(IUserBussines userBuissnes)
        {
            this.userBuissnes = userBuissnes;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Registration(RegisterModel model)
        {
            var IsEmailExists = userBuissnes.IsEmailExisting(model.Email);
            if (IsEmailExists)
            {
                return Ok(new ResponseModel<string> { status = true, message = "Email Already exists", data = model.Email });
            }
            else
            {
                var result = userBuissnes.UserRegisteration(model);
                if (result != null)
                {
                    return Ok(new ResponseModel<UserEntity> { status = true, message = "Registration successfull", data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<UserEntity> { status = false, message = "registraion failed" });
                }
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel login)
        {
            var result = userBuissnes.UserLogin(login);
            if (result !=null)
            {
                return Ok( new ResponseModel<string> { status=true,message="Login SuccessFull",data=result});
            }
            else
            {
                return BadRequest(new ResponseModel<string> { status = false, message = "Login Faild" });
            }
        }
        [HttpGet]
        [Route("UserInfo")]

        public IActionResult  GetUserData(){

            List<UserEntity> result = userBuissnes.PrintAllDetail();

            if (result != null)
            {
                return Ok(new ResponseModel<List<UserEntity>> {status=true,message="user deatails",data=result});  
            }
            else
            {
                return BadRequest(new ResponseModel<List<UserEntity>> { status = false, message = "not extists" });
            }
        }

        [HttpPost]
        [Route("ForgetPassword")]

        public IActionResult ForGetPassword(string Email) {

            var result = userBuissnes.ForgetPassword(Email);

            if (result != null)
            {
                return Ok(new ResponseModel<string> { status = true, message = "Message sent", data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { status = false, message = "Message sent Failed " });
            }

        }

        [HttpPut]
        [Route("Reset Password")]

        public IActionResult ResetPassword(string Email,resetPassword reset)
        {

            var result = userBuissnes.ResetPassword(Email,reset);

            if (result != null)
            {
                return Ok(new ResponseModel<string> { status = true, message = "Password is Reset "});
            }
            else
            {
                return BadRequest(new ResponseModel<string> { status = false, message = "Password is not Reset " });
            }

        }
    }

   
}