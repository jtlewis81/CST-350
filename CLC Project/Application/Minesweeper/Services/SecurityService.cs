﻿using Minesweeper.Models;

namespace Minesweeper.Services
{
    public class SecurityService
    {
        SecurityDAO securityDAO = new SecurityDAO();

        public bool IsValid(UserModel user)
        {
            return securityDAO.FindUserByNameAndPassword(user);
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



    }
}
