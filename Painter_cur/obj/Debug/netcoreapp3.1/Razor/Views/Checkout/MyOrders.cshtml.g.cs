#pragma checksum "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\Checkout\MyOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abe2a87fc5e8a6a2f8de23aacda60b5d4f13bc4c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Checkout_MyOrders), @"mvc.1.0.view", @"/Views/Checkout/MyOrders.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abe2a87fc5e8a6a2f8de23aacda60b5d4f13bc4c", @"/Views/Checkout/MyOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf033026df0f9492d819b44cb617616efcc82685", @"/Views/_ViewImports.cshtml")]
    public class Views_Checkout_MyOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Browse", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Store", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\Checkout\MyOrders.cshtml"
  
    ViewBag.Title = "Мои заказы";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"bask_content\">\r\n    <div class=\"table_bask\">\r\n        <div class=\"bask_table\">\r\n");
#nullable restore
#line 10 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\Checkout\MyOrders.cshtml"
             for (int i = 0; i < Model.Count; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"prod_row\">\r\n                    <div class=\"inf_prod_td\">\r\n                        <div>\r\n                            <span class=\"name_prod\">Заказ №");
#nullable restore
#line 15 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\Checkout\MyOrders.cshtml"
                                                      Write(Model[i].o_code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            <span>Дата заказа: ");
#nullable restore
#line 16 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\Checkout\MyOrders.cshtml"
                                          Write(Model[i].o_date);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                            <span>Тип доставки: ");
#nullable restore
#line 17 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\Checkout\MyOrders.cshtml"
                                           Write(Model[i].o_delivery);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"inf_prod_td\">\r\n                        <div>\r\n                            <span class=\"name_prod\">Товаров ");
#nullable restore
#line 22 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\Checkout\MyOrders.cshtml"
                                                       Write(ViewBag.Counts[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" шт.</span>\r\n                            <span>Сумма заказа:  ");
#nullable restore
#line 23 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\Checkout\MyOrders.cshtml"
                                            Write(ViewBag.Sums[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" руб. </span>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 27 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\Checkout\MyOrders.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 31 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\Checkout\MyOrders.cshtml"
     if (Model.Count == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"total_box\">\r\n            <div id=\"empty_bask\">\r\n                <span style=\"color: darkgray; font: 17px; font-family: \'Conv_AmaticSC-Regular\';\"> У вас пока нет заказов :( </span>\r\n                <br />\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "abe2a87fc5e8a6a2f8de23aacda60b5d4f13bc4c7165", async() => {
                WriteLiteral(" Отправиться за покупками ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n           \r\n        </div>\r\n");
#nullable restore
#line 41 "C:\Users\Пользователь\source\repos\Painter_cur\Painter_cur\Views\Checkout\MyOrders.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591