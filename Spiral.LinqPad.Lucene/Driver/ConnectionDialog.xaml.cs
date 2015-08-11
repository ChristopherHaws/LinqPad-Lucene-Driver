using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using LINQPad.Extensibility.DataContext;
using LINQPad.Extensibility.DataContext.UI;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace Spiral.LinqPad.Lucene.Driver
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ConnectionDialog : Window
	{
	    private readonly IConnectionInfo connectionInfo;

	    public ConnectionDialog(IConnectionInfo connectionInfo)
		{
			this.connectionInfo = connectionInfo;
			DataContext = connectionInfo.CustomTypeInfo;
			InitializeComponent();
		}

		private void OnOkButtonClick(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}

		private void BrowseIndexDirectory(object sender, RoutedEventArgs e)
		{
			var dialog = new FolderBrowserDialog()
			{
				Description = "Choose lucene index directory"
			};

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				MessageBox.Show(dialog.SelectedPath);
			}
		}
	}
}
