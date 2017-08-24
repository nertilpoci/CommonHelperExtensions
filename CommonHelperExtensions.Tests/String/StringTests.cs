using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CommonHelperExtensions.String;

namespace CommonHelperExtensions.Tests.String
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void ReverseTest()
        {
            //even character count
            string normal = "string";
            string reverse = normal.Reverse();
            Assert.IsTrue(reverse == "gnirts");

            //odd character count
            string normal2 = "strings";
            string reverse2 = normal2.Reverse();
            Assert.IsTrue(reverse2 == "sgnirts");
        }

        [TestMethod]
        public void IsPalidromeTest()
        {
            string notpalindrome = "notpalindrome";
            string palindrome = "alula";
            
            Assert.IsFalse(notpalindrome.IsPalindrome());
            Assert.IsTrue(palindrome.IsPalindrome());
        }
        [TestMethod]
        public void ToTitleCaseTest()
        {
            string normal = "this is a sentence";
            string titled = "This Is A Sentence";

            Assert.IsTrue(normal.ToTitleCase()==titled);
        }
        [TestMethod]
        public void CountOccurencesTest()
        {
            string sentence = "this is a sentence, just a normal sentence";
            string word = "sentence";
            Assert.IsTrue(sentence.CountOccurences(word)==2);
        }

        [TestMethod]
        public void AbrevationTest()
        {
            string sentence = "Bussiness Technology Company";
            var result = sentence.Abrevation();
            Assert.IsTrue(result == "B.T.C");
        }
        [TestMethod]
        public void MaskfirstXChars()
        {

            string word = "Sample";
            Assert.IsTrue(word.MaskFirstXChars(0) == "Sample");
            Assert.IsTrue(word.MaskFirstXChars(1) == "*ample");
            Assert.IsTrue(word.MaskFirstXChars(2) == "**mple");
            Assert.IsTrue(word.MaskFirstXChars(3) == "***ple");
            Assert.IsTrue(word.MaskFirstXChars(4) == "****le");
            Assert.IsTrue(word.MaskFirstXChars(5) == "*****e");
            Assert.IsTrue(word.MaskFirstXChars(6) == "******");
            Assert.IsTrue(word.MaskFirstXChars(7) == "******");
        }
        [TestMethod]
        public void MaskLastXChars()
        {

            string word = "Sample";
            Assert.IsTrue(word.MaskLastXChars(0) == "Sample");
            Assert.IsTrue(word.MaskLastXChars(1) == "Sampl*");
            Assert.IsTrue(word.MaskLastXChars(2) == "Samp**");
            Assert.IsTrue(word.MaskLastXChars(3) == "Sam***");
            Assert.IsTrue(word.MaskLastXChars(4) == "Sa****");
            Assert.IsTrue(word.MaskLastXChars(5) == "S*****");
            Assert.IsTrue(word.MaskLastXChars(6) == "******");
            Assert.IsTrue(word.MaskLastXChars(7) == "******");
        }
        [TestMethod]
        public void MaskFirstAndLastXChars()
        {

            string evenWord = "Sample";
            Assert.IsTrue(evenWord.MaskFirstAndLastXChars(0) == "Sample");
            Assert.IsTrue(evenWord.MaskFirstAndLastXChars(1) == "*ampl*");
            Assert.IsTrue(evenWord.MaskFirstAndLastXChars(2) == "**mp**");
            Assert.IsTrue(evenWord.MaskFirstAndLastXChars(3) == "******");
            Assert.IsTrue(evenWord.MaskFirstAndLastXChars(4) == "******");
            string oddWord = "Sample2";
            Assert.IsTrue(oddWord.MaskFirstAndLastXChars(0) == "Sample2");
            Assert.IsTrue(oddWord.MaskFirstAndLastXChars(1) == "*ample*");
            Assert.IsTrue(oddWord.MaskFirstAndLastXChars(2) == "**mpl**");
            Assert.IsTrue(oddWord.MaskFirstAndLastXChars(3) == "***p***");
            Assert.IsTrue(oddWord.MaskFirstAndLastXChars(4) == "*******");

        }
        [TestMethod]
        public void NumberOfVowelsTest()
        {
            string sentence = "abcde";
            Assert.IsTrue(sentence.NumberOfVowels() ==2);
        }
        [TestMethod]
        public void LineCountTest()
        {
            string sentence = "this is a multiline \n string \n multiline";
            Assert.IsTrue(sentence.LineCount() == 3);
        }
        [TestMethod]
        public void IsEmailTest()
        {
            var email1 = "email@email.email";
            var email2 = "email@@email.email";
            var email3 = "email.com";
            Assert.IsTrue(email1.IsEmail());
            Assert.IsFalse(email2.IsEmail());
            Assert.IsFalse(email3.IsEmail());
        }
      
        [TestMethod]
        public void ExtractEmailTest()
        {
            var text = "abc@.abc@abc.com";
            var eEmail = text.ExtractEmail();
            Assert.IsTrue(eEmail == "abc@abc.com");
        }
        [TestMethod]
        public void QueryStringTest()
        {
            //var text = "abc.abc@abc.com";
            //Assert.IsTrue(text.ExtractEmail() == "abc@abc.com");
        }
        [TestMethod]
        public void Ipv4Test()
        {
            var validIp = "192.168.0.1";
            var invalidIp = "1192.168.0.1";
            Assert.IsTrue(validIp.IsIPV4Address());
            Assert.IsFalse(invalidIp.IsIPV4Address());
        }
        [TestMethod]
        public void Ipv6Test()
        {
            var validIp = "2001:0db8:0a0b:12f0:0000:0000:0000:0001";
            var invalidIp = "192.168.1.1";
            Assert.IsTrue(validIp.IsIPV6Address());
            Assert.IsFalse(invalidIp.IsIPV6Address());
        }
        [TestMethod]
        public void EnumParseTest()
        {
            var value = "Value1";           
            Assert.IsTrue(value.ToEnum<TestEnum>()==TestEnum.Value1);
        }
        [TestMethod]
        public void IsGuidTest()
        {
            var value = "77e0e90b-753a-440d-ac02-53e1aff29e7f";
            var value2 = "77e0e90b-753a-440d-ac02-53e1aff29e744f";
            Assert.IsTrue(value.IsGuid());
            Assert.IsFalse(value2.IsGuid());
        }
        [TestMethod]
        public void IsValidUrlTst()
        {
            var validUrls = new[] { "www.google.com", "http://google.com" ,"http://www.google.com", "https://google.com", "https://www.google.com"};
            var invalidUrls = new[] { "htt:www.google.com","http::google.com" };
            Assert.IsTrue(validUrls.All(z=>z.IsValidUrl()));
            Assert.IsTrue(invalidUrls.All(z => z.IsValidUrl()==false));
        }
        [TestMethod]
        public void ToSlugTest()
        {
            var value = "This is an article name";
            var slug = value.ToSlug();
            Assert.IsTrue(slug == "this_is_an_article_name");
        }
        [TestMethod]
        public void ToPluralTest()
        {
            var value = "car";
            var value2 = "auto";
            var value3 = "brush";
            Assert.IsTrue(value.ToPlural() == "cars");
            Assert.IsTrue(value2.ToPlural() == "autos");
            Assert.IsTrue(value3.ToPlural() == "brushes");
        }
        [TestMethod]
        public void IsStrongPasswordTest()
        {
            var value = "User1234";
            var value2 = "User@1";
            var value3 = "User@2017";
            Assert.IsFalse(value.IsStrongPassword() );
            Assert.IsFalse(value2.IsStrongPassword() );
            Assert.IsTrue(value3.IsStrongPassword() );
        }
        [TestMethod]
        public void EvaluateTest()
        {
            var value = "2+(5-1)/2";
            Assert.IsTrue(value.Evaluate()=="4");
        }
        [TestMethod]
        public void ContainsAllTest()
        {
            var vaues1 = new[] { "value1","value2","value3" };
            var vaues2 = new[] { "value1","value2","value3","value4" };
            var text = "This is value1 and value2 and value3";
            Assert.IsTrue(text.ContainsAll(vaues1));
            Assert.IsFalse(text.ContainsAll(vaues2));
        }
        [TestMethod]
        public void ContainsAnyTest()
        {
            var vaues1 = new[] { "value1", "value2", "value3" };
            var vaues2 = new[] { "value4", "value5", "value6", "value7" };
            var text = "This is value1 ";
            Assert.IsTrue(text.ContainsAny(vaues1));
            Assert.IsFalse(text.ContainsAny(vaues2));
        }
        [TestMethod]
        public void LengthLimitTest()
        {
            var text = "This is a long string";
            Assert.IsTrue(text.LimitLength(7)=="This...");
        }

      [TestMethod]
        public void IsDateTest()
        {
            var text = "01.01.2017";
            Assert.IsTrue(text.IsDate());
        }
        [TestMethod]
        public void StripHtmlTest()
        {
            var text = "<h1>My First Heading</h1>result<p>My first paragraph.</p>";
            var htmlLess = text.StripHtml();
            Assert.IsTrue(htmlLess == " My First Heading result My first paragraph. ");
        }
        [TestMethod]
        public void ContainsHtmlTest()
        {
            var text = "<h1>My First Heading</h1>result<p>My first paragraph.</p>";
            var text2 = "Html free text";
            Assert.IsTrue(text.ContainsHtml());
            Assert.IsFalse(text.StripHtml().ContainsHtml());
            Assert.IsFalse(text2.ContainsHtml());
        }
        [TestMethod]
        public void ToStringTest()
        {
            var values1 = new string[] { "value1", "value2", "value3" };
            Assert.IsTrue(values1.ToString("-") == "value1-value2-value3");
        }
        [TestMethod]
        public void FormatWithObjectTest()
        {

            var testobject = new TestObject() { Name="John", Age=25,Birthday= "19 September 1992" };
            var format = "Name {Name}, age {Age}, and birthday {Birthday}";
            Assert.IsTrue(format.FormatWithObject(testobject) == "Name John, age 25, and birthday 19 September 1992");
           

        }
    }
    
}
