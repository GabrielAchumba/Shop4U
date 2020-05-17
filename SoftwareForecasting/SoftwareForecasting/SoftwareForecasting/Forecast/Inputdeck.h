#pragma once

#include <iostream>
#include <fstream>
#include <stdio.h>
#include <string>
#include <vector>
#include <iomanip>
#include <time.h>
#include <algorithm>
#include "Forecast.h"
#include "FractionalFlow.h"
#include "Decline_Curve_Analysis.h"

using namespace std;

class EXT_FORECAST Inputdeck
{
private:
	FractionalFlow fractionalFlow;
	Decline_Curve_Analysis decline_Curve_Analysis;
public:
	Inputdeck();
	void Get_InputDeckStructList(InputDeckStruct* _inputdecks, int size);
	void tokenize(string const& str, const char delimeter, vector<string>& out);
	vector<InputDeckStruct> GetInputDecksPointer(const char* filepath, const char delimeter);
	bool IsContains(vector<string>& Faclities, string& Facility);
	vector<string> GetFacilities(InputDeckStruct* _inputdeckss, int size);
	vector <vector<InputDeckStruct>> GetModulesByFacility(vector<string>& Faclities, vector<InputDeckStruct>& decks, int size);
	void ValidateDeck(InputDeckStruct& extendedInputDeck);
	void ToLower(string& x);
	~Inputdeck();
	InputDeckStruct* inputdecks;
	
};

