#pragma checksum "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Accounts\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a483c6b69b0ab0bfff30a23edb76ed2e361388b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Accounts_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Accounts/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a483c6b69b0ab0bfff30a23edb76ed2e361388b", @"/Areas/Admin/Views/Accounts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4985db65a771f75426001a99cec54ba09437bf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Accounts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AppUser>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Accounts\Index.cshtml"
  
    ViewData["Title"] = "Danh sách tài khoản";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""page-header"">
    <h2 class=""header-title"">Danh sách tài khoản</h2>
    <div class=""header-sub-title"">
        <nav class=""breadcrumb breadcrumb-dash"">
            <a href=""/admin/trang-chu"" class=""breadcrumb-item""><i class=""anticon anticon-home m-r-5""></i>Trang chủ</a>
            <span class=""breadcrumb-item active"">Danh sách tài khoản</span>
        </nav>
    </div>
</div>
<div class=""card"">
    <div class=""card-header"">
        <div class=""card-title"">
            <h4 class=""card-title"">Danh sách tài khoản</h4>
        </div>
    </div>
    <div class=""card-body"">
        <table id=""d_table"" class=""table"">
            <thead>
                <tr>
                    <td>Mã TK</td>
                    <td>Tên tài khoản</td>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 31 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Accounts\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 35 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Accounts\Index.cshtml"
                       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>");
#nullable restore
#line 37 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Accounts\Index.cshtml"
                       Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 39 "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Accounts\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n            <tfoot>\r\n                <tr>\r\n                    <td>Mã TK</td>\r\n                    <td>Tên tài khoản</td>\r\n                </tr>\r\n            </tfoot>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            $(\"#d_table\").dataTable();\r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AppUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
