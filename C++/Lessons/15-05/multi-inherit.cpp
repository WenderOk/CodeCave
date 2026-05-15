#include <iostream>

const int maxSize{256};

class Horns
{
protected:
    char color[maxSize];
    double weight;
public:
    Horns(): color{"Dirty"}, weight{20}
    {}
    Horns(const char* c, double w): weight{w}
    { std::strcpy(color, c); }
};

class Kopyta
{
protected:
    char form[maxSize];
    double diameter;
public:
    Kopyta(): form{"circle"}, diameter{50}
    {}
    Kopyta(const char* f, double d): diameter{d}
    { std::strcpy(form, f); }

};

class Moose: public Horns, public Kopyta
{
    char name[maxSize];
public:
    Moose(const char* n)
    { std::strcpy(name, n); }
    void show()
    {
         std::cout << "Name: " << name
                   << "\nHorns: " << color << ", " << weight << " kg"
                   << "\nKopyta: " << form << ", " << diameter << " mm"
                   <<'\n';
    }
};

int main()
{
    Moose m{"Vasya"};
    m.show();

    return 0;
}