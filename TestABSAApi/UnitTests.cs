using ABSA.Core.Service;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;


namespace TestABSAApi
{
    public class Tests
    {
        private ABSA.Core.Service.Services.PhoneBookService _service;
      
        
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ABSAPhoneBookDbContext>()
            .UseInMemoryDatabase(databaseName: "PhoneBook")
            .Options;

            var context = new ABSAPhoneBookDbContext(options);

            var mapperMock = new Mock<IMapper>();
            _service = new ABSA.Core.Service.Services.PhoneBookService(mapperMock.Object, context);
        }

        [Test]
        public void PhoneBookServiceTests()
        {
            var Pb = new ABSA.Core.Service.Models.phonebook();
            Pb.id = 0;
            Pb.phonebookname = "Test Name should Pass";

            var succ = _service.PhoneBook_Add(Pb);
            if (succ != -1) Assert.Pass();
            else Assert.Fail();

        }
        [Test]
        public void PhoneBookServiceNegative()
        {
            var Pb = new ABSA.Core.Service.Models.phonebook();            
            Pb.phonebookname = null;

            var succ = _service.PhoneBook_Add(Pb);
            if (succ != -1) Assert.Fail();
            else Assert.Pass();

        }
    }
}