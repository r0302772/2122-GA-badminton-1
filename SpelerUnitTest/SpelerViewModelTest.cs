using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using System.Text;
using System.Collections.Generic;
using Badminton_DAL;
using Badminton_WPF.ViewModels;



namespace SpelerUnitTest
{
    [TestClass]
    public class SpelerViewModelTest
    {
        SpelerViewModel model = new SpelerViewModel();

        [TestMethod]
        public void VoegSpelerToe()
        {
            model.SpelerRecord = new Speler()
            {
                Id = 1,
                Voornaam = "Suleyman",
                Familienaam = "Yavas",
                GeslachtID = 1,
                ClubID = null,
                Email = "test@test.be",
                Telefoonnummer = "044444",
                Geboortedatum = new DateTime(day: 20, month: 04, year: 1990)
            };
            Assert.Contains();


        }

        [TestMethod]
        public void VerwijderSpeler()
        {
        }
        [TestMethod]
        public void WijzigrSpeler()
        {
        }

        [TestMethod]
        public void ZoekSpelerSpeler()
        {
        }
    }
}
