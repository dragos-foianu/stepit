// ConsoleApplication2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"


int main()
{
   long int n,a,b,c,d,m;
   printf("n= "); scanf_s("%d", &m);
   if (m > 999 && m < 10000) {
       a = m / 1000;
       b = m / 100 % 10;
       c = m / 10 % 10;
       d = m % 10;
       n = b * 1000 + a * 100 + d * 10 + c;
       printf("the swaped numbers = %d ", n);

   }
   else printf("nr nu are 4 cifre");
 
    return 0;
}

