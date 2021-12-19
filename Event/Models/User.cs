using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Event.Models
{
    public class User
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string UserInformation => $"" +
            $"Förnamn:    {FirstName}\n" +
            $"Efternamn:  {LastName}\n" +
            $"Email:      {Email}\n";

        public bool SetEmailAdess(string email)
        {
            try
            {
                var csRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                             @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                if (new Regex(csRegex).IsMatch(email))
                {
                    Email = email;
                    return true;
                }
                else
                    Console.WriteLine(" (Du måste ange gilltig email-adress)");

                return false;
            }
            catch { return false; }


        }

        public bool SetStringLengt(string name)
        {

            if (name.Length >= 2)
            {
                FirstName = name.ToLower();
                return true;
            }
            else
                Console.WriteLine(" (Ange giltigt förnamn. Minst två bokstäver)");
            //Console.WriteLine("Förnamn: ");

            return false;

        }
        public bool SetStringLengt2(string lastname)
        {
            if (lastname.Length >= 2)
            {
                LastName = lastname.ToLower();
                return true;
            }
            else
                Console.WriteLine(" (Ange giltigt efternamn. Minst två bokstäver)");
            //Console.WriteLine("Efternamn: ");

            return false;

        }

    }
}
