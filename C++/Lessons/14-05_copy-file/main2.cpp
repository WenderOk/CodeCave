#include <iostream>
#include <string>

class Person
{
class Person::Account
{
public:
    std::string email;
    std::string password;
    Account(const std::string& em, const std::string& ps)
        : email{em}, password{ps}
    {}
};
    std::string name;
public:
    class Account;
    Account account{"",""};
    Person(const std::string& nm, const std::string& em, const std::string& ps): name{nm}
    {
        account = Account{em, ps};
    }
    void print() const
    {
        std::cout << "Person: " << name
                  << ", email: " << account.email
                  << ", password: " << account.password;
    }

};


int main()
{
    Person p1{"George", "asd.main.ru", "some pass"};
    p1.print();

    return 0;
}