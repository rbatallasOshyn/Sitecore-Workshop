using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Workshop.Foundation.SitecoreExtensions.Extensions
{
    public static class StringExtensions
    {
        public static string Humanize(this string input)
        {
            return Regex.Replace(input, "(\\B[A-Z])", " $1");
        }

        public static string ToCssUrlValue(this string url)
        {
            return string.IsNullOrWhiteSpace(url) ? "none" : $"url('{url}')";
        }
        public static string GetItemCustomName(this string name)
        {
            return name.Replace(" ", "");
        }

        public static string StripHTMLTags(this string value)
        {
            return Regex.Replace(value, "<.*?>", string.Empty);
        }
        public static string LimitedWords(this string value, int? count)
        {
            var wordCount = count ?? 30;
            if (!string.IsNullOrEmpty(value) && value.Length > wordCount)
            {
                var text = value.StripHTMLTags();
                var topWords = text.Split(' ').Take(wordCount);

                return string.Join(" ", topWords);
            }
            return value;
        }
    }
}