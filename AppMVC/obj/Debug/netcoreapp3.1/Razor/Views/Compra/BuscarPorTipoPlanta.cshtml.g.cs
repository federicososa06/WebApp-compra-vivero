#pragma checksum "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b27d619b75c5d3a83bbd5dbd046da12c94991ea1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Compra_BuscarPorTipoPlanta), @"mvc.1.0.view", @"/Views/Compra/BuscarPorTipoPlanta.cshtml")]
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
#line 1 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\_ViewImports.cshtml"
using AppMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\_ViewImports.cshtml"
using AppMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b27d619b75c5d3a83bbd5dbd046da12c94991ea1", @"/Views/Compra/BuscarPorTipoPlanta.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05577273c34e02672dffa2e85f508c6eba29f11f", @"/Views/_ViewImports.cshtml")]
    public class Views_Compra_BuscarPorTipoPlanta : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AppMVC.Models.ViewModelCompleto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BuscarPorTipoPlanta", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
  
    ViewData["Title"] = "Buscar compras por tipo planta";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Buscar compras</h1>\r\n\r\n");
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-6 mb-3\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b27d619b75c5d3a83bbd5dbd046da12c94991ea14973", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b27d619b75c5d3a83bbd5dbd046da12c94991ea15243", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 14 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label\">Buscar por tipo</label>\r\n                <select name=\"idTipoSeleccionado\">\r\n");
#nullable restore
#line 19 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
                     foreach (var tipo in Model.ListaTiposPlanta)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b27d619b75c5d3a83bbd5dbd046da12c94991ea17398", async() => {
#nullable restore
#line 21 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
                                            Write(tipo.Nombre);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 21 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
                           WriteLiteral(tipo.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 22 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </select>\r\n                <input type=\"submit\" value=\"Buscar\" class=\"btn btn-light\" />\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<span class=\"text-danger\">");
#nullable restore
#line 30 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
                     Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n\r\n\r\n\r\n");
#nullable restore
#line 35 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
 if (Model.ListaCompras != null && Model.ListaCompras.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>Resultados</h4>\r\n");
            WriteLiteral(@"    <table class=""col table table-striped"">
        <thead>
            <tr>
                <th>
                    Id compra
                </th>
                <th>
                    Fecha compra
                </th>
                <th>
                    Nombre cientifico
                </th>
                <th>
                    Cantidad unidades
                </th>
                <th>
                    Costo total
                </th>
            </tr>
                
        </thead>
        <tbody>
");
#nullable restore
#line 61 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
             foreach (var item in Model.ListaCompras)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 65 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
               Write(Html.DisplayFor(modelItem => item.CompraId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 68 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
               Write(Html.DisplayFor(modelItem => item.Fecha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 71 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
               Write(Html.DisplayFor(modelItem => item.NombreCientifico));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 75 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
               Write(Html.DisplayFor(modelItem => item.Cantidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 78 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
               Write(Html.DisplayFor(modelItem => item.CostoTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 81 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
                
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 85 "C:\Users\feder\Desktop\Fede\ORT\a\AppMVC\Views\Compra\BuscarPorTipoPlanta.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AppMVC.Models.ViewModelCompleto> Html { get; private set; }
    }
}
#pragma warning restore 1591
