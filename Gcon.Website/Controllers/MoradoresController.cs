﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcon.Website.Controllers
{
    [FiltroAcesso(Tipo = "ADM")]
    public class MoradoresController : Controller
    {
        // GET: Moradores
        public ActionResult Index()
        {
            return View();
        }
    }
}