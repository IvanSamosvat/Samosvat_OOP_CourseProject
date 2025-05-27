using System;
using System.Windows;
using System.Windows.Controls;
using OOP_CourseProject_Fitness.Models;

namespace OOP_CourseProject_Fitness
{
    public partial class LoginWindow : Window
    {
        public User LoggedInUser { get; private set; }  // Добавляем свойство для авторизованного пользователя

        public LoginWindow()
        {
            InitializeComponent();
        }

        // Обработчик кнопки "Login"
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string role = ((ComboBoxItem)RoleComboBox.SelectedItem)?.Content.ToString();

            // Пытаемся авторизовать пользователя
            var user = AuthenticationService.Login(username, password);

            if (user != null && user.Role == role)
            {
                MessageBox.Show("Login successful!");

                // Устанавливаем авторизованного пользователя в свойство
                LoggedInUser = user;

                // Закрываем LoginWindow
 
                // Открываем MainWindow, передаем авторизованного пользователя
                var mainWindow = new MainWindow(user);
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Invalid username, password, or role.");
            }
        }

        // Обработчик кнопки "Register"
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string role = ((ComboBoxItem)RoleComboBox.SelectedItem)?.Content.ToString();

            var result = AuthenticationService.Register(username, password, role);

            if (result)
            {
                MessageBox.Show("Registration successful!");
            }
            else
            {
                MessageBox.Show("Username already exists.");
            }
        }
    }
}
