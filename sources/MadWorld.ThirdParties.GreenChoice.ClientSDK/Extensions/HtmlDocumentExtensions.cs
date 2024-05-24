using HtmlAgilityPack;

namespace MadWorldNL.GreenChoice.Extensions;

public static class HtmlDocumentExtensions
{
    public static string GetValueFromInput(this HtmlDocument doc, string name)
    {
        var node = doc.DocumentNode.SelectNodes($"//input[@name='{name}']").FirstOrDefault();
        return node?.GetAttributeValue("value", "") ?? string.Empty;
    }
}