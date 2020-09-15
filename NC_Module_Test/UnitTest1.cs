using Microsoft.VisualStudio.TestTools.UnitTesting;
using NC_Module;
using NC_Module.BLL.NonConfBLL;
using NC_Module.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NC_Module_Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void ShouldReturnTheNcCode()
        {
            NonConfBLL nonConfBll = new NonConfBLL();
            NonConf nonConf = new NonConf();
            nonConfBll.NcCodeGenerator(nonConf);
            Assert.AreEqual("2020:00:01", nonConf.Code);
        }

     




    }
}
