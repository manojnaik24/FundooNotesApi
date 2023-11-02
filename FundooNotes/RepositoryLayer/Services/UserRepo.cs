using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NPOI.SS.Formula.Eval;
using NPOI.SS.Formula.Functions;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRepo : IUserRepo
    {
        private readonly FundoDbContext fundooContext;
        private readonly IConfiguration configuration;

        public UserRepo(FundoDbContext fundooContext, IConfiguration configuration)
        {
            this.fundooContext = fundooContext;
            this.configuration= configuration;
        }

        public UserEntity UserRegisteration(RegisterModel model)
        {
            
            UserEntity entity = new UserEntity();
            entity.First_Name = model.First_Name;
            entity.Last_Name = model.Last_Name;
            entity.Email = model.Email;
            entity.Password = EncryptPassword(model.Password);
            fundooContext.user.Add(entity);
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

        public string UserLogin(LoginModel login)
        {
            var encodePwd= EncryptPassword(login.Password);
            
            UserEntity checkEmail = fundooContext.user.FirstOrDefault(x => x.Email == login.EMail);
            UserEntity checkpass = fundooContext.user.FirstOrDefault(x=>x.Password == login.Password);

            if (checkEmail != null)
            {
                if (checkpass != null)
                {
                 var token=GenerateToken(checkEmail.Email,checkEmail.Id);   
                    return token;
                }
                else
                {
                    return null;
                }
            }else
            {
                return null;
            }

        }

        public bool IsEmailExisting(string Email)
        {
            var EmailCount = fundooContext.user.Where(x => x.Email == Email).Count();
            return EmailCount > 0;
        }


        public static string EncryptPassword(string Password)
        {
            try
            {
                byte[] encData_byte = new byte[Password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(Password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        private string GenerateToken(string Email,int Id)
        {
           
            
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                new Claim("Email",Email),
                new Claim("Id",Id.ToString())
            };
                var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                    configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: credentials);


                return new JwtSecurityTokenHandler().WriteToken(token);
            
           
        }

        public UserEntity EmailEmailExicting(string Email)
        {

            var EmailExict = fundooContext.user.FirstOrDefault(x => x.Email == Email);
            return EmailExict;
        }
        public List<UserEntity> PrintAllDetail()
        {
            List<UserEntity> result=(List<UserEntity>)fundooContext.user.ToList();
            return result;
        }
        
        public string ForgetPassword(string Email)
        {
                var result = fundooContext.user.FirstOrDefault(x => x.Email == Email);
                if (result != null)
                {
                    var token = this.GenerateToken(result.Email, result.Id);
                    MSMQModel msmqmodel = new MSMQModel();
                    msmqmodel.SendMessage(token, result.Email, result.First_Name);
                    return token.ToString();
                }
                else
                {
                    return null;
                }
            
        }

        public bool ResetPassword(string Email, resetPassword reset)
        {
            string encryptedpwd = EncryptPassword(reset.Passsword);
            string encrytedCofirmpwd = EncryptPassword(reset.ConfirmPassword);


            if(encryptedpwd.Equals(encrytedCofirmpwd))
            {
                var user=fundooContext.user.Where(x=>x.Email == Email).FirstOrDefault();
                user.Password = reset.ConfirmPassword;
                fundooContext.SaveChanges();
                return true;
            }else
            {
                return false;
            }
        }
      
    }
}
