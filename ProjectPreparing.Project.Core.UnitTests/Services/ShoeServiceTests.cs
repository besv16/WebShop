using System;
using System.Collections.Generic;
using System.Text;
using ProjectPreparing.Project.Core.Repositories;
using ProjectPreparing.Project.Core.Repositories.Implementations;
using ProjectPreparing.Project.Core.Models;
using ProjectPreparing.Project.Core.Services;
using NUnit.Framework;
using NUnit;
using FakeItEasy;

namespace ProjectPreparing.Project.Core.UnitTests.Services
{
    class ShoeServiceTests
    {

        private ShoeService shoeService;
        private IShoeRepository shoeRepository;

        [SetUp]
        public void SetUp()
        {
            this.shoeRepository = A.Fake<IShoeRepository>();
            this.shoeService = new ShoeService(this.shoeRepository);
        }

        [Test]
        public void GetAll_ReturnsExpectedProducts()
        {
            // Arrange
            var products = new List<ShoeViewModel>
            {
            new ShoeViewModel { Name = "Vans Old Skool" }
            };

            A.CallTo(() => this.shoeRepository.GetAll()).Returns(products);

            // Act
            var result = this.shoeService.GetAll();

            // Assert
            Assert.That(result, Is.EqualTo(products));
        }
        }
    }
