using PcLibraryApp.Infrastructure;
using PcLibraryApp.Models;
using PcLibraryApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Data.Entity;

namespace PcLibraryApp.ViewModels
{
    public class ConstructorViewModel : ViewModelBase
    {
        private readonly int? _editingBuildId = null;
        private string _buildName = "Новая сборка";
        private Component _selectedCpu;
        private Component _selectedGpu;
        private Component _selectedRam;
        private Component _selectedMotherboard;

        public ObservableCollection<Component> AvailableCpus { get; set; }
        public ObservableCollection<Component> AvailableGpus { get; set; }
        public ObservableCollection<Component> AvailableRams { get; set; }
        public ObservableCollection<Component> AvailableMotherboards { get; set; }

        public string BuildName { get => _buildName; set => SetProperty(ref _buildName, value); }

        public Component SelectedCpu { get => _selectedCpu; set { if (SetProperty(ref _selectedCpu, value)) UpdateTotals(); } }
        public Component SelectedGpu { get => _selectedGpu; set { if (SetProperty(ref _selectedGpu, value)) UpdateTotals(); } }
        public Component SelectedRam { get => _selectedRam; set { if (SetProperty(ref _selectedRam, value)) UpdateTotals(); } }
        public Component SelectedMotherboard { get => _selectedMotherboard; set { if (SetProperty(ref _selectedMotherboard, value)) UpdateTotals(); } }

        public decimal TotalPrice =>
            (SelectedCpu?.Price ?? 0) +
            (SelectedGpu?.Price ?? 0) +
            (SelectedRam?.Price ?? 0) +
            (SelectedMotherboard?.Price ?? 0);

        public string TotalTdp => "Расчет TDP доступен в PRO версии";

        public ICommand SaveBuildCommand { get; }

        public ConstructorViewModel()
        {
            AvailableCpus = new ObservableCollection<Component>();
            AvailableGpus = new ObservableCollection<Component>();
            AvailableRams = new ObservableCollection<Component>();
            AvailableMotherboards = new ObservableCollection<Component>();

            LoadAvailableComponents();

            // Кнопка сохранения активна, если введено имя сборки и выбран хотя бы один компонент
            SaveBuildCommand = new RelayCommand(p => SaveBuild(), c => !string.IsNullOrWhiteSpace(BuildName) && TotalPrice > 0);
        }

        public ConstructorViewModel(PcBuild buildToEdit) : this()
        {
            if (buildToEdit == null) return;

            _editingBuildId = buildToEdit.Id;
            BuildName = buildToEdit.Name;

            foreach (var comp in buildToEdit.Components)
            {
                if (comp.Category.Equals("CPU", StringComparison.OrdinalIgnoreCase)) { AvailableCpus.Add(comp); SelectedCpu = comp; }
                else if (comp.Category.Equals("GPU", StringComparison.OrdinalIgnoreCase)) { AvailableGpus.Add(comp); SelectedGpu = comp; }
                else if (comp.Category.Equals("RAM", StringComparison.OrdinalIgnoreCase)) { AvailableRams.Add(comp); SelectedRam = comp; }
                else if (comp.Category.Equals("Motherboard", StringComparison.OrdinalIgnoreCase)) { AvailableMotherboards.Add(comp); SelectedMotherboard = comp; }
            }
        }

        private void LoadAvailableComponents()
        {
            using (var db = new AppDbContext())
            {
                // Загружаем только те физические детали, которые свободны (BuildId == null)
                var freeComponents = db.Components.Where(c => c.BuildId == null).ToList();

                foreach (var item in freeComponents)
                {
                    // Распределяем по спискам в зависимости от категории
                    if (item.Category.Equals("CPU", StringComparison.OrdinalIgnoreCase)) AvailableCpus.Add(item);
                    else if (item.Category.Equals("GPU", StringComparison.OrdinalIgnoreCase)) AvailableGpus.Add(item);
                    else if (item.Category.Equals("RAM", StringComparison.OrdinalIgnoreCase)) AvailableRams.Add(item);
                    else if (item.Category.Equals("Motherboard", StringComparison.OrdinalIgnoreCase)) AvailableMotherboards.Add(item);
                }
            }
        }

        private void UpdateTotals()
        {
            // Уведомляем интерфейс, что итоговая цена изменилась
            OnPropertyChanged(nameof(TotalPrice));
        }

        private void SaveBuild()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    PcBuild currentBuild;

                    if (_editingBuildId.HasValue)
                    {
                        // Режим редактирования: берем существующую сборку и очищаем старые привязанные детали
                        currentBuild = db.Builds.Include(b => b.Components).FirstOrDefault(b => b.Id == _editingBuildId.Value);
                        if (currentBuild == null) return;

                        currentBuild.Name = BuildName.Trim();

                        // "Освобождаем" абсолютно все старые детали этой сборки в базе данных
                        var oldComponents = db.Components.Where(c => c.BuildId == currentBuild.Id).ToList();
                        foreach (var oldComp in oldComponents)
                        {
                            oldComp.BuildId = null;
                        }
                        db.SaveChanges();
                    }
                    else
                    {
                        // Режим создания новой сборки
                        currentBuild = new PcBuild { Name = BuildName.Trim() };
                        db.Builds.Add(currentBuild);
                        db.SaveChanges();
                    }

                    // Привязываем новые выбранные детали к Id нашей сборки
                    var selectedItems = new List<Component> { SelectedCpu, SelectedGpu, SelectedRam, SelectedMotherboard };
                    foreach (var item in selectedItems)
                    {
                        if (item == null) continue;
                        var dbComponent = db.Components.Find(item.Id);
                        if (dbComponent != null)
                        {
                            dbComponent.BuildId = currentBuild.Id;
                        }
                    }

                    db.SaveChanges();
                }

                string msg = _editingBuildId.HasValue ? "Сборка успешно обновлена!" : $"Сборка '{BuildName}' успешно сохранена!";
                MessageBox.Show(msg, "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                ResetConstructor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении сборки: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ResetConstructor()
        {
            BuildName = "Новая сборка";
            SelectedCpu = null;
            SelectedGpu = null;
            SelectedRam = null;
            SelectedMotherboard = null;

            AvailableCpus.Clear();
            AvailableGpus.Clear();
            AvailableRams.Clear();
            AvailableMotherboards.Clear();
            LoadAvailableComponents();
        }
    }
}
