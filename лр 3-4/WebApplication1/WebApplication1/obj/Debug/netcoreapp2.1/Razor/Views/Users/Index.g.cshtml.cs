#pragma checksum "C:\Users\v_zah\OneDrive\Desktop\учеба\4курс\веб технологии\Web-technology\лр 3-4\WebApplication1\WebApplication1\Views\Users\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c57faca4e4a8e9bf188921f0c10e7808a1eed5c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Index), @"mvc.1.0.view", @"/Views/Users/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Users/Index.cshtml", typeof(AspNetCore.Views_Users_Index))]
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
#line 1 "C:\Users\v_zah\OneDrive\Desktop\учеба\4курс\веб технологии\Web-technology\лр 3-4\WebApplication1\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#line 2 "C:\Users\v_zah\OneDrive\Desktop\учеба\4курс\веб технологии\Web-technology\лр 3-4\WebApplication1\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
#line 1 "C:\Users\v_zah\OneDrive\Desktop\учеба\4курс\веб технологии\Web-technology\лр 3-4\WebApplication1\WebApplication1\Views\Users\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c57faca4e4a8e9bf188921f0c10e7808a1eed5c", @"/Views/Users/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ApplicationUser>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(119, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Users\v_zah\OneDrive\Desktop\учеба\4курс\веб технологии\Web-technology\лр 3-4\WebApplication1\WebApplication1\Views\Users\Index.cshtml"
  
    //ViewData["Title"] = "Управление пользователями";
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(209, 6, true);
            WriteLiteral("\r\n<h1>");
            EndContext();
            BeginContext(216, 17, false);
#line 10 "C:\Users\v_zah\OneDrive\Desktop\учеба\4курс\веб технологии\Web-technology\лр 3-4\WebApplication1\WebApplication1\Views\Users\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(233, 30, true);
            WriteLiteral("</h1>\r\n<div class=\"btn-block\">");
            EndContext();
            BeginContext(264, 52, false);
#line 11 "C:\Users\v_zah\OneDrive\Desktop\учеба\4курс\веб технологии\Web-technology\лр 3-4\WebApplication1\WebApplication1\Views\Users\Index.cshtml"
                  Write(Html.ActionLink("Зарегистрировать", "Edit", "Users"));

#line default
#line hidden
            EndContext();
            BeginContext(316, 169, true);
            WriteLiteral("</div>\r\n<table class=\"table\">\r\n    <thead>\r\n    <tr>\r\n        <td>Действие</td>\r\n        <td>Email</td>\r\n        <td>ФИО</td>\r\n    </tr>\r\n    </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 21 "C:\Users\v_zah\OneDrive\Desktop\учеба\4курс\веб технологии\Web-technology\лр 3-4\WebApplication1\WebApplication1\Views\Users\Index.cshtml"
     foreach (var user in Model)
    {
        var action = await UserManager.IsInRoleAsync(user, "Admin") ? "Забрать права администратора" : "Сделать администратором";

#line default
#line hidden
            BeginContext(657, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(688, 65, false);
#line 25 "C:\Users\v_zah\OneDrive\Desktop\учеба\4курс\веб технологии\Web-technology\лр 3-4\WebApplication1\WebApplication1\Views\Users\Index.cshtml"
           Write(Html.ActionLink("Редакт.", "Edit", "Users", new { id = user.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(753, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(755, 63, false);
#line 25 "C:\Users\v_zah\OneDrive\Desktop\учеба\4курс\веб технологии\Web-technology\лр 3-4\WebApplication1\WebApplication1\Views\Users\Index.cshtml"
                                                                              Write(Html.ActionLink("Уд.", "Remove", "Users", new { id = user.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(818, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(820, 66, false);
#line 25 "C:\Users\v_zah\OneDrive\Desktop\учеба\4курс\веб технологии\Web-technology\лр 3-4\WebApplication1\WebApplication1\Views\Users\Index.cshtml"
                                                                                                                                               Write(Html.ActionLink(action,"ToggleAdmin","Users",new { id = user.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(886, 24, true);
            WriteLiteral(" </td>\r\n            <td>");
            EndContext();
            BeginContext(911, 10, false);
#line 26 "C:\Users\v_zah\OneDrive\Desktop\учеба\4курс\веб технологии\Web-technology\лр 3-4\WebApplication1\WebApplication1\Views\Users\Index.cshtml"
           Write(user.Email);

#line default
#line hidden
            EndContext();
            BeginContext(921, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(945, 15, false);
#line 27 "C:\Users\v_zah\OneDrive\Desktop\учеба\4курс\веб технологии\Web-technology\лр 3-4\WebApplication1\WebApplication1\Views\Users\Index.cshtml"
           Write(user.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(960, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 29 "C:\Users\v_zah\OneDrive\Desktop\учеба\4курс\веб технологии\Web-technology\лр 3-4\WebApplication1\WebApplication1\Views\Users\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(989, 26, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ApplicationUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
