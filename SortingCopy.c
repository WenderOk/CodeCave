#include <stdio.h>

int main(void)
{
    int n; 
    scanf("%i",&n);
    int Numbers[n];
    scanf("%i", Numbers);
    for (int i = 0; i < n; i++)
    {
        printf("%i ",Numbers[i]);
    }
}
