#pragma checksum "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df451e2c512377a914decf8799723223c2e03795"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Trazabilidad_Index), @"mvc.1.0.view", @"/Views/Trazabilidad/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df451e2c512377a914decf8799723223c2e03795", @"/Views/Trazabilidad/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Trazabilidad_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\Index.cshtml"
  
    ViewBag.Title = "Trazabilidad";
    ViewBag.Modulo = "Requerimientos";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<script>\r\n    var url_getRequerimientos = \"");
#nullable restore
#line 7 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\Index.cshtml"
                            Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" + \"Trazabilidad/getRequerimientos\";\r\n    var url_getRequerimientoDetalle = \"");
#nullable restore
#line 8 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\Index.cshtml"
                                  Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" + ""Trazabilidad/getRequerimientoDetalle"";
</script>
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-2"">
            <div class=""mb-3"">
                <label for=""fecIni"" class=""form-label"">Fecha Inicial</label>
                <input type=""date"" class=""form-control"" id=""fecIni"" autocomplete=""off"" />
            </div>
        </div>
        <div class=""col-2"">
            <div class=""mb-3"">
                <label for=""fecFin"" class=""form-label"">Fecha Final</label>
                <input type=""date"" class=""form-control"" id=""fecFin"" autocomplete=""off"" />
            </div>
        </div>
        <div class=""col-1"">
            <div class=""mb-3"">
                <label for=""btnBuscar"" class=""form-label"">&nbsp;</label>
                <button id=""btnBuscar"" type=""button"" class=""form-control btn btn-primary"">
                    <i class=""ion ion-md-search""></i>
                </button>
            </div>

        </div>
    </div>
</div>
<hr />
<table id");
            WriteLiteral(@"=""tRequerimientos"" class=""table table-striped"" style=""width:100%""></table>





<div class=""modal fade"" id=""mDetalle"" data-bs-backdrop=""static"" data-bs-keyboard=""false"" tabindex=""-1"" aria-labelledby=""staticBackdropLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered modal-xl"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""staticBackdropLabel"">Detalle Requerimiento</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <table id=""tRequerimientosDetalle"" class=""table table-striped"" style=""width:100%""></table>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-bs-dismiss=""modal"">Cerrar</button>
");
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 2411, "\"", 2465, 1);
#nullable restore
#line 62 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\Index.cshtml"
WriteAttributeValue("", 2417, Url.Content("~/Scripts/Portal/trazabilidad.js"), 2417, 48, false);

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