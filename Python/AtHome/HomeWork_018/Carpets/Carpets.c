#include <conio.h>
#include <stdio.h>
int a, b, c;

int main(void){
    printf("Enter length and width of the room and the side of carpet: \n");
    scanf("%i", &a);
    scanf("%i", &b);
    scanf("%i", &c);
    printf("%i\nEnter any key to continue", (a/c) * (b/c));
    getch();
}
//Damn, I write in English...