#pragma once

enum class ClothType{coat, jacket, cloak};

class Overcoat
{
    ClothType type;
    double price;

public:
    Overcoat(ClothType tp, double pr): type{tp}, price{pr}
    {}

    bool operator==(const Overcoat& ovr) const
    { return ovr.type == type; }
    
    const Overcoat& operator=(Overcoat& ovr)
    {
        if(this == &ovr)
            return *this;

        type = ovr.type;
        price = ovr.price;

        return *this;
    }

    bool operator>(Overcoat& ovr)
    { 
        if(type != ovr.type) 
            return false;
        return price > ovr.price;
    }

    bool operator<(Overcoat& ovr)
    { return !(*this > ovr); }

    const char* getStrType()
    { 
        switch(type)
        {
            case ClothType::coat:
                return "coat";
                break;
            case ClothType::jacket:
                return "jacket";
                break;
            case ClothType::cloak:
                return "cloak";
                break;
        }
        return "";
    }

    ClothType getType()
    { return type; }

    double getPrice()
    { return price; }
};