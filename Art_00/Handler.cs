using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Art_00.classes.model;
using Art_00.classes.dao;
using Nito.AsyncEx.Synchronous; // Need to install package

namespace Art_00
{
    /**
     * The handler is a helper class that executes objective tasks issued by the command class
     */
    class Handler
    {
        // Maximum & minimum numbers for login menu decisions
        const int MIN_LOGIN_MENU_OPTION_NUM = 1;
        const int MAX_LOGIN_MENU_OPTION_NUM = 4;

        // Maximum & minimum characters allowed for the username
        const int MIN_USERNAME_LENGTH = 3;
        const int MAX_USERNAME_LENGTH = 21;

        // Maximum & minimum characters allowed for the password
        const int MIN_PASSWORD_LENGTH = 7;
        const int MAX_PASSWORD_LENGTH = 15;

        // DAO's for CRUD operations
        PostgresUserDao userDao = new PostgresUserDao();

        /**
         * Reads the user input string at the login menu, retrieved from the UI's displayLoginMenu 
         * method. Converts it to an integer. Throws error message if the input is invalid.
         * @param  string userInputStr - an integer string that corresponds to a menu option
         * @return int - an integer that corresponds to a menu option
         */
        public int handleLoginMenu(string loginMenuOptionInputStr) {

            int loginMenuOptionInputInt = -1;

            try
            {
                loginMenuOptionInputInt = int.Parse(loginMenuOptionInputStr);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            if (loginMenuOptionInputInt < MIN_LOGIN_MENU_OPTION_NUM || 
                loginMenuOptionInputInt > MIN_LOGIN_MENU_OPTION_NUM) {
                Console.WriteLine("Please enter a valid input");
            }

            return loginMenuOptionInputInt;
        }

        /**
         * Checks if the username format submits to the username registration rules
         * The username must be unique and contain letters & numbers only, except for the special
         * characters @ and _. Cannot start with a number nor a special character. Needs to be 
         * between 3-21 characters
         * @param  string usernameInput - user's entry for their username
         * @return boolean[] usernameValidity - a boolean array, first element indicates whether 
         * the format of username entered is valid, second element indicates whether the username
         * is already taken
         */
        public bool[] checkIsUsernameValid(string usernameInput)
        {
            bool usernameFormatValid = true;
            bool usernameUnique = true;


            // Invalid if first character isn't a letter, or if the username is too long/short
            if (!Char.IsLetter(usernameInput[0]) || usernameInput.Length < MIN_USERNAME_LENGTH ||
                usernameInput.Length > MAX_USERNAME_LENGTH)
            {
                usernameFormatValid = false;
            }

            // Checks the username format rule on each character
            foreach (char character in usernameInput.Skip(0))
            {
                if (!Char.IsLetter(character) && !Char.IsNumber(character) && 
                    character.CompareTo('@') != 0 && character.CompareTo('_') != 0)
                {
                    usernameFormatValid = false;
                }
            }

            // Checks if the username is unique
            if (usernameFormatValid)
            {
                var task = userDao.GetAllUsers();
                var allUsers = task.WaitAndUnwrapException();
                foreach (User user in allUsers)
                {
                    if (user.username.Equals(usernameInput))
                    {
                        usernameUnique = false;
                    }
                }

            }

            bool[] usernameValidity = {usernameFormatValid, usernameUnique};
            return usernameValidity;
        }

        /**
         * Checks if the password format submits to the password registration rules
         * The password must contain at least a capitalized letter, number,  and special character.
         * It also must be between 7-15 characters. 
         * @param  string passwordInput - user's entry for their password
         * @return bool - a boolean that indicates whether the password has correct format
         */
        public bool checkIsPasswordValid(string passwordInput)
        {
            bool hasUpperCaseLetter = false;
            bool hasNumber = false;
            bool hasSpecialChar = false;
            bool correctLength = false;
            bool isPasswordValid = false;

            // Checks if the password has the correct length
            if (passwordInput.Length >= MIN_PASSWORD_LENGTH && 
                passwordInput.Length <= MAX_PASSWORD_LENGTH)
            {
                correctLength = true;
            }

            // Checks the password format rule by looping over its chars
            foreach (char character in passwordInput)
            {
                if (Char.IsLetter(character) && Char.IsUpper(character))
                {
                    hasUpperCaseLetter = true;
                }
                if (Char.IsNumber(character))
                {
                    hasNumber = true;
                }
                if (!Char.IsLetter(character) && !Char.IsNumber(character))
                {
                    hasSpecialChar = true;
                }
            }

            if(hasUpperCaseLetter && hasNumber && hasSpecialChar && correctLength) 
            {
                isPasswordValid = true;
            }

            return isPasswordValid;
        }

        public void SaveUser()
        {
            User user = new User();
            var task = userDao.PostUser(user);
            User newUser = task.WaitAndUnwrapException();
        }


    }
}
