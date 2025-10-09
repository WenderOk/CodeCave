#include <iostream>

int task1()
{
    double distance{}, time{}, speed{};
    
    std::cout << "Enter distance (km): ";
    std::cin >> distance;

    std::cout << "Enter time (min): ";
    std::cin >> time;
    
    speed = distance / (time / 60);

    std::cout << "Speed: "<< speed << " km/h" << "\n";

    return 0;
}

int task2() 
{
    int seconds1{}, minutes1{}, hours1{};
    int seconds2{}, minutes2{}, hours2{};
    int time{}, time1{}, time2{};
    double cost{}, price{};

    std::cout << "Enter start time (hours minutes seconds): ";
    std::cin >> hours1 >> minutes1 >> seconds1;

    std::cout << "Enter end time (hours minutes seconds): ";
    std::cin >> hours2 >> minutes2 >> seconds2;

    std::cout << "Enter price (rub/min): ";
    std::cin >> price;
    
    time1 = hours1 * 60 + minutes1 + seconds1 / 60;
    time2 = hours2 * 60 + minutes2 + seconds2 / 60;
    time = time2 - time1;
    cost = time * price;
    
    std::cout << "Total cost: "<< cost << " rub" <<"\n";

    return 0;
}

int task3()
{
    double distance{}, consumption{}, price1{}, price2{}, price3{};

    std::cout << "Enter distnace (km): ";
    std::cin >> distance;

    std::cout << "Enter fuel consumption (l/100km): ";
    std::cin >> consumption;

    std::cout << "Enter price for 3 types of fuel (separating with space): ";
    std::cin >> price1 >> price2 >> price3;

    std::cout << "АИ-92\t" << "АИ-95\t" << "АИ-98" << "\n";
    std::cout << distance * price1 * consumption / 100 << "\t" << distance * price2 * consumption / 100 << "\t" << distance * price3 * consumption / 100 << "\n";

    return 0;
}

int main()
{
    int tasknum{};
    std::cout << "Enter number of task to run (1-3): "; 
    std::cin >> tasknum;
    if (tasknum == 1) {task1();}
    else if (tasknum == 2) {task2();}
    else if (tasknum == 3) {task3();}
    else {std::cout << "Invalid task number!\n";}
    return 0;
}