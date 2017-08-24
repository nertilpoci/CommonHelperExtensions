using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace HelperExtensions.String
{
    public static class Extensions
    {
        /// <summary>
        /// Reverse the order of the string
        /// </summary>
        /// <returns>The reversed string</returns>
        public static string Reverse(this string value)
        {
            char[] chars = value.ToCharArray();
            int length = chars.Length;
            for (int i = 0; i <= (length / 2) - ((length % 2 == 0) ? 1 : 0); i++)
            {
                var temp = chars[i];
                chars[i] = chars[length - i - 1];
                chars[length - i - 1] = temp;
            }
            return new string(chars);
           
        }
        /// <summary>
        /// Check if the string is the same if it were reversed
        /// </summary>
        /// <returns>boolean status</returns>
        public static bool IsPalindrome(this string value)
        {
            return value == value.Reverse();
        }
        /// <summary>
        /// Convert string into its byte represantation of string
        /// </summary>
        /// <returns>Array of bytes</returns>
        public static byte[] GetByteArray(this string value)
        {
            return Encoding.Unicode.GetBytes(value);
        }
        /// <summary>
        /// Make every word start with uppecase letter
        /// </summary>
        public static string ToTitleCase(this string value)
        {
            char[] splitchar = { ' ' };
            string[] words = value.Split(splitchar);
            for (int i = 0; i < words.Length; i++)
            {
                char[] chars = words[i].ToCharArray();
                if (chars.Length > 0) chars[0] = chars[0].ToString().ToUpper()[0];
                words[i] = new string(chars);
            }
            return string.Join(" ", words);

        }
        /// <summary>
        /// Count occurences of a string within a string
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>Number of occurences</returns>
        public static int CountOccurences(this string value, string searchString)
        {
            Regex rex = new Regex(searchString);
            return rex.Matches(value).Count;
        }
        /// <summary>
        /// Count number of words in a sentence
        /// </summary>
        /// <returns>Number of words found</returns>
        public static int WordCount(this string value)
        {
            MatchCollection words = System.Text.RegularExpressions.Regex.Matches(value, @"[\S]+");
            return words.Count;
        }
        /// <summary>
        /// Get base64 represantation of a string
        /// </summary>
        public static string ToBase64(this string value)
        {
            return Convert.ToBase64String(value.GetByteArray());
        }
        /// <summary>
        /// Convert back from base64 to normal text
        /// </summary>
        public static string FromBase64(this string value)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }
        /// <summary>
        /// Cheeck if a given string is a number
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumber(this string value)
        {
            return Int32.TryParse(value,out int i);
        }
        /// <summary>
        /// Get the abrevation of a long name or seences
        /// </summary>
        /// <param name="denominator">Character between letters</param>
        public static string Abrevation(this string value,string denominator=".")
        {
            var result= value.Split(' ').Aggregate("", (x, y) => x += denominator+ y[0]).ToUpper();
            return result.Length > 0 ? result.Substring(1) : result;
        }
        /// <summary>
        /// Mask a string from the end backwards
        /// </summary>
        /// <param name="charCount">How many characters to mask</param>
        /// <param name="mask">The mask character</param>
        public static string MaskLastXChars(this string value,int charCount,char mask='*')
        {
           
            if (charCount < 0) throw new InvalidDataException("Character count cannot be negative");
            if (charCount >= value.Length) return "".PadLeft(value.Length, mask);
            var visibleValue = value.Substring(0,  value.Length- charCount);
            return visibleValue.PadRight(visibleValue.Length + charCount, mask);
        }
        /// <summary>
        /// Mask a string from the begining forward
        /// </summary>
        /// <param name="charCount">How many characters to mask</param>
        /// <param name="mask">The mask character</param>
        public static string MaskFirstXChars(this string value, int charCount, char mask = '*')
        {
            if (charCount < 0) throw new InvalidDataException("Character count cannot be negative");
            if (charCount >= value.Length) return "".PadLeft(value.Length, mask);
            var visibleValue = value.Substring(charCount);
            return visibleValue.PadLeft(visibleValue.Length + charCount, mask);
        }
        /// <summary>
        /// Mask a string from both directions
        /// </summary>
        /// <param name="charCount">Number of characters you want to mask in both directions</param>
        /// <param name="mask">Character to mask with</param>
        /// <returns></returns>
        public static string MaskFirstAndLastXChars(this string value, int charCount, char mask = '*')
        {
            if (charCount < 0) throw new InvalidDataException("Character count cannot be negative");
            if (charCount >= value.Length || charCount*2>=value.Length) return "".PadLeft(value.Length, mask);
            var visibleValue = value.Substring(charCount, value.Length - charCount*2);
            var rightPad = visibleValue.PadRight(visibleValue.Length + charCount, mask);
            var leftPad = rightPad.PadLeft(rightPad.Length + charCount, mask);
            return leftPad;
        }
        /// <summary>
        /// Get the number of Vowels fround in text
        /// </summary>
        /// <param name="vowels">Vowels change this if you want another language other than English</param>
        public static int NumberOfVowels(this string value,string vowels= "aeiou")
        {
            return value.Count(c => vowels.Contains(Char.ToLower(c)));
        }
        /// <summary>
        /// Write text to file using BinaryWriter
        /// </summary>
        /// <param name="fileName">What file to write to</param>
        /// <param name="mode">Write mode</param>
        public static void WriteToDisk(this string value, string fileName,FileMode mode=FileMode.OpenOrCreate)
        {    
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, mode)))
                {
                    writer.Write(value);
                }         
        }
        /// <summary>
        /// Get number of lines in a text
        /// </summary>
        public static long LineCount(this string value)
        {
            long count = 1;
            int start = 0;
            while ((start = value.IndexOf('\n', start)) != -1)
            {
                count++;
                start++;
            }
            return count;
        }

        /// <summary>
        /// Escape a string, escape special characters
        /// </summary>
        public static string Escape(this string value)
        {
            return Regex.Escape(value);
        }
        /// <summary>
        /// Unescape previously escaped string
        /// </summary>
        public static string UnEscape(this string value)
        {
            return Regex.Unescape(value);
        }
        /// <summary>
        /// Calculate string similarity using The Levenshtein Method
        /// </summary>
        /// <param name="value2">text to compare too</param>
        public static double Similarity(this string value,string value2)
        {
            return CalculateSimilarity(value,value2);
        }
        static int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }
        static double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            int stepsToSame = ComputeLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }
        /// <summary>
        /// Check if a specific text is a valid email address
        /// </summary>
        public static bool IsEmail(this string input)
        {
            var match = Regex.Match(input,
              @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            return match.Success;
        }  
       
        /// <summary>
        /// Extract email address from text
        /// </summary>
        public static string ExtractEmail(this string input)
        {
            if (input == null || string.IsNullOrWhiteSpace(input)) return string.Empty;

            var match = Regex.Match(input, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            return match.Success ? match.Value : string.Empty;
        }
        /// <summary>
        /// Get values from querystrings
        /// </summary>
        /// <param name="paramName"></param>
        public static string GetQueryStringParamValue(this string queryString, string paramName)
        {
            if (string.IsNullOrWhiteSpace(queryString) || string.IsNullOrWhiteSpace(paramName)) return string.Empty;
            var query = queryString.Replace("?", "");
            if (!query.Contains("=")) return string.Empty;
            var queryValues = query.Split('&').Select(piQ => piQ.Split('=')).ToDictionary(
              piKey => piKey[0].ToLower().Trim(), piValue => piValue[1]);
            string result;
            var found = queryValues.TryGetValue(paramName.ToLower().Trim(), out result);
            return found ? result : string.Empty;
        }
        /// <summary>
        /// Determine if a string is a valid ip v4 address
        /// </summary>
        public static bool IsIPV4Address(this string input)
        {
            IPAddress address;
            if (IPAddress.TryParse(input, out address))
            {
                return address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork;
            }
            return false;
        }
        /// <summary>
        /// Determine if a string is a valid ip v6 address
        /// </summary>
        public static bool IsIPV6Address(this string input)
        {
            IPAddress address;
            if (IPAddress.TryParse(input, out address))
            {
                return address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6;
            }
            return false;
        }
        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        /// <summary>
        /// Parse and get the enum value for a giving type from text
        /// </summary>
        /// <typeparam name="TEnum">Type of enum</typeparam>
        public static TEnum ToEnum<TEnum>(this string input){
           return ParseEnum<TEnum>(input);
        }
        /// <summary>
        /// Check if a given string is a valid guid value
        /// </summary>
        public static bool IsGuid(this string input)
        {
            return Guid.TryParse(input, out Guid result);
        }
        /// <summary>
        /// Check if string is a valid url
        /// </summary>
        public static bool IsValidUrl(this string input) 
        {
            var isMatch = new Regex(@"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$");
            return isMatch.IsMatch(input);
           
        }
        /// <summary>
        /// Convert text to Seo slug url
        /// </summary>
        public static string ToSlug(this string input) {
            string value = input.Normalize(NormalizationForm.FormD).Trim();
            StringBuilder builder = new StringBuilder();
            foreach (char c in value.ToCharArray())
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark) builder.Append(c);
            value = builder.ToString(); byte[] bytes = Encoding.ASCII.GetBytes(value);
            value = Regex.Replace(Regex.Replace(Encoding.ASCII.GetString(bytes), @"\s{2,}|[^\w]", " ", RegexOptions.ECMAScript).Trim(), @"\s+", "_");
            return value.ToLowerInvariant(); }
        /// <summary>
        /// Make word plural
        /// </summary>
        public static string ToPlural(this string singular)
        {
            int index = singular.LastIndexOf(" of ");
            if (index > 0) return (singular.Substring(0, index)) + singular.Remove(0, index).ToPlural();
            if (singular.EndsWith("sh")) return singular + "es";
            if (singular.EndsWith("ch")) return singular + "es";
            if (singular.EndsWith("us")) return singular + "es";
            if (singular.EndsWith("ss")) return singular + "es";
            if (singular.EndsWith("y")) return singular.Remove(singular.Length - 1, 1) + "ies";
            return singular + "s";
        }
        /// <summary>
        /// Check if a text is a strong value for strong password
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsStrongPassword(this string s)
        {
            bool isStrong = Regex.IsMatch(s, @"[\d]");
            if (isStrong) isStrong = Regex.IsMatch(s, @"[a-z]");
            if (isStrong) isStrong = Regex.IsMatch(s, @"[A-Z]");
            if (isStrong) isStrong = Regex.IsMatch(s, @"[\s~!@#\$%\^&\*\(\)\{\}\|\[\]\\:;'?,.`+=<>\/]");
            if (isStrong) isStrong = s.Length > 7;
            return isStrong;
        }
        /// <summary>
        /// Evaluate equation given in a text format
        /// </summary>
        public static string Evaluate(this string e)
        {
            Func<string, bool> VerifyAllowed = e1 =>
            {
                string allowed = "0123456789+-*/()%.,";
                for (int i = 0; i < e1.Length; i++)
                {
                    if (allowed.IndexOf("" + e1[i]) == -1)
                    {
                        return false;
                    }
                }
                return true;
            };

            if (e.Length == 0) { return string.Empty; }
            if (!VerifyAllowed(e)) { return "String contains illegal characters"; }
            if (e[0] == '-') { e = "0" + e; }
            string res = "";
            try
            {
                res = Calculate(e).ToString();
            }
            catch
            {
                return "The call caused an exception";
            }
            return res;
        }
        private static double Calculate(this string e)
        {
            e = e.Replace(".", ",");
            if (e.IndexOf("(") != -1)
            {
                int a = e.LastIndexOf("(");
                int b = e.IndexOf(")", a);
                double middle = Calculate(e.Substring(a + 1, b - a - 1));
                return Calculate(e.Substring(0, a) + middle.ToString() + e.Substring(b + 1));
            }
            double result = 0;
            string[] plus = e.Split('+');
            if (plus.Length > 1)
            {
                // there were some +
                result = Calculate(plus[0]);
                for (int i = 1; i < plus.Length; i++)
                {
                    result += Calculate(plus[i]);
                }
                return result;
            }
            else
            {
                // no +
                string[] minus = plus[0].Split('-');
                if (minus.Length > 1)
                {
                    // there were some -
                    result = Calculate(minus[0]);
                    for (int i = 1; i < minus.Length; i++)
                    {
                        result -= Calculate(minus[i]);
                    }
                    return result;
                }
                else
                {
                    // no -
                    string[] mult = minus[0].Split('*');
                    if (mult.Length > 1)
                    {
                        // there were some *
                        result = Calculate(mult[0]);
                        for (int i = 1; i < mult.Length; i++)
                        {
                            result *= Calculate(mult[i]);
                        }
                        return result;
                    }
                    else
                    {
                        // no *
                        string[] div = mult[0].Split('/');
                        if (div.Length > 1)
                        {
                            // there were some /
                            result = Calculate(div[0]);
                            for (int i = 1; i < div.Length; i++)
                            {
                                result /= Calculate(div[i]);
                            }
                            return result;
                        }
                        else
                        {
                            // no /
                            string[] mod = mult[0].Split('%');
                            if (mod.Length > 1)
                            {
                                // there were some %
                                result = Calculate(mod[0]);
                                for (int i = 1; i < mod.Length; i++)
                                {
                                    result %= Calculate(mod[i]);
                                }
                                return result;
                            }
                            else
                            {
                                // no %
                                return double.Parse(e);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Check if a text contains all values in a given collection
        /// </summary>
        /// <param name="values">Colleciton to check against</param>
        public static bool ContainsAll( this string value,params string[] values)
        {
            foreach (string one in values)
            {
                if (!value.Contains(one))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Check if text contains any value in a given collection
        /// </summary>
        /// <param name="str"></param>
        /// <param name="values">Colleciton to check agains</param>
        public static bool ContainsAny(this string str, params string[] values)
        {
            if (!string.IsNullOrEmpty(str) || values.Length == 0)
            {
                foreach (string value in values)
                {
                    if (str.Contains(value))
                        return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Limit the length of a text, remove the characters that go beyond the length you want to.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="maxLength">Length of how long you want the text to be</param>
        /// <param name="showEllipsis">Show '...' at the end of the text to indicate longer text</param>
        /// <returns></returns>
        public static string LimitLength(this string input, int maxLength, bool showEllipsis = true)
        {
            if (maxLength < 0) throw new ArgumentOutOfRangeException("maxLength", "Value must not be negative");
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            var n = input.Length;
            var ellipsis = showEllipsis ? "..." : string.Empty;
            var minLength = ellipsis.Length;
            maxLength = Math.Max(minLength, maxLength);
            return n > maxLength ? input.Substring(0, Math.Min(maxLength - minLength, n)) + ellipsis : input;
        }
        /// <summary>
        /// Check if text is a valid date
        /// </summary>>
        public static bool IsDate(this string input)
        {
            return (DateTime.TryParse(input, out DateTime dt));
        }
      
        /// <summary>
        /// Remove html tags from text
        /// </summary>
        public static string StripHtml(this string input,string replaceTagsWith=" ")
        {
            var tagsExpression = new Regex(@"</?.+?>");
            return tagsExpression.Replace(input, replaceTagsWith);
        }
        /// <summary>
        /// Check if text contains html tags
        /// </summary>
        public static bool ContainsHtml(this string input)
        {
            var tagsExpression = new Regex(@"</?.+?>");
            return tagsExpression.Match(input).Success;
        }
        /// <summary>
        /// Check if the text is a valid file on the file system
        /// </summary>
        public static bool FileExists(this string input)
        {
            try
            {
               return File.Exists(input);
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// Check if the text is a valid directory on the file system
        /// </summary>
        public static bool DirectoryExists(this string input)
        {
            try
            {
                return Directory.Exists(input);
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// Get the file size from the path
        /// </summary>
        public static long GetFileSize(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return stream.Length;
            }
        }
        /// <summary>
        /// Format string with object using PropertyNames, if object property is not found anerror is not thrown the string will not be parsed 
        /// </summary>
        /// <param name="format">{Property1}{Property2}</param>
        /// <param name="obj">Object to parse agains</param>
        public static string FormatWithObject(this string format, object obj)
        {
            string result= format;
            if (null!=obj)
            {

                var objectProperties = obj.AsDictionary();
                result = objectProperties.Aggregate(format, (current, o) => current.Replace("{" + o.Key + "}", (o.Value.ToString() ?? string.Empty).ToString()));
            }
            return result;
        }
        private static T ToObject<T>(this IDictionary<string, object> source)
         where T : class, new()
        {
            T someObject = new T();
            Type someObjectType = someObject.GetType();

            foreach (KeyValuePair<string, object> item in source)
            {
                someObjectType.GetProperty(item.Key).SetValue(someObject, item.Value, null);
            }

            return someObject;
        }
        /// <summary>
        /// Convert collection of strings to string using a separator
        /// </summary>
        /// <param name="separator">What to place inbetween items</param>
        /// <returns></returns>
        public static string ToString(this string[] input, string separator)
        {
            StringBuilder str = new StringBuilder();
            if (input.Length == 0) return "";
            for (int i = 0; i < input.Length-1; i++)
            {
                str.Append(input[i] + separator);
            }
            str.Append(input[input.Length-1] );
            return str.ToString();
        }


         private static IDictionary<string, object> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public)
        {
            return source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );

        }
    }
}

