#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main(void)
{
    int n;
    int StepCounter;
do
{
    printf("Enter value of numbers: ");
    scanf("%i", &n);
} while (n<2);

    int Numbers[n];
    for (int i = 0; i < n; i++)
    {
        printf("Enter a number with index %i: ", i+1);
        scanf("%i", &Numbers[i]);
    }
    
    int Changes;
    do
    {
        Changes = 0;
        for (int i = 0; i < n; i++)
        {
            if (Numbers[i]>Numbers[i+1])
            {
                int a;
                a = Numbers[i];
                Numbers[i] = Numbers[i+1];
                Numbers[i+1] = a;
                Changes++;
                StepCounter++;
            }
        }
        
    } while (Changes!=0);   
    printf("Steps made: %i\n",StepCounter);
    printf("Sorted list: ");
    
    for (int i = 0; i < n; i++)
    {
        printf("%i ",Numbers[i+1]);
    }   
    printf("\n");
}