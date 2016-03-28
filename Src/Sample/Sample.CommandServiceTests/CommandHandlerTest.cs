﻿using IFramework.Command;
using IFramework.Infrastructure;
using IFramework.Infrastructure.Unity.LifetimeManagers;
using IFramework.Message;

namespace Sample.CommandServiceTests
{
    public class CommandHandlerProxy<TCommandHanlder>
    {
        public object ExecuteCommand(ICommand command)
        {
            IMessageContext commandContext = new EmptyMessageContext(command);
            PerMessageContextLifetimeManager.CurrentMessageContext = commandContext;
            var commandHandler = IoCFactory.Resolve<TCommandHanlder>();
            ((dynamic)commandHandler).Handle((dynamic)command);
            var result = commandContext.Reply;
            PerMessageContextLifetimeManager.CurrentMessageContext = null;
            return result;
        }

        public object ExecuteCommand(IMessageContext commandContext)
        {
            PerMessageContextLifetimeManager.CurrentMessageContext = commandContext;
            var commandHandler = IoCFactory.Resolve<TCommandHanlder>();
            ((dynamic)commandHandler).Handle((dynamic)commandContext.Message);
            var result = commandContext.Reply;
            PerMessageContextLifetimeManager.CurrentMessageContext = null;
            return result;
        }
    }
}