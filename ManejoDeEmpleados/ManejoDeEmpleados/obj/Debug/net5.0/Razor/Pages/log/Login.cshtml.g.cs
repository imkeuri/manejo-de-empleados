#pragma checksum "C:\Users\keury\Desktop\manejo-de-empleados-dev\manejo-de-empleados-dev\ManejoDeEmpleados\ManejoDeEmpleados\Pages\log\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d62b25dc6a423eb616c665d4ae589bcf7fbc567"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ManejoDeEmpleados.Pages.log.Pages_log_Login), @"mvc.1.0.razor-page", @"/Pages/log/Login.cshtml")]
namespace ManejoDeEmpleados.Pages.log
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
#line 1 "C:\Users\keury\Desktop\manejo-de-empleados-dev\manejo-de-empleados-dev\ManejoDeEmpleados\ManejoDeEmpleados\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\keury\Desktop\manejo-de-empleados-dev\manejo-de-empleados-dev\ManejoDeEmpleados\ManejoDeEmpleados\Pages\_ViewImports.cshtml"
using ManejoDeEmpleados;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\keury\Desktop\manejo-de-empleados-dev\manejo-de-empleados-dev\ManejoDeEmpleados\ManejoDeEmpleados\Pages\_ViewImports.cshtml"
using ManejoDeEmpleados.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/log/login")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d62b25dc6a423eb616c665d4ae589bcf7fbc567", @"/Pages/log/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49eaca4c1202a4f591fda601736453c4e4649083", @"/Pages/_ViewImports.cshtml")]
    public class Pages_log_Login : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/pages/Dashboard"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 114, "\"", 152, 1);
#nullable restore
#line 6 "C:\Users\keury\Desktop\manejo-de-empleados-dev\manejo-de-empleados-dev\ManejoDeEmpleados\ManejoDeEmpleados\Pages\log\Login.cshtml"
WriteAttributeValue("", 121, Url.Content("~/css/Index.css"), 121, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\"/>\r\n");
            }
            );
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""card text-center"" style=""padding: 20px;"">
         <h3><strong>Iniciar sesion</strong> </h3>
                <div class=""mb-3 form-group"" style=""text-align: start;"">
                    <input  type=""text"" class=""form-control"" placeholder=""User""  required>               
                </div>
                <div class="" mb-3 form-group"" style=""text-align: start;"">
                    <input type=""password"" class=""form-control"" placeholder=""Password"" required>
                </div>
                <div class=""mb-3 form-group"">            
                     ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d62b25dc6a423eb616c665d4ae589bcf7fbc5675280", async() => {
                WriteLiteral("<button class=\"btn btn-primary me-2\" type=\"submit\" >Entrar</button>");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"    
                    <a href=""javascript:history.go(-1)""><button class=""btn btn-outline-secondary"" >Volver</button></a>
                </div>
                <div class=""form-group"">
                    <a style=""color: #dc3545; cursor: pointer;"" href=""/log/register"">Crear usuario</a>
                </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ManejoDeEmpleados.Pages.Login_y_Register.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ManejoDeEmpleados.Pages.Login_y_Register.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ManejoDeEmpleados.Pages.Login_y_Register.IndexModel>)PageContext?.ViewData;
        public ManejoDeEmpleados.Pages.Login_y_Register.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
