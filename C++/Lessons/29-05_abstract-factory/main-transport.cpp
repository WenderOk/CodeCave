#include <iostream>

class Logistics
{};
class RoadLogistics: public Logistics
{};
class SeaLogistics: public Logistics
{};

class Transport
{};
class Truck: public Transport
{};
class Ship: public Transport
{};

int main()
{
    return 0;
}