using Core.Entities;
using FluentAssertions;
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
        private Mock<IMessageFeeder> _messageFeederMock;
        private Guid _user1Guid = Guid.NewGuid();
        private DateTime _latestTime = DateTime.Now.AddHours(-1);
        [OneTimeSetUp]
        public void OnewTimeSetup()
        {
            _messageFeederMock = new Mock<IMessageFeeder>();
            var user1 = new User(_user1Guid, "user1");
            var user2 = new User(new Guid(), "user2");
            var user3 = new User(new Guid(), "user3");
            var user4 = new User(new Guid(), "user4");
            var user5 = new User(new Guid(), "user5");
            user1.Posts.Add(new UserPost(new Guid(), user1.Guid, _latestTime, "Latest post by user1"));
            user1.Posts.Add(new UserPost(new Guid(), user1.Guid, _latestTime.AddHours(-2), "Second post by user1"));
            user1.Posts.Add(new UserPost(new Guid(), user1.Guid, _latestTime.AddHours(-3), "Third post by user1"));
            user1.Posts.Add(new UserPost(new Guid(), user1.Guid, _latestTime.AddHours(-4), "Fourth post by user1"));
            user1.Posts.Add(new UserPost(new Guid(), user1.Guid, _latestTime.AddHours(-5), "Fifth post by user1"));
            user2.Posts.Add(new UserPost(new Guid(), user2.Guid, _latestTime, "Latest post by user2"));
            user2.Posts.Add(new UserPost(new Guid(), user2.Guid, _latestTime.AddHours(-2), "Second post by user2"));
            user3.Posts.Add(new UserPost(new Guid(), user3.Guid, _latestTime, "Latest post by user3"));
            user3.Posts.Add(new UserPost(new Guid(), user3.Guid, _latestTime.AddHours(-2), "Second post by user3"));
            user4.Posts.Add(new UserPost(new Guid(), user4.Guid, _latestTime, "Latest post by user4"));
            user4.Posts.Add(new UserPost(new Guid(), user4.Guid, _latestTime.AddHours(-2), "Second post by user4"));
            user5.Posts.Add(new UserPost(new Guid(), user5.Guid, _latestTime, "Latest post by user5"));
            user5.Posts.Add(new UserPost(new Guid(), user5.Guid, _latestTime.AddHours(-2), "Second post by user5"));
            _messageFeederMock.Setup(f => f.GetPosts()).Returns(Task.FromResult(new User[] { user1, user2, user3, user4, user5 }));
        }
        [Test]
        public async Task ShouldGetLastPostsByUser()
        {
            IMessageFeeder messageFeeder = _messageFeederMock.Object;
            var messageService = new MessageService(messageFeeder);
            var postsResult = await messageService.GetLastPostsByUser(3, _user1Guid);
            postsResult.Should().HaveCount(3);
            postsResult[0].UserGuid.Should().Be(_user1Guid);
            postsResult[1].UserGuid.Should().Be(_user1Guid);
            postsResult[2].UserGuid.Should().Be(_user1Guid);
            postsResult[0].PublishTime.Should().Be(_latestTime);
            postsResult[1].PublishTime.Should().Be(_latestTime.AddHours(-2));
            postsResult[2].PublishTime.Should().Be(_latestTime.AddHours(-3));
        }
        [Test]
        public async Task ShouldGetLastPostsByUser()
        {
            IMessageFeeder messageFeeder = _messageFeederMock.Object;
            var messageService = new MessageService(messageFeeder);
            var postsResult = await messageService.GetLastPostsByUser(3, _user1Guid);
            postsResult.Should().HaveCount(3);
            postsResult[0].UserGuid.Should().Be(_user1Guid);
            postsResult[1].UserGuid.Should().Be(_user1Guid);
            postsResult[2].UserGuid.Should().Be(_user1Guid);
            postsResult[0].PublishTime.Should().Be(_latestTime);
            postsResult[1].PublishTime.Should().Be(_latestTime.AddHours(-2));
            postsResult[2].PublishTime.Should().Be(_latestTime.AddHours(-3));
        }
    }
}
