#include <iostream>
#include <ctime>
#include <cstdlib>

class Queue
{
    int* wait;
    int maxQueueSize;
    int queueSize;
public:
    Queue(int m);
    ~Queue();
    void add(int el);
    int extract();
    void clear();
    bool isEmpty() const;
    bool isFull() const;
    int getCount() const;
    void print() const;
};

int main()
{
    std::srand(std::time(nullptr));

    Queue qu{25};

    for(int i{}; i < 5; i++)
        qu.add(std::rand() % 50);
    
    qu.print();

    qu.extract();
    qu.print();
    

    return 0;
}

Queue::Queue(int m)
{
    maxQueueSize = m;
    wait = new int[m]; 
    queueSize = 0;
}

Queue::~Queue()
{ delete[] wait; }

void Queue::add(int el)
{
    if(!isFull())
        wait[queueSize++] = el;
}

int Queue::extract()
{
    if(!isEmpty())
    {
        int temp(wait[0]);
        for(int i{1}; i < queueSize; i++)
            wait[i-1] = wait[i];
        queueSize--;
        return temp;
    }
    else
        return -1;
}

void Queue::clear()
{ queueSize = 0; }

bool Queue::isEmpty() const
{ return queueSize == 0; }

bool Queue::isFull() const
{ return queueSize == maxQueueSize; }

int Queue::getCount() const
{ return queueSize; }

void Queue::print() const
{
    for(int i{}; i < queueSize; i++)
        std::cout << wait[i] << ' ';
    std::cout <<'\n';
}
