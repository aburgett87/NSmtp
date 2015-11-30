namespace NSmtp.Models.DataFields
{
    public class AttachmentDataFiled : IDataField
    {
        public AttachmentDataFiled(string heading, string content)
        {
            Heading = heading;
            Content = content;
        }
        public string Heading
        {
            get;
            private set;
        }

        public string Content
        {
            get;
            private set;
        }
    }
}
