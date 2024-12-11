using TimeZoneLockDemo.ViewModels;

namespace TimeZoneLockDemo
{
    public partial class MainPage : ContentPage
    {


        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }


    }

}
