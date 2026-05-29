#include <iostream>
#include <string>
#include <map>

class Aircraft
{
    std::string aircraftType;
    std::map<std::string, std::string> parts;

public:
    Aircraft(std::string t): aircraftType{t}
    {}
    virtual ~Aircraft()
    {}
    std::string getPart(const std::string& key)
    {
        if(!CheckForPart(key))
            throw "Key not found!";
        return parts[key];
    }
    void setPart(const std::string& key, const std::string& value)
    {
        parts[key] = value;
    }
    bool CheckForPart(const std::string& key)
    {
        return parts.find(key) != parts.end() ? true : false;
    }
    void Show()
    {
        std::cout << "Type of aircraft: " << aircraftType << '\n';
        // for(std::pair part: parts)
        //     std::cout << part.first << ": " << part.second << '\n';

        for(auto iter{parts.begin()}; iter != parts.end(); iter++)
            std::cout << (*iter).first << ": " << (*iter).second << '\n';
    }
};

class AircraftBuilder
{
protected:
    Aircraft* aircraft;
public:
    AircraftBuilder(){}
    virtual ~AircraftBuilder(){}
    Aircraft* GetAircraft()
    {
        return aircraft;
    }
    virtual void BuildFrame() = 0;
    virtual void BuildEngine() = 0;
    virtual void BuildWheels() = 0;
    virtual void BuildDoors() = 0;
    virtual void BuildWings() = 0;
};

class HandGliderBuilder: public AircraftBuilder
{
public:
    HandGliderBuilder()
    { aircraft = new Aircraft{"Deltaplan"}; }
    virtual ~HandGliderBuilder()
    { delete aircraft; }

    void BuildFrame()
    { aircraft->setPart("frame", "Frame of the deltaplan"); }
    void BuildEngine()
    { aircraft->setPart("engine", "no engine"); }
    void BuildWheels()
    { aircraft->setPart("wheels", "no wheels"); }
    void BuildDoors()
    { aircraft->setPart("doors", "no doors"); }
    void BuildWings()
    { aircraft->setPart("wings", "1"); }
};

class GliderBuilder: public AircraftBuilder
{
public:
    GliderBuilder()
    { aircraft = new Aircraft{"Planer"}; }
    virtual ~GliderBuilder()
    { delete aircraft; }

    void BuildFrame()
    { aircraft->setPart("frame", "Frame of the planer"); }
    void BuildEngine()
    { aircraft->setPart("engine", "no engine"); }
    void BuildWheels()
    { aircraft->setPart("wheels", "1"); }
    void BuildDoors()
    { aircraft->setPart("doors", "1"); }
    void BuildWings()
    { aircraft->setPart("wings", "Wings of the planer"); }
};

class AircraftDirector
{
public:
    AircraftDirector() {}
    virtual ~AircraftDirector() {}
    void Construct(AircraftBuilder* builder)
    {
        builder->BuildFrame(); 
        builder->BuildEngine(); 
        builder->BuildWheels(); 
        builder->BuildDoors(); 
        builder->BuildWings(); 
    }
};

int main()
{
    try
    {
        AircraftBuilder* builder;
        
        AircraftDirector* director {new AircraftDirector{}};
        // builder = new HandGliderBuilder{};
        builder = new GliderBuilder{};
        
        director->Construct(builder);
        
        builder->GetAircraft()->Show();
        
        delete builder;
        delete director;
    }
    catch(const char* e)
    {
        std::cerr << e << '\n';
    }

    return 0;
}