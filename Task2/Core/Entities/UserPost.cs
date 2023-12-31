﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserPost
    {
        public Guid Guid { get; set; }
        public Guid UserGuid { get; set; }
        public DateTime PublishTime { get; set; }
        public string Message { get; set; }
        public UserPost(Guid guid, Guid userGuid, DateTime publishTime, string message)
        {
            Guid = guid;
            UserGuid = userGuid;
            PublishTime = publishTime;
            Message = message;
        }
    }
}
