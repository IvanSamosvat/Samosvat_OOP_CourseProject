using System;
using System.Linq;
using System.Windows;
using OOP_CourseProject_Fitness.Models;

namespace OOP_CourseProject_Fitness
{
    public partial class EditClientWindow : Window
    {
        private Client _client;

        public event EventHandler<Client> ClientUpdated;

        public EditClientWindow(Client client)
        {
            InitializeComponent();
            _client = client;

            // Привязываем данные клиента к полям
            FirstNameTextBox.Text = _client.FirstName;
            LastNameTextBox.Text = _client.LastName;
            ContactInfoTextBox.Text = _client.ContactInfo;
            MedicalDetailsTextBox.Text = _client.MedicalDetails;
        }

        private void SaveClient_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем данные клиента
            _client.FirstName = FirstNameTextBox.Text;
            _client.LastName = LastNameTextBox.Text;
            _client.ContactInfo = ContactInfoTextBox.Text;
            _client.MedicalDetails = MedicalDetailsTextBox.Text;

            // Вызываем событие для передачи обновленного клиента
            ClientUpdated?.Invoke(this, _client);

            // Закрываем окно после сохранения изменений
            this.Close();
        }
    }

}
