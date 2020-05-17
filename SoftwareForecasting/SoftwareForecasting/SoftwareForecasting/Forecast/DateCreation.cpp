#include <iostream>
#include <fstream>
#include <stdio.h>
#include <string>
#include <vector>
#include <iomanip>
#include <time.h>
#include <algorithm>
#include "Forecast.h"
#include "DateCreation.h"

using namespace std;

EXT_FORECAST DateCreation::DateCreation()
{

}

EXT_FORECAST DateCreation::~DateCreation()
{

}

bool DateCreation::Compare(const Date& d1, const Date& d2)
{
	if (d1.year < d2.year)
	{
		return true;
	}

	if (d1.year == d2.year && d1.month < d2.month)
	{
		return true;
	}

	if (d1.year == d2.year && d1.month == d2.month && d1.day < d2.day)
	{
		return true;
	}

	return false;
}

bool DateCreation::EqualTo(const Date& d1, const Date& d2)
{
	if (d1.year == d2.year && d1.month == d2.month && d1.day == d2.day)
	{
		return true;
	}

	return false;
}

Date DateCreation::GetMinimumDate(const Date& d1, const Date& d2)
{
	bool check = false;

	check = Compare(d1, d2);

	if (check == true)
	{
		return d1;
	}
	else
	{
		return d2;
	}

}

Date DateCreation::GetMaximumDate(const Date& d1, const Date& d2)
{
	bool check = false;

	check = Compare(d1, d2);

	if (check == true)
	{
		return d2;
	}
	else
	{
		return d1;
	}

}

bool DateCreation::IsMinimumDate(Date& d1, Date& d2)
{
	bool check = false;

	check = Compare(d1, d2);

	if (check == true)
	{
		return true;
	}
	else
	{
		return false;
	}
}

bool DateCreation::IsMaximumDate(Date& d1, Date& d2)
{
	bool check = false;

	check = Compare(d1, d2);

	if (check == false)
	{
		return true;
	}
	else
	{
		return false;
	}
}

bool DateCreation::IsContains(vector<Date>& dates, Date& d1)
{
	bool check = false;
	for (int i = 0; i < dates.size(); i++)
	{
		if (dates[i].year == d1.year && dates[i].month == d1.month && dates[i].day == d1.day)
		{
			check = true; break;
		}
	}

	return check;
}

void DateCreation::DateIncrementByMonth(Date& d1)
{
	switch (d1.month)
	{
	case 1:
		d1.month = d1.month + 1;
		break;
	case 2:
		d1.month = d1.month + 1;
		break;
	case 3:
		d1.month = d1.month + 1;
		break;
	case 4:
		d1.month = d1.month + 1;
		break;
	case 5:
		d1.month = d1.month + 1;
		break;
	case 6:
		d1.month = d1.month + 1;
		break;
	case 7:
		d1.month = d1.month + 1;
		break;
	case 8:
		d1.month = d1.month + 1;
		break;
	case 9:
		d1.month = d1.month + 1;
		break;
	case 10:
		d1.month = d1.month + 1;
		break;
	case 11:
		d1.month = d1.month + 1;
		break;
	case 12:
		d1.month = 1;
		d1.year = d1.year + 1;
		break;
	}
}

void DateCreation::SortDate(vector<Date>& dates)
{
	for (int i = 0; i < dates.size() - 1; i++)
	{
		for (int j = i + 1; j < dates.size(); j++)
		{
			if (IsMaximumDate(dates[i], dates[j]) == true)
			{
				Date temp = dates[i];
				dates[i] = dates[j];
				dates[j] = temp;
			}
		}
	}
}

void DateCreation::GetDateList(InputDeckStruct* decks, Date StopDate, int size, string TimeFrequency)
{

	Date StartDate;

	for (int i = 0; i < size; i++)
	{
		if (IsContains(dateTimes, decks->Date_1P_1C) == false)
			dateTimes.push_back(decks->Date_1P_1C);

		if (IsContains(dateTimes, decks->Date_2P_2C) == false)
			dateTimes.push_back(decks->Date_2P_2C);

		if (IsContains(dateTimes, decks->Date_3P_3C) == false)
			dateTimes.push_back(decks->Date_3P_3C);
		decks++;
	}

	StartDate = dateTimes[0];

	for (int i = 1; i < dateTimes.size(); i++)
	{
		StartDate = GetMinimumDate(StartDate, dateTimes[i]);
	}

	Date d = StartDate;

	while (IsMinimumDate(d, StopDate) == true) {

		if (IsContains(dateTimes, d) == false)
			dateTimes.push_back(d);

		DateIncrementByMonth(d);
	}

	SortDate(dateTimes);

	/*for (int i = 0; i < dateTimes.size(); i++)
	{
		cout << dateTimes[i].day << "/" << dateTimes[i].month << "/" << dateTimes[i].year << endl;
	}*/

}

int DateCreation::DaysInMonth(int& month)
{
	int days = 0;
	switch (month)
	{
	case 1:
		days = 31;
		break;
	case 2:
		days = 28;
		break;
	case 3:
		days = 31;
		break;
	case 4:
		days = 30;
		break;
	case 5:
		days = 31;
		break;
	case 6:
		days = 30;
		break;
	case 7:
		days = 31;
		break;
	case 8:
		days = 31;
		break;
	case 9:
		days = 30;
		break;
	case 10:
		days = 31;
		break;
	case 11:
		days = 30;
		break;
	case 12:
		days = 31;
		break;
	}

	return days;
}

int DateCreation::DateDiff_TotalDays(Date& d1, Date& d2)
{
	int days = 0;

	if (d1.year > d2.year)
	{
		for (int i = d2.year; i < d1.year; i++)
		{
			if ((i % 4) == 0)days = days + 366;
			else days = days + 365;

		}
	}
	else
	{
		for (int i = d2.year; i < d1.year; i++)
		{
			if ((i % 4) == 0)days = days - 366;
			else days = days - 365;
		}
	}

	if (d1.month > d2.month)
	{
		for (int i = d2.month; i < d1.month; i++)
		{
			days = days + DaysInMonth(i);
		}
	}
	else
	{
		for (int i = d1.month; i < d2.month; i++)
		{
			days = days - DaysInMonth(i);
		}
	}

	if (d1.day > d2.day)
	{
		days = days + (d1.day - d2.day);
	}
	else
	{
		days = days - (d1.day - d2.day);
	}

	return  days;
}

void DateCreation::GetDaysList(Date& StartDate)
{
	int days = 0;
	for (int i = 0; i < dateTimes.size(); i++)
	{
		days = DateDiff_TotalDays(dateTimes[i], StartDate);
		daysList.push_back(days);
	}
}