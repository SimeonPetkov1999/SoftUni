﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP.Contracts
{
    public interface IHttpServer
    {

        Task StartAsync(int port);
    }
}
