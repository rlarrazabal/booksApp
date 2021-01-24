using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksAppsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookWebPage : ContentPage
    {
        public BookWebPage(string url)
        {
            InitializeComponent();
            webView.Source = url;
        }
    }
}