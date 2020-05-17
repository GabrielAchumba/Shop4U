#pragma once

#ifndef INTEGRATION_H
#define INTEGRATION_H




#include <iostream>
#include <fstream>
#include <stdio.h>
#include <string>
#include <vector>
#include <iomanip>
#include <time.h>
#include <functional>
#include <math.h>
#include "Forecast.h"

using namespace std;

//template<typename T, typename U>
//template<typename T, int n>
template<typename T>
class  Integration
{
private:
    #define EPS 1.0e-5
	#define JMAX 20
public:

	Integration();
	/*
	
	~Integration();*/

	T trapzd(function<T(T)> func, T& a, T& b, int& n);

	T qtrap(function<T(T)> func, T& a, T& b);

	//double TrapezoidalRule(function<double(double)> fun, double& lowerBound, double& upperBound, int& intervals);

};
#endif // !INTEGRATION_H

template<typename T>
Integration<T>::Integration()
{

}




//double Integration::TrapezoidalRule(function<double(double)>  fun, double& lower, double& upper, int& subInterval)
//{
//
//    int i;
//    double k;
//
//    
//        /* Finding step size */
//    int stepSize = (upper - lower) / subInterval;
//
//    /* Finding Integration Value */
//
//    double integration = fun(lower) + fun(upper);
//
//    for (i = 1; i <= subInterval - 1; i++)
//    {
//        k = lower + i * stepSize;
//        integration = integration + 2 * (fun(k));
//    }
//
//    integration = integration * stepSize / 2;
//
//    return integration;
//}

template<typename T>
T Integration<T>::trapzd(function<T(T)> func, T& a, T& b, int& n)
{
    T x, tnm, sum, del;
    static T s;
    int it, j;
    if (n == 1) {
        return (s = 0.5 * (b - a) * (func(a) + func(b)));
    }
    else {
        for (it = 1, j = 1; j < n - 1; j++) 
            it <<= 1;
        tnm = it;
        del = (b - a) / tnm; //This is the spacing of the points to be added.
        x = a + 0.5 * del;
        for (sum = 0.0, j = 1; j <= it; j++, x += del) 
            sum += func(x);
        s = 0.5 * (s + (b - a) * sum / tnm); //This replaces s by its refined value.
        return s;
    }
}

template<typename T>
T Integration<T>::qtrap(function<T(T)> func, T& a, T& b)
{
    // float trapzd(float (*func)(float), float a, float b, int n);
     //void nrerror(char error_text[]);
    int j;
    T s, olds = 0.0;                            //Initial value of olds is arbitrary.
    for (j = 1; j <= JMAX; j++) {
        s = trapzd(func, a, b, j);
        if (j > 5)                             //Avoid spurious early convergence.
            if (fabs(s - olds) < EPS * fabs(olds) ||
                (s == 0.0 && olds == 0.0)) return s;
        olds = s;
    }
    //nrerror("Too many steps in routine qtrap");
    return 0.0; //Never get here.
}