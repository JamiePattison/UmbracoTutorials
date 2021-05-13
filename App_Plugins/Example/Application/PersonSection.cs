using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.businesslogic;
using umbraco.interfaces;

namespace UmbracoTutorials.App_Plugins.Example.Application
{
    [Application("example", "Example", "icon-people", 15)]
    public class PersonSection : IApplication
    {
    }
}