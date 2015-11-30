using NSmtp;

namespace NSmtp.Models.DataFields
{
    public class MimeVersionDataField : IDataField
    {
        public MimeVersionDataField(string version)
        {
            Content = version;
        }

        public string Heading
        {
            get { return DataFieldHeadings.MimeVersion; }
        }

        public string Content
        {
            get;
            private set;
        }
    }
}
