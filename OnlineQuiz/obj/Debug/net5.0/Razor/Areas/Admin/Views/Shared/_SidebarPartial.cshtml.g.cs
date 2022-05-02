#pragma checksum "D:\ASP.NET-Core_Projects\OnlineQuiz\OnlineQuiz\Areas\Admin\Views\Shared\_SidebarPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63e05cbc274b4d622dd854cade9e941758a2a95c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__SidebarPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_SidebarPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63e05cbc274b4d622dd854cade9e941758a2a95c", @"/Areas/Admin/Views/Shared/_SidebarPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4985db65a771f75426001a99cec54ba09437bf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared__SidebarPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""side-nav"">
    <div class=""side-nav-inner"">
        <ul class=""side-nav-menu scrollable"">
            <li class=""nav-item dropdown"">
                <a href=""/admin/hoc-sinh"">
                    <span class=""icon-holder"">
                        <i class=""anticon anticon-dashboard""></i>
                    </span>
                    <span class=""title"">Trang chủ</span>
                </a>
            </li>
            <li class=""nav-item dropdown"">
                <a class=""dropdown-toggle"" href=""javascript:void(0);"">
                    <span class=""icon-holder"">
                        <i class=""anticon anticon-pie-chart""></i>
                    </span>
                    <span class=""title"">Quản lý học sinh</span>
                    <span class=""arrow"">
                        <i class=""arrow-icon""></i>
                    </span>
                </a>
                <ul class=""dropdown-menu"">
                    <li>
                        <a href=""/admin/khoa");
            WriteLiteral(@""">Danh sách khoa</a>
                    </li>
                    <li>
                        <a href=""/admin/lop"">Danh sách lớp</a>
                    </li>
                    <li>
                        <a href=""/admin/hoc-sinh"">Danh sách sinh viên</a>
                    </li>
                </ul>
            </li>
            <li class=""nav-item dropdown"">
                <a class=""dropdown-toggle"" href=""javascript:void(0);"">
                    <span class=""icon-holder"">
                        <i class=""anticon anticon-ordered-list""></i>
                    </span>
                    <span class=""title"">Quản lý môn học</span>
                    <span class=""arrow"">
                        <i class=""arrow-icon""></i>
                    </span>
                </a>
                <ul class=""dropdown-menu"">
                    <li>
                        <a href=""/admin/mon-hoc"">Danh sách môn học</a>
                    </li>
                    <li>
            ");
            WriteLiteral(@"            <a href=""/admin/bai-thi"">Danh sách bài thi</a>
                    </li>
                    <li>
                        <a href=""/admin/cau-hoi"">Danh sách câu hỏi</a>
                    </li>
                    <li>
                        <a href=""/admin/tra-loi"">Danh sách câu trả lời</a>
                    </li>
                </ul>
            </li>
            <li class=""nav-item dropdown"">
                <a class=""dropdown-toggle"" href=""javascript:void(0);"">
                    <span class=""icon-holder"">
                        <i class=""anticon anticon-highlight""></i>
                    </span>
                    <span class=""title"">Quản lý điểm thi</span>
                    <span class=""arrow"">
                        <i class=""arrow-icon""></i>
                    </span>
                </a>
                <ul class=""dropdown-menu"">
                    <li>
                        <a href=""/admin/diem"">Danh sách điểm thi</a>
                   ");
            WriteLiteral(@" </li>
                </ul>
            </li>
            <li class=""nav-item dropdown"">
                <a class=""dropdown-toggle"" href=""javascript:void(0);"">
                    <span class=""icon-holder"">
                        <i class=""anticon anticon-enter""></i>
                    </span>
                    <span class=""title"">Tài khoản và quyền truy cập</span>
                    <span class=""arrow"">
                        <i class=""arrow-icon""></i>
                    </span>
                </a>
                <ul class=""dropdown-menu"">
                    <li>
                        <a href=""/admin/tai-khoan"">Danh sách tài khoản</a>
                    </li>
                    <li>
                        <a href=""/admin/quyen-truy-cap"">DS quyền truy cập</a>
                    </li>
                </ul>
            </li>
        </ul>
    </div>
</div>
");
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
