using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcLab.Data.Models;
using MvcLab.Data.Repositories;
using System.Collections.Generic;

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
            UserEntity user = new UserEntity()
            {
                //UserId = Guid.NewGuid(),
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

            userRepo.Add(user);

            //act
            var retrievedUser = userRepo.GetUser(user.UserEntityId);

            //assert
            Assert.AreEqual(user, retrievedUser);
        }
        [TestMethod]
        public void CreatedUserGetsAddedToTemporaryMemory()
        {
            //arrange
            UserRepository userRepo = new UserRepository();
            UserEntity user = new UserEntity()
            {
                //UserId = Guid.NewGuid(),
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
            userRepo.Add(user);

            List<UserEntity> users = userRepo.RetrieveAll();  
            //Assert
            if (users.Contains(user))
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }
    }
}
