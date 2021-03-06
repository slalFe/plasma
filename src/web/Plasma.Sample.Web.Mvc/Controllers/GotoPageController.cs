﻿/* **********************************************************************************
 *
 * Copyright 2010 ThoughtWorks, Inc.  
 * ThoughtWorks provides the software "as is" without warranty of any kind, either express or implied, including but not limited to, 
 * the implied warranties of merchantability, satisfactory quality, non-infringement and fitness for a particular purpose.
 *
 * This source code is subject to terms and conditions of the Microsoft Permissive
 * License (MS-PL).  
 *
 * You must not remove this notice, or any other, from this software.
 *
 * **********************************************************************************/
using System.Web.Mvc;
using System.Web.Routing;

namespace Plasma.Sample.Web.Mvc.Controllers
{
    public class GotoPageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OtherPage()
        {
            return View();
        }

        public ActionResult ThreeOhOne()
        {
            return new ThreeOhOneRedirectResult("Default", new RouteValueDictionary {{"Controller", "GotoPage"}, {"Action", "Index"}});
        }

        public ActionResult ThreeOhTwo()
        {
            return RedirectToAction("Index");
        }
    }

    public class ThreeOhOneRedirectResult : RedirectToRouteResult
    {
        public ThreeOhOneRedirectResult(RouteValueDictionary routeValues) : base(routeValues)
        {
        }

        public ThreeOhOneRedirectResult(string routeName, RouteValueDictionary routeValues) : base(routeName, routeValues)
        {
        }

        public override void ExecuteResult(ControllerContext context)
        {
            base.ExecuteResult(context);
            context.HttpContext.Response.StatusCode = 301;
        }
    }
}
