using System;
using System.Text;
using System.Text.RegularExpressions;

// --------------------------------------------------------------------------------------------------
//
// Google Photos Clickable Preview
// -------------------------------
//
// Takes a full URL of a Google Photos image and returns clickable preview,
// which you can use in your Octopress blog.
//
// [example]
// input: dotnet gpcpreview.dll https://lh3.googleusercontent.com/some-photo=w3360-h1488-no
// output: <a href="https://lh3.googleusercontent.com/some-photo=w3360-h1488-no" target="_blank">{% img center https://lh3.googleusercontent.com/some-photo=w700 Description %}</a>
//
// --------------------------------------------------------------------------------------------------

namespace gpcpreview
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = string.Empty;
            
            switch (args.Length)
            {
                case 0:
                    result = "You did not provide the link";
                    break;
                case 1:
                    string link = args[0];
                    if (!IsItCorrectGooglePhotosLink(link))
                        { result = "This thing you've provided doesn't seem to be a correct Google Photos link"; }
                    else
                        { result = MakeClickablePreview(link, 700); }
                    break;
                default:
                    result = "You have provided way too many arguments, there should be only one - the link";
                    break;
            }

            Console.WriteLine(result);
        }

        /// <summary>
        /// Checks, if it is a valid Google Photos link
        /// </summary>
        /// <param name="link">Link to check</param>
        /// <returns>true, if link is valid; false, if link is invalid</returns>
        static bool IsItCorrectGooglePhotosLink(string link)
        {
            string re = @"https:\/\/.*googleusercontent.com\/.*=w\d*-h\d*-no";
            return Regex.Match(link, re).Success;
        }

        /// <summary>
        /// Creates a clickable preview for the provided Google Photos link
        /// </summary>
        /// <param name="link">Link to the original photo</param>
        /// <param name="width">Desired width of the preview</param>
        /// <returns>Clickable Octopress-ready preview</returns>
        static string MakeClickablePreview(string link, int width)
        {
            string preview = $"{link.Substring(0, link.LastIndexOf("=w") + 2)}{width}";
            
            StringBuilder ahref = new StringBuilder();
            ahref.Append($"<a href=\"{link}\" target=\"_blank\">");
            ahref.Append($"{{% img center {preview} Description %}}");
            ahref.Append("</a>");
            
            return ahref.ToString();
        }
    }
}
