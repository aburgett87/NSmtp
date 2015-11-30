namespace NSmtp.Models.DataFields
{
    public class BccDataField : IDataField
    {
        public BccDataField(string text)
        {
            Content = text;
        }

        public string Heading
        {
            get { return DataFieldHeadings.Bcc; }
        }

        public string Content
        {
            get;
            private set;
        }
    }
}
