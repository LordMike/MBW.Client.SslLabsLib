using System;
using System.Text;
using System.Web;

namespace MBW.Client.SslLabsLib.Helpers;

internal class UrlBuilder
{
    private readonly StringBuilder _uri;
    private bool _firstParam = true;

    public UrlBuilder(string endpoint)
    {
        _uri = new StringBuilder();
        _uri.Append(endpoint);
    }

    public UrlBuilder AddParam(string key, string value)
    {
        if (_firstParam)
        {
            _uri.Append("?");
            _firstParam = false;
        }
        else
            _uri.Append("&");

        _uri.Append(key)
            .Append("=")
            .Append(HttpUtility.UrlEncode(value));

        return this;
    }

    public Uri Build()
    {
        return new Uri(_uri.ToString(), UriKind.Relative);
    }
}