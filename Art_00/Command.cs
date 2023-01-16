using System;
using System.Collections.Generic;
using Nito.AsyncEx.Synchronous;
using Art_00.classes.model;
using Art_00.classes.dao;

namespace Art_00
{
    /**
     * The Command class is the controller of the entire project. It calls the Handler help class
     * to carry out its objective tasks, the UI helper class to display messages & query intakes
     * from the user, and the dao classes to interact with the database.
     */
    class Command 
    {
        static void Main(string[] args) 
        {
            /*var command = new Command();*/

            bool exitProgram = false;
            User user = new User();
            UserInterface UI = new UserInterface();
            Handler handler = new Handler();

            while (!exitProgram)
            {
                bool atLogin;

                string loginMenuOptionInputStr = UI.displayLoginMenu();
                int loginMenuOptionInputInt = handler.handleLoginMenu(loginMenuOptionInputStr);

                // Login Menu
                switch (loginMenuOptionInputInt)
                {
                    // Who is Artemis?
                    //case 1:

                    //    break;

                    // User login
                    case 2:
                        atLogin = true;
                        break;

                    // User registration
                    case 3:

                        atLogin = false;
                        bool isUsernameValid = false;

                        while (!isUsernameValid)
                        {

                            string registrationUsernameInput = UI.queryForUsername(atLogin);
                            Boolean[] usernameValidity = handler.checkIsUsernameValid(registrationUsernameInput);

                            if (usernameValidity[0] && usernameValidity[1]) // If username format is correct & username is unique
                            {

                                bool isPasswordValid = false;

                                while (!isPasswordValid) 
                                {

                                    string registrationPasswordInput = UI.queryForPassword(atLogin);
                                    isPasswordValid = handler.checkIsPasswordValid(registrationPasswordInput);

                                    if (isPasswordValid) 
                                    {

                                        handler.SaveUser();
                                        // UI.display success
                                    }
                                }

                                isUsernameValid = true;
                            } 
                            else
                            {
                                // UI.display message
                            }

                        }

                        break;

                    // Exit program
                    case 4:

                        exitProgram= true;
                        break;
                }
            }
        }
    }
}
