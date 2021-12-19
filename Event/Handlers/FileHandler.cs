using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Handlers
{
    public interface IFileHandler
    {
        bool Add( List<string> userinfo);
        bool Show();
        void CreateSavePath( List<string> list);
    }

    public class FileHandler : IFileHandler
    {
       private readonly string path = @"C:\Users\jessi\Desktop\MyTest.txt";

        /*
         * Creates textpath and loops thru a list,writhe to textfile line by line from list.
         */
        public bool Add( List<string> userinfo)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (string line in userinfo)
                        sw.WriteLine(line);

                    sw.Close();
                    Console.WriteLine("" +
                   $"* Sparad till textfil i sökvägen {path}\n");
                    return true;
                }
                
            }
            catch { return false; }
            
        }
        /*
         * Read all text in textfile,in the path.
         */
        public bool Show()
        {
            try 
            {
                string text = System.IO.File.ReadAllText(path);
                Console.WriteLine(text);
                return true; 
            }
            catch { return false; }
            
        }

        public void CreateSavePath( List<string> list)
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(list.ToString());


                }
            }
        }
    }
}
