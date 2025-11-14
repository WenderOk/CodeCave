#include <conio.h>
#include <stdio.h>
int a, b, c, ak, bk, result;

int main(void){
    printf("Enter length and width of the room and the side of carpet: \n");
    scanf("%d %d %d", &a,&b,&c);
    while (a > 0){
        ak++;
        a-=c;
    }
    while (b > 0){
        bk++;
        b-=c;
    }
    for(int i = 0; i < bk; i++){ result += ak; }
    printf("%i\nEnter any key to continue\n", result);
    getch();
}
//Damn, I write in English...