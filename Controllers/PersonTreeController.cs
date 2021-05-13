using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using ClientDependency.Core;
using umbraco;
using umbraco.BusinessLogic.Actions;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;
using UmbracoTutorials.Controllers;

namespace TestSection.Controllers
{
    [Tree("example", "personTree", "Person")]
    [PluginController("Example")]
    public class PersonTreeController : TreeController
    {
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            //if (id == Constants.System.Root.ToInVariantString())
            //{
                var ctrl = new PersonApiController();
                var nodes = new TreeNodeCollection();

                foreach (var person in ctrl.GetAll())
                {
                    var node = CreateTreeNode(person.Id.ToString(), "-1", queryStrings, person.ToString());
                    nodes.Add(node);
                }
            //}

            return nodes;
        }

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
           var menu = new MenuItemCollection();

           //if(id == Constants.System)
           menu.Items.Add<CreateChildEntity, ActionNew>(ui.Text(("actions"), ActionNew.Instance.Alias));
           return menu;
        }
    }
}