#pragma checksum "D:\.NET\fake_news_detection\project-main\WebAPI\Pages\Errors\AccessDenied.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e5200c7b830babed20b98ae8baa55cfd3f37fef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebAPI.Pages.Errors.Pages_Errors_AccessDenied), @"mvc.1.0.razor-page", @"/Pages/Errors/AccessDenied.cshtml")]
namespace WebAPI.Pages.Errors
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
#line 1 "D:\.NET\fake_news_detection\project-main\WebAPI\Pages\_ViewImports.cshtml"
using WebAPI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e5200c7b830babed20b98ae8baa55cfd3f37fef", @"/Pages/Errors/AccessDenied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbf1c2137f7f7b158b8786da62817592da36f63f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Errors_AccessDenied : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div>\n    <h1>Access Denied</h1>\n    You don\'t have access to the page you are looking for.\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebAPI.Pages.Account.AccessDeniedModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebAPI.Pages.Account.AccessDeniedModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebAPI.Pages.Account.AccessDeniedModel>)PageContext?.ViewData;
        public WebAPI.Pages.Account.AccessDeniedModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591