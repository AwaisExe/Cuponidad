#pragma checksum "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91bdd1b0bdbdbea73f3ee1fa2af696337648fcca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SearchList), @"mvc.1.0.view", @"/Views/Home/SearchList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/SearchList.cshtml", typeof(AspNetCore.Views_Home_SearchList))]
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
#line 1 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\_ViewImports.cshtml"
using Cuponidad;

#line default
#line hidden
#line 2 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\_ViewImports.cshtml"
using Cuponidad.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91bdd1b0bdbdbea73f3ee1fa2af696337648fcca", @"/Views/Home/SearchList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b81f9d4be119cdd7175b07cd4d1be2f0d05b761b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_SearchList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Cuponidad.DataAccessLayer.Model.Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/offer.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-offer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml"
  
    ViewData["Title"] = "SearchList";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(147, 242, true);
            WriteLiteral("\r\n<div class=\"main-content fixed-content\">\r\n    <div class=\"container\">\r\n        <div class=\"wrap-sect\">\r\n            <div id=\"ofertas_relacionadas\">\r\n                <div id=\"wrap-offer-list\">\r\n                    <div id=\"cnt-offer-list\">\r\n");
            EndContext();
#line 13 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml"
                         foreach (var product in Model)
                        {

#line default
#line hidden
            BeginContext(473, 155, true);
            WriteLiteral("                            <div class=\"card offer-unit\">\r\n                                <figure class=\"img-offer\">\r\n                                    ");
            EndContext();
            BeginContext(628, 285, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "724885829e4d47e7be24915a0fb84d3e", async() => {
                BeginContext(772, 42, true);
                WriteLiteral("\r\n                                        ");
                EndContext();
                BeginContext(814, 57, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "acc27d30fef94559b4e1eb212e70af11", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 824, "~/", 824, 2, true);
#line 18 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml"
AddHtmlAttributeValue("", 826, product.ImagePath, 826, 18, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(871, 38, true);
                WriteLiteral("\r\n                                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 17 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml"
                                                                                             WriteLiteral(product.ProductID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 17 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml"
                                                                                                                                     WriteLiteral(product.Category.Family.FamilyID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["familyID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-familyID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["familyID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(913, 58, true);
            WriteLiteral("\r\n                                    <span class=\"offer\">");
            EndContext();
            BeginContext(971, 30, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "90c4b6208806480a8d813929b5ea9354", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1001, 294, true);
            WriteLiteral(@"</span>
                                </figure>
                                <div class=""card-body desc-offer"">
                                    <div class=""data-offer-allvalue"">
                                        <div class=""data-offer-linea1""><span class=""listing-price-b"">S/");
            EndContext();
            BeginContext(1296, 22, false);
#line 24 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml"
                                                                                                  Write(product.DiscountAmount);

#line default
#line hidden
            EndContext();
            BeginContext(1318, 350, true);
            WriteLiteral(@"</span></div>
                                        <div class=""data-offer-linea2"">
                                            <span class=""before-price-b"">
                                                <span class=""before-price-etiqueta"">Precio</span>
                                                <span class=""before-price-precioreal"">S/");
            EndContext();
            BeginContext(1669, 13, false);
#line 28 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml"
                                                                                   Write(product.Prize);

#line default
#line hidden
            EndContext();
            BeginContext(1682, 205, true);
            WriteLiteral(" </span>\r\n                                            </span>\r\n                                        </div>\r\n                                        <div class=\"data-offer-linea3\"><span class=\"dscto-b\">-");
            EndContext();
            BeginContext(1888, 16, false);
#line 31 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml"
                                                                                         Write(product.Discount);

#line default
#line hidden
            EndContext();
            BeginContext(1904, 167, true);
            WriteLiteral(" DSCTO</span></div>\r\n                                    </div>\r\n                                    <h2 class=\"title-offer\">\r\n                                        ");
            EndContext();
            BeginContext(2071, 283, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a73ca2afcee540e69365142c66114e46", async() => {
                BeginContext(2215, 46, true);
                WriteLiteral("\r\n                                            ");
                EndContext();
                BeginContext(2262, 25, false);
#line 35 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml"
                                       Write(product.Company.Direction);

#line default
#line hidden
                EndContext();
                BeginContext(2287, 1, true);
                WriteLiteral(":");
                EndContext();
                BeginContext(2289, 19, false);
#line 35 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml"
                                                                  Write(product.Description);

#line default
#line hidden
                EndContext();
                BeginContext(2308, 42, true);
                WriteLiteral("\r\n                                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 34 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml"
                                                                                                 WriteLiteral(product.ProductID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 34 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml"
                                                                                                                                         WriteLiteral(product.Category.Family.FamilyID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["familyID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-familyID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["familyID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2354, 412, true);
            WriteLiteral(@"
                                    </h2>
                                </div>
                                <div class=""card-footer"">
                                    <span class=""comerc""></span>
                                    <div class=""prices"">
                                        <div class=""prices-item2"">de Lun. a Dom. (Inc. Feriados)</div>
                                        ");
            EndContext();
            BeginContext(2766, 192, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96ed44f325d847258c3da698611bb8fe", async() => {
                BeginContext(2932, 22, true);
                WriteLiteral("Ver <strong>+</strong>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 43 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml"
                                                                                                 WriteLiteral(product.ProductID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 43 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml"
                                                                                                                                         WriteLiteral(product.Category.Family.FamilyID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["familyID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-familyID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["familyID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2958, 122, true);
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
            EndContext();
#line 47 "E:\Work Space\FreelancingProject\Cupon\Cuponidad\Cuponidad\Views\Home\SearchList.cshtml"
                        }

#line default
#line hidden
            BeginContext(3107, 129, true);
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div><!-- PAGE-ENDS-HERE -->");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Cuponidad.DataAccessLayer.Model.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
