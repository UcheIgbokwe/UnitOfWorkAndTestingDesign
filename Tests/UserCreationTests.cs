using System.Collections.Generic;
using Domain.Model;
using Infrastructure;
using Infrastructure.Repository.Interfaces;
using Moq;
using Xunit;

namespace Tests
{
    public class UserCreationTests
    {
        private IUnitOfWork unitOfWork;
        
        [Fact]
        public void Get_All_User_Count_Result() {

        Mock<IUnitOfWork> mock = new();

        mock.Setup(m => m.Repository<User>().GetAll()).Returns(new List<User> {
            new User { Name = "Uche", Email = "u@gmail.com"},
            new User { Name = "Imoh", Email = "i@gmail.com"},
            new User { Name = "Dan", Email = "d@gmail.com"}
        });

        unitOfWork = mock.Object;

        //Arrange
        UserCreation userCreation = new(unitOfWork);

        //Act
        var getResult = userCreation.GetAllUsers();

        //Assert
        Assert.Equal<int>(3, getResult.Count); 
        }
    }
}