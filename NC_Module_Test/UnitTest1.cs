using Microsoft.VisualStudio.TestTools.UnitTesting;
using NC_Module.Models;

namespace NC_Module_Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void MustCreateNC()
        {
            
        }

        [TestMethod]
        public void MustReturnTheNcCode()
        {
            NonConf nonConf = new NonConf(1, 0, "anything");

            Assert.IsTrue("2020:01:01".Equals(nonConf.Code));
        }
    }
}
