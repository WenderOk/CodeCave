using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace _02_06
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double totalExpence = 0.0;
        public ObservableCollection<CheckMoney> checkMoneyList = new ObservableCollection<CheckMoney>();
        public int nextId = 0;
        public string strCategory {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private double DeterminateTaxRate()
        {
            if (radioButtonFood.IsChecked == true)
            {
                strCategory = "Food ";
                return 0.05;
            }
            else if (radioButtonTransport.IsChecked == true)
            {
                strCategory = "Transport ";
                return 0.1;
            }
            else if (radioButtonGames.IsChecked == true)
            {
                strCategory = "Game ";
                return 0.15;
            }
            else return 0;
        }

        private double DeterminationAdditionalCard()
        {
            return radioButtonCard.IsChecked == true ? 0.02 : 0.0;
        }

        private double CalculateDiscount()
        {
            if (checkBox10.IsChecked == true)
                return 0.1;
            else if (checkBox15.IsChecked == true)
                return 0.15;
            else if (checkBox20.IsChecked == true)
                return 0.2;
            else return 0.0;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(textBoxAmount.Text, out double amount) )
            {
                double taxRateAmount = DeterminateTaxRate() * amount;
                double additionalCardAmount = DeterminationAdditionalCard() * amount; 
                double discountAmount = CalculateDiscount() * amount;
                
                CheckMoney money = new CheckMoney();
                money.Id = nextId;
                money.Category = strCategory;
                money.Amount = amount;
                money.TaxRateSum = taxRateAmount;
                money.AdditionalCardSum = additionalCardAmount;
                money.DiscountSum = discountAmount;
                money.TotalSum = amount + taxRateAmount + additionalCardAmount - discountAmount;
                checkMoneyList.Add(money);
                nextId++;

                amount += taxRateAmount;
                amount += additionalCardAmount;
                amount -= discountAmount;
                totalExpence += amount;
                lbl.Content = "Текущая трата " + amount.ToString() + " руб.";
                LabelTotal.Content = $"Итого: {totalExpence} руб.";

            }
        }

        private void ButtonViewList_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1(checkMoneyList, totalExpence.ToString());
            window.ShowDialog();
        }
    }
}
