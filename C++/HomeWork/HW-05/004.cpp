#include <iostream>

int main()
{
    int userOp{};
    int companionOp{};
    int callMin{};

    double minCost1{2};
    double minCost2{3};
    double minCost3{2.5};

    std::cout << "1 - LEOphone\n";
    std::cout << "2 - Artelink\n";
    std::cout << "3 - Sevanet\n\n";
    std::cout << "Select your mobile operator: ";
    std::cin >> userOp;
    std::cout << "Select your friend mobile operator: ";
    std::cin >> companionOp;

    std::cout << "Enter call duration:\n";
    std::cin >> callMin;

    if (userOp == companionOp)
        std::cout << "No commission!";
    
    else if (userOp == 1)
        std::cout << "Call cost - " << callMin * minCost1;
    
    else if (userOp == 2)
        std::cout << "Call cost - " << callMin * minCost2;
    
    else if (userOp == 3)
        std::cout << "Call cost - " << callMin * minCost3;
    
    else
        std::cout << "Wrong input!";
    
    return 0;
}