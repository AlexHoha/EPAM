using System;
using System.Collections.Generic;

namespace Solutions
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            BoldText boldText = new BoldText
            {
                Text = "bold"
            };
            Hyperlink hyperlink = new Hyperlink
            {
                Url = "epam",
                Text = "link"
            };
            PlainText plainText = new PlainText
            {
                Text = "plain"
            };

            NewFormat newFormat = new NewFormat
            {
                Text = "new"
            };
            List<DocumentPart> parts = new List<DocumentPart>(){boldText, hyperlink, plainText, newFormat};
            Document document = new Document(parts);
            string res = "";

            res = document.ToHtml();
            Console.WriteLine(res);

            Console.WriteLine("_____________________");

            res = document.ToPlainText();
            Console.WriteLine(res);

            Console.WriteLine("_____________________");

            res = document.ToLaTeX();
            Console.WriteLine(res);
*/

            Generator generator = new Generator();
            generator.Generate(1.1, 2.2,10);
        }
    }
}
