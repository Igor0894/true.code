using Core.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Tests
{
    internal class MessageServiceTests
    {
        [Test]
        public async ShouldGetLastPostsByUser()
        {
            var messageFeeder = new Mock<IMessageFeeder>();
            messageFeeder.Setup(f => f.GetPosts()).Returns(Task.FromResult(new User[]
            {
                new User
                {
                    Guid = Guid.NewGuid(),
                    Name = "User1",
                    Posts= new List<UserPost> 
                    {
                        new UserPost
                        {
                            Guid = Guid.NewGuid(),
                            UserGuid = 
                        }
                    }
                }
            }));
        }
    }
}
