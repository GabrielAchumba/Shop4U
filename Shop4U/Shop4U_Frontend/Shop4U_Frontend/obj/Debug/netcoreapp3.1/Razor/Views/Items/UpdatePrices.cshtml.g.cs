#pragma checksum "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f32dd3b366c519b71e176d3d0744c3ad547c8c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Items_UpdatePrices), @"mvc.1.0.view", @"/Views/Items/UpdatePrices.cshtml")]
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
#line 1 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\_ViewImports.cshtml"
using Shop4U_Frontend.ViewModels.Supermarkets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\_ViewImports.cshtml"
using Shop4U_Frontend.ViewModels.PoultryFarms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\_ViewImports.cshtml"
using Shop4U_Frontend.ViewModels.Pharmacies;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\_ViewImports.cshtml"
using Shop4U_Frontend.ViewModels.LocalMarkets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\_ViewImports.cshtml"
using Shop4U_Frontend.ViewModels.CookingGas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\_ViewImports.cshtml"
using Shop4U_Frontend.ViewModels.FrozenFeeds;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\_ViewImports.cshtml"
using Shop4U_Frontend.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f32dd3b366c519b71e176d3d0744c3ad547c8c4", @"/Views/Items/UpdatePrices.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ad118c81f8a039137b40b1d3d22e75b3f065b58", @"/Views/_ViewImports.cshtml")]
    public class Views_Items_UpdatePrices : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UpdatePricesVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
  
    Layout = "~/Views/Shared/_SuperAdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<!-- Content Header (Page header) -->
<section class=""content-header"">
    <div class=""container-fluid"">
        <!-- /.col -->
        <div class=""col-md-12"">
            <div class=""card card-success"">
                <div class=""card-header"">
                    <h3 class=""card-title"">");
#nullable restore
#line 15 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
                                      Write(Model.ItemName.ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                    <!-- /.card-tools -->\r\n                </div>\r\n                <!-- /.card-header -->\r\n                <div class=\"card-body\">\r\n                    <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 614, "\"", 639, 1);
#nullable restore
#line 20 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
WriteAttributeValue("", 620, Model.Base64String, 620, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 640, "\"", 661, 1);
#nullable restore
#line 20 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
WriteAttributeValue("", 646, Model.ItemName, 646, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                         style=\"width:200px;height:200px; \" />\r\n                    <div class=\"form-group\">\r\n                        <input type=\"text\" class=\"form-control\" id=\"ItemPriceId\"");
            BeginWriteAttribute("value", "\r\n                               value=\"", 854, "\"", 907, 1);
#nullable restore
#line 24 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
WriteAttributeValue("", 894, Model.ItemId, 894, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""ItemPriceId"" hidden>
                    </div>
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>
        <!-- /.col -->
    </div><!-- /.container-fluid -->
</section>

<section class=""content"">
    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-header"">
                    <h3 class=""card-title"">Price Lists for ");
#nullable restore
#line 40 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
                                                      Write(Model.MarketName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                </div>
                <!-- /.card-header -->
                <div class=""card-body"">
                    <table id=""example1"" class=""table table-bordered table-striped"">
                        <thead>
                            <tr>
                                <th>S/N</th>
                                <th>Market Name</th>
                                <th>Price (NGN)</th>
                                <th>Update</th>
                                <th>Delete</th>
                            </tr>
                        </thead>
                        <tbody>

");
#nullable restore
#line 56 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
                             for (int i = 1; i <= Model.ItemPriceList.Count; i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td scope=\"row\">");
#nullable restore
#line 59 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
                                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 60 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
                               Write(Model.ItemPriceList[i - 1].MarketName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 61 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
                               Write(Model.ItemPriceList[i - 1].CostPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 2462, "\"", 2597, 8);
            WriteAttributeValue("", 2469, "/Items/UpdatePrice/", 2469, 19, true);
#nullable restore
#line 63 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
WriteAttributeValue("", 2488, Model.ItemPriceList[i - 1].Id, 2488, 30, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2518, "?Others=", 2518, 8, true);
#nullable restore
#line 63 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
WriteAttributeValue("", 2526, Model.ItemPriceList[i - 1].MarketName, 2526, 38, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2564, "?", 2564, 1, true);
#nullable restore
#line 63 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
WriteAttributeValue("", 2565, Model.MarketGroup, 2565, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2583, "?", 2583, 1, true);
#nullable restore
#line 63 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
WriteAttributeValue("", 2584, Model.ItemId, 2584, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info\">Update Price</a>\r\n                                </td>\r\n                                <td>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 2753, "\"", 2892, 8);
            WriteAttributeValue("", 2760, "/Items/DeleteItemPrice/", 2760, 23, true);
#nullable restore
#line 66 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
WriteAttributeValue("", 2783, Model.ItemPriceList[i - 1].Id, 2783, 30, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2813, "?Others=", 2813, 8, true);
#nullable restore
#line 66 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
WriteAttributeValue("", 2821, Model.ItemPriceList[i - 1].MarketName, 2821, 38, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2859, "?", 2859, 1, true);
#nullable restore
#line 66 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
WriteAttributeValue("", 2860, Model.MarketGroup, 2860, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2878, "?", 2878, 1, true);
#nullable restore
#line 66 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
WriteAttributeValue("", 2879, Model.ItemId, 2879, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info\">Delete Price</a>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 69 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Items\UpdatePrices.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n");
            WriteLiteral("                    </table>\r\n                </div>\r\n                <!-- /.card-body -->\r\n            </div>\r\n        </div>\r\n        <!-- /.col -->\r\n    </div>\r\n    <!-- /.row -->\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UpdatePricesVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
