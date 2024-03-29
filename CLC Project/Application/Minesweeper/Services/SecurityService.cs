﻿using Minesweeper.Models;

namespace Minesweeper.Services
{
    public class SecurityService
    {
        SecurityDAO securityDAO = new SecurityDAO();

        // Method for validating a user trying to login
        public bool IsValid(UserModel user)
        {
            return securityDAO.UsernameAndPasswordIsValid(user);
        }

        // Method for finding if the user already exists
        public bool UserExists(UserModel user)
        {
            return securityDAO.FindUserByNameAndEmail(user);
        }
        
        // Method for adding new user
        public void AddUser(UserModel user)
        {
            securityDAO.AddUser(user);
        }


        // Method for getting the user id
        public int GetUserId(UserModel user)
        {
            return securityDAO.GetUserIdUsingUsernameAndPassword(user);
        }

        // Method for getting the returninf the user from the id
        public UserModel GetUser(int userId)
        {
            return securityDAO.FindUserById(userId);
        }
    }
}
