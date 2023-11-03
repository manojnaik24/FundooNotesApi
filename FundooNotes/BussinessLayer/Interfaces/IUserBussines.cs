using CommonLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace BussinessLayer.Interfaces
{
    public interface IUserBussines
    {
        string UserLogin(LoginModel login);
        UserEntity UserRegisteration(RegisterModel model);
        public bool IsEmailExisting(string email);

        public List<UserEntity> PrintAllDetail();

        public UserEntity EmailEmailExicting(string Email);

        public string ForgetPassword(string Email);

        public bool ResetPassword(string Email, resetPassword reset);

        public UserTicket CreateTick(string Email, String token);
    }
}