using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
        Guid Guid { get; set; }
        string Name { get; set; }
        List<UserPost> Posts { get; set; }
        public User(Guid guid, string name, List<UserPost> posts)
        {
            this.Guid = guid;
            this.Name = name;
            this.Posts = posts;
        }
    }
}
