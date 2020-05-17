#pragma once


#ifndef MATHFUNCS_HPP
#define MATHFUNCS_HPP



#include <stdexcept>
#include <iostream> 
#include <string>

using namespace std;

namespace MathFuncs
{
    struct InputDeckStuct
    {
        double OilRate;
        char ModuleName;
    };

    extern "C" { __declspec(dllexport) double _stdcall Add(double a, double b); }
    extern "C" { __declspec(dllexport) double _stdcall  Subtract(double a, double b); }
    extern "C" { __declspec(dllexport) double _stdcall  Multiply(double a, double b); }
    extern "C" { __declspec(dllexport) double _stdcall Divide(double a, double b); }
    extern "C" { __declspec(dllexport) void _stdcall GetString(char* a); }
    extern "C" { __declspec(dllexport) char* _stdcall GetString2(char* a); }
    extern "C" { __declspec(dllexport) int _stdcall TestArrayOfInts(int* pArray, int size); }
    extern "C" { __declspec(dllexport) int _stdcall TestArrayOfStruct(InputDeckStuct* pArray, int size); }

    
}

#endif