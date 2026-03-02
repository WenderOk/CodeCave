public class MyClass
{
    public int number;
    public string name;
    public bool IsStudent;

    public MyClass() { }
    public MyClass(int nP)
    {
        number = nP;
        name = "aboab";
        IsStudent = true;
    }
    public MyClass(int nP, string sP)
    {
        number = nP;
        name = sP;
        IsStudent = true;
    }
    public MyClass(int nP, string sP, bool bP)
    {
        number = nP;
        name = sP;
        IsStudent = bP;
    }

    public void Print()
    {
        Console.WriteLine($"number = {number}, name = {name}, isStudent = {IsStudent}");
    }


}