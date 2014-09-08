﻿using IFramework.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.DTO;

namespace Sample.Command
{
    public class LoginCommand : CommandBase, ICommand<Account>, ILinearCommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Account Result { get; set; }
        public RegisterCommand[] Tags { get; set; }
    }
}