#pragma checksum "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\CheckLogin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "241aea5e43200956fc417e0babfd702df3183be3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_CheckLogin), @"mvc.1.0.view", @"/Views/Login/CheckLogin.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"241aea5e43200956fc417e0babfd702df3183be3", @"/Views/Login/CheckLogin.cshtml")]
    public class Views_Login_CheckLogin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MVCWebServer.Models.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\CheckLogin.cshtml"
  
    ViewData["Title"] = "Checking Login";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\CheckLogin.cshtml"
  
    if (Model.auth)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\CheckLogin.cshtml"
   Write(Html.Label(Model.username + " welcome back!"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\CheckLogin.cshtml"
                                                      ;
    }
    else
    {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\CheckLogin.cshtml"
       Write(Html.Label("WHY ARE YOU HERE???"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\CheckLogin.cshtml"
                                              ;
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MVCWebServer.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
