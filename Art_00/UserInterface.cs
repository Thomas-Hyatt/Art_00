using System;
using System.Collections.Generic;
using System.Text;

namespace Art_00
{
    /**
     * The UI is called by the command class to display menus & messages to the user. It also 
     * queryies the user for input & relays it back to command.
     */
    class UserInterface
    {
    /// Menu Displays

        /**
         * Displays the login page and presents the user with the following options:
         *  1. Who is Artemis?
         *  2. Login
         *  3. Register
         *  4. Exit Program
         * Prompts the user to choose an option with an integer input and returns it to command
         * @param  none
         * @return string - an integer string that corresponds to a menu option
         */
        public string displayLoginMenu()
        {
            // displays menu messages
            Console.WriteLine();
            Console.WriteLine("Welcome to Artemis, your loyal solution huntress :)");
            Console.WriteLine("Select an option below to get started:");
            Console.WriteLine();
            Console.WriteLine("1. Who is Artemis?");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Register");
            Console.WriteLine("4. Exit Program");

            // prompts user for input
            string userInputStr = Console.ReadLine();

            // returns user input
            return userInputStr;
        }

    /// Query Messages

        /**
         * Queries the user for a username during either registration or login, denoted by the bool
         * atLogin parameter.
         * If atLogin = false, the username must be unique and contain letters & numbers only, 
         * except for the special characters @ and _. Cannot start with a number nor a special
         * character. Needs to be between 3-21 characters. These requirements will be checked by 
         * the handler.
         * If atLogin = true, the username will be checked by the handler to see if any matches
         * come up in the database.
         * @param bool atLogin - A boolean indicating whether the user is at the registration or
         * login screen
         * @return string - a user input string which is the user's desired username
         */
        public string queryForUsername(bool atLogin)
        {
            // displays query message
            Console.WriteLine();
            if (!atLogin)
            {
                Console.WriteLine("*Usernames must start with a letter and contain only letters " +
                    "and numbers, except for special characters @ and _");
                Console.WriteLine("Please enter your desired username: ");
            }
            else {
                Console.WriteLine("Please enter your username: ");
            }
            // prompts user for input
            string userInputStr = Console.ReadLine();

            // returns user input
            return userInputStr;
        }

        /**
         * Queries the user for a password during either registration or login, denoted by the bool
         * atLogin parameter.
         * If atLogin = false, the password must contain at least a capitalized letter, number,
         * and special character. It also must be between 7-15 characters. These requirements will 
         * be checked by the handler.
         * If atLogin = true, the password will be checked by the handler to see if any matches
         * come up in the database.
         * @param bool atLogin - A boolean indicating whether the user is at the registration or
         * login screen
         * @return string - a user input string which is the user's desired password
         */
        public string queryForPassword(bool atLogin)
        {
            // displays query message
            Console.WriteLine();
            if (!atLogin)
            {
                Console.WriteLine("*Passwords must contain at least a capitalized letter, " +
                    "number, and special character");
                Console.WriteLine("Please enter your desired password: ");
            }
            else
            {
                Console.WriteLine("Please enter your password: ");
            }
            // prompts user for input
            string userInputStr = Console.ReadLine();

            // returns user input
            return userInputStr;
        }

        /// Notification Messages

        /**
         * Notifies the user that their username entered at registration is valid
         */
        public void displayUsernameValidMessage()
        {

            Console.WriteLine();
            Console.WriteLine("Username valid!");

        }

        /**
         * Notifies the user that their password entered at registration is valid
         */
        public void displayPasswordValidMessage()
        {

            Console.WriteLine();
            Console.WriteLine("Password valid!");

        }
    }
}
