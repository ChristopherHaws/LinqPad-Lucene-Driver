using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using LINQPad.Extensibility.DataContext;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Spiral.LinqPad.Lucene.Extentions;

namespace Spiral.LinqPad.Lucene.Driver
{
	/// <summary>
	/// This static driver let users query any data source that looks like a Data Context - in other words,
	/// that exposes properties of type IEnumerable of T.
	/// </summary>
	public class LuceneIndexDriver : StaticDataContextDriver
	{
		public override string Name => "Lucene Driver";

		public override string Author => "Christopher Haws";

		public override string GetConnectionDescription(IConnectionInfo connectionInfo)
		{
			// For static drivers, we can use the description of the custom type & its assembly:
			return "FOO!";
		}

		public override bool ShowConnectionDialog(IConnectionInfo connectionInfo, bool isNewConnection)
		{
			// Prompt the user for a lucene connection:
			return new ConnectionDialog(connectionInfo).ShowDialog() == true;
		}

		public override void InitializeContext(IConnectionInfo connectionInfo, object context, QueryExecutionManager executionManager)
		{
			//TODO: Create LuceneProvider
		}

		public override List<ExplorerItem> GetSchema(IConnectionInfo connectionInfo, Type customType)
		{
            var indexDirectory = connectionInfo.DriverData.FromXElement<LuceneDriverData>().IndexDirectory;

			//TODO: Fields with configured delimiters should show up as a tree
			//TODO: Show Numeric and String fields with their types
			//TODO: If the directory selected contains sub-directories, maybe we should show them all...

			using (var directory = FSDirectory.Open(new DirectoryInfo(indexDirectory)))
			using (var indexReader = IndexReader.Open(directory, true))
			{
				return indexReader
					.GetFieldNames(IndexReader.FieldOption.ALL)
					.Select(fieldName =>
					{
						//var field = //TODO: Get the first document with this field and get its types.
                        return new ExplorerItem(fieldName, ExplorerItemKind.QueryableObject, ExplorerIcon.Column)
						{
							IsEnumerable = false,       //TODO: Should be true when its a multi-field
							ToolTipText = "Cool tip"
						};
					})
					.ToList();
			}
		}
	}
}