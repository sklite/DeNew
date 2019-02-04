#pragma checksum "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e41aeb99cc4f624f95133b0bf40b0d7ebfaae69"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_IndexNew), @"mvc.1.0.view", @"/Views/Home/IndexNew.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/IndexNew.cshtml", typeof(AspNetCore.Views_Home_IndexNew))]
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
#line 1 "C:\Prj\github\DeNew\DeNew\Views\_ViewImports.cshtml"
using DeNew;

#line default
#line hidden
#line 2 "C:\Prj\github\DeNew\DeNew\Views\_ViewImports.cshtml"
using DeNew.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e41aeb99cc4f624f95133b0bf40b0d7ebfaae69", @"/Views/Home/IndexNew.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"830cec0cba8a25db1bcc76038244e3d92c09ebd8", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_IndexNew : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DeNew.Models.ViewModels.PageViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateNewPage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("top-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
  
    ViewBag.Title = Model.Name;
    ViewBag.Description = Model.MetaDescription;
    ViewBag.Keywords = Model.Keywords;

#line default
#line hidden
            BeginContext(178, 12, true);
            WriteLiteral("\r\n<h1>\r\n    ");
            EndContext();
            BeginContext(191, 10, false);
#line 10 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(201, 12, true);
            WriteLiteral("\r\n</h1>\r\n<p>");
            EndContext();
            BeginContext(214, 23, false);
#line 12 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
Write(Html.Raw(Model.Content));

#line default
#line hidden
            EndContext();
            BeginContext(237, 8, true);
            WriteLiteral("</p>\r\n\r\n");
            EndContext();
#line 14 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
 if (Model.SubPages.Any())
{

#line default
#line hidden
            BeginContext(276, 25, true);
            WriteLiteral("<section class=\"tiles\">\r\n");
            EndContext();
#line 17 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
     foreach (var item in Model.SubPages.OrderBy(cat => cat.OrderNum))
    {

#line default
#line hidden
            BeginContext(380, 34, true);
            WriteLiteral("        <article class=\"style3\">\r\n");
            EndContext();
#line 20 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
             if (Model.CanEdit)
            {

#line default
#line hidden
            BeginContext(462, 58, true);
            WriteLiteral("                <div class=\"top-right-relative red-button\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 520, "\"", 553, 3);
            WriteAttributeValue("", 530, "RemoveArticle(", 530, 14, true);
#line 22 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
WriteAttributeValue("", 544, item.Id, 544, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 552, ")", 552, 1, true);
            EndWriteAttribute();
            BeginContext(554, 16, true);
            WriteLiteral(">Удалить</div>\r\n");
            EndContext();
#line 23 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
            }

#line default
#line hidden
            BeginContext(585, 136, true);
            WriteLiteral("            <span class=\"image\">\r\n                <object data=\"/images/preview/imgStub.jpg\" type=\"image/png\">\r\n                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 721, "\"", 742, 1);
#line 26 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
WriteAttributeValue("", 727, item.ImagePath, 727, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(743, 73, true);
            WriteLiteral(" alt=\"\"/>\r\n                </object>\r\n            </span>\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 816, "\"", 834, 2);
            WriteAttributeValue("", 823, "/", 823, 1, true);
#line 29 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
WriteAttributeValue("", 824, item.Link, 824, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(835, 23, true);
            WriteLiteral(">\r\n                <h2>");
            EndContext();
            BeginContext(859, 9, false);
#line 30 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
               Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(868, 69, true);
            WriteLiteral("</h2>\r\n                <div class=\"content\">\r\n                    <p>");
            EndContext();
            BeginContext(938, 16, false);
#line 32 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
                  Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(954, 68, true);
            WriteLiteral("</p>\r\n                </div>\r\n            </a>\r\n        </article>\r\n");
            EndContext();
#line 36 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
    }

#line default
#line hidden
            BeginContext(1029, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 37 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
     if (Model.CanEdit)
    {

#line default
#line hidden
            BeginContext(1061, 146, true);
            WriteLiteral("        <article class=\"style3\">\r\n            <span class=\"image\">\r\n                <object data=\"/images/preview/imgStub.jpg\" type=\"image/png\">\r\n");
            EndContext();
            BeginContext(1269, 60, true);
            WriteLiteral("                </object>\r\n            </span>\r\n            ");
            EndContext();
            BeginContext(1329, 260, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d41acd16af6b42d1bdf7cf2d29a9a877", async() => {
                BeginContext(1413, 172, true);
                WriteLiteral("\r\n                <h2>Добавить страницу</h2>\r\n                <div class=\"content\">\r\n                    <p>Создать новую страницу</p>\r\n                </div>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-parentId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 45 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
                                                                         WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["parentId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-parentId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["parentId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1589, 22, true);
            WriteLiteral("\r\n        </article>\r\n");
            EndContext();
#line 52 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
    }

#line default
#line hidden
            BeginContext(1618, 14, true);
            WriteLiteral("\r\n</section>\r\n");
            EndContext();
#line 55 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
}

#line default
#line hidden
            BeginContext(1635, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 57 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
 if (Model.CanEdit)
{

#line default
#line hidden
            BeginContext(1661, 88, true);
            WriteLiteral("    <input type=\"submit\" value=\"Редактировать страницу\" class=\"btn btn-default\" />\r\n    ");
            EndContext();
            BeginContext(1749, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f9e132538b244779916990e568c58191", async() => {
                BeginContext(1813, 5, true);
                WriteLiteral("Выйти");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1822, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 61 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1836, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(1840, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "49b4f21585614f9c92e8b6a21a887ca4", async() => {
                BeginContext(1903, 5, true);
                WriteLiteral("Войти");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1912, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 65 "C:\Prj\github\DeNew\DeNew\Views\Home\IndexNew.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DeNew.Models.ViewModels.PageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
