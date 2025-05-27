using System;
using System.Linq;
using System.Windows;
using OOP_CourseProject_Fitness.Models;

namespace OOP_CourseProject_Fitness
{
    public partial class MainWindow : Window
    {
        private User _currentUser;
        private Client _selectedClient;
        private JsonDataService _jsonDataService;

        // Конструктор, в который передается объект пользователя
        public MainWindow(User user)
        {
            InitializeComponent();  // Инициализация всех компонентов UI
            _currentUser = user;
            this.DataContext = _currentUser;  // Устанавливаем DataContext для привязки данных
            _jsonDataService = new JsonDataService();  // Инициализация JsonDataService

            LoadData();  // Загружаем данные клиентов
        }

        // Метод для загрузки данных клиентов
        private void LoadData()
        {
            // Загружаем список клиентов из dataClient.json
            var clients = _jsonDataService.LoadData<Client>(isClientData: true);  // Загружаем данные клиентов
            ClientsDataGrid.ItemsSource = clients;  // Привязываем данные к DataGrid
          if (clients != null && ClientsDataGrid != null)
            {
                ClientsDataGrid.ItemsSource = clients;  // Привязываем обновленные данные к DataGrid
            }
            else
            {
                MessageBox.Show("Не вдалося завантажити дані про клієнтів.");
            }
        }

        // Обработчик для кнопки "Додати клієнта"
        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            var addClientWindow = new AddClientWindow();
            addClientWindow.ClientAdded += AddClientWindow_ClientAdded;
            addClientWindow.ShowDialog();
        }

        // Обработчик события добавления клиента
        private void AddClientWindow_ClientAdded(object sender, Client newClient)
        {
            var clients = _jsonDataService.LoadData<Client>(isClientData: true);  // Загружаем клиентов из dataClient.json
            clients.Add(newClient);  // Добавляем нового клиента в список
            _jsonDataService.SaveData(clients, isClientData: true);  // Сохраняем обновленный список клиентов в dataClient.json
            LoadData();  // Обновляем список на интерфейсе
        }

        // Обработчик для выбора клиента из списка
        private void ClientsDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Проверяем, есть ли выбранный элемент
            if (ClientsDataGrid.SelectedItem != null)
            {
                // Преобразуем выбранный элемент в объект клиента
                _selectedClient = (Client)ClientsDataGrid.SelectedItem;

                // Включаем кнопки "Редактировать" и "Удалить"
                EditClientButton.IsEnabled = true;
                DeleteClientButton.IsEnabled = true;
            }
            else
            {
                // Если ничего не выбрано, отключаем кнопки
                EditClientButton.IsEnabled = false;
                DeleteClientButton.IsEnabled = false;
            }
        }



        // Обработчик для кнопки "Редагувати клієнта"
        private void EditClient_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedClient != null)
            {
                // Создаем окно редактирования и передаем выбранного клиента
                var editClientWindow = new EditClientWindow(_selectedClient);

                // Подписываемся на событие обновления клиента
                editClientWindow.ClientUpdated += EditClientWindow_ClientUpdated;

                // Открываем окно редактирования
                editClientWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Оберіть клієнта.");
            }
        }

        // Обработчик события обновления клиента
        private void EditClientWindow_ClientUpdated(object sender, Client updatedClient)
        {
            // Загружаем список клиентов из файла
            var clients = _jsonDataService.LoadData<Client>(isClientData: true);

            // Ищем клиента по ID и обновляем его данные
            var client = clients.FirstOrDefault(c => c.ID == updatedClient.ID);
            if (client != null)
            {
                client.FirstName = updatedClient.FirstName;
                client.LastName = updatedClient.LastName;
                client.ContactInfo = updatedClient.ContactInfo;
                client.MedicalDetails = updatedClient.MedicalDetails;

                // Сохраняем обновленный список клиентов в dataClient.json
                _jsonDataService.SaveData(clients, isClientData: true);

                // Обновляем данные на экране
                LoadData();  // Обновляем список клиентов
            }
        }


        // Обработчик для кнопки "Видалити клієнта"
        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var clients = _jsonDataService.LoadData<Client>(isClientData: true);  // Загружаем клиентов из dataClient.json
            var client = clients.FirstOrDefault(c => c.ID == _selectedClient.ID);
            if (client != null)
            {
                clients.Remove(client);  // Удаляем клиента из списка
                _jsonDataService.SaveData(clients, isClientData: true);  // Сохраняем изменения в dataClient.json
                LoadData();  // Обновляем список клиентов
            }
        }
        private void RefeshClient_Click(object sender, RoutedEventArgs e)
        {LoadData();

        }

        // Обработчик для кнопки "Додати абонемент"
        private void AddMembership_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что выбран клиент
            if (_selectedClient != null)
            {
                var addMembershipWindow = new AddMembershipWindow(_selectedClient);  // Передаем выбранного клиента
                addMembershipWindow.MembershipAdded += AddMembershipWindow_MembershipAdded;
                addMembershipWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть клієнта.");
            }
        }

        // Обработчик события добавления абонемента
        private void AddMembershipWindow_MembershipAdded(object sender, Membership newMembership)
        {
            var memberships = _jsonDataService.LoadData<Membership>();  // Загружаем текущий список абонементов
            memberships.Add(newMembership);  // Добавляем новый абонемент
            _jsonDataService.SaveData(memberships);  // Сохраняем изменения в файл
            LoadData();  // Обновляем данные на экране
        }

        // Обработчик для кнопки "Додати оплату"
        private void AddPayment_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что выбран клиент
            if (_selectedClient != null)
            {
                var addPaymentWindow = new AddPaymentWindow(_selectedClient);  // Передаем выбранного клиента
                addPaymentWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть клієнта.");
            }
        }
    }
}
