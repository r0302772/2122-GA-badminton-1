using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace SpelerUnitTest
{
    [TestFixture]
    public class EndToEndTests
    {
        string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        string WpfAppId = @"C:\Users\Dennis Nijs\Documents\School\Programmeren Jaar 2\2e semester\Agile en testing\E2E testing\Nunit Tutorial\Nunit Tutorial\bin\Debug\Nunit Tutorial.exe";

        WindowsDriver<WindowsElement> session;

        WindowsElement voornaam, familienaam, geslacht, geboortedatum, telefoonnummer, email, foutmelding, toevoegen, aanpassen, verwijderen;

        [SetUp]
        public void Setup()
        {
            if (session == null)
            {
                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", WpfAppId);
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);

                voornaam = session.FindElementByAccessibilityId("Voornaam");
                familienaam = session.FindElementByAccessibilityId("Familienaam");
                geslacht = session.FindElementByAccessibilityId("Geslacht");
                geboortedatum = session.FindElementByAccessibilityId("Geboortedatum");
                telefoonnummer = session.FindElementByAccessibilityId("Telefoonnummer");
                email = session.FindElementByAccessibilityId("Email");

                foutmelding = session.FindElementByAccessibilityId("Foutmelding");

                toevoegen = session.FindElementByAccessibilityId("Toevoegen");
                aanpassen = session.FindElementByAccessibilityId("Aanpassen");
                verwijderen = session.FindElementByAccessibilityId("Verwijderen");
            }
        }

        [Test]
        public void SpelerToevoegen()
        {
            // Act
            voornaam.SendKeys("Tom");
            familienaam.SendKeys("Waes");
            geslacht.SendKeys("M");
            geboortedatum.SendKeys("20/12/1970");
            telefoonnummer.SendKeys("0477889900");
            email.SendKeys("tom.Waes@hotmail.com");
            toevoegen.Click();

            // Assert
            Assert.AreEqual("Tom", voornaam.Text);
            Assert.AreEqual("Waes", familienaam.Text);
            Assert.AreEqual("M", geslacht.Text);
            Assert.AreEqual("20/12/1970", geboortedatum.Text);
            Assert.AreEqual("0477889900", telefoonnummer.Text);
            Assert.AreEqual("tom.Waes@hotmail.com", email.Text);
            Assert.AreEqual("", foutmelding.Text);
        }

        [Test]
        public void SpelerAanpassen()
        {
            // Act

            aanpassen.Click();

            // Assert

        }

        [Test]
        public void SpelerVerwijderen()
        {
            // Act

            verwijderen.Click();

            // Assert

        }

        [Test]
        public void SpelerLezen()
        {
            // Act


            // Assert

        }

        [TearDown]
        public void TearDown()
        {
            voornaam.Clear();
            familienaam.Clear();
            geslacht.Clear();
            geboortedatum.Clear();
            telefoonnummer.Clear();
            email.Clear();
        }

        [OneTimeTearDown]
        public void CloseSession()
        {
            session.Close();
        }
    }
}
