using Event.Handlers;
using Event.Models;
using System.Collections.Generic;
using Xunit;

namespace EventTest
{
    public class ListHandlerShould
    {
        private IListHandler sut = new ListHandler();
        private List<string> ulist = new List<string>();
        private bool succeeded;

        [Fact]
        public void Show_List()
        {
            succeeded = sut.ShowList(ulist);
            Assert.True(succeeded);

        }
        
    }
}
