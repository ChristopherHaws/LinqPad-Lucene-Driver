using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;
using LINQPad.Extensibility.DataContext;
using Spiral.LinqPad.Lucene.Extentions;

namespace Spiral.LinqPad.Lucene.Driver
{
    public partial class ConnectionDialog : Window
	{
	    private readonly IConnectionInfo connectionInfo;
	    private readonly LuceneDriverData driverData;

	    public ConnectionDialog(IConnectionInfo connectionInfo)
		{
			this.connectionInfo = connectionInfo;
			this.driverData = new LuceneDriverData();
			DataContext = this.driverData;
			InitializeComponent();
		}

		private void OnOkButtonClick(object sender, RoutedEventArgs e)
		{
			//this.connectionInfo.Persist = this.driverData.Persist;
			this.connectionInfo.DriverData = this.driverData.ToXElement();
            DialogResult = true;
		}

		private void BrowseIndexDirectory(object sender, RoutedEventArgs e)
		{
			var dialog = new FolderBrowserDialog
			{
				Description = "Choose lucene index directory"
			};

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
				this.driverData.IndexDirectory = dialog.SelectedPath;
                this.connectionInfo.DisplayName = new DirectoryInfo(dialog.SelectedPath).Name;
			}
		}
	}
}
