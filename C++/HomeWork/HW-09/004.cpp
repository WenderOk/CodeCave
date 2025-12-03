#include <iostream>

double changeCurrency(double deposit, double rate, double percent);

int main()
{
    const int numMonths{12};
    double initialDeposit{};
    std::cout << "Enter deposit in euro: ";
    std::cin >> initialDeposit;
    
    double rates[numMonths];
    double percents[numMonths];
    
    for(int i = 0; i < numMonths; ++i)
    {
        std::cout << "Enter dollar to euro exchange (" << i + 1 << " month): ";
        std::cin >> rates[i];
        
        std::cout << "Enter deposit percent (" << i + 1 << " month): ";
        std::cin >> percents[i];
    }
    
    while(true)
    {
        int month_index;
        std::cout << "\nEnter number of month (1 - " << numMonths << ", or enter negative number to exit): ";
        std::cin >> month_index;
        
        if(month_index <= 0 || month_index > numMonths)
            break;
            
        double withdrawalAmount = changeCurrency(initialDeposit, rates[month_index - 1], percents[month_index - 1]);
        
        if(withdrawalAmount > 0)
            std::cout << "Money is available for withdrawal: $" << withdrawalAmount << "\n";
        else
            std::cout << "Not enough for withdrawal." << "\n";
    }
    
    return 0;
}

double changeCurrency(double deposit, double rate, double percent)
{
    double profit_Euro = deposit * (percent / 100);    
    double profit_Dollars = profit_Euro * rate;
    
    if (profit_Dollars >= 500) 
        return profit_Dollars / 2;
    else 
        return 0;
}
