﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using mission_9_CollinYoung.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission_9_CollinYoung.Infrastructure
{
    [HtmlTargetElement("div", Attributes="page-model")]
    public class pagetaghelp : TagHelper
    {
        //build page links for us

        private IUrlHelperFactory uhf;

        public pagetaghelp(IUrlHelperFactory temp)
        {
            uhf = temp;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        public PageInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public override void Process (TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes["href"] = uh.Action(PageAction, new { pagenum = i });
                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
                    
            }

            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}
