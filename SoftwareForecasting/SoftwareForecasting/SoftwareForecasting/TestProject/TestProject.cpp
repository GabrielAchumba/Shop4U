

#include <iostream>
#include <fstream>
#include <stdio.h>
#include <string>
#include <vector>
#include <iomanip>
#include <time.h>
#include <functional>
#include <direct.h>
#include <windows.h>
#include "Forecast.h"
#include "Inputdeck.h"
#include "DateCreation.h"
#include "CalculateDeckVariables.h"
#include "MathematicsLibrary.h"
#include "MathsUtils.h"
#include "LinearAlgebra.h"

using namespace std;

void TestMaths();
double MultBy2(double num);
double Domath(function<double(double)> func, double num);
void Test_Linear_Algebra();



int main()
{
	TestMaths();

	auto times2 = MultBy2;

	cout << Domath(times2, 6) << endl;




	//Read Input Decks

	const char* filepath = "C:\\Users\\Gabriel Achumba\\Documents\\inputdeck33.txt";
	const char delimeter = '\t';

	Inputdeck deckobj;

	vector<InputDeckStruct> InputDecks = deckobj.GetInputDecksPointer(filepath, delimeter);

	const int ndecks = InputDecks.size();

	InputDeckStruct* decks_ptrs = &InputDecks[0];// convert vector to array

	deckobj.Get_InputDeckStructList(decks_ptrs, ndecks);

	DateCreation dateCreation;

	Date StopDate;

	StopDate.year = 2050;
	StopDate.month = 12;
	StopDate.day = 31;

	string TimeFrequency = "Monthly";

	dateCreation.GetDateList(decks_ptrs, StopDate, ndecks, TimeFrequency);

	dateCreation.GetDaysList(dateCreation.dateTimes[0]);

	vector<string> Facilities = deckobj.GetFacilities(decks_ptrs, ndecks);

	vector<vector<InputDeckStruct>> FacilitiesObj = deckobj.GetModulesByFacility(Facilities, InputDecks, ndecks);

	int scenario = 1;
	CalculateDeckVariables calculateDeckVariables;
	calculateDeckVariables.GetDeckVariables(FacilitiesObj, dateCreation.dateTimes, dateCreation.daysList, scenario);
	
	string BasePath = "C:\\Users\\Gabriel Achumba\\Documents\\SoftwareForecasting\\SoftwareForecasting\\SoftwareForecasting\\RESULTS\\";


	calculateDeckVariables.CreateFiles(BasePath, FacilitiesObj, Facilities, dateCreation.dateTimes, dateCreation.daysList, scenario);

	calculateDeckVariables.PrintResults(BasePath, Facilities, FacilitiesObj);
	

	return 0;
}

void TestMaths()
{
	Test_Linear_Algebra();
}

double MultBy2(double num)
{
	return num * 2;
}

double Domath(function<double(double)> func, double num)
{
	return func(num);
}

void Test_Linear_Algebra()
{
	LinearAlgebra<double, int> linAlg;
	double* bPtr, * dPtr, * colPtr; double** aPtr; int* indx;
	double** yPtr; double det;
	const int nr = 4, nc = 4;
	double a[nr][nc] = { { 0, 0, 0, 0 }, { 0, 0.3, 0.52, 1 }, {0,  0.5, 1, 1.9 },{ 0, 0.1, 0.3, 0.5 } };
	double b[nr] = { 0, -0.01, 0.67, -0.44 };
	double d[nr] = { 0, -0.01, 0.67, -0.44 };


	det = 0;
	bPtr = new double[nr];
	dPtr = new double[nr];
	indx = new int[nr];
	colPtr = new double[nr];

	aPtr = new double* [nr];
	yPtr = new double* [nr];

	for (int i = 0; i < nr; i++)
	{
		aPtr[i] = new double[nc];
		bPtr[i] = b[i];
		dPtr[i] = d[i];
		indx[i] = 0;
		yPtr[i] = new double[nc];
		colPtr[i] = 0;
	}


	for (int i = 0; i < nr; ++i)
	{
		for (int j = 0; j < nc; ++j)
		{
			aPtr[i][j] = a[i][j];
			yPtr[i][j] = 0;
		}
	}

	const int n = nr - 1;
	//linAlg.ludcmp(aPtr, n, indx, dPtr);
	//linAlg.lubksb(aPtr, n, indx, b);

	/*linAlg.lu_minverse(aPtr, n, indx, dPtr, yPtr, colPtr);

	for (int i = 0; i < nr; ++i)
	{
		for (int j = 0; j < nc; ++j)
		{
			cout << yPtr[i][j] << " ";
		}
		cout << endl;
	}*/

	linAlg.lu_determinant(aPtr, n, indx, dPtr, det);

	cout << det << " ";
}