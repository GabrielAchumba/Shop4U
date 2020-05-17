#pragma once


#include <iostream>
#include <fstream>
#include <stdio.h>
#include <string>
#include <vector>
#include <time.h>
#include <iomanip>
#include <functional>
#include "pch.h"




using namespace std;

#ifndef EXT_MATHEMATICSLIBRARY

	#ifdef DLL_BUILD
	#define EXT_MATHEMATICSLIBRARY __declspec(dllexport)
	#else
	#pragma comment(lib, "MathematicsLibrary.lib")
	#define EXT_MATHEMATICSLIBRARY __declspec(dllimport)
	#endif // DLL_BUILD


#endif // !EXT_MATHEMATICSLIBRARY

extern void EXT_MATHEMATICSLIBRARY test();

