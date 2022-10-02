using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Windows;

namespace Clasess
{
    public class Loader
    {
        public HtmlDocument Load(Uri uri)
        {
            try
            {
                WebRequest webRequest = WebRequest.Create(uri);
                using WebResponse NewListResponse = webRequest.GetResponse();
                using Stream stream = NewListResponse.GetResponseStream();
                HtmlDocument document = new HtmlDocument();
                document.Load(stream);
                return document;
            } 
            catch (Exception e) 
            {
                MessageBox.Show($"При загрузки html документа произошла ошибка {e.Message}", "Ошибка");
                return null;
            }
        }
    }
}
