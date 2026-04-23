class Counter
{
    int cnt;
public:
    Counter(int start): cnt{start}
    {}
    Counter(): Counter(0)
    {}

    int operator()()
    { return cnt++; }

    void resetTo(int start)
    { cnt = start; }
};

