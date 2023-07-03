using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace ApplicationServices
{
    internal interface IMessageService
    {
        Task<User[]> GetPosts();
    }
}
