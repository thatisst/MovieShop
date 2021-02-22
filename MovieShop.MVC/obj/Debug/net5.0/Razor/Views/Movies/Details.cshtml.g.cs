#pragma checksum "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "897772d610b59ed0e1675afe7028ffa2712f0e51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Details), @"mvc.1.0.view", @"/Views/Movies/Details.cshtml")]
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
#line 1 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\_ViewImports.cshtml"
using MovieShop.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\_ViewImports.cshtml"
using MovieShop.MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"897772d610b59ed0e1675afe7028ffa2712f0e51", @"/Views/Movies/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53ed27a90769d57c4cf1e99ddf07e56b08d479e3", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieShop.Core.Models.Response.MovieDetailsResponseModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<style>\r\n    .jumbotron {\r\n        background-image: url(\"");
#nullable restore
#line 4 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                          Write(Model.BackdropUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""");
        background-size: cover;
        /*backdrop-filter: blur(6px);*/
        color: white;
    }
</style>

<div class=""bg-light"">
    <div class=""container"">

        <div class=""jumbotron"">
            <div class=""row"">
                <div class=""col-4 "">

                    <img");
            BeginWriteAttribute("src", " src=\"", 445, "\"", 467, 1);
#nullable restore
#line 18 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 451, Model.PosterUrl, 451, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 468, "\"", 486, 1);
#nullable restore
#line 18 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 474, Model.Title, 474, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"rounded img-fluid\" />\r\n                </div>\r\n\r\n                <div class=\"col-4\">\r\n                    <h1>");
#nullable restore
#line 22 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                   Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                    <h5>");
#nullable restore
#line 23 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                   Write(Model.Tagline);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <h6>");
#nullable restore
#line 24 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                   Write(Model.RunTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" m | ");
#nullable restore
#line 24 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                                      Write(Model.ReleaseDate.Value.ToString("yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h6>\r\n");
#nullable restore
#line 25 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                     foreach (var genre in Model.Genres)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"badge badge-dark badge-pill\"> ");
#nullable restore
#line 27 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                                                              Write(genre.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n");
#nullable restore
#line 28 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n                    <h3><span class=\"badge badge-warning badge-pill\"> Rating: 8.3 </span></h3>\r\n                    <p>\r\n                        ");
#nullable restore
#line 34 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                   Write(Model.Overview);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                </div>

                <div class=""col-4"">
                    <ul class=""list-group list"">
                        <li class=""list-group-item d-flex justify-content-start align-items-center"">
                            <button class=""btn btn-dark btn-outline-light btn-block"">
                                REVIEW
                            </button>
                        </li>
                        <li class=""list-group-item d-flex justify-content-start align-items-center"">
                            <button class=""btn btn-dark btn-outline-light btn-block"">
                                TRAILER
                            </button>
                        </li>
                        <li class=""list-group-item d-flex justify-content-start align-items-center"">
                            <button class=""btn btn-light btn-block"">
                                BUY $ ");
#nullable restore
#line 52 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                                 Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </button>
                        </li>
                        <li class=""list-group-item d-flex justify-content-start align-items-center"">
                            <button class=""btn btn-light btn-block"">
                                WATCH MOVIE
                            </button>
                        </li>
                    </ul>
                </div>
            </div>
            


            

        </div>

        <div class=""row"">
            <div class=""col-4"">
                <h3>
                    MOVIE FACTS
                </h3>
                <ul class=""list-group list-group-flush"">
                    <li class=""list-group-item d-flex justify-content-start align-items-center"">
                        Release Date
                        <span class=""badge badge-dark badge-pill""> ");
#nullable restore
#line 78 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                                                              Write(Model.ReleaseDate.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                    </li>\r\n                    <li class=\"list-group-item d-flex justify-content-start align-items-center\">\r\n                        Run Time\r\n                        <span class=\"badge badge-dark badge-pill\"> ");
#nullable restore
#line 82 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                                                              Write(Model.RunTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" m</span>\r\n                    </li>\r\n                    <li class=\"list-group-item d-flex justify-content-start align-items-center\">\r\n                        Box Office\r\n                        <span class=\"badge badge-dark badge-pill\"> $ ");
#nullable restore
#line 86 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                                                                Write(Model.Revenue);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </li>\r\n                    <li class=\"list-group-item d-flex justify-content-start align-items-center\">\r\n                        Budget\r\n                        <span class=\"badge badge-dark badge-pill\"> $ ");
#nullable restore
#line 90 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                                                                Write(Model.Budget);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </li>\r\n\r\n                </ul>\r\n            </div>\r\n            <div class=\"col-8\">\r\n                <h3>\r\n                    CAST\r\n                </h3>\r\n                <table class=\"table\">\r\n");
#nullable restore
#line 100 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                     foreach (var cast in Model.Casts)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr class=\"d-sm-table-row\">\r\n                            <td><img");
            BeginWriteAttribute("src", " src=\"", 4151, "\"", 4174, 1);
#nullable restore
#line 103 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 4157, cast.ProfilePath, 4157, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 4175, "\"", 4191, 1);
#nullable restore
#line 103 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 4181, cast.Name, 4181, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\" cast-small-img rounded-circle\"/></td>\r\n                            <td>");
#nullable restore
#line 104 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                           Write(cast.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 105 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                           Write(cast.Character);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>                       \r\n                        </tr>\r\n");
#nullable restore
#line 107 "C:\Users\Stell\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </table>\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n\r\n    \r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MovieShop.Core.Models.Response.MovieDetailsResponseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
