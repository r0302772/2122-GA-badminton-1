using System;
using NUnit.Framework;
using System.Text;
using System.Collections.Generic;
using Badminton_DAL;
using Badminton_WPF.ViewModels;



namespace SpelerUnitTest
{
    [TestFixture]
    public class UnitTests
    {
        SpelerViewModel model = new SpelerViewModel();
        ClubViewModel clubModel = new ClubViewModel();

        [Test]
        public void VoegSpelerToe()
        {
            //Arrange
            model.SpelerRecord.Voornaam = "Suleyman";
            model.SpelerRecord.Familienaam = "Yavas";
            model.SpelerRecord.GeslachtID = 1;
            model.SpelerRecord.Email = "test@test.be";
            model.SpelerRecord.Telefoonnummer = "044444";
            model.SpelerRecord.Geboortedatum = new DateTime(day: 20, month: 04, year: 1990);

            //Act
            model.Toevoegen();

            //Assert
            Assert.AreEqual("", model.Foutmelding);
        }

        [Test]
        public void VoornaamIngevuld()
        {
            //Arrange
            model.SpelerRecord.Voornaam = "";

            //Act
            model.Toevoegen();

            //Assert
            Assert.AreEqual(string.Empty, model.SpelerRecord.Voornaam);
        }

        [Test]
        public void FamilienaamIngevuld()
        {
            //Arrange
            model.SpelerRecord.Familienaam = "";

            //Act
            model.Toevoegen();

            //Assert
            Assert.IsEmpty(model.SpelerRecord.Familienaam);
        }

        [Test]
        public void GeslachtGeslecteerd()
        {
            //Arrange
            model.SpelerRecord.GeslachtID = 0;

            //Act
            model.Toevoegen();

            //Assert
            Assert.AreEqual(0, model.SpelerRecord.GeslachtID);
        }

        [Test]
        public void EmailIngevuld()
        {
            //Arrange
            model.SpelerRecord.Email = "";

            //Act
            model.Toevoegen();

            //Assert
            Assert.AreEqual("", model.SpelerRecord.Email);
        }

        [Test]
        public void TelefoonCorrectIngevuld()
        {
            //Arrange
            model.SpelerRecord.Telefoonnummer = "0488332299";

            //Act
            model.Toevoegen();

            //Assert
            Assert.That(model.SpelerRecord.Telefoonnummer, Has.Length.EqualTo(10));
            Assert.IsTrue(int.TryParse(model.SpelerRecord.Telefoonnummer, out int telefoonnummer));
        }

        [Test]
        public void GeboortedatumIngevuld()
        {
            //Arrange
            model.SpelerRecord.Geboortedatum = new DateTime(day: 20, month: 04, year: 1990);

            //Act
            model.Toevoegen();

            //Assert
            Assert.IsInstanceOf<DateTime>(model.SpelerRecord.Geboortedatum);
        }
        [Test]
        public void ClubNaamIngevuld()
        {
            //Arrange
            clubModel.ClubRecord.Clubnaam = "";

            //Act
            clubModel.Toevoegen();

            //Assert
            Assert.AreEqual(string.Empty, clubModel.ClubRecord.Clubnaam);
        }

        [Test]
        public void ClubEmailIngevuld()
        {
            //Arrange
            clubModel.ClubRecord.Email = "";

            //Act
            clubModel.Toevoegen();

            //Assert
            Assert.AreEqual("", clubModel.ClubRecord.Email);
        }

        [Test]
        public void ClubTelefoonCorrectIngevuld()
        {
            //Arrange
            clubModel.ClubRecord.Telefoonnummer = "0488332299";

            //Act
            clubModel.Toevoegen();

            //Assert
            Assert.That(clubModel.ClubRecord.Telefoonnummer, Has.Length.EqualTo(10));
            Assert.IsTrue(int.TryParse(clubModel.ClubRecord.Telefoonnummer, out int telefoonnummer));
        }
    }
}
