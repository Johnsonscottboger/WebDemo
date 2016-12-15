using System;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Web.Data.Paging
{
    /// <summary>
    /// 分页控件
    /// </summary>
    public class PagingLinks : TagHelper
    {
        public PagingInfo pagingInfo { get; set; }
        public Func<long,string> pageUrl { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (pagingInfo == null)
            {
                return;
            }

            Int64 i = 1;
            Int32 showPage = 11;
            Int32 midelPage = 6;
            var builder = new StringBuilder();
           
            if (!(pagingInfo.CurrentPage - 1 >= 1))
            {
                builder.Append("<li class=\"disable\"><a aria-lable = \"Previous\">首页</a></li>");
            }
            else
            {
                builder.Append("<li><a aria-lable = \"Previous\">首页</a></li>");
            }

            #region 生成页码
            //总页数小于等于显示页数
            if (pagingInfo.TotalPages <= showPage)
            {
                i = 1;
                string tagBuilder = string.Empty;
                for (; i < pagingInfo.TotalPages; i++)
                {
                    if (i != pagingInfo.CurrentPage)
                    {
                        tagBuilder = $"<li><a>{i}</a></li>";
                    }
                    else
                    {
                        tagBuilder = $"<li class=\"active \"><a class=\"selected\">{i}</a></li>";
                    }
                    builder.Append(tagBuilder);
                }
            }
            //总页数大于显示页数
            else if (pagingInfo.TotalPages > showPage)
            {
                //当前页小于中间页
                if (pagingInfo.CurrentPage <= midelPage)
                {
                    i = 1;
                    string tagBuilder = string.Empty;
                    for (; i < showPage; i++)
                    {
                        if (i != pagingInfo.CurrentPage)
                        {
                            tagBuilder = $"<li><a>{i}</a></li>";
                        }
                        else
                        {
                            tagBuilder = $"<li class=\"active \"><a class=\"selected\">{i}</a></li>";
                        }
                        builder.Append(tagBuilder);
                    }
                }
                //当前页大于中间页
                else if (pagingInfo.CurrentPage > midelPage && pagingInfo.TotalPages - pagingInfo.CurrentPage >= midelPage)
                {
                    i = pagingInfo.CurrentPage - midelPage + 1;
                    string tagBuilder = string.Empty;
                    for (; i < pagingInfo.CurrentPage + midelPage - 1; i++)
                    {
                        if (i != pagingInfo.CurrentPage)
                        {
                            tagBuilder = $"<li><a>{i}</a></li>";
                        }
                        else
                        {
                            tagBuilder = $"<li class=\"active \"><a class=\"selected\">{i}</a></li>";
                        }
                        builder.Append(tagBuilder);
                    }
                }
                else if (pagingInfo.TotalPages - pagingInfo.CurrentPage < midelPage)
                {
                    i = pagingInfo.CurrentPage - midelPage + 1;
                    string tagBuilder = string.Empty;
                    for (; i <= pagingInfo.TotalPages; i++)
                    {
                        if (i != pagingInfo.CurrentPage)
                        {
                            tagBuilder = $"<li><a>{i}</a></li>";
                        }
                        else
                        {
                            tagBuilder = $"<li class=\"active \"><a class=\"selected\">{i}</a></li>";
                        }
                        builder.Append(tagBuilder);
                    }
                }
            }
            #endregion

            if (!(pagingInfo.CurrentPage + 1 <= pagingInfo.TotalPages))
            {
                builder.Append("<li class=\"disable\"><a aria-lable = \"Next\">尾页</a></li>");
            }
            else
            {
                builder.Append("<li><a aria-lable = \"Next\">尾页</a></li>");
            }

            output.TagName = "ul";
            output.Attributes.Add("class", "pagination");
            output.Content.SetHtmlContent(builder.ToString());
        }
    }

    #region MvcHtmlString扩展
    //public static class PagingLinks
    //{
    //    public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<long, string> pageUrl)
    //    {
    //        long i = 1;
    //        int showPage = 11;
    //        int midelPPage = 6;

    //        StringBuilder result = new StringBuilder();
    //        TagBuilder tag_li_previous = new TagBuilder("li");
    //        TagBuilder tag_a_previous = new TagBuilder("a");
    //        TagBuilder tag_span_previous = new TagBuilder("span");
    //        tag_span_previous.MergeAttribute("aria-hidden", "true");
    //        tag_span_previous.InnerHtml = "&laquo;";
    //        if (pagingInfo.CurrentPage - 1 >= 1)
    //        {
    //            //tag_a_previous.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage - 1));
    //        }
    //        else
    //        {
    //            tag_li_previous.AddCssClass("disabled");
    //        }
    //        tag_a_previous.MergeAttribute("aria-lable", "Previous");
    //        //tag_a_previous.InnerHtml = tag_span_previous.ToString();
    //        tag_a_previous.InnerHtml = "首页";
    //        tag_li_previous.InnerHtml = tag_a_previous.ToString();
    //        result.Append(tag_li_previous.ToString());

    //        //总页数小等于显示页数
    //        if (pagingInfo.TotalPages <= showPage)
    //        {
    //            i = 1;
    //            for (; i < pagingInfo.TotalPages; i++)
    //            {
    //                TagBuilder tag_li = new TagBuilder("li");
    //                TagBuilder tag_a = new TagBuilder("a");
    //                //tag_a.MergeAttribute("href", pageUrl(i));
    //                tag_a.InnerHtml = i.ToString();
    //                if (i == pagingInfo.CurrentPage)
    //                {
    //                    tag_li.AddCssClass("active");
    //                    tag_a.AddCssClass("selected");
    //                }

    //                tag_li.InnerHtml = tag_a.ToString();
    //                result.Append(tag_li.ToString());
    //            }
    //        }
    //        //总页数大于显示页数
    //        else if (pagingInfo.TotalPages > showPage)
    //        {
    //            //当前页小于中间页
    //            if (pagingInfo.CurrentPage <= midelPPage)
    //            {
    //                i = 1;
    //                for (; i <= showPage; i++)
    //                {
    //                    TagBuilder tag_li = new TagBuilder("li");
    //                    TagBuilder tag_a = new TagBuilder("a");
    //                    //tag_a.MergeAttribute("href", pageUrl(i));
    //                    tag_a.InnerHtml = i.ToString();
    //                    if (i == pagingInfo.CurrentPage)
    //                    {
    //                        tag_li.AddCssClass("active");
    //                        tag_a.AddCssClass("selected");
    //                    }

    //                    tag_li.InnerHtml = tag_a.ToString();
    //                    result.Append(tag_li.ToString());
    //                }
    //            }
    //            //当前页大于中间页
    //            else if (pagingInfo.CurrentPage > midelPPage && pagingInfo.TotalPages - pagingInfo.CurrentPage >= midelPPage)
    //            {
    //                i = pagingInfo.CurrentPage - midelPPage + 1;
    //                for (; i <= pagingInfo.CurrentPage + midelPPage - 1; i++)
    //                {
    //                    TagBuilder tag_li = new TagBuilder("li");
    //                    TagBuilder tag_a = new TagBuilder("a");
    //                    //tag_a.MergeAttribute("href", pageUrl(i));
    //                    tag_a.InnerHtml = i.ToString();
    //                    if (i == pagingInfo.CurrentPage)
    //                    {
    //                        tag_li.AddCssClass("active");
    //                        tag_a.AddCssClass("selected");
    //                    }

    //                    tag_li.InnerHtml = tag_a.ToString();
    //                    result.Append(tag_li.ToString());
    //                }
    //            }
    //            else if (pagingInfo.TotalPages - pagingInfo.CurrentPage < midelPPage)
    //            {
    //                i = pagingInfo.CurrentPage - midelPPage + 1;
    //                for (; i <= pagingInfo.TotalPages; i++)
    //                {
    //                    TagBuilder tag_li = new TagBuilder("li");
    //                    TagBuilder tag_a = new TagBuilder("a");
    //                    //tag_a.MergeAttribute("href", pageUrl(i));
    //                    tag_a.InnerHtml = i.ToString();
    //                    if (i == pagingInfo.CurrentPage)
    //                    {
    //                        tag_li.AddCssClass("active");
    //                        tag_a.AddCssClass("selected");
    //                    }

    //                    tag_li.InnerHtml = tag_a.ToString();
    //                    result.Append(tag_li.ToString());
    //                }
    //            }
    //        }

    //        TagBuilder tag_li_next = new TagBuilder("li");
    //        TagBuilder tag_a_next = new TagBuilder("a");
    //        TagBuilder tag_span_next = new TagBuilder("span");
    //        tag_span_next.MergeAttribute("aria-hidden", "true");
    //        tag_span_next.InnerHtml = "&raquo;";
    //        if (pagingInfo.CurrentPage + 1 <= pagingInfo.TotalPages)
    //        {
    //            //tag_a_next.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage + 1));
    //        }
    //        else
    //        {
    //            tag_li_next.AddCssClass("disabled");
    //        }
    //        tag_a_next.MergeAttribute("aria-lable", "Next");
    //        //tag_a_next.InnerHtml = tag_span_next.ToString();
    //        tag_a_next.InnerHtml = "尾页";

    //        tag_li_next.InnerHtml = tag_a_next.ToString();
    //        result.Append(tag_li_next.ToString());
    //        return MvcHtmlString.Create(result.ToString());
    //    }
    //}
    #endregion
}
