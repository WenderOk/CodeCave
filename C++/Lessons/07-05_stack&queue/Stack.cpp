#include <iostream>
#include <ctime>
#include <cstdlib>

class Stack
{
    enum { EMPTY = -1, FULL = 20 };
    char st[FULL + 1];
    int top;
public:
    Stack();
    void push(char c);
    char pop();
    void clear();
    bool isEmpty();
    bool isFull();
    int getCount();
};

int main()
{
    std::srand(std::time(nullptr));

    Stack st;
    char c;

    while(!st.isFull())
    {
        c = std::rand() % 4 + 2;
        st.push(c);
    }

    while(c = st.pop())
        std::cout << c << ' ';
    std::cout << '\n';
    

    return 0;
}

Stack::Stack()
{ top = EMPTY; }

void Stack::push(char c)
{
    if(!isFull())
        st[++top] = c;
}

char Stack::pop()
{
    if(!isEmpty())
        return st[top--];
    else
        return 0;
}

void Stack::clear()
{ top = EMPTY; }

bool Stack::isEmpty()
{ return top == EMPTY; }

bool Stack::isFull()
{ return top == FULL; }