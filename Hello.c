#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>

int main(void)
{
     char Name[80];

     printf("Write your name please: ");
     scanf("%s", Name);
     printf("Hello, %s\n", Name);
}