#pragma checksum "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d7030b90088c81c3aea187521384f90b76468873"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pole_Pole), @"mvc.1.0.view", @"/Views/Pole/Pole.cshtml")]
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
#line 1 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\_ViewImports.cshtml"
using AstarWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\_ViewImports.cshtml"
using AstarWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7030b90088c81c3aea187521384f90b76468873", @"/Views/Pole/Pole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b307ef73928bee9b1418e558ddf992e8e269848e", @"/Views/_ViewImports.cshtml")]
    public class Views_Pole_Pole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AstarWeb.Models.PoleModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("buttonNumber"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Pole", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "HandleButtonClick", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
  
    ViewData["Title"] = "View";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
 using (Html.BeginForm("handleButtonClick", "Pole"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d7030b90088c81c3aea187521384f90b764688735223", async() => {
                WriteLiteral("wyznacz trase");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 10 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 14 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
 for (int i = 0; i < Model.Count(); i++)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
     if (ViewBag.Sciezka != null)
    {
        bool dodaniePola = false;
        for (int j = 0; j < ViewBag.Sciezka.Count; j++)
        {

            if (Model.ElementAt(i).Id == ViewBag.Sciezka[j].Id)
            {
                dodaniePola = true;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div id=\"nr\" class=\"Sciezka\">\r\n                    <div class=\"G\">");
#nullable restore
#line 26 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
                              Write(Html.DisplayFor(modelItem => Model.ElementAt(i).G));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"H\">");
#nullable restore
#line 27 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
                              Write(Html.DisplayFor(modelItem => Model.ElementAt(i).H));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"Rodzic\"> Id= ");
#nullable restore
#line 28 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
                                        Write(Html.DisplayFor(modelItem => Model.ElementAt(i).Id));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                </div>\r\n");
#nullable restore
#line 30 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
            }
        }
        if (dodaniePola == true)
        {

            continue;
        }

    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
     if (i % 10 == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div style=\"clear:both\"></div>\r\n");
#nullable restore
#line 44 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"

    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
     

    if (Model.ElementAt(i).StartKon == 's')
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div id=\"nr\" class=\"PoleS\">\r\n\r\n            <div class=\"G\">");
#nullable restore
#line 51 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
                      Write(Html.DisplayFor(modelItem => Model.ElementAt(i).G));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"H\">");
#nullable restore
#line 52 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
                      Write(Html.DisplayFor(modelItem => Model.ElementAt(i).H));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n            <div class=\"Rodzic\"> Id= ");
#nullable restore
#line 54 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
                                Write(Html.DisplayFor(modelItem => Model.ElementAt(i).Id));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n\r\n        </div>\r\n");
#nullable restore
#line 57 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
        continue;
    }
    if (Model.ElementAt(i).StartKon == 'k')
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div id=\"nr\" class=\"PoleK\">\r\n\r\n            <div class=\"G\">");
#nullable restore
#line 63 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
                      Write(Html.DisplayFor(modelItem => Model.ElementAt(i).G));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"H\">");
#nullable restore
#line 64 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
                      Write(Html.DisplayFor(modelItem => Model.ElementAt(i).H));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n            <div class=\"Rodzic\"> Id= ");
#nullable restore
#line 66 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
                                Write(Html.DisplayFor(modelItem => Model.ElementAt(i).Id));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n\r\n        </div>\r\n");
#nullable restore
#line 69 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
        continue;
    }
    if (Model.ElementAt(i).Osiagalny == true)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div id=\"nr\" class=\"Pole\">\r\n\r\n            <div class=\"G\">");
#nullable restore
#line 75 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
                      Write(Html.DisplayFor(modelItem => Model.ElementAt(i).G));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"H\">");
#nullable restore
#line 76 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
                      Write(Html.DisplayFor(modelItem => Model.ElementAt(i).H));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n            <div class=\"Rodzic\"> Id= ");
#nullable restore
#line 78 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
                                Write(Html.DisplayFor(modelItem => Model.ElementAt(i).Id));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n\r\n        </div>\r\n");
#nullable restore
#line 81 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
        continue;
    }
    if (Model.ElementAt(i).Osiagalny == false)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div id=\"nr\" class=\"PoleP\">\r\n\r\n            <div class=\"G\">");
#nullable restore
#line 87 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
                      Write(Html.DisplayFor(modelItem => Model.ElementAt(i).G));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"H\">");
#nullable restore
#line 88 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
                      Write(Html.DisplayFor(modelItem => Model.ElementAt(i).H));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n            <div class=\"Rodzic\"> Id= ");
#nullable restore
#line 90 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
                                Write(Html.DisplayFor(modelItem => Model.ElementAt(i).Id));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n\r\n        </div>\r\n");
#nullable restore
#line 93 "D:\Dokumenty\studia\PracaDyplomowa\AstarWeb\AstarWeb\Views\Pole\Pole.cshtml"
        continue;


    }









}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AstarWeb.Models.PoleModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
