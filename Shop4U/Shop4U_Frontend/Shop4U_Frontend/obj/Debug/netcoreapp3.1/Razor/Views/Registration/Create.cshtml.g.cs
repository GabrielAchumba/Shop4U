#pragma checksum "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Registration\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0af878cd73caacb0622b9be2a772242e1774f846"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Registration_Create), @"mvc.1.0.view", @"/Views/Registration/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0af878cd73caacb0622b9be2a772242e1774f846", @"/Views/Registration/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ad118c81f8a039137b40b1d3d22e75b3f065b58", @"/Views/_ViewImports.cshtml")]
    public class Views_Registration_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Registration\Create.cshtml"
  
    Layout = "~/Views/Shared/_LoginLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Gabriel Achumba\Documents\Shop4USoft\Shop4U\Shop4U\Shop4U\Shop4U_Frontend\Shop4U_Frontend\Views\Registration\Create.cshtml"
  
    ViewBag.Title = "Shop4U | Registration Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""content"">

    <div class=""hold-transition register-page"">
        <div class=""register-box"">
            <div class=""register-logo"">
                <a href=""#""><b>Shop</b>4U</a>
            </div>

            <div class=""card"">
                <div class=""card-body register-card-body"">
                    <p class=""login-box-msg"">Register a new membership</p>

                    <form action=""/Registration/Create"" method=""post"">
                        <div class=""input-group mb-3"">
                            <input type=""text"" class=""form-control"" placeholder=""First name"" name=""FirstName"">
                            <div class=""input-group-append"">
                                <div class=""input-group-text"">
                                    <span class=""fas fa-user""></span>
                                </div>
                            </div>
                        </div>

                        <div class=""input-group mb-3"">
                         ");
            WriteLiteral(@"   <input type=""text"" class=""form-control"" placeholder=""Last name"" name=""LastName"">
                            <div class=""input-group-append"">
                                <div class=""input-group-text"">
                                    <span class=""fas fa-user""></span>
                                </div>
                            </div>
                        </div>

                        <div class=""input-group mb-3"">
                            <input type=""text"" class=""form-control"" placeholder=""Username"" name=""UserName"">
                            <div class=""input-group-append"">
                                <div class=""input-group-text"">
                                    <span class=""fas fa-user""></span>
                                </div>
                            </div>
                        </div>

                        <div class=""input-group mb-3"">
                            <input type=""text"" class=""form-control"" placeholder=""Phone number"" name=""Pho");
            WriteLiteral(@"neNumber"">
                            <div class=""input-group-append"">
                                <div class=""input-group-text"">
                                    <span class=""fas fa-user""></span>
                                </div>
                            </div>
                        </div>

                        <div class=""input-group mb-3"">
                            <input type=""password"" class=""form-control"" placeholder=""Password"" name=""Password"">
                            <div class=""input-group-append"">
                                <div class=""input-group-text"">
                                    <span class=""fas fa-lock""></span>
                                </div>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-8"">
                                <div class=""icheck-primary"">
                                    <input type=""checkbox"" id=""agreeTerms"" na");
            WriteLiteral(@"me=""terms"" value=""agree"">
                                    <label for=""agreeTerms"">
                                        I agree to the <a href=""#"">terms</a>
                                    </label>
                                </div>
                            </div>
                            <!-- /.col -->
                            <div class=""col-4"">
                                <button type=""submit"" class=""btn btn-primary btn-block"">Register</button>
                            </div>
                            <!-- /.col -->
                        </div>
                    </form>

                    <div class=""social-auth-links text-center"">
                        <p>- OR -</p>
                        <a href=""#"" class=""btn btn-block btn-primary"">
                            <i class=""fab fa-facebook mr-2""></i>
                            Sign up using Facebook
                        </a>
                        <a href=""#"" class=""btn btn-block btn-danger""");
            WriteLiteral(@">
                            <i class=""fab fa-google-plus mr-2""></i>
                            Sign up using Google+
                        </a>
                    </div>

                    <a href=""/Login/UserLogin"" class=""text-center"">I already have a membership</a>
                </div>
                <!-- /.form-box -->
            </div><!-- /.card -->
        </div>
        <!-- /.register-box -->
    </div>
    </section>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
