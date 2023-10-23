using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gastosalon_net.Helpers
{
    public static class XmlConverter<T>
    {
        private static XmlSerializer _serializer = null;

        #region Static Constructor

        /// <summary>
        /// Static constructor that initialises the serializer for this type
        /// </summary>
        static XmlConverter()
        {
            _serializer = new XmlSerializer(typeof(T));
        }

        #endregion

        #region Public

        /// <summary>
        /// Deserialize the supplied XML into an object
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T ToObject(string xml)
        {
            return (T)_serializer.Deserialize(new StringReader(xml));
        }

        /// <summary>
        /// Serialize the supplied object into XML
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToXML(T obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                _serializer.Serialize(memoryStream, obj);

                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        #endregion
    }
}
