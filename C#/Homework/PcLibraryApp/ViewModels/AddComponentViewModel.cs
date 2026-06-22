using PcLibraryApp.Infrastructure;
using PcLibraryApp.ViewModels.Base;
using PcLibraryApp.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace PcLibraryApp.ViewModels
{
    public class AddComponentViewModel : ViewModelBase
    {
        private readonly int? _editingComponentId = null;
        private string _category = "CPU"; // Значение по умолчанию
        private string _manufacturer = string.Empty;
        private string _model = string.Empty;
        private decimal _price;
        private string _description = string.Empty;

        public string FormTitle => _editingComponentId.HasValue ? "Редактирование компонента" : "Добавление нового компонента";

        // Массив категорий для выпадающего списка (ComboBox)
        public string[] Categories { get; } = { "CPU", "GPU", "RAM", "Motherboard", "Power Supply", "Storage" };

        public string Category { get => _category; set => SetProperty(ref _category, value); }
        public string Manufacturer { get => _manufacturer; set => SetProperty(ref _manufacturer, value); }
        public string Model { get => _model; set => SetProperty(ref _model, value); }
        public decimal Price { get => _price; set => SetProperty(ref _price, value); }
        public string Description { get => _description; set => SetProperty(ref _description, value); }

        public ICommand SaveCommand { get; }

        public AddComponentViewModel()
        {
            // Команда сохранения активна, только если заполнены производитель и модель
            SaveCommand = new RelayCommand(p => SaveComponent(), c => !string.IsNullOrWhiteSpace(Manufacturer) && !string.IsNullOrWhiteSpace(Model));
        }

        public AddComponentViewModel(Component component) : this()
        {
            if (component == null) return;

            _editingComponentId = component.Id;
            Category = component.Category;
            Manufacturer = component.Manufacturer;
            Model = component.Model;
            Price = component.Price;
            Description = component.Description;
        }

        private void SaveComponent()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    if (_editingComponentId.HasValue)
                    {
                        // РЕЖИМ РЕДАКТИРОВАНИЯ: Находим деталь в БД и обновляем поля
                        var dbComponent = db.Components.Find(_editingComponentId.Value);
                        if (dbComponent != null)
                        {
                            dbComponent.Category = this.Category;
                            dbComponent.Manufacturer = this.Manufacturer.Trim();
                            dbComponent.Model = this.Model.Trim();
                            dbComponent.Price = this.Price;
                            dbComponent.Description = this.Description.Trim();
                        }
                    }
                    else
                    {
                        // РЕЖИМ СОЗДАНИЯ: Добавляем новую запись
                        var newComponent = new Component
                        {
                            Category = this.Category,
                            Manufacturer = this.Manufacturer.Trim(),
                            Model = this.Model.Trim(),
                            Price = this.Price,
                            Description = this.Description.Trim(),
                            BuildId = null
                        };
                        db.Components.Add(newComponent);
                    }

                    db.SaveChanges();
                }

                string successMessage = _editingComponentId.HasValue ? "Изменения успешно сохранены!" : "Компонент успешно добавлен в каталог!";
                MessageBox.Show(successMessage, "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                if (!_editingComponentId.HasValue) ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearFields()
        {
            Manufacturer = string.Empty;
            Model = string.Empty;
            Price = 0;
            Description = string.Empty;
        }
    }
}
