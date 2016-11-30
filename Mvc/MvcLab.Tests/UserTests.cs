using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcLab.Data.Models;
using MvcLab.Data.Repositories;

namespace MvcLab.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void RetreiveAnExistingUserFromTemporaryMemory()
        {
            //arrange
            UserRepository userRepo = new UserRepository();
            UserModel user = new UserModel()
            {
                Id = Guid.NewGuid(),
                Firstname = "ivan",
                Lastname = "prgomet",
                Phone = "9238457",
                Email = "ivan.prgomet@hotmail.com",
                Street = "långgatan 74",
                Username = "ivanprgomet",
                Password = "ivano",
                Country = "sweden",
                City = "Lund",
                DateRegistered = DateTime.Now,
            };

            UserRepository.Users.Add(user);

            //act
            var retrievedUser = userRepo.GetUser(user.Id);

            //assert
            Assert.AreEqual(user, retrievedUser);
        }
        [TestMethod]
        public void CreatedUserGetsAddedToTemporaryMemory()
        {
            //arrange
            UserRepository userRepo = new UserRepository();
            UserModel user = new UserModel()
            {
                Id = Guid.NewGuid(),
                Firstname = "ivan",
                Lastname = "prgomet",
                Phone = "9238457",
                Email = "ivan.prgomet@hotmail.com",
                Street = "långgatan 74",
                Username = "ivanprgomet",
                Password = "ivano",
                Country = "sweden",
                City = "Lund",
                DateRegistered = DateTime.Now,
            };

            //Act
            userRepo.CreateUser(user);

            //Assert
            if (UserRepository.Users.Contains(user))
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }
    }
}
