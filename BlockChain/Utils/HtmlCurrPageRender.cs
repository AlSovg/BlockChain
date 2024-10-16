using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlockChain.Utils;

public static class HtmlCurrPageRender
{
    public static IHtmlContent GetCurrPageHtml(this IHtmlHelper helper, string? url)
    {
        var htmlStringBuilder = new StringBuilder();
        var href = url?.Split('/');
        var currPageHtml = href?.LastOrDefault();
        htmlStringBuilder.Append(currPageHtml);
        
        return new HtmlString(htmlStringBuilder.ToString());
    }
}