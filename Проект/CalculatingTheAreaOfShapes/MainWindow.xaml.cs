using CalculatingTheAreaOfShapes.AppData;
using CalculatingTheAreaOfShapes.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatingTheAreaOfShapes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ControlClass.FrameMain = FrmMain;
            ControlClass.FrameMain.Navigate(new MainCalcPage());
        }
        
        //Свернуть
        private void BtnRollUp_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //Развернуть
        private void BtnWinState_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                BtnWinState.Content = Char.ConvertFromUtf32(0xE922);
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                this.WindowState = WindowState.Normal;
            }
            else if (this.WindowState == WindowState.Normal)
            {
                BtnWinState.Content = Char.ConvertFromUtf32(0xE923);
                this.WindowState = WindowState.Maximized;
            }
        }

        //Закрыть
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        //Изменился размер окна
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                BtnWinState.Content = Char.ConvertFromUtf32(0xE923);
                BtnWinState.ToolTip = "Восстановить";
                GridMain.Margin = new Thickness(7);
            }
            else
            {
                BtnWinState.Content = Char.ConvertFromUtf32(0xE922);
                BtnWinState.ToolTip = "Развернуть";
                GridMain.Margin = new Thickness(0);
            }
        }
    }
}
