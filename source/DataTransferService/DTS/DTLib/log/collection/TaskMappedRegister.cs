﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson.Serialization;

using DTLib.mapped;
namespace DTLib.log.collection
{
    public class TaskMappedRegister : IMappedRegister
    {
        public void Register()
        {
            BsonClassMap.RegisterClassMap<Task>();
        }
    }
}
