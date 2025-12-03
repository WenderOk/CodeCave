#include <iostream>

void printArray(double arr[], int size);
void inputArray(double arr[], int size);
double avgInArr(int arr[], int size);
double sumArr(int arr[], int size);

int main()
{
    const int size{7};
    double arr[size]{};

    inputArray(arr, size);
    std::cout << "Entered expenses: ";
    printArray(arr, size);
    
    int count{};
    for(int i{}; i < size; i++)
    {
        if(arr[i] > 100)
        {
            count++;
            switch (i)
            {
            case 0:
                std::cout << "On Monday expenses were more than 100$ and were equals = "
                          << arr[i] << "\n";
                break;
            case 1:
            std::cout << "On Tuesday expenses were more than 100$ and were equals = "
                        << arr[i] << "\n";
                break;
            case 2:
            std::cout << "On Wednesday expenses were more than 100$ and were equals = "
                        << arr[i] << "\n";
                break;
            case 3:
            std::cout << "On Thursday expenses were more than 100$ and were equals = "
                        << arr[i] << "\n";
                break;
            case 4:
            std::cout << "On Friday expenses were more than 100$ and were equals = "
                        << arr[i] << "\n";
                break;
            case 5:
            std::cout << "On Saturday expenses were more than 100$ and were equals = "
                        << arr[i] << "\n";
                break;
            case 6:
            std::cout << "On Sunday expenses were more than 100$ and were equals = "
                        << arr[i] << "\n";
                break;
            default:
                std::cout << "Wrong number of days!\n";
                break;
            }
        }
    }
    std::cout << "Number of days of overspending: " << count << "\n";
}

double sumArr(double arr[], int size)
{
    double sum{};
    for(int i{}; i < size; i++)
        sum += arr[i];
    return sum;
}

double avgInArr(double arr[], int size)
{
    double sum{};
    for(int i{}; i < size; i++)
        sum += arr[i];
    return sum / size;
}

void inputArray(double arr[], int size)
{
    std::cout << "Enter expenses for each day of week\n";
    for(int i{}; i < size; i++)
    {
        std::cout << "For " << i+1 << " day: ";
        std::cin >> arr[i];
    }
}

void printArray(double arr[], int size)
{
    for(int i{}; i < size; i++)
        std::cout << arr[i] << " ";
    std::cout << "\n";
}