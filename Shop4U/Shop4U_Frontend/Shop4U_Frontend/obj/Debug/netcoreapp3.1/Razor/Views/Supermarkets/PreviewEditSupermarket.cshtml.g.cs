#pragma checksum "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\PreviewEditSupermarket.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "579433cdfab538737f601f7ed0c07f849e51fc41"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Supermarkets_PreviewEditSupermarket), @"mvc.1.0.view", @"/Views/Supermarkets/PreviewEditSupermarket.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"579433cdfab538737f601f7ed0c07f849e51fc41", @"/Views/Supermarkets/PreviewEditSupermarket.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39d6459cec3f45c01096d7489d7673bcad949188", @"/Views/_ViewImports.cshtml")]
    public class Views_Supermarkets_PreviewEditSupermarket : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CreateSupermarketVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\PreviewEditSupermarket.cshtml"
  
    Layout = "~/Views/Shared/_SuperAdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\PreviewEditSupermarket.cshtml"
  
    ViewBag.Title = Model.PageTitle;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card-header\">\r\n    <h3 class=\"card-title\">");
#nullable restore
#line 13 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\PreviewEditSupermarket.cshtml"
                      Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n</div>\r\n\r\n<div class=\"card-body\">\r\n    <form method=\"get\" action=\"/Supermarkets/ListofSupermarketsAdmin\">\r\n\r\n        <img");
            BeginWriteAttribute("alt", " alt=\"", 338, "\"", 344, 0);
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 345, "\"", 370, 1);
#nullable restore
#line 19 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\PreviewEditSupermarket.cshtml"
WriteAttributeValue("", 351, Model.Base64String, 351, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n\r\n        <div class=\"form-group\">\r\n            <input class=\"form-control\" placeholder=\"Heading\" name=\"Heading\"");
            BeginWriteAttribute("value", " value=\"", 490, "\"", 512, 1);
#nullable restore
#line 23 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\PreviewEditSupermarket.cshtml"
WriteAttributeValue("", 498, Model.Heading, 498, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <textarea id=\"compose-textarea\" class=\"form-control\" style=\"height: 300px\" name=\"Description\">\r\n                 ");
#nullable restore
#line 28 "C:\Users\Gabriel Achumba\Documents\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Supermarkets\PreviewEditSupermarket.cshtml"
            Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</textarea>
        </div>


        <div class=""card-footer"">
            <div class=""float-right"">
                <button type=""submit"" class=""btn btn-primary""><i class=""far fa-envelope""></i> Done</button>
            </div>
        </div>



    </form>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CreateSupermarketVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
