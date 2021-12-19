using Event.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Handlers
{
    public interface IListHandler
    {
        bool AddToList(List<string> usersList, List<string> userEmailList);
        bool ShowList(List<string> usersList);
        bool RemoveFromeList(List<string> usersList, List<string> userEmailList);
        bool GetUserInput();


    }

    public class ListHandler : IListHandler
    {
        User user = new User();

        /*
         * while-loop to controle user-input .
         * Every field must pass private sets in "class User" before moving to next field.
         * returns true if succeded
         */
        public bool GetUserInput()
        {
            bool valid = false;
            while (valid == false)
            {
                if (user.FirstName == string.Empty)
                {
                    Console.Write("Förnamn: ");
                    var firstname = Console.ReadLine();
                    if (firstname != null) 
                        user.SetStringLengt(firstname);
                }
                else if (user.LastName == string.Empty)
                {
                    Console.Write("Efternamn: ");
                    var lastname = Console.ReadLine();
                    if (lastname != null)
                        user.SetStringLengt2(lastname);
                }
                else if (user.Email == string.Empty)
                {
                    Console.Write("Email: ");
                    var email = Console.ReadLine();
                    if (email != null)
                        user.SetEmailAdess(email);
                }
                else if (user.FirstName != string.Empty && user.LastName != string.Empty && user.Email != string.Empty)
                {
                    
                    return true;
                }
            }
            return false;
        }
        /*
         * Takes in two List parameters.
         * check if GetUserInput() return true
         * if true- adds user information to userlist and  emaillist. 
         * returns true if succeded
         */
        public bool AddToList(List<string> usersList, List<string> userEmailList)
        {
            
            if (GetUserInput())
            {
                usersList.Add(user.UserInformation);
                userEmailList.Add(user.Email);
                user = new User();

                return true;
            }

            return false;
            
        }
        /*
         * Takes in a list parameter, foreach-loop to show content in the list. 
         * return true if succeded
         */
        public bool ShowList(List<string> usersList)
        {
            try
            {
                IEnumerable<string> elist;
                elist = usersList;
                foreach (var item in elist)
                    Console.WriteLine($"{item} \n");
                return true;
            }
            catch { return false; }
            
        }
        /*
         * Takes in two List parameters to remove a user from.
         * checks GetUserInput() thats going to be removed
         * Checks if metod Remove(the user to be removed) are removed from list, returns true if succeded
         * if succesed - remove from the other list to.
         * returns true if succeeded.
         */
        public bool RemoveFromeList(List<string> usersList, List<string> userEmailList)
        {
            
            if (GetUserInput())
            {
                
                if (usersList.Remove(user.UserInformation))
                {
                    userEmailList.Remove(user.Email);
                    user = new User();
                    return true;
                }else
                    return false;
            }
            return false;
        }
    }
}
