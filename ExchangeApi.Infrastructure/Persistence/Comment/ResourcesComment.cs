using System.Xml.Linq;

namespace ExchangeApi.Infrastructure.Persistence.Comment;

public class ResourcesComment
{
    public static string GetComment(string key)
    {
        var resxPath = Path
            .Combine
                (AppContext.BaseDirectory
                , "DataDictionary.resx");
        
        if (!File.Exists(resxPath))
            throw 
                new 
                FileNotFoundException
                ($"Resx file not found at path: {resxPath}");

        var xdoc = XDocument
                .Load(resxPath);

        var data = xdoc
            .Descendants("data")
            .FirstOrDefault(d => d.Attribute("name")?.Value == key);

        var comment = data?
            .Element("comment")?.Value;

        if (string.IsNullOrEmpty(comment))
            throw new 
                Exception
                ($"No comment found for key '{key}' in {resxPath}");

        return comment;
    }
}
