#pragma once

#include <iostream>
#include <string>
#include "Pointers.h"

using namespace std;

void Pointers::Example1()
{
	int num = 20;
	int val;
	int* iptr;

	iptr = &num;
	val = *iptr;
	cout << "Statements:\n";
	cout << "\tint num=20;\n\tint val;\n\tint *ptr;";
	cout << "\n\tiptr = &num;\n\tval = *iptr\n\n";
	cout << "Output:\n";
	cout << "\tnum = " << num << "\n\tval = " << val;

}

void Pointers::Example2()
{
	float a = 5.999;
	float* b, * c;
	b = &a;
	c = b;
	cout << "Statements:\n";
	cout << "\tfloat a = 5.999;\n\tfloat *b, *c;\n";
	cout << "\tb = &a\n\tc = b\n\n";

	cout << "Output:\n\t";
	cout << "a = " << a << "\n\t";
	cout << "*(&a) = " << *(&a) << "\n\t";
	cout << "*b = " << *b << "\n\t";
	cout << "*c = " << *c << "\n";
}

void Pointers::check(int x, int* y)
{
	x = x * x;
	*y = *y * *y;
	cout << "In:\t";
	cout << x << "\t" << *y << "\n\n";
}

void Pointers::Example3()
{
	int a = 6, b = -4;
	cout << "Before:\t";
	cout << a << "\t" << b << "\n\n";
	check(a, &b);
	cout << "After:\t";
	cout << a << "\t" << b;
}

void Pointers::fun(int x, int* y)
{
	x = *(y) += 2;
}

void Pointers::Example4()
{
	int arr[5] = { 2, 4, 6, 8, 10 };
	int i, b = 5;
	for (i = 0; i < 5; i++)
	{
		fun(arr[i], &b);
		cout << arr[i] << "\t" << b << "\n";
	}
}

void Pointers::Example5()
{
	int arr[] = { 4, 6, 10, 12 };
	int* ptr;
	int i;
	ptr = arr;
	for (i = 0; i < 3; i++)
	{
		cout << *ptr << " -> ";
		ptr++;
	}
	cout << "\n";
	for (i = 0; i < 4; i++)
	{
		(*ptr) *= 3;
		--ptr;
	}
	for (i = 0; i < 4; i++)
	{
		cout << arr[i] << " -> ";
	}
}

void Pointers::Example6()
{
	int arra[] = { 11, 22, 33, 44, 55 };
	int a;
	int* ptra;
	ptra = arra;
	a = *ptra++;
	cout << "*ptra = " << *ptra << "\n";
	cout << "a = " << a << "\n\n";

	int arrb[] = { 11, 22, 33, 44, 55 };
	int b;
	int* ptrb;
	ptrb = arrb;
	b = (*ptrb)++;
	cout << "*ptrb = " << *ptrb << "\n";
	cout << "b = " << b << "\n\n";

	int arrc[] = { 11, 22, 33, 44, 55 };
	int c;
	int* ptrc;
	ptrc = arrc;
	c = *++ptrc;
	cout << "*ptrc = " << *ptrc << "\n";
	cout << "c = " << c << "\n\n";
}

void Pointers::DynamicMemoryAllocation1()
{
	int size, i;
	cout << "How many elements for the array ? ";
	cin >> size;
	rollno = new int[size]; 	// dynamically allocate rollno array
	marks = new float[size];        // dynamically allocate marks array

	// first check, whether the memory is available or not
	if ((!rollno) || (!marks))       // if rollno or marks is null pointer
	{
		cout << "Out of Memory..!!..Aborting..!!\n";
		cout << "Press any key to exit..";
		exit(1);
	}

	// read values in the array elements
	for (i = 0; i < size; i++)
	{
		cout << "Enter rollno and marks for student " << (i + 1) << "\n";
		cin >> rollno[i] >> marks[i];
	}

	// now display the array contents
	cout << "\nRollNo\t\tMarks\n";
	for (i = 0; i < size; i++)
	{
		cout << rollno[i] << "\t\t" << marks[i] << "\n";
	}

	delete[]rollno;    // deallocating rollno array
	delete[]marks;     // deallocating marks array
}

void Pointers::DynamicMemoryAllocation2()
{
	int* val, * rows, * cols;
	int maxr, maxc, i, j;
	cout << "Enter the dimension of the array (row col): ";
	cin >> maxr >> maxc;
	val = new int[maxr * maxc];
	rows = new int[maxr];
	cols = new int[maxc];

	for (i = 0; i < maxr; i++)
	{
		cout << "\nEnter elements for row " << i + 1 << " : ";
		rows[i] = 0;
		for (j = 0; j < maxc; j++)
		{
			cin >> val[i * maxc + j];
			rows[i] = rows[i] + val[i * maxc + j];
		}
	}

	for (j = 0; j < maxc; j++)
	{
		cols[j] = 0;
		for (i = 0; i < maxr; i++)
		{
			cols[j] = cols[j] + val[i * maxc + j];
		}
	}

	cout << "\nThe given array in two dimensional (alongwith rowsum and colsum) is :\n";
	for (i = 0; i < maxr; i++)
	{
		for (j = 0; j < maxc; j++)
		{
			cout << val[i * maxc + j] << "\t";
		}
		cout << rows[i] << "\n";
	}

	for (j = 0; j < maxc; j++)
	{
		cout << cols[j] << "\t";
	}
	cout << "\n";
}