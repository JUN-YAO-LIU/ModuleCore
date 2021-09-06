#pragma checksum "C:\Users\momom\Desktop\JimCode\MiniProject\lesson\aspnetcore\ModuleCore-main\ModuleCore\Views\TestFunction\GameHub.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d4b1343c163c5b38b9f4a159fae63ff9cc917319"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TestFunction_GameHub), @"mvc.1.0.view", @"/Views/TestFunction/GameHub.cshtml")]
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
#line 1 "C:\Users\momom\Desktop\JimCode\MiniProject\lesson\aspnetcore\ModuleCore-main\ModuleCore\Views\_ViewImports.cshtml"
using ModuleCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\momom\Desktop\JimCode\MiniProject\lesson\aspnetcore\ModuleCore-main\ModuleCore\Views\_ViewImports.cshtml"
using ModuleCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\momom\Desktop\JimCode\MiniProject\lesson\aspnetcore\ModuleCore-main\ModuleCore\Views\_ViewImports.cshtml"
using ModuleCore.Views;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4b1343c163c5b38b9f4a159fae63ff9cc917319", @"/Views/TestFunction/GameHub.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbf0cc32c0e545a44779e8552c3ef4c35a8a09d9", @"/Views/_ViewImports.cshtml")]
    public class Views_TestFunction_GameHub : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\n<html lang=\"en\">\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d4b1343c163c5b38b9f4a159fae63ff9cc9173193613", async() => {
                WriteLiteral("\n    <meta charset=\"UTF-8\">\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n    <title>SignalRPage</title>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d4b1343c163c5b38b9f4a159fae63ff9cc9173194717", async() => {
                WriteLiteral(@"

    <h1>GameHub</h1>

    <div class=""container"">
        <div class=""row"">&nbsp;</div>
        <div class=""row"">
            <div class=""col-2"">User</div>
            <div class=""col-4""><input type=""text"" id=""userInput"" /></div>
        </div>
        <div class=""row"">
            <div class=""col-2"">Message</div>
            <div class=""col-4""><input type=""text"" id=""messageInput"" /></div>
        </div>
        <div class=""row"">&nbsp;</div>
        <div class=""row"">
            <div class=""col-6"">
                <input type=""button"" id=""sendButton"" value=""Send Message"" />
            </div>
            <div class=""col-6"">
                <button type=""submit""><a href=""ShareQRCode"">分享吧</a></button>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-12"">
            <hr />
        </div>
    </div>
    <div class=""row"">
        <div class=""col-6"">
            <ul id=""messagesList""></ul>
        </div>
    </div>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/");
                WriteLiteral(@"microsoft-signalr/3.1.7/signalr.js""></script>
    <script>
        var connection = new signalR.HubConnectionBuilder().withUrl(""/GameHub"").build();

        //Disable send button until connection is established
        document.getElementById(""sendButton"").disabled = true;

        connection.start().then(function () {
            document.getElementById(""sendButton"").disabled = false;
        }).catch(function (err) {
            return console.error(err.toString());
        });

        //接收訊息
        connection.on(""ReceiveMessage"", function (user, message) {
            var li = document.createElement(""li"");
            document.getElementById(""messagesList"").appendChild(li);
            // We can assign user-supplied strings to an element's textContent because it
            // is not interpreted as markup. If you're assigning in any other way, you
            // should be aware of possible script injection concerns.
            li.textContent = `${user} says ${message}`;
        });

        connection.o");
                WriteLiteral(@"n(""RecHub_EnableNextbtn"", function (user, message) {
            li.textContent = `${user} says ${message}`;
        });

        //傳送訊息
        document.getElementById(""sendButton"").addEventListener(""click"", function (event) {
            var user = document.getElementById(""userInput"").value;
            var message = document.getElementById(""messageInput"").value;
            connection.invoke(""SendMessage"", user, message).catch(function (err) {
                return console.error(err.toString());
            });
            event.preventDefault();
        });

    </script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</html>\n\n");
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