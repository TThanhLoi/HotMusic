#pragma checksum "E:\project\HotMusic\HotMusic\Areas\Admin\Views\Album\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0806c69f6049c26e824395527d926eb0e6cfa5ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Album_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/Album/Details.cshtml")]
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
#line 1 "E:\project\HotMusic\HotMusic\Areas\Admin\Views\_ViewImports.cshtml"
using HotMusic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\project\HotMusic\HotMusic\Areas\Admin\Views\_ViewImports.cshtml"
using HotMusic.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0806c69f6049c26e824395527d926eb0e6cfa5ec", @"/Areas/Admin/Views/Album/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85178b924cd4eca741fe8a37a6bbf4988d2977bb", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Album_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HotMusic.Models.Album>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("200"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("200"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\project\HotMusic\HotMusic\Areas\Admin\Views\Album\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1 style=""margin-left: 30px; color: white;"">Th??ng tin chi ti???t Album</h1>

<div>
    <hr />
    <div class=""col-10"" style=""padding: 25px;"">
        <div  class=""card mb-4"" style=""padding: 25px;"">
            <div class=""card-body"">
                <h4 class=""card-title"">Th??ng tin Album : ");
#nullable restore
#line 15 "E:\project\HotMusic\HotMusic\Areas\Admin\Views\Album\Details.cshtml"
                                                    Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
                <div class=""table-responsive"">
                    <table class=""product-info-table m-t-20"">
                        <tbody>
                            <tr>
                                <td>ID:</td>
                                <td class=""text-dark font-weight-semibold"">");
#nullable restore
#line 21 "E:\project\HotMusic\HotMusic\Areas\Admin\Views\Album\Details.cshtml"
                                                                      Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td>T??n Album:</td>\r\n                                <td>");
#nullable restore
#line 25 "E:\project\HotMusic\HotMusic\Areas\Admin\Views\Album\Details.cshtml"
                               Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td>The loai:</td>\r\n                                <td>");
#nullable restore
#line 29 "E:\project\HotMusic\HotMusic\Areas\Admin\Views\Album\Details.cshtml"
                               Write(Model.Category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td>URL:</td>\r\n                                <td>");
#nullable restore
#line 33 "E:\project\HotMusic\HotMusic\Areas\Admin\Views\Album\Details.cshtml"
                               Write(Model.Url);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                            </tr>\r\n                            <tr>\r\n                                <td>Ngay tao Album:</td>\r\n                                <td>");
#nullable restore
#line 42 "E:\project\HotMusic\HotMusic\Areas\Admin\Views\Album\Details.cshtml"
                               Write(Model.Createdate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            \r\n                            <tr>\r\n                                <td>S??? l?????t Th??ch:</td>\r\n                                <td>");
#nullable restore
#line 47 "E:\project\HotMusic\HotMusic\Areas\Admin\Views\Album\Details.cshtml"
                               Write(Model.FavoriteQuantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td>???nh ?????i di???n:</td>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0806c69f6049c26e824395527d926eb0e6cfa5ec8716", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2282, "~/images/Album/", 2282, 15, true);
#nullable restore
#line 52 "E:\project\HotMusic\HotMusic\Areas\Admin\Views\Album\Details.cshtml"
AddHtmlAttributeValue("", 2297, Model.Imange, 2297, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 52 "E:\project\HotMusic\HotMusic\Areas\Admin\Views\Album\Details.cshtml"
AddHtmlAttributeValue("", 2317, Model.Imange, 2317, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td>M?? t??? s???n ph???m:</td>\r\n                                <td>");
#nullable restore
#line 57 "E:\project\HotMusic\HotMusic\Areas\Admin\Views\Album\Details.cshtml"
                               Write(Html.Raw(Model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n            <div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0806c69f6049c26e824395527d926eb0e6cfa5ec11467", async() => {
                WriteLiteral("Ch???nh s???a");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "E:\project\HotMusic\HotMusic\Areas\Admin\Views\Album\Details.cshtml"
                                       WriteLiteral(Model.Id);

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
            WriteLiteral(" |\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0806c69f6049c26e824395527d926eb0e6cfa5ec13627", async() => {
                WriteLiteral("Quay l???i");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HotMusic.Models.Album> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
