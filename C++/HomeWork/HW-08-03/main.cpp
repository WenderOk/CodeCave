#include <iostream>
#include "Fraction.h"
 
int main()
{
    // использовал цепочку вызовов, которую прошли на уроке, потому что очень удобно
    
    // не стал делать обработку случаев когда получается с целой частью т.к пришлось бы добаить доп. поле в класс и программа бы усложнилась
    // тем более в задании это не требуется

    Fraction fr1;
    std::cout << "Fraction 1: ";
    fr1.setNum(1).setDen(2).print();
    
    Fraction fr2;
    std::cout << "Fraction 2: ";
    fr2.setNum(2).setDen(3).print();

    std::cout << "Addition 1/2 and 2/3: ";
    fr1.add(fr1, fr2).print();

    std::cout << "Substraction 2/3 from 1/2: ";
    fr1.sub(fr1, fr2).print();
    
    std::cout << "Multiplication 1/2 and 2/3: ";
    fr1.mul(fr1, fr2).print();

    std::cout << "Division 1/2 on 2/3: ";
    fr1.div(fr1, fr2).print();


    return 0;
}