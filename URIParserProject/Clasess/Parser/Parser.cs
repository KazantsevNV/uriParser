using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace Clasess
{
    public class Parser : IParser
    {
        private const string _parseTag = "//a";

        public List<Record> Parse(HtmlDocument document, Uri baseUri, out int count) 
        {
            var nodes = document.DocumentNode.SelectNodes(_parseTag);
            count = nodes.Count;
            var dictionary = CreateDictionary(nodes, baseUri);
            return ConvertToListRecord(dictionary);
        }

        private Dictionary<Uri, int> CreateDictionary(HtmlNodeCollection nodes, Uri baseUri) 
        {
            Dictionary<Uri, int> recordDictionary = new Dictionary<Uri, int>();
            foreach (HtmlNode node in nodes)
            {
                var href = node.GetAttributeValue("href", "");

                var newUri = new Uri(baseUri, href);
                if (recordDictionary.ContainsKey(newUri))
                {
                    recordDictionary[newUri] += 1;
                }
                else
                {
                    recordDictionary.Add(newUri, 1);
                }
            }
            return recordDictionary;
        }

        private List<Record> ConvertToListRecord(Dictionary<Uri, int> recordDictionary) 
        {
            List<Record> records = new List<Record>();
            foreach (KeyValuePair<Uri, int> keyValuePair in recordDictionary) 
            {
                records.Add(new Record(keyValuePair.Key, keyValuePair.Value));
            }
            return records;
        }
    }
}
