#pragma checksum "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dffe98f35a75bfdfd960e92e9e4cd8c65bf6688e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Tests_DisplayByCourse), @"mvc.1.0.view", @"/Areas/Admin/Views/Tests/DisplayByCourse.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dffe98f35a75bfdfd960e92e9e4cd8c65bf6688e", @"/Areas/Admin/Views/Tests/DisplayByCourse.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4985db65a771f75426001a99cec54ba09437bf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Tests_DisplayByCourse : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OnlineQuiz.Models.Test>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Students", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
  
    ViewData["Title"] = "DisplayByCourse";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""page-header"">
    <h2 class=""header-title"">Danh sách bài thi</h2>
    <div class=""header-sub-title"">
        <nav class=""breadcrumb breadcrumb-dash"">
            <a href=""/admin/trang-chu"" class=""breadcrumb-item""><i class=""anticon anticon-home m-r-5""></i>Trang chủ</a>
            <span class=""breadcrumb-item active"">Danh sách bài thi</span>
        </nav>
    </div>
</div>
<div class=""card"">
    <div class=""card-header"">
        <div class=""card-title"">
            <h4 class=""card-title"">Danh sách bài thi</h4>
            <a href=""/admin/bai-thi/tao-moi"" class=""btn btn-primary"">
                <i class=""anticon anticon-plus-circle""></i> Thêm
            </a>
        </div>
    </div>
    <div class=""card-body"">
        <table id=""d_table"" class=""table"">
            <thead>
                <tr>
                    <th>Tên bài thi</th>
                    <th>Trạng thái</th>
                    <th>Dạng đề</th>
                    <th>Môn học</th>
          ");
            WriteLiteral("          <th>#</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 38 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
                   int i = 0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 42 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
                       Write(item.TestName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 43 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
                         if (item.IsActive)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>Hiện</td>\r\n");
#nullable restore
#line 46 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>Ẩn</td>\r\n");
#nullable restore
#line 50 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 52 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
                         if (item.HasConstructed)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>Trắc nghiệm - Tự luận</td>\r\n");
#nullable restore
#line 55 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>Trắc nghiệm</td>\r\n");
#nullable restore
#line 59 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 60 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
                       Write(item.Course.CourseName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dffe98f35a75bfdfd960e92e9e4cd8c65bf6688e9044", async() => {
                WriteLiteral("\r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 2334, "\"", 2378, 2);
                WriteAttributeValue("", 2341, "/admin/bai-thi/chinh-sua/", 2341, 25, true);
#nullable restore
#line 63 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
WriteAttributeValue("", 2366, item.TestId, 2366, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-warning\">\r\n                                    <i class=\"anticon anticon-edit\"></i>\r\n                                </a>\r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 2552, "\"", 2608, 2);
                WriteAttributeValue("", 2559, "/admin/cau-hoi/hien-thi-theo-bai-thi/", 2559, 37, true);
#nullable restore
#line 66 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
WriteAttributeValue("", 2596, item.TestId, 2596, 12, false);

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
#line 62 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
                                                                                                   WriteLiteral(item.TestId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 62 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
                                                                                                                                WriteLiteral(item.CourseId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["Cid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Cid", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["Cid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2281, "submitDelete_", 2281, 13, true);
#nullable restore
#line 62 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
AddHtmlAttributeValue("", 2294, i, 2294, 2, false);

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
#line 73 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
                    i++;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
            <tfoot>
                <tr>
                    <th>Tên sinh viên</th>
                    <th>Thông tin</th>
                    <th>Giới tính</th>
                    <th>Lớp</th>
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
#line 98 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Tests\DisplayByCourse.cshtml"
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
                title: 'Xóa bài thi này ?',
                text: ""Chú ý : Hành động này không thể phục hồi"",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Đồng ý',
                cancelButtonText: 'Từ chối',
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OnlineQuiz.Models.Test>> Html { get; private set; }
    }
}
#pragma warning restore 1591