using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace ApplicationServices
{
    public interface IMessageService
    {
        Task<UserPost[]> GetLastPostsByUser(int count, Guid userGuid);
        Task<UserPost[]> GetLastPosts(int count);
    }
}
