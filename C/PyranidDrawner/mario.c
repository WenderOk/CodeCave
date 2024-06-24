#include <stdio.h>

void print_row(int spaces, int bricks);

int main (void)
{
    int n;
    do
    {
        printf("Height: ");
        scanf("%i", &n);
    }
    while(n<=0);

    for(int i=0; i<n; i++)
    {
        while(i<n)
        {
            print_row(n-(i+1), i+1);
            i++;
        }
    }

}

void print_row(int spaces, int bricks)
{
    for (int i = 0; i < spaces; i++)
    {
        printf(" ");
    }
    for (int i = 0; i < bricks; i++)
    {
        printf("#");
    }
    printf("  ");
    for (int i = 0; i < bricks; i++)
    {
        printf("#");
    }
    printf("\n");
}
