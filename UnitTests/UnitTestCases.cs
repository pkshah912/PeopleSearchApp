using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using PeopleSearchApp;
using PeopleSearchApp.Controllers;

namespace UnitTests
{
    [TestClass]
    public class UnitTestCases
    {
        //Test case for index method in Home Controller
        [TestMethod]
        public void IndexHomeController()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        //Test case for index method in Person Controller
        [TestMethod]
        public void IndexPeopleController()
        {
            //Arrange
            PersonController controller = new PersonController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        // Test case for testing the search functionality with text entered in the text box
        [TestMethod]
        public void SearchPeopleByString()
        {
            //Arrange
            PersonController controller = new PersonController();

            //Act
            var result = controller.SearchPeopleByString("shah") as JsonResult;

            //Assert
            dynamic data = result.Data;

            Assert.AreEqual(3, data.Count);
            Assert.AreEqual("Shah", data[0].LastName);
        }

        //Test case for testing the search functionality with no text entered in the text box
        [TestMethod]
        public void SearchPeopleWithoutString()
        {
            //Arrange
            PersonController controller = new PersonController();

            //Act
            var result = controller.SearchPeopleByString("") as JsonResult;

            //Assert
            dynamic data = result.Data;

            Assert.AreEqual(7, data.Count);

            Assert.AreEqual("Boston,MA", data[0].Address);

        }

        //Test case for testing the search functionality where no records are found
        [TestMethod]
        public void SearchPeopleNoRecords()
        {
            //Arrange
            PersonController controller = new PersonController();

            //Act
            var result = controller.SearchPeopleByString("wani") as JsonResult;

            //Assert
            dynamic data = result.Data;

            Assert.AreEqual(0, data.Count);
        }
    }
}
