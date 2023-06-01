﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EventBusBase
{
    public class SubscriptionInfo
    {

        public Type HandlerType { get; }

        public SubscriptionInfo(Type handlerType)
        {
            HandlerType = handlerType ?? throw new ArgumentNullException(nameof(handlerType));
        }

        public static SubscriptionInfo Typed(Type handlerType)
        {
            return new SubscriptionInfo(handlerType);
        }
    }
}
