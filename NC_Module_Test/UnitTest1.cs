using Microsoft.VisualStudio.TestTools.UnitTesting;
using NC_Module;
using NC_Module.BLL.NonConfBLL;
using NC_Module.ModelDTO;
using NC_Module.Models;
using NC_Module.Services.NonConfService;
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

        [TestMethod]
        public void ShouldEvaluateLikeEffective()
        {
            NonConf nonConf = new NonConf();
            NonConfBLL nonConfBLL = new NonConfBLL();

            nonConfBLL.EvaluateNc(nonConf, 1);

            Assert.AreEqual(1, nonConf.Status);
        }

        [TestMethod]
        public void ShouldEvaluateLikeNonEffective()
        {
            NonConf nonConf = new NonConf();
            NonConfBLL nonConfBLL = new NonConfBLL();

            nonConfBLL.EvaluateNc(nonConf, 2);

            Assert.AreEqual(2, nonConf.Status);
        }

        [TestMethod]
        public void IfEvaluateNonEffectiveShouldReturnNewNc()
        {
            NonConf nonConf = new NonConf();
            NonConfBLL nonConfBLL = new NonConfBLL();

            NonConf newNonConf = nonConfBLL.EvaluateNc(nonConf, 2);

            Assert.AreNotSame(nonConf, newNonConf);
        }

        [TestMethod]
        public void ShouldIncrementNcVersion()
        {
            NonConf nonConf = new NonConf();
            NonConfBLL nonConfBLL = new NonConfBLL();

            NonConf newNonConf = nonConfBLL.EvaluateNc(nonConf, 2);

            Assert.AreEqual("2020:00:02", newNonConf.Code);
        }




    }
}
