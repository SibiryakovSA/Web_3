#pragma checksum "C:\Users\User\OneDrive\Desktop\Web_3\Views\Shared\CommentsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a6a6a1b2e8efd084d5979ded4815f0ac1a32783"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_CommentsPartial), @"mvc.1.0.view", @"/Views/Shared/CommentsPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a6a6a1b2e8efd084d5979ded4815f0ac1a32783", @"/Views/Shared/CommentsPartial.cshtml")]
    public class Views_Shared_CommentsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IQueryable<Web_3_6.Models.DataBase.Classes.Comment>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    \r\n");
#nullable restore
#line 3 "C:\Users\User\OneDrive\Desktop\Web_3\Views\Shared\CommentsPartial.cshtml"
 foreach (var comment in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>");
#nullable restore
#line 5 "C:\Users\User\OneDrive\Desktop\Web_3\Views\Shared\CommentsPartial.cshtml"
  Write(comment.commentText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 6 "C:\Users\User\OneDrive\Desktop\Web_3\Views\Shared\CommentsPartial.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IQueryable<Web_3_6.Models.DataBase.Classes.Comment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
