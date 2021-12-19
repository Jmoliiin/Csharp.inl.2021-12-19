using Event.Handlers;

//!!!!To change the textfile path go to : Event/Handlers/FileHandlers

IMenuHandler menuhandler = new MenuHandler();

var menuChoise = -1;
bool exitProgram = true;

Console.WriteLine("" +
            "######################################################\n" +
            "                Deltagarhantering - Event             \n" +
            "######################################################\n");
Console.WriteLine("Press any key to open the program");
Console.ReadKey();
Console.Clear();


//Program start.
while (exitProgram)
{
    //If statement to loop out a text after every case-choise
    if (menuChoise != 0)
        menuhandler.MenuOption();

    //if..else statement to controll if the user not use a int.
    if (!int.TryParse(Console.ReadLine(), out menuChoise))
        Console.WriteLine("Vänligen välj en siffra mellan 1-5");
    else
        //switch menu
        switch (menuChoise)
        {
            case 1:
                menuhandler.Add();

                break;
            case 2:
                menuhandler.Remove();
                break;
            case 3:
                menuhandler.ShowList();
                break;
            case 4:
                menuhandler.Discount();
                break;
            case 5:
                menuhandler.SaveToFile();
                break;
            case 6:
                menuhandler.PrintTextFile();
                break;
            case 7:
                menuhandler.Exit();
                exitProgram = false;
                break;
            default:
                
                break;
        }
}
Console.WriteLine("Avslutar program...");
Console.ReadLine();


