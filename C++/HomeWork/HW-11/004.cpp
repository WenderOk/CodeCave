#include <iostream>

void print_card(int value, int suit);

int main() {
    std::cout << "VALUES\n"
              << "2-10 numbers\n"
              << "11 - Jack\n"
              << "12 - Queen\n"
              << "13 - King\n"
              << "14 - Ace\n"
              << "SUITS\n"
              << "0 - Spades\n"
              << "1 - Hearts\n"
              << "2 - Diamonds\n"
              << "3 - Clubs\n"
              << "Enter value and suit of card: ";


    int suit{};
    int value{};

    std::cin >> value >> suit;

    print_card(value, suit);

    return 0;
}

void print_card(int value, int suit) {
    
    char suits[] = {'S', 'H', 'D', 'C'};
    char values[] = {' ',' ', '2','3','4','5','6','7','8','9',' ','J','Q','K','A'};
    
    char card_suit = suits[suit];
    char card_value{};
    if(value != 10)
    {
        char card_value = values[value];

        std::cout << "┌─────────┐\n"
                  << "│ "<< card_value << card_suit << "      │\n"
                  << "│         │\n"
                  << "│    " << card_suit << "    │\n"
                  << "│         │\n"
                  << "│      "<< card_value << card_suit << " │ \n"
                  << "└─────────┘\n";
    }
    else
    {
        std::cout << "┌─────────┐\n"
                  << "│ "<< 10 << card_suit << "     │\n"
                  << "│         │\n"
                  << "│    " << card_suit << "    │\n"
                  << "│         │\n"
                  << "│     "<< 10 << card_suit << " │ \n"
                  << "└─────────┘\n";    
    }
}

