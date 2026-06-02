using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_06
{
    public class CheckMoney
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }
        public double Amount { get; set; }
        public double TaxRateSum { get; set; }
        public double AdditionalCardSum { get; set; }
        public double DiscountSum { get; set; }
        public double TotalSum { get; set; }
        public CheckMoney()
        { }

        public CheckMoney(int id, string category, double amount, double taxRateSum, double additionalCardSum, double discountSum, double totalSum)
        {
            Id = id;
            Category = category;
            Date = DateTime.Now.ToString();
            Amount = amount;
            TaxRateSum = taxRateSum;
            AdditionalCardSum = additionalCardSum;
            DiscountSum = discountSum;
            TotalSum = totalSum;
        }

        public string Display
        {
            get { return $"ID: {Id,-5} | Категория: {Category,-15} | Дата: {Date,-10} | Сумма: {Amount,10:F2} | Налог: {TaxRateSum,10:F2} | Доп. карта: {AdditionalCardSum,10:F2} | Скидка: {DiscountSum,10:F2} | Итого: {TotalSum,10:F2}"; }
        }
    }
}
