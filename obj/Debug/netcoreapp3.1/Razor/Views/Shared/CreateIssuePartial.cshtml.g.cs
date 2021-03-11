#pragma checksum "C:\Users\User\OneDrive\Desktop\Web_3\Views\Shared\CreateIssuePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b4a80222c43fdc4e8aa26dfc02bd43371f87492"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_CreateIssuePartial), @"mvc.1.0.view", @"/Views/Shared/CreateIssuePartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b4a80222c43fdc4e8aa26dfc02bd43371f87492", @"/Views/Shared/CreateIssuePartial.cshtml")]
    public class Views_Shared_CreateIssuePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""container"">
    <div class=""row"">
        <button type=""button"" id=""myBtn"" class=""col-md-12 btn-link btn-lg"" style=""outline: none; margin-bottom: 35px"">Создать задачу</button>

        <div class=""modal fade"" id=""myModal"" role=""dialog"">
            <div class=""modal-dialog"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                        <h4 class=""modal-title"">Создание задачи</h4>
                    </div>
                    <div class=""modal-body"">
                        <div class=""form-group"">
                            <label>Название</label>
                            <input placeholder=""Введите название задачи"" class=""form-control"" type=""text"" id=""issueName""/>
                        </div>
                        <div class=""form-group"">
                            <label>Описание</label>
                            <tex");
            WriteLiteral(@"tarea placeholder=""Введите описание задачи"" class=""form-control"" rows=""4"" style=""resize: none"" id=""issueText""></textarea>
                        </div>
                        <div class=""form-group"">
                            <label class=""form-check-label"">Выполнено</label>
                            <input type=""checkbox"" class=""form-check-input"" id=""isComplited""/>
                        </div>
                        <div class=""form-group"" style=""margin-left: 82%"">
                            <input type=""submit"" class=""btn btn-primary"" value=""Сохранить"" id=""confirmEdit""/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<script>
$(document).ready(function(){
  $(""#myBtn"").click(function(){
    $(""#myModal"").modal();
  });
});
</script>
<script type=""text/javascript"">
        $(""#confirmCreate"").click(function() {
            const name = $(""#issueName"").val();
            const descr = $(""");
            WriteLiteral(@"#issueText"").val();
            const isComplite = $(""#isComplited"").val();
            $.ajax({
              url: 'Issues/AddIssue',
              type: ""POST"",
              data: {issueName: name, issueText: descr, isComplited: isComplite},
              success: function(data) {
                $('#issues').html(data);
                $(""#myModal"").modal('hide');
              }
            });
          });
</script>");
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