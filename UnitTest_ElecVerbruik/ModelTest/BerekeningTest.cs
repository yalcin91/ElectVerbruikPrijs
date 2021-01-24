using System;
using System.Collections.Generic;
using System.Text;

using BusinessLayer.Model;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_ElecVerbruik.ModelTest
{
    [TestClass]
    public class BerekeningTest
    {
        private Berekening Berekening;

        [TestInitialize]
        public void Setup()
        {
            Berekening = new Berekening();
        }

        [TestMethod]
        public void Test_Propertys()
        {
            int uren = 2;
            int dagen = 5;
            double vermogenInWatt = 10;
            decimal prijsPerKwh = 0.1m;
            Berekening.Uren = uren;
            Berekening.Dagen = dagen;
            Berekening.VermogenInWatt = vermogenInWatt;
            Berekening.PrijsPerKwh = prijsPerKwh;
            Assert.AreEqual(2, Berekening.Uren);
            Assert.AreEqual(5, Berekening.Dagen);
            Assert.AreEqual(10, Berekening.VermogenInWatt);
            Assert.AreEqual(0.1m, Berekening.PrijsPerKwh);
        }

        [TestMethod]
        public void Test_Formule()
        {
            int uren = 8;
            int dagen = 100;
            double vermogenInWatt = 10;
            decimal prijsPerKwh = 0.1m;
            Berekening.Uren = uren;
            Berekening.Dagen = dagen;
            Berekening.VermogenInWatt = vermogenInWatt;
            Berekening.PrijsPerKwh = prijsPerKwh;

            Assert.AreEqual(0.8m, Berekening.Formule());
        }
    }
}
