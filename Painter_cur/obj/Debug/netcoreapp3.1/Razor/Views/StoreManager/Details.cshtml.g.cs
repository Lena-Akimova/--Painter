#pragma checksum "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a1b89ebc3ce2b96c2c19e94d5f371dda16124c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StoreManager_Details), @"mvc.1.0.view", @"/Views/StoreManager/Details.cshtml")]
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
#line 1 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\_ViewImports.cshtml"
using Painter_cur;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\_ViewImports.cshtml"
using Painter_cur.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a1b89ebc3ce2b96c2c19e94d5f371dda16124c9", @"/Views/StoreManager/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf033026df0f9492d819b44cb617616efcc82685", @"/Views/_ViewImports.cshtml")]
    public class Views_StoreManager_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Painter_cur.Models.Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
  
    ViewData["Title"] = "Подробности";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"form_create\">\r\n    <div class=\"box_del\">\r\n        <dl class=\"det_tab\">\r\n            <dt class=\"name\">\r\n                ");
#nullable restore
#line 11 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.P_categ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"value\">\r\n                ");
#nullable restore
#line 14 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
           Write(Html.DisplayFor(model => model.P_categ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"name\">\r\n                ");
#nullable restore
#line 17 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.P_name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"value\">\r\n                ");
#nullable restore
#line 20 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
           Write(Html.DisplayFor(model => model.P_name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"name\">\r\n                ");
#nullable restore
#line 23 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.P_price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"value\">\r\n                ");
#nullable restore
#line 26 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
           Write(Html.DisplayFor(model => model.P_price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"name\">\r\n                ");
#nullable restore
#line 29 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.P_prod));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"value\">\r\n                ");
#nullable restore
#line 32 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
           Write(Html.DisplayFor(model => model.P_prod));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"name\">\r\n                ");
#nullable restore
#line 35 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.P_img));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"value\">\r\n                ");
#nullable restore
#line 38 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
           Write(Html.DisplayFor(model => model.P_img));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n\r\n\r\n");
#nullable restore
#line 42 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
             if (ViewBag.KonkProd != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                 switch (Model.P_categ)
                {
                    case "Paints":

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <dt class=\"name\">\r\n                            <label class=\"control-label\">Тип  </label>\r\n                        </dt>\r\n                        <dd class=\"value\">\r\n                            <span class=\"form-control\">");
#nullable restore
#line 51 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                                                  Write(ViewBag.KonkProd.pai_type);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </dd>
                        <dt class=""name"">
                            <label class=""control-label"">Цвет  </label>
                        </dt>
                        <dd class=""value"">
                            <span class=""form-control"">");
#nullable restore
#line 57 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                                                  Write(ViewBag.KonkProd.pai_color);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </dd>
                        <dt class=""name"">
                            <label class=""control-label"">Объем, мл  </label>
                        </dt>
                        <dd class=""value"">
                            <span class=""form-control"">");
#nullable restore
#line 63 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                                                  Write(ViewBag.KonkProd.pai_volume);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </dd>
                        <dt class=""name"">
                            <label class=""control-label"">Количество цветов  </label>
                        </dt>
                        <dd class=""value"">
                            <span class=""form-control"">");
#nullable restore
#line 69 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                                                  Write(ViewBag.KonkProd.pai_quant);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </dd>\r\n");
#nullable restore
#line 71 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"

                        break;

                    case "Brushes":

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <dt class=\"name\">\r\n                            <label class=\"control-label\">Материал  </label>\r\n                        </dt>\r\n                        <dd class=\"value\">\r\n                            <span class=\"form-control\">");
#nullable restore
#line 79 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                                                  Write(ViewBag.KonkProd.b_mater);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </dd>
                        <dt class=""name"">
                            <label class=""control-label"">Номер  </label>
                        </dt>
                        <dd class=""value"">
                            <span class=""form-control"">");
#nullable restore
#line 85 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                                                  Write(ViewBag.KonkProd.b_numb);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </dd>
                        <dt class=""name"">
                            <label class=""control-label"">Форма  </label>
                        </dt>
                        <dd class=""value"">
                            <span class=""form-control"">");
#nullable restore
#line 91 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                                                  Write(ViewBag.KonkProd.b_form);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </dd>\r\n");
#nullable restore
#line 93 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                        break;

                    case "Papers":

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <dt class=\"name\">\r\n                            <label class=\"control-label\">Тип  </label>\r\n                        </dt>\r\n                        <dd class=\"value\">\r\n                            <span class=\"form-control\">");
#nullable restore
#line 100 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                                                  Write(ViewBag.KonkProd.pap_type);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </dd>
                        <dt class=""name"">
                            <label class=""control-label"">Формат  </label>
                        </dt>
                        <dd class=""value"">
                            <span class=""form-control"">");
#nullable restore
#line 106 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                                                  Write(ViewBag.KonkProd.pap_format);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </dd>
                        <dt class=""name"">
                            <label class=""control-label"">Плотность  </label>
                        </dt>
                        <dd class=""value"">
                            <span class=""form-control"">");
#nullable restore
#line 112 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                                                  Write(ViewBag.KonkProd.pap_density);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </dd>\r\n");
#nullable restore
#line 114 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"

                        break;
                    case "Implements":

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <dt class=\"name\">\r\n                            <label class=\"control-label\">Тип  </label>\r\n                        </dt>\r\n                        <dd class=\"value\">\r\n                            <span class=\"form-control\">");
#nullable restore
#line 121 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                                                  Write(ViewBag.KonkProd.i_type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </dd>\r\n");
#nullable restore
#line 123 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                        break;
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 124 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                 }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </dl>\r\n    </div>\r\n\r\n    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a1b89ebc3ce2b96c2c19e94d5f371dda16124c915939", async() => {
                WriteLiteral("Изменить");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 129 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\StoreManager\Details.cshtml"
                               WriteLiteral(Model.P_art);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a1b89ebc3ce2b96c2c19e94d5f371dda16124c918111", async() => {
                WriteLiteral(@"<svg width=""1em"" height=""1em"" viewBox=""0 0 16 16"" class=""bi bi-arrow-left-circle"" fill=""currentColor"" xmlns=""http://www.w3.org/2000/svg"">
    <path fill-rule=""evenodd"" d=""M8 15A7 7 0 1 0 8 1a7 7 0 0 0 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"" />
    <path fill-rule=""evenodd"" d=""M8.354 11.354a.5.5 0 0 0 0-.708L5.707 8l2.647-2.646a.5.5 0 1 0-.708-.708l-3 3a.5.5 0 0 0 0 .708l3 3a.5.5 0 0 0 .708 0z"" />
    <path fill-rule=""evenodd"" d=""M11.5 8a.5.5 0 0 0-.5-.5H6a.5.5 0 0 0 0 1h5a.5.5 0 0 0 .5-.5z"" />
</svg>Назад к списку");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Painter_cur.Models.Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
