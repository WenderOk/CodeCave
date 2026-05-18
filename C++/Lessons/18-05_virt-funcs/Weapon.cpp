#include <iostream>

class Weapon
{
protected:
    int damage;
public:
    Weapon(int d): damage{d}
    {}
    virtual int use() = 0;
};

class Sword: public Weapon
{
public:
    Sword(): Weapon{35}
    {}
    virtual int use()
    {
        std::cout << "You hit enemy by sword\n"; 
        return damage;
    }
};

class Spear: public Weapon
{
public:
    virtual int use()
    {
        std::cout << "You pierce enemy by spear\n";
        return damage;
    }
};

class Bow: public Weapon
{
public:    
    virtual int use()
    {
        std::cout << "You shoot enemy by bow\n";
        return damage;
    }
};

class Player
{
    bool rightHanded;
    Weapon * rightHand;
    Weapon * leftHand;
public:
    Player(bool rh): rightHanded{rh}
    {}
    bool isRightHanded()
    { return rightHanded; };

    void pickWeapon(Weapon * w)
    {
        if(isRightHanded())
            rightHand = w; 
        else
            leftHand = w; 
    }

    void attack(int & enemy)
    {
        if(enemy > 0)
            enemy -= rightHand->use();
        else
            std::cout << "Enemy already dead!\n";
    }
};

int main()
{
    int enemy{100};
    Player p{true};
    p.pickWeapon(new Sword{});

    if(p.isRightHanded())
    {
        std::cout << "Attacking enemy with right hand\n";
        while(enemy > 0)
        {
            std::cout << "Enemy's health: " << enemy << "\n";
            p.attack(enemy);
        }
    }
    else
    {
        std::cout << "Attacking enemy with left hand\n";
        while(enemy > 0)
        {
            std::cout << "Enemy's health: " << enemy << "\n";
            p.attack(enemy);
        }
    }

    return 0;
}