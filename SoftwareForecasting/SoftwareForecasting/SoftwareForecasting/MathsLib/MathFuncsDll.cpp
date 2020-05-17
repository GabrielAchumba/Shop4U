#include <iostream>
#include <string>
#include <stdexcept>
#include "MathFuncsDll.h"

namespace MathFuncs
{
    double Add(double a, double b)
    {
        return a + b;
    }

    double Subtract(double a, double b)
    {
        return a - b;
    }

    double Multiply(double a, double b)
    {
        return a * b;
    }

    double Divide(double a, double b)
    {
        if (b == 0)
            throw invalid_argument("b cannot be zero!");
        return a / b;
    }

    void GetString(char *a)
    {
        printf("this is a test \n", a);
        fflush(stdout);
        
    }

    char* GetString2(char* a)
    {
        //char b = *a;
        return a;

    }

    int  TestArrayOfInts(int* pArray, int size)
    {
        int result = 0;

        for (int i = 0; i < size; i++)
        {
            result += pArray[i];
            pArray[i] += 100;
        }
        return result;
    }

    int TestArrayOfStruct(InputDeckStuct* pArray, int size)
    {

       cout << pArray->ModuleName;
        return 0;
    }
}