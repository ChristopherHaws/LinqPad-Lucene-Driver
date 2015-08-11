using System;
using System.Xml.Serialization;

namespace Spiral.LinqPad.Lucene.Driver
{
	[XmlRoot("DriverData")]
	public class LuceneDriverData
	{
		public String IndexDirectory { get; set; }

		public Boolean ReadOnlyMode { get; set; }

		public Boolean ForceUnlock { get; set; }
	}
}