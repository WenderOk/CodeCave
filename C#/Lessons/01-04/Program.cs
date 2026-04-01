using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interf_1
{
    internal class Program
    {
        public interface IPayment
        {
            void Pay(double amount);
        }
        public class CardPayment : IPayment
        {

            public CardPayment() { }

            public void Pay(double amount)
            {
                Console.WriteLine($"Оплата картой на сумму {amount} выполнена");
            }
        }
        public class CashPayment : IPayment
        {

            public CashPayment() { }

            public void Pay(double amount)
            {
                Console.WriteLine($"Оплата наличными на сумму {amount} выполнена");
            }
        }
        public class Shop
        {
            public double Purchase_price { get; set; } //стоимость покупки
            //Shop не знает, как происходит оплата - это делает интерфейс
            public void ProcessPayment(IPayment payment)
            {
                payment.Pay(Purchase_price);
            }
        }
        public class Test
        {
            public void Run()
            {
                Shop shop = new Shop();
                //ввод суммы
                Console.Write("введите сумму покупки:    ");
                if (!double.TryParse(Console.ReadLine(), out double amount))
                {
                    Console.WriteLine("ошибка ввода");
                    return;
                }
                shop.Purchase_price = amount;

                //выбрать способ оплаты
                Console.WriteLine("М е н ю     Выберите способ оплаты ");
                Console.WriteLine("1. Карта");
                Console.WriteLine("2. Наличные");

                string choise = Console.ReadLine();
                IPayment payment = GetPaymentMethod(choise);  //жесткая зависимость
                                                              //выбор и создание осуществляется в классе
                if (payment == null)
                {
                    Console.WriteLine("Неверный выбор");
                    return;
                }
                // выполнение оплаты
                shop.ProcessPayment(payment);

            }
            private IPayment GetPaymentMethod(string choise)
            {
                switch (choise)
                {
                    case "1": return new CardPayment();
                    case "2": return new CashPayment();
                    default: return null;
                }
            }

        }
        public class Test2
        {
            private readonly IPayment payment_spos;
            public Test2(IPayment payment)
            {
                payment_spos = payment;
            }

            public void run()
            {   
                Console.Write("введите сумму покупки:    ");
                if (!double.TryParse(Console.ReadLine(), out double amount))
                {
                    Console.WriteLine("ошибка ввода");
                    return;
                }
                Shop shop = new Shop();
                shop.Purchase_price = amount;
                shop.ProcessPayment(payment_spos);
            }
        }

        public class Test2Menu
        {
            public void run()
            { 
                Console.WriteLine("М е н ю     Выберите способ оплаты ");
                Console.WriteLine("1. Карта");
                Console.WriteLine("2. Наличные");
                string choice = Console.ReadLine();
                IPayment payment = null;
                switch (choice)
                {
                    case "1": 
                        payment = new CardPayment();
                        break;
                    case "2": 
                        payment = new CashPayment();
                        break;
                    default: 
                        Console.WriteLine("Wrong input!");
                        return;
                }
                Test2 t2 = new Test2( payment = payment );
                t2.run();
            }
        }

    
        static void Main(string[] args)
        {
            Test2Menu t2m = new Test2Menu();
            t2m.run();
        }
    }
}
