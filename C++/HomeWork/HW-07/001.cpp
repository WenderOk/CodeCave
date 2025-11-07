#include <iostream>

int main()
{
    int width{};
    int height{};
    int flag{-1};

    while(flag != 0)
    {
        std::cout << "\nFigure drawer\n";
        std::cout << "Enter number of figure (enter 0 to exit): ";
        std::cin >> flag;

        switch  (flag)
        {
            case 1:
            std::cout << "Enter width and height: ";
            std::cin >> width >> height;

            for(int j{1}; j <= height; j++)
            {
                for (int i{1}; i <= width; i++)
                {
                    if(i > j)
                        std::cout << "@ ";
                    else
                        std::cout << "  ";
                }
                std::cout << "\n";
            }
            break;

            case 2:
            std::cout << "Enter width and height: ";
            std::cin >> width >> height;

            for(int j{1}; j <= height; j++)
            {
                for (int i{1}; i <= width; i++)
                {
                    if(i < j)
                        std::cout << "@ ";
                    else
                        std::cout << "";
                }
                std::cout << "\n";
            }
            break;

            case 3:
            std::cout << "Enter width and height: ";
            std::cin >> width >> height;

            for(int j{1}; j <= height; j++)
            {
                for (int i{1}; i <= width; i++)
                {
                    if((i > j) && (i + j < width + 1))
                        std::cout << " @";
                    else
                        std::cout << "  ";
                }
                std::cout << "\n";
            }
            break;

            case 4:
            std::cout << "Enter width and height: ";
            std::cin >> width >> height;

            for(int j{1}; j <= height; j++)
            {
                for (int i{1}; i <= width; i++)
                {
                    if((i < j) && (i + j > width + 1))
                        std::cout << " @";
                    else
                        std::cout << "  ";
                }
                std::cout << "\n";
            }
            break;

            case 5:
            std::cout << "Enter width and height: ";
            std::cin >> width >> height;

            for(int j{1}; j <= height; j++)
            {
                for (int i{1}; i <= width; i++)
                {
                    if(((i > j) && (i + j < width + 1)) | (i + j == width + 1))
                        std::cout << "@ ";
                    else if(((i < j) && (i + j > width + 1)) | (i == j))
                        std::cout << "@ ";
                    else
                        std::cout << "  ";
                }
                std::cout << "\n";
            }
            break;

            case 6:
            std::cout << "Enter width and height: ";
            std::cin >> width >> height;

            for(int j{1}; j <= height; j++)
            {
                for (int i{1}; i <= width; i++)
                {
                    if(((i < j) && (i + j < width + 1)) | (i == j))
                        std::cout << "@ ";
                    else if(((i > j) && (i + j > width + 1)) | (i + j == width + 1))
                        std::cout << "@ ";
                    else
                        std::cout << "  ";
                }
                std::cout << "\n";
            }
            break;

            case 7:
            std::cout << "Enter width and height: ";
            std::cin >> width >> height;

            for(int j{1}; j <= height; j++)
            {
                for (int i{1}; i <= width; i++)
                {
                    if((i < j) && (i + j < width + 1))
                        std::cout << "@ ";
                    else
                        std::cout << "  ";
                }
                std::cout << "\n";
            }
            break;

            case 8:
            std::cout << "Enter width and height: ";
            std::cin >> width >> height;

            for(int j{1}; j <= height; j++)
            {
                for (int i{1}; i <= width; i++)
                {
                    if((i > j) && (i + j > width + 1))
                        std::cout << "@ ";
                    else
                        std::cout <<  "  ";
                }
                std::cout << "\n";
            }
            break;

            case 9:
            std::cout << "Enter width and height: ";
            std::cin >> width >> height;

            for(int j{1}; j <= height; j++)
            {
                for (int i{1}; i <= width; i++)
                {
                    if(i > j)
                        std::cout << " @";
                    else
                        std::cout << "";
                }
                std::cout << "\n";
            }
            break;

            case 10:
            std::cout << "Enter width and height: ";
            std::cin >> width >> height;

            for(int j{1}; j <= height; j++)
            {
                for (int i{1}; i <= width; i++)
                {
                    if(i + j > height + 1)
                        std::cout << " @";
                    else
                        std::cout << "  ";
                }
                std::cout << "\n";
            }
            break;

            default:
                if(flag == 0)
                    std::cout << "Exiting...\n";
                else
                    std::cout << "Wrong menu item!\n";
            break;
        }
    }
    return 0;
}