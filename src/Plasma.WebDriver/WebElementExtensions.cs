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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using OpenQA.Selenium;

namespace Plasma.WebDriver
{

    public static class WebElementExtensions
    {
        public static string InnerHtml(this IWebElement webElement)
        {
            return ((HtmlElement) webElement).InnerHtml;
        }

        public static ReadOnlyCollection<IWebElement> AsReadonlyCollection(this IEnumerable<XElement> xmlElements)
        {
            return new ReadOnlyCollection<IWebElement>(xmlElements.Select(x => new HtmlElement(x)).Cast<IWebElement>().ToList());
        }
    }
}