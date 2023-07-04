using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserPost
    {
        public Guid Guid { get; set; }
        public User User { get; set; }
        public DateTime PublishTime { get; set; }
        public string Message { get; set; }
        public UserPost(Guid guid, User user, DateTime publishTime, string message)
        {
            Guid = guid;
            User = user;
            PublishTime = publishTime;
            Message = message;
        }
    }
}
