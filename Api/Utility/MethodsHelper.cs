using System.Globalization;

namespace Autenticul.Gaming.Api.Utility
{
    public static class MethodsHelper
    {
        public static string FormatSlug(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Înlocuiește cratimele cu spații
            string withSpaces = input.Replace("-", " ");

            // Transformă în Title Case (fiecare cuvânt cu literă mare)
            TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;
            string result = textInfo.ToTitleCase(withSpaces.ToLower());

            return result;
        }
    }
}
