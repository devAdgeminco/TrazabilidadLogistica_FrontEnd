#pragma checksum "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\CodigoBarras\EscaneoProductos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2d6bca668749f05b7eede7f3441a4e3165f0638"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CodigoBarras_EscaneoProductos), @"mvc.1.0.view", @"/Views/CodigoBarras/EscaneoProductos.cshtml")]
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
#line 1 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2d6bca668749f05b7eede7f3441a4e3165f0638", @"/Views/CodigoBarras/EscaneoProductos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_CodigoBarras_EscaneoProductos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\CodigoBarras\EscaneoProductos.cshtml"
  
    ViewData["Title"] = "CodigoBarras";
    ViewData["Modulo"] = "EscaneoProductos";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>EscaneoProductos</h1>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 206, "\"", 264, 1);
#nullable restore
#line 12 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\CodigoBarras\EscaneoProductos.cshtml"
WriteAttributeValue("", 212, Url.Content("~/Scripts/Portal/EscaneoProductos.js"), 212, 52, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n");
            }
            );
            WriteLiteral("}");
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
