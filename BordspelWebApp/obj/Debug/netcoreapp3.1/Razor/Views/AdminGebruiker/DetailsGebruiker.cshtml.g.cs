#pragma checksum "C:\Data\School\Programmeren - TM Lier\22 Webapplicaties (ZX1606)\00 - Project\BordspelWebApp\BordspelWebApp\Views\AdminGebruiker\DetailsGebruiker.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2c564c3658433bcef7ebce68ffe1c671c349014"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminGebruiker_DetailsGebruiker), @"mvc.1.0.view", @"/Views/AdminGebruiker/DetailsGebruiker.cshtml")]
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
#line 1 "C:\Data\School\Programmeren - TM Lier\22 Webapplicaties (ZX1606)\00 - Project\BordspelWebApp\BordspelWebApp\Views\_ViewImports.cshtml"
using BordspelWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Data\School\Programmeren - TM Lier\22 Webapplicaties (ZX1606)\00 - Project\BordspelWebApp\BordspelWebApp\Views\_ViewImports.cshtml"
using BordspelWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2c564c3658433bcef7ebce68ffe1c671c349014", @"/Views/AdminGebruiker/DetailsGebruiker.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88b16009469a83569a2653fb2f7bf67956ce6a03", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_AdminGebruiker_DetailsGebruiker : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BordspelWebApp.ViewModels.Details.DetailsGebruikerViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Data\School\Programmeren - TM Lier\22 Webapplicaties (ZX1606)\00 - Project\BordspelWebApp\BordspelWebApp\Views\AdminGebruiker\DetailsGebruiker.cshtml"
  
    ViewData["Title"] = "Details gebruiker";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col\">\r\n            <h3 class=\"display-4\">");
#nullable restore
#line 10 "C:\Data\School\Programmeren - TM Lier\22 Webapplicaties (ZX1606)\00 - Project\BordspelWebApp\BordspelWebApp\Views\AdminGebruiker\DetailsGebruiker.cshtml"
                             Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col m-1\">\r\n            <ul class=\"list-group\">\r\n                <li class=\"list-group-item bodyBG\"><b>Id:</b> ");
#nullable restore
#line 16 "C:\Data\School\Programmeren - TM Lier\22 Webapplicaties (ZX1606)\00 - Project\BordspelWebApp\BordspelWebApp\Views\AdminGebruiker\DetailsGebruiker.cshtml"
                                                         Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item bodyBG\"><b>Username:</b> ");
#nullable restore
#line 17 "C:\Data\School\Programmeren - TM Lier\22 Webapplicaties (ZX1606)\00 - Project\BordspelWebApp\BordspelWebApp\Views\AdminGebruiker\DetailsGebruiker.cshtml"
                                                               Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item bodyBG\"><b>Naam: </b>");
#nullable restore
#line 18 "C:\Data\School\Programmeren - TM Lier\22 Webapplicaties (ZX1606)\00 - Project\BordspelWebApp\BordspelWebApp\Views\AdminGebruiker\DetailsGebruiker.cshtml"
                                                           Write(Model.Naam);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 18 "C:\Data\School\Programmeren - TM Lier\22 Webapplicaties (ZX1606)\00 - Project\BordspelWebApp\BordspelWebApp\Views\AdminGebruiker\DetailsGebruiker.cshtml"
                                                                       Write(Model.Voornaam);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n    <button class=\"btn btn-outline-info\" type=\"submit\"");
            BeginWriteAttribute("onclick", " onclick=\"", 745, "\"", 813, 3);
            WriteAttributeValue("", 755, "location.href=\'", 755, 15, true);
#nullable restore
#line 22 "C:\Data\School\Programmeren - TM Lier\22 Webapplicaties (ZX1606)\00 - Project\BordspelWebApp\BordspelWebApp\Views\AdminGebruiker\DetailsGebruiker.cshtml"
WriteAttributeValue("", 770, Url.Action("Gebruikers","AdminGebruiker"), 770, 42, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 812, "\'", 812, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Terug</button>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BordspelWebApp.ViewModels.Details.DetailsGebruikerViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
