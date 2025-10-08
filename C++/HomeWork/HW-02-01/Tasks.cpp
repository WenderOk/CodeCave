#include <iostream>
#include <cmath>

int task1()
{
    double R0{}, R1{}, R2{}, R3{};
    
    std::cout << "Enter values of R1, R2 and R3 separating numbers with space\n";
    std::cin >> R1 >> R2 >> R3;
    
    R0 = 1/(1/R1+1/R2+1/R3);

    std::cout << "R0 = " << R0 << "\n";

    return 0;
}

int task2() 
{
    double L{}, S{}, R{};
    const double PI{3.14};

    std::cout << "Enter value of L\n";
    std::cin >> L;
    R = L/(2*PI);
    S = PI*pow(R,2);

    std::cout << "S = " << S << "\n";

    return 0;
}

int task3()
{
    double v{}, t{}, a{}, S{};

    std::cout << "Enter values of v, t and a separating numbers with space\n";
    std::cin >> v >> t >> a;

    S = v*t+(a*pow(t,2))/2;

    std::cout << "S = " << S << "\n";

    return 0;
}

int main()
{
    int tasknum{};
    std::cout << "Enter number of task to run (1-3):\n"; 
    std::cin >> tasknum;
    if (tasknum == 1) {task1();}
    else if (tasknum == 2) {task2();}
    else if (tasknum == 3) {task3();}
    else {std::cout << "Invalid task number!\n";}
    return 0;
}