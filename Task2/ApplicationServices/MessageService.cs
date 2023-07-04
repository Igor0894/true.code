using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices
{
    public class MessageService : IMessageService
    {
        private readonly IMessageFeeder _messageFeeder;
        public MessageService(IMessageFeeder messageFeeder)
        {
            _messageFeeder = messageFeeder;
        }
        public async Task<UserPost[]> GetLastPostsByUser(int count, Guid userGuid)
        {
            var allPosts = await _messageFeeder.GetPosts();
            if (!allPosts.Any(u => u.Guid== userGuid) && allPosts.Where(u => u.Guid == userGuid).FirstOrDefault()?.Posts != null) { throw new Exception($"There is no any post by user {userGuid}"); }
            var postsByUser = allPosts.Where(u => u.Guid == userGuid).First().Posts;
            var lastPostsByCount = postsByUser.OrderByDescending(p => p.PublishTime).Take(count);
            return lastPostsByCount.ToArray();
        }
        public async Task<UserPost[]> GetLastPosts(int count)
        {
            var allPosts = await _messageFeeder.GetPosts();
            var topPostsAllUsers = allPosts.Where(u => u.Posts != null)
                .SelectMany(u => u.Posts)
                .OrderByDescending(p => p.PublishTime).Take(1);

            var topPostsAllUsersByCount = topPostsAllUsers.OrderByDescending(p => p.PublishTime).Take(count);
            return topPostsAllUsersByCount.ToArray();
        }
    }
}
