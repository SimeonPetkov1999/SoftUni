﻿using Microsoft.EntityFrameworkCore;
using SUS.HTTP;
using SUS.HTTP.Enums;
using SUS.MvcFramework;
using SUSApp.Controllers;
using SUSApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUSApp
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {
        }

        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }
    }
}
