using Badminton_DAL;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpelerUnitTest
{
    [TestFixture]
    public class MockingTests
    {
        private BadmintonEntities entities = A.Fake<BadmintonEntities>();

        [Test]
        public void OphalenSpelers()
        {
            //Arrange
            ObservableCollection<Speler> spelers;

            //Act
            spelers = new ObservableCollection<Speler>(entities.Spelers.Local);

            //Assert
            Assert.NotNull(spelers);
            Assert.IsInstanceOf<ObservableCollection<Speler>>(spelers);
        }

        [Test]
        public void SpelerCreate()
        {
            //Arrange


            //Act


            //Assert

        }

        [Test]
        public void SpelerRead()
        {
            //Arrange
            Speler speler = A.Fake<Speler>();

            //Act
            speler = entities.Spelers.Find(DatabaseOperations.GetSpelerByPK(speler.Id));

            //Assert
            Assert.NotNull(speler);
            Assert.IsInstanceOf<Speler>(speler);
        }

        [Test]
        public void SpelerUpdate()
        {
            //Arrange


            //Act


            //Assert

        }

        [Test]
        public void SpelerDelete()
        {
            //Arrange


            //Act


            //Assert

        }

        [Test]
        public void OphalenClubs()
        {
            //Arrange
            ObservableCollection<Club> clubs;

            //Act
            clubs = new ObservableCollection<Club>(entities.Clubs.Local);

            //Assert
            Assert.NotNull(clubs);
            Assert.IsInstanceOf<ObservableCollection<Speler>>(clubs);
        }
    }
}
