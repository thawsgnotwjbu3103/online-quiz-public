#pragma checksum "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Questions\DisplayByTest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7232a475baf4f732e584be687cd533cf6a194b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Questions_DisplayByTest), @"mvc.1.0.view", @"/Areas/Admin/Views/Questions/DisplayByTest.cshtml")]
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
#line 1 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\_ViewImports.cshtml"
using OnlineQuiz;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\_ViewImports.cshtml"
using OnlineQuiz.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7232a475baf4f732e584be687cd533cf6a194b0", @"/Areas/Admin/Views/Questions/DisplayByTest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4985db65a771f75426001a99cec54ba09437bf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Questions_DisplayByTest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OnlineQuiz.Models.Question>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Questions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Questions\DisplayByTest.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""page-header"">
    <h2 class=""header-title"">Danh sa??ch c??u ho??i</h2>
    <div class=""header-sub-title"">
        <nav class=""breadcrumb breadcrumb-dash"">
            <a href=""/admin/trang-chu"" class=""breadcrumb-item""><i class=""anticon anticon-home m-r-5""></i>Trang chu??</a>
            <span class=""breadcrumb-item active"">Danh sa??ch c??u ho??i</span>
        </nav>
    </div>
</div>
<div class=""card"">
    <div class=""card-header"">
        <div class=""card-title"">
            <h4 class=""card-title"">Danh sa??ch c??u ho??i</h4>
            <a href=""/admin/cau-hoi/tao-moi"" class=""btn btn-primary"">
                <i class=""anticon anticon-plus-circle""></i> Th??m
            </a>
        </div>
    </div>
    <div class=""card-body"">
        <table id=""d_table"" class=""table"">
            <thead>
                <tr>
                    <th>T??n c??u ho??i</th>
                    <th>Ba??i thi</th>
                    <th>#</th>
                </tr>
            </thead>
            <tbo");
            WriteLiteral("dy>\r\n");
#nullable restore
#line 36 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Questions\DisplayByTest.cshtml"
                   int i = 0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Questions\DisplayByTest.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 40 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Questions\DisplayByTest.cshtml"
                       Write(item.QuestionTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 41 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Questions\DisplayByTest.cshtml"
                       Write(item.Test.TestName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7232a475baf4f732e584be687cd533cf6a194b07149", async() => {
                WriteLiteral("\r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 1677, "\"", 1725, 2);
                WriteAttributeValue("", 1684, "/admin/cau-hoi/chinh-sua/", 1684, 25, true);
#nullable restore
#line 44 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Questions\DisplayByTest.cshtml"
WriteAttributeValue("", 1709, item.QuestionId, 1709, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-warning\">\r\n                                    <i class=\"anticon anticon-edit\"></i>\r\n                                </a>\r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 1899, "\"", 1959, 2);
                WriteAttributeValue("", 1906, "/admin/tra-loi/hien-thi-theo-cau-hoi/", 1906, 37, true);
#nullable restore
#line 47 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Questions\DisplayByTest.cshtml"
WriteAttributeValue("", 1943, item.QuestionId, 1943, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""btn btn-info"">
                                    <i class=""anticon anticon-profile""></i>
                                </a>
                                <button type=""button"" class=""btn btn-danger submitbtn""><i class=""anticon anticon-delete""></i></button>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Questions\DisplayByTest.cshtml"
                                                                                                    WriteLiteral(item.QuestionId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Questions\DisplayByTest.cshtml"
                                                                                                                                     WriteLiteral(item.QuestionId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["Tid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Tid", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["Tid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1624, "submitDelete_", 1624, 13, true);
#nullable restore
#line 43 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Questions\DisplayByTest.cshtml"
AddHtmlAttributeValue("", 1637, i, 1637, 2, false);

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
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 54 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Questions\DisplayByTest.cshtml"
                    i++;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
            <tfoot>
                <tr>
                    <th>T??n c??u ho??i</th>
                    <th>Ba??i thi</th>
                    <th>#</th>
                </tr>
            </tfoot>
        </table>
    </div>
</div>



");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            $(\'#d_table\').DataTable();\r\n        });\r\n\r\n        btn = document.getElementsByClassName(\"submitbtn\");\r\n        for (let i = 0; i < ");
#nullable restore
#line 77 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Questions\DisplayByTest.cshtml"
                       Write(ViewBag.Count);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"; i++) {
            btn[i].addEventListener(""click"", function () {
                onConfirm(i);
            });
        }

        function onConfirm(number) {
            Swal.fire({
                title: 'Xo??a c??u ho??i na??y ?',
                text: ""Chu?? y?? : Ha??nh ??????ng na??y kh??ng th???? phu??c h????i"",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: '??????ng y??',
                cancelButtonText: 'T???? ch????i',
            }).then((result) => {
                if (result.isConfirmed) {
                    var query = "".submitDelete_"" + number;
                    document.querySelector(query).submit();
                }
            })
        };
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OnlineQuiz.Models.Question>> Html { get; private set; }
    }
}
#pragma warning restore 1591
