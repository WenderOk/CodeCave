#include <iostream>
#include "DynArr.h"

int main()
{
    DynArr da1{5};
    da1.randomize().print();
    DynArr da2{da1};
    da2.print();


    return 0;
}