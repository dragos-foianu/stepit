// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<stdio.h>
int main()
{   float a, b,res;
    char key;
    printf("dati doua numere a si b");
    scanf_s("%f%f", &a, &b);
    printf("tastati operatia \n");
        scanf_s(" %c", &key);
        switch (key)
        {
        case '+':
                res = a + b;
                printf("%f", res); break;
        case '-':
                res = a - b;
                printf("%f", res); break;
        case '*':
                res = a * b;
                printf("%f", res); break;
        case '/':
                res = a / b;
                printf("%f", res); break;
        default: printf("error");
           
   
    }
    return 0;
}

