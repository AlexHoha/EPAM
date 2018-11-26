using System;
namespace Solutions
{
    public class NewFormat : DocumentPart
    {
        public override string ToHtml()
        {
            return "/NewFormat/" + this.Text + "/NewFormat";
        }

        public override string ToLaTeX()
        {
            return "???" + this.Text + "???";
        }

        public override string ToPlainText()
        {
            return this.Text;
        }
    }
}
