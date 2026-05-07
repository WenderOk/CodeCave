#include <iostream>
#include <vector>
#include <algorithm>
#include <string>
#include <iomanip>

struct Entry
{
    std::string word;
    int count;
};

std::vector<Entry> getDictionary(std::string text);
std::vector<std::string> getWords(std::string text);

bool sortByWords(const std::string& word1, const std::string& word2)
{ return word1 < word2; }

bool sortByFreq(Entry en1, Entry en2)
{ return en1.count > en2.count; }

int main()
{
    std::string text
    {
        R"(
        Programming in C++ is powerful and fast. Many programmers love C++ because C++ is efficient.
        Writing code can be challenging, but coding is also fun. Data structures and algorithms are the core of programming.
        Is programming hard? Some say programming is easy, others say programming is difficult.
        Practice every day, and you will master C++!
        )"
    };


    std::vector<Entry> dictionary = getDictionary(text);

    std::sort(dictionary.begin(), dictionary.begin() + dictionary.size(), sortByFreq);

    for (Entry entry: dictionary)
    {
        std::cout << std::setw(12) << entry.word
                  << std::setw(4) << entry.count << '\n';
    }

    return 0;
}

std::vector<Entry> getDictionary(std::string text)
{
    std::vector<Entry> entries;                       // записи о словах
    std::vector<std::string> words{ getWords(text) }; // слова из текста
    // сортировка слов (по какому принципу?)
    std::sort(words.begin(), words.begin() + words.size(),
              sortByWords);

    int i{}; // индекс слова в векторе слов
    // перебрать слова в векторе для подсчета их количества
    while (i < words.size())
    {
        Entry entry{ words[i], 0 };
        while (i < words.size() && words[i] == entry.word)
        {
            entry.count++;
            i++;
        }
        entries.push_back(entry);
    }
    return entries;
}

std::vector<std::string> getWords(std::string text)
{
    std::vector<std::string> words;
    
    int pos{};
    while (pos < text.size())
    {
        // пропустить все не буквы и найти начало слова
        while (pos < text.size() && !isalpha(text[pos]))
            pos++;
        // если достигли конца текста, выйти из цикла
        if (pos == text.size())
            break;

        // начало слова
        int wordStart{ pos };

        // найти конец слова
        while (pos < text.size() && isalpha(text[pos]))
            pos++;

        int wordLen{ pos - wordStart };
        words.push_back(text.substr(wordStart, wordLen));
    }
    return words;
}