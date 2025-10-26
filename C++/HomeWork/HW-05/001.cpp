#include <iostream>

int main()
{
    enum pizza {peperoni = 1, pineapple, cheese, mix}; 
    enum drinks {tea = 1, coffee, cola};
    int pizzaID{};
    int drinkID{};

    int pizzaAmount{};
    int drinkAmount{};
    
    double pizzaCost{};
    double drinkCost{};
    
    int temp{};
    
    double peperoniPrice{5.5};
    double pineapplePrice{7.42};
    double cheesePrice{12.78};
    double mixPrice{15.21};

    double teaPrice = 1.1;
    double coffeePrice = 2.3;
    double colaPrice = 3.45;

    double orderCost{};

    std::cout << "Choose pizza:\n";
    std::cout << "1 - Peperoni Pizza " << peperoniPrice << " rub" << "\n"; 
    std::cout << "2 - Pineapple Pizza " << pineapplePrice << " rub" << "\n";
    std::cout << "3 - Cheese Pizza " << cheesePrice << " rub" << "\n";
    std::cout << "4 - Mix Pizza " << mixPrice << " rub" << "\n";
    std::cin >> pizzaID;

    std::cout << "Enter amount of pizza: ";
    std::cin >> pizzaAmount;

    std::cout << "Choose a drink:\n";
    std::cout << "1 - Black tea (0,5) " << teaPrice << " rub" << "\n";
    std::cout << "2 - Coffee latte (0,5) " << coffeePrice << " rub" << "\n";
    std::cout << "3 - Coca-cola (1,5 l) " << colaPrice << " rub" << "\n";
    std::cin >> drinkID;
    std::cout << "Enter amount of drink: ";
    std::cin >> drinkAmount;

    switch (pizzaID)
    {
    case peperoni:
        pizzaCost = peperoniPrice;
    break;
    case pineapple:
        pizzaCost = pineapplePrice;
    break;
    case cheese:
        pizzaCost = cheesePrice;
    break;
    case mix:
        pizzaCost = mixPrice;
    break;
    default:
        std::cout << "There is no pizza with this ID\n";
        pizzaCost = 0;
    break;
    }

    switch (drinkID)
    {
    case tea:
        drinkCost = teaPrice;
    break;
    case coffee:
        drinkCost = coffeePrice;
    break;
    case cola:
        drinkCost = colaPrice;
    break;
    default:
        std::cout << "There is no drink with this ID\n";
        drinkCost = 0;
    break;
    }

    temp = pizzaAmount;

    if (pizzaAmount >= 5)
    {
        std::cout << "You have a discount - every 5th pizza is free\n";
        pizzaAmount /= pizzaAmount / 5;
    }

    orderCost += pizzaAmount * pizzaCost;

    if ((drinkAmount >= 3) && (drinkCost>2))
    {
        std::cout << "You have a discount on drinks\n";
        orderCost += drinkAmount * drinkCost * (1 - 0.15);
    }
    else
    {
        orderCost += drinkAmount * drinkCost;
    }
    if (orderCost > 50)
    {
        std::cout << "You have a discount (20%) for whole order\n";
        orderCost = orderCost * (1 - 0.2);
    }

    std::cout << "Your order:\n";
    std::cout << "Pizza №"<< pizzaID <<" - x" << temp <<" - " << pizzaCost << " rub" <<"\n";
    std::cout << "Drink №" << drinkID << " - x" << drinkAmount << " - " << drinkCost << " rub" << "\n";
    std::cout << "Sum: "<< orderCost << " rub" << "\n";

    return 0;
}