using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace ECommerse.WebUI.TagHelpers
{
    [HtmlTargetElement("product-list-pager")]
    public class PagingTagHelper:TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }

        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }

        [HtmlAttributeName("current-category")]
        public int CurrentCategory { get; set; }

        
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }
       
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            var sb = new StringBuilder();

            if (PageCount > 1)
            {
                sb.Append("<ul class='pagination'>");

                if (CurrentPage > 1)
                {
                    sb.AppendFormat("<li class='page-item'><a class='page-link' href='/product/index?page={0}&category={1}'>&laquo; Prev</a></li>", CurrentPage - 1, CurrentCategory);
                }

                for (int i = 1; i <= PageCount; i++)
                {
                    var itemClass = (i == CurrentPage) ? "page-item active" : "page-item";
                    sb.AppendFormat("<li class='{0}'><a class='page-link' href='/product/index?page={1}&category={2}'>{3}</a></li>", itemClass, i, CurrentCategory, i);
                }

                if (CurrentPage < PageCount)
                {
                    sb.AppendFormat("<li class='page-item'><a class='page-link' href='/product/index?page={0}&category={1}'>Next &raquo;</a></li>", CurrentPage + 1, CurrentCategory);
                }

                sb.Append("</ul>");
            }

            output.Content.SetHtmlContent(sb.ToString());
        }


    }
}
