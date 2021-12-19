using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Handlers
{
    public interface IMenuHandler
    {
        void MenuOption();
        void Add();
        void Remove();
        void ShowList();
        void Discount();
        void SaveToFile();
        void PrintTextFile();
        void Exit();

    }

    public class MenuHandler : IMenuHandler
    {

        private IListHandler listhandler = new ListHandler();
        private IFileHandler filehandler = new FileHandler();
        

        private List<string> usersList = new List<string>();
        private List<string> userEmailList = new();


        public void MenuOption()
        {
            Console.WriteLine("" +
            "¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤\n" +
            "                        MENU                          \n" +
            "¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤\n" +
            "1. Registrera en kund för evenemang\n" +
            "2. Avbokning. Ta bort kund från deltagarlista\n" +
            "3. Skriv ut kundlista över deltagande på evenemanget\n" +
            "4. Skicka rabattkod till registrerade kunder\n" +
            "5. Spara kundlistan till textfil\n" +
            "6. Skriv ut kunder från textfilen\n" +
            "7. Avsluta program");

        }

        /*
         * method who calls another metod to add user. 
         */
        public void Add()
        {
            Console.Clear();
            Console.WriteLine("" +
                "----------------------------------------------------\n" +
                "           Registrera kund för evenemang            \n" +
                "                                                    \n" +
                "Fyll i förnamn, efternamn och Email-adress          \n" +
                "----------------------------------------------------\n");

            if (listhandler.AddToList(usersList,userEmailList))
            {
                Console.WriteLine("" +
                    "                             Registrering klar\n");
            }
            else Console.WriteLine("" +
                "                              Kunde inte registrera\n");
            ClearConsole();
        }
        /*
         * method who calls class listhandler metod to show user and Remove user. 
         */
        public void Remove()
        {
            Console.Clear();
            Console.WriteLine("" +
                "---------------------------------------------------\n" +
                "          Avboka kund från evenemang               \n" +
                "---------------------------------------------------\n");
            Console.WriteLine("" +
                "------------Befintlig kundlista:--------------------\n");
            listhandler.ShowList(usersList);
            Console.WriteLine("" +
                "Avboka kund: \n");
            if (listhandler.RemoveFromeList(usersList, userEmailList))
                Console.WriteLine($"" +
                    $"                          Kunden är borttagen\n");
            else
                Console.WriteLine("" +
                    "                         Kunden gick inte hitta\n");
            ClearConsole();
        }
        /*
         * method who calls class listhandler metod to Show list of user. 
         */
        public void ShowList()
        {
            Console.Clear();
            Console.WriteLine("" +
                "---------------------------------------------------\n" +
                "       Deltagande kunder på evenemanget            \n" +
                "---------------------------------------------------\n");
            listhandler.ShowList(usersList);
            ClearConsole();
        }
        /*
         * Makes a uniq discount using Guid() and random() to send to emaillist.
         */
        public void Discount()
        {
            Console.Clear();
            Console.WriteLine("" +
            "------------------------------------------------------\n" +
            "    Skicka rabattkod till deltagandes email-adresser  \n" +
            "------------------------------------------------------\n");
            listhandler.ShowList(userEmailList);

            Guid g = Guid.NewGuid();
            Random rn = new Random();
            string gs = g.ToString();
            int randomInt = rn.Next(5, 10 + 1);
            var Discount = gs.Substring(gs.Length - randomInt - 1, randomInt);

            Console.WriteLine($"Rabattkod: {Discount}");
            Console.WriteLine($"" +
                $"\nSkicka rabattkod till deltargarlistan?\n" +
                $"y = ja / n = nej");

            if (Console.ReadLine() == "y") { Console.WriteLine("Skickat.\n"); }
            else { Console.WriteLine("Ej skickat.\n"); }
            ClearConsole();
        }

        /*
        * method who calls filehandler metod to Add users to textfile. 
        */
        public void SaveToFile()
        {
            Console.Clear();
            Console.WriteLine("" +
                "---------------------------------------------------\n" +
                "       Sparar deltagande kunder till Textfil       \n" +
                "---------------------------------------------------\n");
            
            filehandler.Add(usersList);
            ClearConsole();
        }
        /*
         * method who calls filehandler metod to read from textfile. 
         */
        public void PrintTextFile()
        {
            Console.Clear();
            Console.WriteLine("" +
                "---------------------------------------------------\n" +
                "        Utskrift av deltagande kunder              \n" +
                "  (glöm ej spara till textfil innan utskrift)                                                 \n" +
                "---------------------------------------------------\n");
            filehandler.Show();
            ClearConsole();
        }
        public void Exit()
        {
            Console.Clear();
            Console.WriteLine("--------------------Avsluta Program-------------------");
            
        }
        /*
         * Clear console. 
         */
        public static void ClearConsole()
        {
            Console.WriteLine("Tyck på en knapp för att komma tillbaka till menyn");
            Console.ReadKey();
            Console.Clear();
        }
    }
    
}
