# HelperExtensions
.net core extensions to help with repeating tasks on daily basis

## Install-Package Helper.Extensions -Version 1.0.0

Extensions included
1. Reverse - change the order of the string
2. IsPalindrome - check if string is the same bacwards and forwards
3. GetByteArray - Get the byte represantation of the string
4. ToTitleCase - Convert every words first letter to Upper Case
5. CountOccurences - Number of occurences a text or character appears in another text
6. WordCount - Number of words in a text
7. ToBase64 - String to Base64
8. FromBase64 - Base 64 back to normal string
9. IsNumber - Check if a given text is a valid number
10. Abrevation- Return the abrevation of a text (ex: My Programming Company => M.P.C)
11. MaskLastXChars - Mask X number of characters from the end of the string (ex: mask email when showing them)
12. MaskFirstXChars- Mask characters starting from the beggining
13. MaskFirstAndLastXChars - Mask same number fo characters from the end and the beggining
14. NumberOfVowels - Return vowel count
15. WriteToDisk - Write file to disk
16. LineCount - Count number of lines in a text
17. Escape - Escape a string, when helpfull when you have to display a string with special characters.
18. UnEscape - Unescape previously escaped string
19. Similarity - See how much two texts are similar using the Levenshein Method
20. IsEmail - Check if a value is a valid email
21. ExtractEmail - Extracts a valid email from the text if it finds one
22. GetQueryStringParamValue - Parse value from querystring parameters
23. IsIPV4Address - Check if string is valid Ipv4 address
24. IsIPV6Address - Check if string is valid ipv6 address
25. ToEnum<TEnum> - Convert string to enum value for a given enum type
26. IsGuid - Check if a text is a valid guid value
27. IsValidUrl - Check if a text is a valid url
28. ToSlug - Convert text to url slug(ex: article name to url. ArticleName:This is my article, ToSlug=>this_is_my_article)
29. ToPlural - Convert words to plural ( won't work on every single word but in most cases)
30. IsStrongPassword - Check if text is suitable for a strong password
31. Evaluate - Evaluate string expression (ex: "2*(3+5)".Evalue()="16")
32. ContainsAll - Check if text contains a list of words
33. ContainsAny - Check if text contains any word in a given list
34. LimitLength - Limit the length of a text to a given number, optional to put elipsis at the end (...)
35. IsDate - Check if text is a valid date
36. StripHtml - Remove html tags from text. Will remove tags only not the content between opening and closing tag
37. ContainsHtml - Check if text contains html tags
38. FileExists - Check if a file path exists on the disk
39. DirectoryExists - Check if a directory path exists on the disk
40. GetFileSize - Get the size of a file in the given path
41. FormatWithObject - Format a string with an object using object property names( ex: {Name} is {Age} old and pass the object Stundent lets say as a parameter which has a Name and Age property, properties not found on the object will not be resolved.
42. ToString - Convert list of strings to a string
