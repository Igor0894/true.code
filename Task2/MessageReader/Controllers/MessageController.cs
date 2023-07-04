using Microsoft.AspNetCore.Mvc;
using ApplicationServices;
using Core.Entities;

namespace Web.Controllers
{
    [ApiController]
    [Route("")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("LastPostsByUser")]
        public async Task<UserPost[]> GetLastPostsByUser(int count, Guid userGuid)
        {
            var lastPostsByUser = await _messageService.GetLastPostsByUser(count, userGuid);
            return lastPostsByUser;
        }
        
        [HttpGet("LastPosts")]
        public async Task<UserPost[]> GetLastPosts(int count)
        {
            var lastPosts = await _messageService.GetLastPosts(count);
            return lastPosts;
        }
    }
}
