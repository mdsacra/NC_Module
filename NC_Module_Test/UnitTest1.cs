using Microsoft.VisualStudio.TestTools.UnitTesting;
using NC_Module.BLL;
using NC_Module.ModelDTO;
using NC_Module.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace NC_Module_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldCreateNc()
        {
            NonConfBLL nonConfBLL = new NonConfBLL();
            List<CorrAction> corrActions = new List<CorrAction>();
            var nonConf = nonConfBLL.CreateNc(1, "anything", corrActions);

            Assert.IsInstanceOfType(nonConf, typeof(NonConf));
        }

        [TestMethod]
        public void ShouldMakeNcDTO()
        {
            NonConf nonConf = new NonConf();
            NonConfBLL nonConfBLL = new NonConfBLL();

            var convertion = nonConfBLL.MakeNcDTO(nonConf);

            Assert.IsInstanceOfType(convertion, typeof(NonConfDto));
        }

        [TestMethod]
        public void ShouldReturnTheNcCode()
        {
            NonConfBLL nonConfBll = new NonConfBLL();

            var nonConfDto = nonConfBll.MakeNcDTO(
                             nonConfBll.CreateNc(1, "anything", new List<CorrAction>()));

            Assert.AreEqual("2020:00:01", nonConfDto.Code);
        }

        [TestMethod]
        public void ShouldReturnNotEmptyCorrActionsList()
        {
            CorrAction corrAction = new CorrAction();
            corrAction.Description = "Do Anything.";
            List<CorrAction> corrActions = new List<CorrAction>();
            corrActions.Add(corrAction);

            NonConfBLL nonConfBLL = new NonConfBLL();
            NonConf nonConf = nonConfBLL.CreateNc(1, "anything", corrActions);

            Assert.IsTrue(nonConf.CorrActions.Count > 0);

        }


    }
}
