using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DC.PaymentProvider
{
    public class Helper<T>
    {
        public XmlDocument Serialize(Object o)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            Stream stream = new MemoryStream();
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, o);

                String x = writer.ToString();

                XmlDocument xml = new XmlDocument();
                xml.LoadXml(x);

                return xml;
            }
        }

        public String SerializeAsXMLString(Object o)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            Stream stream = new MemoryStream();
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, o);
                return writer.ToString();
            }
        }
    }
}
