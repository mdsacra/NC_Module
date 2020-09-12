using Microsoft.VisualStudio.TestTools.UnitTesting;
using NC_Module.BLL;
using NC_Module.ModelDTO;
using NC_Module.Models;
using System;
using System.Security.Cryptography.X509Certificates;

namespace NC_Module_Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void MustMakeNcDTO()
        {

            NonConf nonConf = new NonConf();
            NonConfBLL nonConfBLL = new NonConfBLL();

            var convertion = nonConfBLL.MakeNcDTO(nonConf);

            Assert.IsInstanceOfType(convertion, typeof(NonConfDto));
        }

        [TestMethod]
        public void MustReturnTheNcCode()
        {
            NonConf nonConf = new NonConf();
            NonConfBLL nonConfBll = new NonConfBLL();

            nonConf.Id = 1;
            nonConf.Date = new DateTime(2020, 09, 12);
            nonConf.Version = 1;

            var nonConfDto = nonConfBll.MakeNcDTO(nonConf);

            Assert.AreEqual("2020:01:01", nonConfDto.Code);
        }


    }
}
