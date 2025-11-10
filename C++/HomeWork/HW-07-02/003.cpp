#include <iostream>
 
void print_menu();

int main()
{
    const int categories{2};
    const int products{4};

    double prices[categories][products] {
        {50.0, 75.0, 150.0, 300.0},
        {25.0, 30.0, 40.0, 50.0}
    };
 
    int customers{};
    int cost{};

    std::cout << "Enter amount of customers: ";
    std::cin >> customers;

    for(int i{}; i < customers; i++)
    {
        std::cout << "Customer number " << i+1;
        int product_id{};
        int category_id{};

        do
        {
            int product_amount{};
            char answer{'y'};

            print_menu();

            std::cout << "Choose category, product and amount: ";
            std::cin >> category_id >> product_id >> product_amount;

            if((category_id-1 < 0) | (category_id > categories))
            {
                std::cout << "Wrong category number!\n";
                continue;
            }
            if((product_id-1 < 0) | (product_id > products))
            {
                std::cout << "Wrong product number!\n";
                continue;
            }

            cost += prices[category_id-1][product_id-1] * product_amount;

            std::cout << "Continue order? (y/n): ";
            std::cin >> answer;

            if(answer == 'n')
                break;

        }while(1);
    }

    std::cout << "\nTotal cost: " << cost << " rub\n";
    return 0;
}


void print_menu()
{
    std::cout << "\nMENU\n"
              << "1 Pastry\n"
              << "1. Sugar bun - 50 rub\n"
              << "2. Apple pie - 75 rub\n"
              << "3. Eclair - 150 rub\n"
              << "4. Chocolate cake - 300 rub\n"
              << "2 Drinks\n"
              << "1. Black tea - 25 rub\n"
              << "2. Green tea - 30 rub\n"
              << "3. Juice - 40 rub\n"
              << "4. Coffee - 50 rub\n";
}