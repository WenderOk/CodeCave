#include <iostream>

int task1()
{
    int seconds{}, minutes{}, hours{};
    
    std::cout << "Enter time in seconds: ";
    std::cin >> seconds;
    
    minutes = seconds / 60;
    seconds %= 60;
    hours = minutes / 60;
    minutes %= 60;
    

    std::cout << hours << ":" << minutes << ":" << seconds << "\n";

    return 0;
}

int task2() 
{
    double money{};
    int dollars{}, cents{};

    std::cout << "Enter money amount (dollars.cents): ";
    std::cin >> money;
    dollars = money;
    cents = (money - dollars) * 100;

    std::cout << dollars << " dollars " << cents << " cents" << "\n";

    return 0;
}

int task3()
{
    int days{}, weeks{};

    std::cout << "Enter number of days: ";
    std::cin >> days;

    weeks = days / 7;
    days %= 7;

    std::cout << "Weeks " << weeks << " Days " << days << "\n";

    return 0;
}

int task4()
{
    int distance{}, minutes{}, seconds{};
    double time{}, speed{};

    std::cout << "Enter distance (meters): ";
    std::cin >> distance;

    std::cout << "Enter time (minutes.seconds): ";
    std::cin >> time;

    minutes = time;
    seconds = (time - minutes) * 100;
    time = (minutes * 60) + seconds;

    speed = distance / time*3.6;

    std::cout << "Distance: " << distance << " m" << "\n";
    std::cout << "Time: " << time << " seconds" << "\n";
    std::cout << "Speed: " << speed << " km/h" << "\n";

    return 0;
}

// В задании не было уточнено какой процент использовать так что я сделал со сложным
int task5()
{
    double percent{}, monthPercent{}, monthSum{}, sum{};

    std::cout << "Enter deposit amount: ";
    std::cin >> sum;
    std::cout << "Enter percent: ";
    std::cin >> percent;

    monthPercent = percent / 12;
    std::cout << "Monthly percanet: " << monthPercent << "\n";

    std::cout << "Monthly profit: ";
    std::cout << "Deposit status: \n";
    for(int i = 0; i < 12; i++)
        {
            monthSum = sum / 100 * monthPercent;
            std::cout << monthSum << "\t\t";
            sum += monthSum;
            std::cout << sum << "\n";
        }

    return 0;
}

int main()
{
    int tasknum{};
    std::cout << "Enter number of task to run (1-5): "; 
    std::cin >> tasknum;
    if (tasknum == 1) {task1();}
    else if (tasknum == 2) {task2();}
    else if (tasknum == 3) {task3();}
    else if (tasknum == 4) {task4();}
    else if (tasknum == 5) {task5();}
    else {std::cout << "Invalid task number!\n";}
    return 0;
}