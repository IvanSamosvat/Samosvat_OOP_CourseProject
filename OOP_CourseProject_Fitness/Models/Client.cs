using System.Collections.Generic;
using System.ComponentModel;
using OOP_CourseProject_Fitness.Interfaces;

namespace OOP_CourseProject_Fitness.Models
{
    public class Client : Entity, INamedEntity, INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string contactInfo;
        private string medicalDetails;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Membership> Memberships { get; set; } = new List<Membership>();
        public List<Payment> Payments { get; set; } = new List<Payment>();

        public string Name
        {
            get => $"{FirstName} {LastName}";
            set
            {
                var parts = value.Split(' ');
                if (parts.Length >= 2)
                {
                    FirstName = parts[0];
                    LastName = parts[1];
                }
            }
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged(nameof(LastName));
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string ContactInfo
        {
            get => contactInfo;
            set
            {
                if (contactInfo != value)
                {
                    contactInfo = value;
                    OnPropertyChanged(nameof(ContactInfo));
                }
            }
        }

        public string MedicalDetails
        {
            get => medicalDetails;
            set
            {
                if (medicalDetails != value)
                {
                    medicalDetails = value;
                    OnPropertyChanged(nameof(MedicalDetails));
                }
            }
        }

        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public override string GetInfo()
        {
            return $"Client: {Name}, Contact: {ContactInfo}, Medical Info: {MedicalDetails}";
        }
    }
}
