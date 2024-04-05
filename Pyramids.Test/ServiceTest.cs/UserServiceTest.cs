using Moq;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using System.Linq.Expressions;

namespace Pyramids.UnitTest.ServiceTests
{
    public class UserServiceTest
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly User _testUser;

        public UserServiceTest()
        {
            _mockUserService = new Mock<IUserService>();
            _testUser = new User
            {
                Id = 1,
                FirstName = "Test",
                LastName = "User",
                Email = "user@user.com",
                PasswordHash = "xxx"
            };
        }

        [Fact]
        public void GetByEmail_ReturnsValidUser()
        {
            _mockUserService.Setup(service => service.Get(It.IsAny<string>()))
                .Returns(_testUser);
            var result = _mockUserService.Object.Get(_testUser.Email);
        }
        //[Fact]
        //public async Task GetByIdAsync_ReturnsValidUser()
        //{
        //    _mockUserService.Setup(service => service.GetByIdAsync(It.IsAny<int>()))
        //        .ReturnsAsync(_testUser);
        //    var result = await _mockUserService.Object.GetByIdAsync(1);
        //    Assert.Equal(_testUser, result);
        //}

        //[Fact]
        //public async Task GetAllAsync_ReturnsListOfUsers()
        //{
        //    _mockUserService.Setup(service => service.GetAllAsync())
        //        .ReturnsAsync(new List<User> { _testUser });
        //    var result = await _mockUserService.Object.GetAllAsync();
        //    Assert.Contains(_testUser, result);
        //}

        [Fact]
        public async Task Where_ReturnsListOfUsers()
        {
            _mockUserService.Setup(service => service.Where(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(new List<User> { _testUser });
            var result = await _mockUserService.Object.Where(u => u.FirstName == "Test");
            Assert.Contains(_testUser, result);
        }

        [Fact]
        public async Task SingleOrDefaultAsync_ReturnsValidUser()
        {
            _mockUserService.Setup(service => service.SingleOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(_testUser);
            var result = await _mockUserService.Object.SingleOrDefaultAsync(u => u.FirstName == "Test");
            Assert.Equal(_testUser, result);
        }

        [Fact]
        public async Task AddAsync_ReturnsValidUser()
        {
            _mockUserService.Setup(service => service.AddAsync(It.IsAny<User>()))
                .ReturnsAsync(_testUser);
            var result = await _mockUserService.Object.AddAsync(_testUser);
            Assert.Equal(_testUser, result);
        }

        [Fact]
        public void Remove_ReturnsVoid()
        {
            _mockUserService.Setup(service => service.Remove(It.IsAny<User>()));
            _mockUserService.Object.Remove(_testUser);
            _mockUserService.Verify(service => service.Remove(_testUser), Times.Once);
        }

        [Fact]
        public void RemoveRange_ReturnsVoid()
        {
            _mockUserService.Setup(service => service.RemoveRange(It.IsAny<IEnumerable<User>>()));
            _mockUserService.Object.RemoveRange(new List<User> { _testUser });
            _mockUserService.Verify(service => service.RemoveRange(new List<User> { _testUser }), Times.Once);
        }

        [Fact]
        public async Task Update_ReturnsValidUser()
        {
            _mockUserService.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<User>()))
                .ReturnsAsync(_testUser);
            var result = await _mockUserService.Object.Update(1, _testUser);
            Assert.Equal(_testUser, result);
        }

    }

}
