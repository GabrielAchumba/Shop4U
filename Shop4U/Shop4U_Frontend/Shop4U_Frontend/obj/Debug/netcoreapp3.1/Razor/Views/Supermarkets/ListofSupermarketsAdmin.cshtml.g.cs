#pragma checksum "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\ListofSupermarketsAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f73eda5db6990de07186e635fc7274e4ec21430e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Supermarkets_ListofSupermarketsAdmin), @"mvc.1.0.view", @"/Views/Supermarkets/ListofSupermarketsAdmin.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\_ViewImports.cshtml"
using Shop4U_Frontend.ViewModels.Supermarkets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\_ViewImports.cshtml"
using Shop4U_Frontend.ViewModels.PoultryFarms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\_ViewImports.cshtml"
using Shop4U_Frontend.ViewModels.Pharmacies;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\_ViewImports.cshtml"
using Shop4U_Frontend.ViewModels.FastFoods;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\_ViewImports.cshtml"
using Shop4U_Frontend.ViewModels.LocalMarkets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\_ViewImports.cshtml"
using Shop4U_Frontend.ViewModels.CookingGas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\_ViewImports.cshtml"
using Shop4U_Frontend.ViewModels.FrozenFeeds;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\_ViewImports.cshtml"
using Shop4U_Frontend.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f73eda5db6990de07186e635fc7274e4ec21430e", @"/Views/Supermarkets/ListofSupermarketsAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39d6459cec3f45c01096d7489d7673bcad949188", @"/Views/_ViewImports.cshtml")]
    public class Views_Supermarkets_ListofSupermarketsAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ListofSupermarketsAdminVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\ListofSupermarketsAdmin.cshtml"
  
    Layout = "~/Views/Shared/_SuperAdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\ListofSupermarketsAdmin.cshtml"
  
    ViewBag.Title = Model.PageTitle;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<nav class=""navbar navbar-dark bg-dark"">
    <form class=""form-inline"">
        <input class=""form-control mr-sm-2"" type=""search"" placeholder=""Search"" aria-label=""Search"">
        <button class=""btn btn-outline-success my-2 my-sm-0"" type=""submit"">Search</button>
    </form>
    <form method=""get"" action=""/Supermarkets/CreateSupermarket"" class=""form-inline"">
        <button class=""btn btn-outline-success my-2 my-sm-0"" type=""submit"">Create Supermarket</button>
    </form>
</nav>

<h3 class=""text-center text-info"">SUPERMARKETS</h3>
<table class=""table table-dark"">

    <thead>
        <tr>
            <th scope=""col"">SN</th>
            <th scope=""col"">Name</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 32 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\ListofSupermarketsAdmin.cshtml"
         for (int i = 1; i <= Model.Supermarkets.Count; i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
#nullable restore
#line 35 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\ListofSupermarketsAdmin.cshtml"
                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td>");
#nullable restore
#line 36 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\ListofSupermarketsAdmin.cshtml"
               Write(Model.Supermarkets[i - 1].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1112, "\"", 1180, 2);
            WriteAttributeValue("", 1119, "/Supermarkets/DeleteSupermarket/", 1119, 32, true);
#nullable restore
#line 38 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\ListofSupermarketsAdmin.cshtml"
WriteAttributeValue("", 1151, Model.Supermarkets[i - 1].Id, 1151, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info\">Delete</a>\r\n                </td>\r\n                <td>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1282, "\"", 1348, 2);
            WriteAttributeValue("", 1289, "/Supermarkets/EditSupermarket/", 1289, 30, true);
#nullable restore
#line 41 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\ListofSupermarketsAdmin.cshtml"
WriteAttributeValue("", 1319, Model.Supermarkets[i - 1].Id, 1319, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info\">Modify</a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 44 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\ListofSupermarketsAdmin.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ListofSupermarketsAdminVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
