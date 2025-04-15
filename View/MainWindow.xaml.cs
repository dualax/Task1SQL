using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task1SqlServer.Core;
using Task1SqlServer.Model;
using Task1SqlServer.View;

namespace Task1SqlServer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DdModelContext.DB = new Task1DB();
        }

        private void BtnCreat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DdModelContext.DB.Users.Add(new User()
                {
                    UserLogin = TbLogin.Text,
                    UserPassword = PbPassword.Password,
                    UserPhone = TbPhone.Text,
                    UserEmail = TbEmail.Text,
                });
                DdModelContext.DB.SaveChanges();
                System.Windows.MessageBox.Show("Данные успешно сохранены",
                                "Системное сообщение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message.ToString(),
                    "Системное оповещение",
                     MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        private void Run_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new InfoWindow().Show();
            Close();
        }
    }
}



