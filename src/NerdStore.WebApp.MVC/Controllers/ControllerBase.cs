﻿using Microsoft.AspNetCore.Mvc;
using System;

namespace NerdStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        public Guid ClienteId => Guid.Parse("7030F1D4-A952-4B27-B323-7277615621FB");
    }
}
