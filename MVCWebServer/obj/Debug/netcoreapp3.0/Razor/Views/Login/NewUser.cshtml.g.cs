#pragma checksum "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\NewUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64843f38cbe11489dc03f761cceb39e47fac9d99"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_NewUser), @"mvc.1.0.view", @"/Views/Login/NewUser.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64843f38cbe11489dc03f761cceb39e47fac9d99", @"/Views/Login/NewUser.cshtml")]
    public class Views_Login_NewUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MVCWebServer.Models.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\NewUser.cshtml"
  
    ViewData["Title"] = "NewUser";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>NewUser</h1>\r\n\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 10 "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\NewUser.cshtml"
 using (Html.BeginForm("CheckLogin", "Login", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\NewUser.cshtml"
Write(Html.TextBoxFor(model => model.username));

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\NewUser.cshtml"
Write(Html.ValidationMessageFor(model => model.username));

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"form-group\">\r\n    ");
#nullable restore
#line 15 "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\NewUser.cshtml"
Write(Html.LabelFor(m => m.Password, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 17 "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\NewUser.cshtml"
   Write(Html.PasswordFor(m => m.Password, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 20 "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\NewUser.cshtml"
Write(Html.ValidationMessageFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button type=\"submit\">Enter</button>\r\n");
#nullable restore
#line 22 "C:\Users\myhog\source\repos\MVCWebServer\MVCWebServer\Views\Login\NewUser.cshtml"
}

#line default
#line hidden
#nullable disable
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
