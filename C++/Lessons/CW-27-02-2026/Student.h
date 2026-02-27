const int MAX_NAME_SIZE{20};
const int MAX_MARKS_COUNT{5};

class Student
{
    char name[MAX_NAME_SIZE];
    int marks[MAX_MARKS_COUNT];

public:
    Student();
    Student(char n[], int m[]);
    ~Student();

    double averageMark();
    void print();

    char* getName();
    void setName(char n[]);

    int getMark(int index);
    int setMark(int index, int mark);

};