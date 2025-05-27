using System;
using System.Linq;
using System.Windows;
using OOP_CourseProject_Fitness.Models;

namespace OOP_CourseProject_Fitness
{
    /// <summary>
    /// Логика взаимодействия для AddMembershipWindow.xaml
    /// </summary>
    public partial class AddMembershipWindow : Window
    {
        // Событие для передачи нового абонемента
        public event EventHandler<Membership> MembershipAdded;

        private Client _selectedClient;  // Для хранения выбранного клиента
        private JsonDataService _jsonDataService;

        // Конструктор с передачей выбранного клиента
        public AddMembershipWindow(Client selectedClient)
        {
            InitializeComponent();
            _selectedClient = selectedClient;  // Сохраняем выбранного клиента
            _jsonDataService = new JsonDataService();  // Инициализация JsonDataService
        }

        // Обработчик нажатия на кнопку "Зберегти абонемент"
        private void SaveMembership_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(MembershipTypeTextBox.Text) ||
                StartDatePicker.SelectedDate == null ||
                EndDatePicker.SelectedDate == null ||
                string.IsNullOrWhiteSpace(DiscountTextBox.Text))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.");
                return;
            }

            // Создаем новый абонемент
            var newMembership = new Membership
            {
                ClientID = _selectedClient.ID,  // Используем ClientID выбранного клиента
                MembershipType = MembershipTypeTextBox.Text,
                StartDate = StartDatePicker.SelectedDate.Value,
                EndDate = EndDatePicker.SelectedDate.Value,
                Discount = decimal.TryParse(DiscountTextBox.Text, out var discount) ? discount : 0
            };

            // Добавляем абонемент к выбранному клиенту
            _selectedClient.Memberships.Add(newMembership);

            // Загружаем список клиентов и обновляем информацию о выбранном
            var clients = _jsonDataService.LoadData<Client>(isClientData: true);

            // Ищем клиента по ID и обновляем его данные
            var client = clients.FirstOrDefault(c => c.ID == _selectedClient.ID);
            if (client != null)
            {
                client.Memberships = _selectedClient.Memberships;  // Обновляем список абонементов клиента
            }

            // Сохраняем обновленный список клиентов в файл
            _jsonDataService.SaveData(clients, isClientData: true);

            // Вызываем событие для передачи нового абонемента в главное окно
            MembershipAdded?.Invoke(this, newMembership);

            // Закрываем окно после добавления абонемента
            this.Close();
        }
    }
}
