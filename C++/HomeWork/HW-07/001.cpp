#include <iostream>

int main()
{
    int width{};
    int height{};
    enum menuItems{a = 1, b, c, d, e, f, g, h, i, j};
    int flag{-1};

    while(flag != 0)
    {
        std::cout << "Figure drawer\n";
        std::cout << "Enter number of figure (enter 0 to exit): ";
        std::cin >> flag;

        switch  (flag)
        {
            case a:
            std::cout << "Enter width and height (enter 0 to exit): ";
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

            case b:
            std::cout << "Enter width and height (enter 0 to exit): ";
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

             case c:
            std::cout << "Enter width and height (enter 0 to exit): ";
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

             case d:
            std::cout << "Enter width and height (enter 0 to exit): ";
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

            case e:
            std::cout << "Enter width and height (enter 0 to exit): ";
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

            case f:
            std::cout << "Enter width and height (enter 0 to exit): ";
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

            case g:
            std::cout << "Enter width and height (enter 0 to exit): ";
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

            case h:
            std::cout << "Enter width and height (enter 0 to exit): ";
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

            case i:
            std::cout << "Enter width and height (enter 0 to exit): ";
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

            case j:
            std::cout << "Enter width and height (enter 0 to exit): ";
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