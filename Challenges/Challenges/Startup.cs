﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Challenges.Startup))]

namespace Challenges
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
