using System;
using System.Linq;
using System.Windows;
using OOP_CourseProject_Fitness.Models;

namespace OOP_CourseProject_Fitness
{
    public partial class AddClientWindow : Window
    {
        public event EventHandler<Client> ClientAdded;
        private JsonDataService _jsonDataService;

        public AddClientWindow()
        {
            InitializeComponent();
            _jsonDataService = new JsonDataService();  // Инициализация JsonDataService
        }

        private void SaveClient_Click(object sender, RoutedEventArgs e)
        {
            // Загружаем текущий список клиентов
            var clients = _jsonDataService.LoadData<Client>(isClientData: true);

            // Генерируем новый ID, который будет уникальным
            int newClientId = clients.Any() ? clients.Max(c => c.ID) + 1 : 1;  // Получаем максимальный ID и увеличиваем его на 1

            var newClient = new Client
            {
                ID = newClientId,  // Используем новый уникальный ID
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                ContactInfo = ContactInfoTextBox.Text,
                MedicalDetails = MedicalDetailsTextBox.Text
            };

            // Добавляем нового клиента в список
            clients.Add(newClient);

            // Сохраняем обновленный список клиентов в dataClient.json
            _jsonDataService.SaveData(clients, isClientData: true);  // Сохраняем именно в dataClient.json

            // Вызываем событие для передачи нового клиента в главное окно
            ClientAdded?.Invoke(this, newClient);

            // Закрываем окно после добавления клиента
            this.Close();
        }
    }
}
