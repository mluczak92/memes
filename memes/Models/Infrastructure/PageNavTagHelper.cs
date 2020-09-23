using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace memes.Models {
    [HtmlTargetElement("nav", Attributes = "page-model")]
    public class PageNavTagHelper : TagHelper {
        private IUrlHelperFactory urlHelperFactory;
        private IUrlHelper urlHelper;
        private TagBuilder ulTag;

        public PageNavTagHelper(IUrlHelperFactory helperFactory) {
            urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PageModel PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();
        public string UlClass { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder navTag = new TagBuilder("nav");
            navTag.AddCssClass("page navigation");

            ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination");
            ulTag.AddCssClass(UlClass);
            navTag.InnerHtml.AppendHtml(ulTag);

            int prev = PageModel.CurrentPage - 1;
            int curr = PageModel.CurrentPage;
            int next = PageModel.CurrentPage + 1;
            int last = PageModel.PagesCount;

            AddButton("first", null, "first", curr > 1);
            AddButton("previous", prev < 2 ? null : (int?)prev, "previous", curr > 1);
            AddButton("current", curr < 2 ? null : (int?)curr, "current", true);
            AddButton("next", Math.Min(next, last), "next", curr < last);
            AddButton("last", PageModel.PagesCount, "last", curr < last);

            output.Content.AppendHtml(navTag.InnerHtml);
        }

        void AddButton(string ariaLabel, int? page, string innerHtml, bool enabled, string liClasses = "") {
            TagBuilder liTag = new TagBuilder("li");
            liTag.AddCssClass("page-item");
            liTag.AddCssClass(liClasses);

            if (!enabled) {
                liTag.AddCssClass("disabled");
            }

            TagBuilder aTag = new TagBuilder("a");
            TagBuilder span1Tag = new TagBuilder("span");
            TagBuilder span2Tag = new TagBuilder("span");

            PageUrlValues["page"] = page;
            aTag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

            aTag.Attributes["aria-label"] = ariaLabel;
            aTag.AddCssClass("page-link");

            span1Tag.Attributes["aria-hidden"] = "true";
            span1Tag.InnerHtml.Append(innerHtml);

            span2Tag.AddCssClass("sr-only");
            span2Tag.InnerHtml.Append(ariaLabel);

            aTag.InnerHtml.AppendHtml(span1Tag);
            aTag.InnerHtml.AppendHtml(span2Tag);
            liTag.InnerHtml.AppendHtml(aTag);
            ulTag.InnerHtml.AppendHtml(liTag);
        }
    }
}
