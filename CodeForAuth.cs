using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace {ProjectName}
{
    public partial class AuthWindow : Window
    {
        {YourDataBaseEntities} Entities = new {YourDataBaseEntities()};
        public static User authUser;

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
                if (String.IsNullOrWhiteSpace(tboxPassword.Text) && !String.IsNullOrWhiteSpace(tboxLogin.Text))
                {
                    MessageBox.Show("Вы не ввели пароль.", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (String.IsNullOrWhiteSpace(tboxPassword.Text) && String.IsNullOrWhiteSpace(tboxLogin.Text))
                {
                    MessageBox.Show("Вы не заполнили данные для авторизации.", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (!String.IsNullOrWhiteSpace(tboxLogin.Text) && !String.IsNullOrWhiteSpace(tboxPassword.Text))
                {
                    MessageBox.Show("В доступе отказано. Проверьте правильность введенных данных.", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (String.IsNullOrWhiteSpace(tboxLogin.Text) && !String.IsNullOrWhiteSpace(tboxPassword.Text))
                {
                    MessageBox.Show("Вы не ввели логин.", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
