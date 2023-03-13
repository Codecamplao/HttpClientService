using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClientService
{
    public class HttpHeaderWrapper
    {
        public HttpHeaderWrapper(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class AuthorizeHeader
    {
        public AuthorizeHeader(string type, string value)
        {
            this.Type = type;
            this.Value = value;
        }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
