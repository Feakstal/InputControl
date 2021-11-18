using {DataBaseName};
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace BuildersApp_Novikov_3ISP11_13.Views
{
    public partial class AuthWindow : Window
    {
        {YourDataBaseEntities } Entities = new {YourDataBaseEntities()};
        public static User authUser;
        private User user = new User();

        public AuthWindow()
        {
            InitializeComponent();
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            authUser = Entities.User.FirstOrDefault(i => i.Login == tboxLogin.Text && i.Password == tboxPassword.Text);
            if (authUser != null)
            {
                MainMenuWindow mainMenuWindow = new MainMenuWindow();
                mainMenuWindow.Show();
                Hide();
            }
            else
            {
                if (tboxPassword.Text.Length == 0 && tboxLogin.Text.Length != 0)
                    MessageBox.Show("Вы не ввели пароль.", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                else if (tboxPassword.Text.Length == 0 && tboxLogin.Text.Length == 0)
                    MessageBox.Show("Вы не заполнили данные для авторизации.", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                else if (tboxLogin.Text.Length != 0 && tboxPassword.Text.Length != 0)
                    MessageBox.Show("Пользователь не найден", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
