#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>


class FileViewer 
{
public:
    virtual ~FileViewer() = default;

    virtual void Display(const char* path)
    {
        std::ifstream file;
        if (!openFile(path, file)) 
        {
            std::cerr << "[Error] Не удалось открыть файл: " << path << '\n';
            return;
        }

        std::string line;
        while (std::getline(file, line)) 
            std::cout << line << '\n';
        // std::ifstream автоматически закроется при выходе из области видимости
    }

protected:
    // Вспомогательный метод для открытия (текстовый режим по умолчанию)
    bool openFile(const char* path, std::ifstream& in) const 
    {
        in.open(path, std::ios::in);
        return in.is_open();
    }
};

class LineNumberViewer : public FileViewer 
{
public:
    void Display(const char* path) override
    {
        std::ifstream file;
        if (!openFile(path, file)) {
            std::cerr << "[Error] Не удалось открыть файл: " << path << '\n';
            return;
        }
    
        std::string line;
        size_t lineNum = 1;
        while (std::getline(file, line)) {
            std::cout << std::setw(4) << lineNum++ << " | " << line << '\n';
        }
    }
};



class BinaryViewer : public FileViewer 
{
    // Вспомогательный метод для перевода байта в строку из 0 и 1
    std::string toBinary(unsigned char byte) const
    {
        std::string res;
        res.reserve(8);
        for (int i = 7; i >= 0; --i)
            res.push_back(((byte >> i) & 1) ? '1' : '0');
        return res;
    }
public:
    void Display(const char* path) override
    {
        // Для двоичного чтения обязателен флаг std::ios::binary
        std::ifstream file;
        file.open(path, std::ios::in | std::ios::binary);
        if (!file.is_open()) 
        {
            std::cerr << "[Error] Не удалось открыть файл: " << path << '\n';
            return;
        }

        unsigned char byte;
        int count = 0;
        // Читаем побайтово
        while (file.read(reinterpret_cast<char*>(&byte), sizeof(byte))) 
        {
            std::cout << toBinary(byte) << ' ';
            if (++count % 8 == 0) std::cout << '\n'; // перенос каждые 8 байт для читаемости
        }
        if (count % 8 != 0) std::cout << '\n';
    }
};


int main() 
{
    const char* testFile = "test.txt";
    
    std::ofstream out(testFile);
    if (out.is_open()) 
    {
        out << "Hello, World!\n";
        out << "C++ File Hierarchy Demo\n";
        out << "Line 3: Testing viewers.\n";
        out.close();
    }

    std::cout << "=== Base Viewer (Simple Text) ===\n";
    FileViewer baseViewer;
    baseViewer.Display(testFile);

    std::cout << "\n=== Line Number Viewer ===\n";
    LineNumberViewer lineViewer;
    lineViewer.Display(testFile);

    std::cout << "\n=== Binary Viewer ===\n";
    BinaryViewer binViewer;
    binViewer.Display(testFile);

    return 0;
}