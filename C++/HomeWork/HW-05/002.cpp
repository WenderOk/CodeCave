#include <iostream>

int main() {
    int ml1{};
    int ml2{};
    int ml3{};
    int bestM{};
    int max{};

    double salary1{};
    double salary2{};
    double salary3{};

    std::cout << "Input level of first manager:\n";
    std::cin >> ml1;
    std::cout << "Input level of second manager:\n";
    std::cin >> ml2;
    std::cout << "Input level of third manager:\n";
    std::cin >> ml3;

    if (ml1 < 500)
        salary1 = 200 + ml1 * 0.003;
    
    else if ((ml1 >= 500) && (ml1 < 1000))
        salary1 = 200 + ml1 * 0.005;

    else
        salary1 = 200 + ml1 * 0.008;
    
    if (ml2 < 500)
        salary2 = 200 + ml2 * 0.003;
    
    else if ((ml1 >= 500) && (ml2 < 1000))
        salary2 = 200 + ml2 * 0.005;
    
    else
        salary2 = 200 + ml2 * 0.008;
    
    if (ml3 < 500)
        salary3 = 200 + ml3 * 0.003;
    
    else if ((ml1 >= 500) && (ml3 < 1000))
        salary3 = 200 + ml3 * 0.005;
    
    else
        salary3 = 200 + ml3 * 0.008;
    
    if (ml1 > ml2)
    {
        bestM = 1;
        max = ml1;
    }
    else
    {
        bestM = 2;
        max = ml2;
    }
    if (ml3 > max)
    {
        bestM = 3;
    }
    
    switch (bestM)
    {
    case 1: 
        salary1 = salary1 + 200;
    break;
    case 2: 
        salary2 = salary2 + 200;
    break;
    case 3: 
        salary3 = salary3 + 200;
    break;
    }

    std::cout << "The best — " << bestM << " manager.\n";
    std::cout << "First manager salary: " << salary1 << "\n";
    std::cout << "Second manager salary: " << salary2 << "\n";
    std::cout << "Third manager salary: " << salary3 << "\n";

    return 0;
}