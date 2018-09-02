using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace News.Client.Extensions
{
    public static class QueryStringExtension
    {
        public static string ToUrlWithQuery(this string url, NameValueCollection values) =>
            $"{url}{values.ToQueryString()}";

        public static string ToQueryString(this NameValueCollection values)
        {
            var array = values.AllKeys
                .Where(key => values.GetValues(key) != null)
                .Select(key => $"{key?.UrlFriendly()}={values.GetValues(key)[0].UrlFriendly()}");

            return "?" + string.Join("&", array);
        }

        public static string UrlFriendly(this string param) =>
            param == null ? string.Empty : Uri.EscapeDataString(param);

        public static string ToQueryString(this object obj, IEnumerable<string> propertiesFilter = null) =>
            obj.ToNameValueCollection(propertiesFilter).ToQueryString();

        public static NameValueCollection ToNameValueCollection(this object obj, IEnumerable<string> propertiesFilter = null)
        {
            var nameValueCollection = new NameValueCollection();

            if (obj == null) return nameValueCollection;

            var objectProperties = obj.GetType().GetProperties();

            if (propertiesFilter != null)
            {
                objectProperties = objectProperties
                    .Where(property => propertiesFilter.Any(propertyName => propertyName == property.Name))
                    .ToArray();
            }

            foreach (var property in objectProperties)
            {
                nameValueCollection.Add(property.Name, property.GetValue(obj)?.ToString());
            }

            return nameValueCollection;
        }
    }
}