#include <iostream>

int main()
{
    int distance1{};
    int distance2{};
    int weight{};
    int fuelCap{300};
    int minFuel{};
    int fuelConsum{};
    
    std::cout << "Enter distance between A and B (km): ";
    std::cin >> distance1;
    std::cout << "Enter distance between B and C (km): ";
    std::cin >> distance2;
    std::cout << "Enter weight (kg): ";
    std::cin >> weight;

    if(weight < 500)
    {
        fuelConsum = 1;
        if(fuelConsum * distance1 <= fuelCap && fuelConsum * distance2 <= fuelCap)
        {
            if(fuelCap - fuelConsum * distance1 <= fuelConsum * distance2)
            {
                minFuel = (fuelConsum * distance2) - (fuelCap - fuelConsum * distance1);
            }
        }
        else
        {
            std::cout << "Not enough fuel capacity for this distances!\n";
            return 0;
        }
    }
    else if(weight < 1000)
    {
        fuelConsum = 4;
        if(fuelConsum * distance1 <= fuelCap && fuelConsum * distance2 <= fuelCap)
        {
            if(fuelCap - fuelConsum * distance1 <= fuelConsum * distance2)
            {
                minFuel = (fuelConsum * distance2) - (fuelCap - fuelConsum * distance1);
            }
        }
        else
        {
            std::cout << "Not enough fuel capacity for this distances!\n";
            return 0;
        }
    }
    else if(weight < 1500)
    {
        fuelConsum = 7;
        if(fuelConsum * distance1 <= fuelCap && fuelConsum * distance2 <= fuelCap)
        {
            if(fuelCap - fuelConsum * distance1 <= fuelConsum * distance2)
            {
                minFuel = (fuelConsum * distance2) - (fuelCap - fuelConsum * distance1);
            }
        }
        else
        {
            std::cout << "Not enough fuel capacity for this distances!\n";
            return 0;
        }
    }
    else if(weight < 2000)
    {
        fuelConsum = 9;
        if(fuelConsum * distance1 <= fuelCap && fuelConsum * distance2 <= fuelCap)
        {
            if(fuelCap - fuelConsum * distance1 <= fuelConsum * distance2)
            {
                minFuel = (fuelConsum * distance2) - (fuelCap - fuelConsum * distance1);
            }
        }
        else
        {
            std::cout << "Not enough fuel capacity for this distances!\n";
            return 0;
        }
    }
    else
    {
        std::cout << "Too much weight!\n";
        return 0;
    }

    std::cout << "Minimum amount of fuel for refueling is: " << minFuel << "\n";

    return 0;
}