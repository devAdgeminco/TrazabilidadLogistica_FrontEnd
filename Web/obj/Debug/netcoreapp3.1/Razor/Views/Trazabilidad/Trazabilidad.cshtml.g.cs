#pragma checksum "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\Trazabilidad.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65b30c7032260f582f844139c8c7f3bfc835befc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Trazabilidad_Trazabilidad), @"mvc.1.0.view", @"/Views/Trazabilidad/Trazabilidad.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65b30c7032260f582f844139c8c7f3bfc835befc", @"/Views/Trazabilidad/Trazabilidad.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Trazabilidad_Trazabilidad : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\Trazabilidad.cshtml"
  
    ViewBag.Title = "Seguimiento";
    ViewBag.Modulo = "Trazabilidad";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<script>\r\n    var url_getRequerimiento = \"");
#nullable restore
#line 7 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\Trazabilidad.cshtml"
                           Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" + \"Trazabilidad/getRequerimiento\";\r\n    var url_getOCompra = \"");
#nullable restore
#line 8 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\Trazabilidad.cshtml"
                     Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" + \"Trazabilidad/getOCompra\";\r\n    var url_getParteEntrada = \"");
#nullable restore
#line 9 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\Trazabilidad.cshtml"
                          Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" + \"Trazabilidad/getParteEntrada\";\r\n    var url_getRequerimientoDetalle = \"");
#nullable restore
#line 10 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\Trazabilidad.cshtml"
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
                <label for=""Req"" class=""form-label"">Requerimiento</label>
                <input type=""text"" class=""form-control"" id=""Req"" autocomplete=""off"" />
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

<div class=""nav-wizards-container"">
    <nav class=""nav nav-wizards-1 mb-2"">
        <!-- completed -->
        <div class=""nav-item col "">
            <a class=""nav-link uno disabled"" href=""#"">
                <div class=""nav-no"">1</div>
                <div class=""nav-");
            WriteLiteral(@"text"">Requerimiento</div>
            </a>
        </div>

        <!-- active -->
        <div class=""nav-item col "">
            <a class=""nav-link dos disabled"" href=""#"">
                <div class=""nav-no"">2</div>
                <div class=""nav-text"">Orden de Compra</div>
            </a>
        </div>

        <!-- disabled -->
        <div class=""nav-item col "">
            <a class=""nav-link tres disabled"" href=""#"">
                <div class=""nav-no"">3</div>
                <div class=""nav-text"">Almacen Tránsito</div>
            </a>
        </div>

        <div class=""nav-item col "">
            <a class=""nav-link cuatro disabled"" href=""#"">
                <div class=""nav-no"">4</div>
                <div class=""nav-text"">Almacen Destino</div>
            </a>
        </div>

        <div class=""nav-item col "">
            <a class=""nav-link cinco disabled"" href=""#"">
                <div class=""nav-no"">5</div>
                <div class=""nav-text"">Vale Entrega</div>
 ");
            WriteLiteral(@"           </a>
        </div>
    </nav>
</div>

<div id=""cReq"" class=""card"">
    <div class=""card-body"">
        <table id=""tRequerimientos"" class=""table table-striped"" style=""width:100%""></table>
    </div>
</div>
<div id=""cOC"" class=""card"">
    <div class=""card-body"">
        <table id=""tOC"" class=""table table-striped"" style=""width:100%""></table>
    </div>
</div>
<div id=""cIA"" class=""card"">
    <div class=""card-body"">
        <table id=""tPE"" class=""table table-striped"" style=""width:100%""></table>
    </div>
</div>
<div id=""cAlmacenDestino"" class=""card insible"">
    <div class=""card-body"">
        Almacen Destino
    </div>
</div>
<div id=""cValeEntrega"" class=""card"">
    <div class=""card-body"">
        Vale Entrega
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 3304, "\"", 3357, 1);
#nullable restore
#line 103 "E:\Dev\Adgeminco\Trazabilidad Logistica\FrontEnd\TrazabilidadLogistica_FrontEnd\Web\Views\Trazabilidad\Trazabilidad.cshtml"
WriteAttributeValue("", 3310, Url.Content("~/Scripts/Portal/seguimiento.js"), 3310, 47, false);

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
