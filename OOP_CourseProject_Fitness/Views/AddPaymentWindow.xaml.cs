using System;
using System.Linq;
using System.Windows;
using OOP_CourseProject_Fitness.Models;

namespace OOP_CourseProject_Fitness
{
    public partial class AddPaymentWindow : Window
    {
        private Client _selectedClient;  // Храним выбранного клиента

        private JsonDataService _jsonDataService;

        // Конструктор с передачей выбранного клиента
        public AddPaymentWindow(Client selectedClient)
        {
            InitializeComponent();
            _selectedClient = selectedClient;  // Сохраняем выбранного клиента
            _jsonDataService = new JsonDataService();  // Инициализация JsonDataService
        }

        // Обработчик нажатия на кнопку "Зберегти платіж"
        private void SavePayment_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(AmountTextBox.Text) || PaymentDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.");
                return;
            }

            // Создаем новый платеж
            var newPayment = new Payment
            {
                Amount = decimal.TryParse(AmountTextBox.Text, out var amount) ? amount : 0,
                PaymentDate = PaymentDatePicker.SelectedDate.Value
            };

            // Загружаем список клиентов
            var clients = _jsonDataService.LoadData<Client>(isClientData: true);  // Получаем список клиентов из dataClient.json

            // Ищем клиента по ID и добавляем платеж
            var client = clients.FirstOrDefault(c => c.ID == _selectedClient.ID);
            if (client != null)
            {
                // Добавляем платеж к выбранному клиенту
                client.Payments.Add(newPayment);

                // Сохраняем обновленный список клиентов с платежами
                _jsonDataService.SaveData(clients, isClientData: true);
            }

            // Закрываем окно после добавления платежа
            this.Close();
        }
    }
}
