#pragma once

class Flat
{
    double area;
    double price;

public:
    Flat(double ar, double pr): area{ar}, price{pr}
    {}

    bool operator==(const Flat& fl) const
    { return fl.area == area; }
    
    const Flat& operator=(Flat& fl)
    {
        if(this == &fl)
            return *this;

        area = fl.area;
        price = fl.price;

        return *this;
    }

    bool operator>(Flat& fl)
    { 
        if(area != fl.area) 
            return false;
        return price > fl.price;
    }

    bool operator<(Flat& fl)
    { return !(*this > fl); }

    double getPrice()
    { return price; }

    double getArea()
    { return area; }
};