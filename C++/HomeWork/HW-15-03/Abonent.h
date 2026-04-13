#pragma once

class Abonent
{
    char* fullName;
    char* homePh;
    char* workPh;
    char* mobPh;
    char* addInfo;

public:
    Abonent();
    Abonent(const char fn[], const char hPh[], const char wPh[], const char mPh[], const char addInf[]);
    Abonent(const char fn[], const char hPh[], const char wPh[], const char mPh[]);
    ~Abonent();
    void print();

    char* getFullName()
    { return fullName; }
    char* getHomeNum()
    { return homePh; }
    char* getWorkNum()
    { return workPh; }
    char* getMobileNum()
    { return mobPh; }
    char* getAddInfo()
    { return addInfo; }

    char* setFullName(const char val[])
    { return fullName; }
    char* setHomeNum(const char val[])
    { return homePh; }
    char* setWorkNum(const char val[])
    { return workPh; }
    char* setMobileNum(const char val[])
    { return mobPh; }
    char* setAddInfo(const char val[])
    { return addInfo; }

private:
    void processStringArgs(char* &field, const char arg[]);
    void copyField(char* &field, char* &other);

};