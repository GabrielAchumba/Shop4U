#pragma once

#include <iostream>
#include <fstream>
#include <stdio.h>
#include <string>
#include <vector>
#include <iomanip>
#include <time.h>
#include "Forecast.h"

using namespace std;

class  EXT_FORECAST DateCreation
{
private:

public:
	DateCreation();
	void GetDateList(InputDeckStruct* decks, Date StopDate, int size,  string TimeFrequency);
	bool Compare(const Date& d1, const Date& d2);
	bool EqualTo(const Date& d1, const Date& d2);
	Date GetMinimumDate(const Date& d1, const Date& d2);
	Date GetMaximumDate(const Date& d1, const Date& d2);
	bool IsMinimumDate(Date& d1, Date& d2);
	bool IsMaximumDate(Date& d1, Date& d2);
	bool IsContains(vector<Date>& dates, Date& d1);
	void DateIncrementByMonth(Date& d1);
	void SortDate(vector<Date>& dates);
	int DaysInMonth(int& month);
	int DateDiff_TotalDays(Date& d1, Date& d2);
	void GetDaysList(Date& StartDate);
	~DateCreation();

	vector<Date> dateTimes;
	vector<int> daysList;
};
