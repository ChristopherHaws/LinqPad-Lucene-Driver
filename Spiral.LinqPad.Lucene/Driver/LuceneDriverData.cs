using System;

namespace Spiral.LinqPad.Lucene.Driver
{
	public class LuceneDriverData
	{
		public String IndexDirectory { get; set; }

		public Boolean ReadOnlyMode { get; set; }

		public Boolean ForceUnlock { get; set; }
	}
}