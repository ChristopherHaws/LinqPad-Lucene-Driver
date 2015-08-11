using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Spiral.LinqPad.Lucene.Extentions
{
	public static class XElementExtentions
	{
		public static XElement ToXElement<T>(this T value)
		{
			using (var memoryStream = new MemoryStream())
			{
				using (TextWriter streamWriter = new StreamWriter(memoryStream))
				{
					var xmlSerializer = new XmlSerializer(typeof(T));
					xmlSerializer.Serialize(streamWriter, value);
					return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
				}
			}
		}

		public static T FromXElement<T>(this XElement element)
		{
			var xmlSerializer = new XmlSerializer(typeof(T));
			return (T)xmlSerializer.Deserialize(element.CreateReader());
		}
	}
}
