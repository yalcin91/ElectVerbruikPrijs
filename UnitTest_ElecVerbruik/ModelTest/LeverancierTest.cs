using System;

using BusinessLayer.Exceptions;
using BusinessLayer.Model;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_ElecVerbruik
{
    [TestClass]
    public class LeverancierTest
    {
        [TestMethod]
        public void Test_Naam()
        {
            string naam = "Luminus";
            Leverancier leverancier = new Leverancier();
            leverancier.Naam = naam;

            Assert.AreEqual(naam, leverancier.Naam);
            Assert.AreEqual(default(long), leverancier.Id);
            Assert.AreEqual(default(decimal), leverancier.PrijsKHW);
            Assert.AreEqual(default(string), leverancier.MaatschappelijkeZetel);
            Assert.AreEqual(default(Leverancier), leverancier.leverancier);
        }

        [TestMethod]
        public void Test_Id()
        {
            long id = 1;
            Leverancier leverancier = new Leverancier();
            leverancier.Id = id;

            Assert.AreEqual(id, leverancier.Id);
            Assert.AreEqual(default(string), leverancier.Naam);
            Assert.AreEqual(default(decimal), leverancier.PrijsKHW);
            Assert.AreEqual(default(string), leverancier.MaatschappelijkeZetel);
            Assert.AreEqual(default(Leverancier), leverancier.leverancier);
        }

        [TestMethod]
        public void Test_Prijs()
        {
            decimal prijs = 2.12m;
            Leverancier leverancier = new Leverancier();
            leverancier.PrijsKHW = prijs;

            Assert.AreEqual(prijs, leverancier.PrijsKHW);
            Assert.AreEqual(default(long), leverancier.Id);
            Assert.AreEqual(default(string), leverancier.Naam);
            Assert.AreEqual(default(string), leverancier.MaatschappelijkeZetel);
            Assert.AreEqual(default(Leverancier), leverancier.leverancier);
        }

        [TestMethod]
        public void Test_MaatschappelijkeZetel()
        {
            string maatschappelijkeZetel = "Simon Bolivarlaan 34 - 1000 Brussel";
            Leverancier leverancier = new Leverancier();
            leverancier.MaatschappelijkeZetel = maatschappelijkeZetel;

            Assert.AreEqual(maatschappelijkeZetel, leverancier.MaatschappelijkeZetel);
            Assert.AreEqual(default(long), leverancier.Id);
            Assert.AreEqual(default(string), leverancier.Naam);
            Assert.AreEqual(default(decimal), leverancier.PrijsKHW);
            Assert.AreEqual(default(Leverancier), leverancier.leverancier);
        }

        [TestMethod]
        public void Test_AllProperty()
        {
            long id = 1;
            string naam = "Luminus";
            decimal prijs = 2.12m;
            string maatschappelijkeZetel = "Simon Bolivarlaan 34 - 1000 Brussel";
            Leverancier leverancier = new Leverancier();
            leverancier.Id = id;
            leverancier.Naam = naam;
            leverancier.PrijsKHW = prijs;
            leverancier.MaatschappelijkeZetel = maatschappelijkeZetel;

            Assert.AreEqual(maatschappelijkeZetel, leverancier.MaatschappelijkeZetel);
            Assert.AreEqual(id, leverancier.Id);
            Assert.AreEqual(naam, leverancier.Naam);
            Assert.AreEqual(prijs, leverancier.PrijsKHW);
            Assert.AreEqual(default(Leverancier), leverancier.leverancier);
        }

        [TestMethod]
        public void Test_SetNaam_ThrowProductException()
        {
            string naam = "";
            Leverancier leverancier = new Leverancier();

            Assert.ThrowsException<LeverancierException>(() => leverancier.SetNaam(naam));
        }

        [TestMethod]
        public void Test_SetId_ThrowProductException()
        {
            long id = 0;
            long id2 = -1;
            Leverancier leverancier = new Leverancier();

            Assert.ThrowsException<LeverancierException>(() => leverancier.SetId(id));
            Assert.ThrowsException<LeverancierException>(() => leverancier.SetId(id2));
        }

        [TestMethod]
        public void Test_SetPrijs_ThrowProductException()
        {
            decimal prijs = 0.0m;
            decimal prijs2 = -1.0m;
            Leverancier leverancier = new Leverancier();

            Assert.ThrowsException<LeverancierException>(() => leverancier.SetPrijs(prijs));
            Assert.ThrowsException<LeverancierException>(() => leverancier.SetPrijs(prijs2));
        }

        [TestMethod]
        public void Test_SetMaatschappelijkeZetel_ThrowProductException()
        {
            string maatschappelijkeZetel = "";
            Leverancier leverancier = new Leverancier();

            Assert.ThrowsException<LeverancierException>(() => leverancier.SetMaatschappelijkeZetel(maatschappelijkeZetel));
        }

        [TestMethod]
        public void Test_SetToekenningLeveringvergunning_ThrowProductException()
        {
            DateTime toekenningLeveringvergunning = DateTime.Parse("1/1/1896");
            Leverancier leverancier = new Leverancier();

            Assert.ThrowsException<LeverancierException>(() => leverancier.SetToekenningLeveringvergunning(toekenningLeveringvergunning));
        }

        [TestMethod]
        public void Test_SetPublicatiebeslissingInBelGischStaatsblad_ThrowProductException()
        {
            DateTime publicatiebeslissingInBelGischStaatsblad = DateTime.Parse("1/1/1896");
            Leverancier leverancier = new Leverancier();

            Assert.ThrowsException<LeverancierException>(() => leverancier.SetPublicatiebeslissingInBelGischStaatsblad(publicatiebeslissingInBelGischStaatsblad));
        }
    }
}
