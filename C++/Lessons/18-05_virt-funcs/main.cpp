#include <iostream>

const int maxLenStr{20};

class Animal
{
protected:
    char title[maxLenStr];
public:
    Animal(char * t)
    { std::strcpy(title, t); }
    virtual void speak() = 0;
};

class Frog: public Animal
{
public:
    Frog(char * t): Animal{t}
    {}
    virtual void speak()
    { std::cout << title << ": kwa-kwa\n"; }
};

class Dog: public Animal
{
public:
    Dog(char * t): Animal{t}
    {}
    virtual void speak()
    { std::cout << title << ": Woof-woof\n"; }
};

class Cat: public Animal
{
public:
    Cat(char * t): Animal{t}
    {}
    virtual void speak()
    { std::cout << title << ": Meow-meow\n"; }
};

class Lion: public Cat
{
public:
    Lion(char * t): Cat{t}
    {}
    // virtual void speak()
    // { std::cout << title << ": Grrrrr\n"; }
    virtual void speak(int when)
    { std::cout << title << ": Grrrrr\n"; }
};

int main()
{
    const int numAnimals{4};
    Animal* animls[numAnimals]
    {
        new Frog("Eugen"),
        new Dog{"Elisey"},
        new Cat{"Barsik"},
        new Lion{"Leo"}
    };

    for(int i{}; i < numAnimals; i++)
        animls[i]->speak();

    Lion lion{"Scar"};
    // lion.speak(12);

    return 0;
}