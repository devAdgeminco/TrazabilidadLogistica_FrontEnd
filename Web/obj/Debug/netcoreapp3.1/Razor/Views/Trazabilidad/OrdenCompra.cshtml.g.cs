#pragma checksum "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\OrdenCompra.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a28fc94331735047e950c2cdfdf754657c9d5d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Trazabilidad_OrdenCompra), @"mvc.1.0.view", @"/Views/Trazabilidad/OrdenCompra.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a28fc94331735047e950c2cdfdf754657c9d5d2", @"/Views/Trazabilidad/OrdenCompra.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Trazabilidad_OrdenCompra : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\OrdenCompra.cshtml"
  
    ViewData["Title"] = "Trazabilidad";
    ViewData["Modulo"] = "OrdenCompra";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script>\r\n    var url_getOrdenCompra = \"");
#nullable restore
#line 9 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\OrdenCompra.cshtml"
                         Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" + \"Trazabilidad/getOrdenCompra\";\r\n    var url_getOrdenCompraDetalle = \"");
#nullable restore
#line 10 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\OrdenCompra.cshtml"
                                Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" + ""Trazabilidad/getOrdenCompraDetalle"";
</script>

<table id=""tOC"" class=""table table-striped"" style=""width:100%""></table>

<div class=""modal fade"" id=""mDetalle"" data-bs-backdrop=""static"" data-bs-keyboard=""false"" tabindex=""-1"" aria-labelledby=""staticBackdropLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered modal-xl"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""staticBackdropLabel"">Detalle de Orden de Compra</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <table id=""tOCDetalle"" class=""table table-striped"" style=""width:100%""></table>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-bs-dismiss=""modal"">Cerrar</button>
");
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 1428, "\"", 1481, 1);
#nullable restore
#line 36 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\OrdenCompra.cshtml"
WriteAttributeValue("", 1434, Url.Content("~/Scripts/Portal/OrdenCompra.js"), 1434, 47, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n");
            }
            );
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
