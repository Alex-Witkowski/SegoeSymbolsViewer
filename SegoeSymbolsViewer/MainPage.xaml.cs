using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SegoeSymbolsViewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var list = new List<SymbolPoco>();
            for (int i = 0xE001; i <= (0xEC7A); i++)
            {
                var poco = new SymbolPoco(i);
                list.Add(poco);
            }

            listView.ItemsSource = list;
        }

        private void AppBarButtonCopyCode_Click(object sender, RoutedEventArgs e)
        {
            if (!(listView.SelectedItem is SymbolPoco))
            {
                return;
            }

            var poco = (SymbolPoco) listView.SelectedItem;
            CopyText(poco.HexText);
        }

        private void AppBarButtonCopyXaml_Click(object sender, RoutedEventArgs e)
        {
            if (!(listView.SelectedItem is SymbolPoco))
            {
                return;
            }

            var poco = (SymbolPoco)listView.SelectedItem;
            CopyText(poco.XamlText);
        }

        private static void CopyText(string text)
        {
            var dataPackage = new DataPackage();
            dataPackage.SetText(text);

            try
            {
                Clipboard.SetContent(dataPackage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
