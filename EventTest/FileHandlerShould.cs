using Event.Handlers;
using Event.Models;
using System.Collections.Generic;
using Xunit;

namespace EventTest
{
    public class FileHandlerShould
    {
        private IFileHandler sut = new FileHandler();
        private List<string> ulist = new List<string>();
        private bool succeeded;
        
        [Fact]
        public void Add_To_Text_File()
        {
            succeeded = sut.Add(ulist);
            Assert.True(succeeded);

        }
        [Fact]
        public void Show_Text_File()
        {
            succeeded = sut.Show();
            Assert.True(succeeded);
            

        }
    }
}