using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserPost
    {
        Guid Guid { get; set; }
        Guid UserGuid { get; set; }
        DateTime PublishTime { get; set; }
        string Message { get; set; }
        public UserPost(Guid guid, Guid userGuid, DateTime publishTime, string message)
        {
            Guid = guid;
            UserGuid = userGuid;
            PublishTime = publishTime;
            Message = message;
        }
    }
}
