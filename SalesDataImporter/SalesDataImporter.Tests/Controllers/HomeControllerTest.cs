using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesDataImporter;
using SalesDataImporter.Controllers;

namespace SalesDataImporter.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Importacao()
        {
            // Arrange
            var controller = new ImportacaoController();

            // Act
            var result = controller.Importacao() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
