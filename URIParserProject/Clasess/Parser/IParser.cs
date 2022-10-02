using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace Clasess
{
    public interface IParser
    {
        List<Record> Parse(HtmlDocument document, Uri baseUri, out int count);
    }
}
