#include <iostream>

void bubbleSort(int arr[], int size);
void printArray(int arr[], int size);

int main()
{
    enum menuItems{input_data = 1, output_data, sort_by_mobile, sort_by_home, exit};
    const int size{5};
    int menuItem{};
    int mobileTel[size]{};
    int homeTel[size]{};
    bool isHavingData{false};

    do{
        std::cout << "\nMENU\n"
                  << "1 - input data\n"
                  << "2 - output data\n"
                  << "3 - sort by mobile number\n"
                  << "4 - sort by home number\n"
                  << "5 - exit\n"
                  << "Choose menu item: ";
        std::cin >> menuItem;
        std::cout << '\n';
        switch (menuItem) 
        {
            case input_data:
            {
                std::cout << "Enter data for each user\n";
                for (int i{}; i < size; i++)
                {
                    std::cout << "Input mobile number for " << i + 1 << " user: ";
                    std::cin >> mobileTel[i];
                    std::cout << "Input home tel number for " << i + 1 << " user: ";
                    std::cin >> homeTel[i];
                }
                isHavingData = true;

                break;
            }
            case output_data:
            {
                if(isHavingData)
                {
                    std::cout << "User | Mobile number | Home number\n";
                    for (int i{}; i < size; i++)
                        std::cout << i + 1 << '\t' << mobileTel[i] << '\t' << homeTel[i] << '\n';
                }
                else
                    std::cout << "Enter user data first!\n";

                break;
            }
            case sort_by_mobile:
            {
                if(isHavingData)
                    bubbleSort(mobileTel, size);
                else
                    std::cout << "Enter user data first!\n";

                break;
            }
            case sort_by_home:
            {
                if(isHavingData)
                    bubbleSort(homeTel, size);
                else
                    std::cout << "Enter user data first!\n";
                
                break;
            }
            case exit:
            {
                std::cout << "Exiting...\n";

                break;
            }
            default:
                std::cout << "Wrong menu item!\n";
        }

    }while(menuItem != 5);

    return 0;
}


void bubbleSort(int arr[], int size)
{
    for(int i{}; i < size; i++)
    {
        bool is_swap{false};
        for(int j{}; j < size-i-1; j++)
        {
            is_swap = false;
            if (arr[j] > arr[j+1])
            {
                int tmp = arr[j];
                arr[j] = arr[j+1];
                arr[j+1] = tmp;
                is_swap = true;
            }
        }
        if (!is_swap)
            break;
    }
}

void printArray(int arr[], int size)
{
    for(int i{}; i < size; i++)
        std::cout << arr[i] << " ";
    std::cout << "\n";
}