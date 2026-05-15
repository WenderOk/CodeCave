#include <iostream>
#include <string>

class Person
{
    std::string name;
    class Account;
    Account* account;
public:
    Person(const std::string& nm, const std::string& em, const std::string& ps);
    void print() const;
};

int main()
{
    Person p1{"George", "asd.main.ru", "some pass"};
    p1.print();

    return 0;
}

class Person::Account
{
public:
    std::string email;
    std::string password;
    Account(){}
    Account(const std::string& em, const std::string& ps)
        : email{em}, password{ps}
    {}
};

Person::Person(const std::string& nm, const std::string& em, const std::string& ps): name{nm}
{ account = new Account{em, ps}; }

void Person::print() const
{
    std::cout << "Person: " << name
                << ", email: " << account->email
                << ", password: " << account->password;
}