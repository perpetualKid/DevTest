using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;

using HtmlParser;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = HttpWebRequest.Create("http://www.heise.de");
//            WebRequest request = FileWebRequest.Create(@"C:\Documents and Settings\Administrator\My Documents\codeproject.html");
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            HtmlDocument document = HtmlDocument.Create(stream);

            stream.Close();
            response.Close();

            ListAllHyperlinks(document.Nodes);

            //using (StreamWriter writer = new StreamWriter("C:\\temp\\test.htm", false, Encoding.Default))
            //{
            //    writer.Write(document.Html);
            //}
            //System.Diagnostics.Process.Start(@"C:\Program Files\TextPad 4\TextPad.exe", "C:\\temp\\test.htm");

            System.Console.ReadLine();
        }

        static void ListAllHyperlinks(HtmlNodeCollection nodes)
        {
            foreach (HtmlNode node in nodes)
            {
                HtmlElement element = node as HtmlElement;
                if (null != element)
                {
                    if ((element.Name.ToLower() == "a") && element.Attributes.Contains("href"))
                    {
                        System.Console.WriteLine(element.ToString());
                    }
                    ListAllHyperlinks((node as HtmlElement).Nodes);
                }
            }
        }
    }
}
