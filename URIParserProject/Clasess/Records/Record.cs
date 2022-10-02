using System;

namespace Clasess
{
    public class Record
    {
        public Uri Uri { get; set; }
        public int Count { get; set; }

        public Record(Uri uri, int count) 
        {
            Uri = uri;
            Count = count;
        }

        public override string ToString()
        {
            return $"{Uri}  {Count}";
        }
    }
}
