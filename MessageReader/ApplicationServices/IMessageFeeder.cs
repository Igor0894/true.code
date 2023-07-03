using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace ApplicationServices
{
    public interface IMessageFeeder
    {
        public Task<User[]> GetPosts();
    }
}
