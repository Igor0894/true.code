using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public List<UserPost> Posts { get; set; }
        public User(Guid guid, string name)
        {
            Guid = guid;
            Name = name;
            Posts = new List<UserPost>();
        }
    }
}
