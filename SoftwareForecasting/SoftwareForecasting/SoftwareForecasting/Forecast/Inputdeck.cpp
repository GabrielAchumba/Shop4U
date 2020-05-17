#include <iostream>
#include <fstream>
#include <stdio.h>
#include <string>
#include <vector>
#include <iomanip>
#include <time.h>
#include <algorithm>

#include "Inputdeck.h"

using namespace std;

EXT_FORECAST Inputdeck::Inputdeck()
{

}

EXT_FORECAST Inputdeck::~Inputdeck()
{

}

void Inputdeck::tokenize(string const& str, const char delimeter,
    vector<string>& out)
{
    size_t start;
    size_t end = 0;

    while ((start = str.find_first_not_of(delimeter, end)) != string::npos)
    {
        end = str.find(delimeter, start);
        out.push_back(str.substr(start, end - start));
    }
}

EXT_FORECAST void Inputdeck::Get_InputDeckStructList(InputDeckStruct* _inputdecks, int size)
{
	inputdecks = _inputdecks;

	/*for (int i = 0; i < size; i++)
	{
		cout << inputdecks->Init_GOR_CGR << ", " << inputdecks->Init_Oil_Gas_Rate_1P_1C << ", " << inputdecks->Module << ", " << inputdecks->Flow_station << endl;
		inputdecks++;
	}*/
}


void Inputdeck::ToLower(string& str)
{
    transform(str.begin(), str.end(), str.begin(), ::tolower);
}

vector<InputDeckStruct> Inputdeck::GetInputDecksPointer(const char* filepath, const char delimeter)
{


    ifstream ifile;
    
    string line;
    ifstream myfile(filepath);

    vector<InputDeckStruct> InputDecks;

    InputDeckStruct deck;

    double MM = 1000000.0;
    double M = 1000.0;

    int counter = 0, j = -1;
    if (myfile.is_open())
    {
        while (getline(myfile, line))
        {
            counter++;
            if (counter > 1)
            {
                j++;

                vector<string> strings;

                tokenize(line, delimeter, strings);

                int i = 0;
                deck.Version_Name = strings[i]; i++;
                deck.Asset_Team = strings[i]; i++;
                deck.Field = strings[i]; i++;
                deck.Reservoir = strings[i]; i++;
                deck.Drainage_Point = strings[i]; i++;
                deck.Production_String = strings[i]; i++;
                deck.Module = strings[i]; i++;
                deck.PEEP_Project = strings[i]; i++;
                deck.Activity_Entity = strings[i]; i++;
                deck.Flow_station = strings[i]; i++;
                deck.Hydrocarbon_Stream = strings[i]; ToLower(deck.Hydrocarbon_Stream); i++;
                deck.Resource_Class = strings[i]; i++;
                deck.Change_Category = strings[i]; i++;
                deck.Technique_1P = strings[i]; i++;
                deck.URo_1P_1C = strtod(strings[i].c_str(), NULL); i++;
                deck.URo_Low = strtod(strings[i].c_str(), NULL); i++;
                deck.URo_2P_2C = strtod(strings[i].c_str(), NULL); i++;
                deck.URo_3P_3C = strtod(strings[i].c_str(), NULL); i++;
                deck.Np = strtod(strings[i].c_str(), NULL); i++;
                deck.URg_1P_1C = strtod(strings[i].c_str(), NULL) * M; i++;
                deck.URg_Low = strtod(strings[i].c_str(), NULL) * M; i++;
                deck.URg_2P_2C = strtod(strings[i].c_str(), NULL) * M; i++;
                deck.URg_3P_3C = strtod(strings[i].c_str(), NULL) * M; i++;
                deck.Gp = strtod(strings[i].c_str(), NULL) * M; i++;

                

                if (deck.Hydrocarbon_Stream == "oil")
                {
                    deck.Init_Oil_Gas_Rate_1P_1C = strtod(strings[i].c_str(), NULL); i++;
                    deck.Init_Oil_Gas_Rate_Low = strtod(strings[i].c_str(), NULL); i++;
                    deck.Init_Oil_Gas_Rate_2P_2C = strtod(strings[i].c_str(), NULL); i++;
                    deck.Init_Oil_Gas_Rate_3P_3C = strtod(strings[i].c_str(), NULL); i++;
                    deck.Aband_Oil_Gas_Rate_1P_1C = strtod(strings[i].c_str(), NULL); i++;
                    deck.Aband_Oil_Gas_Rate_2P_2C = strtod(strings[i].c_str(), NULL); i++;
                    deck.Aband_Oil_Gas_Rate_3P_3C = strtod(strings[i].c_str(), NULL); i++;
                }
                else
                {
                    deck.Init_Oil_Gas_Rate_1P_1C = strtod(strings[i].c_str(), NULL) * MM; i++;
                    deck.Init_Oil_Gas_Rate_Low = strtod(strings[i].c_str(), NULL) * MM; i++;
                    deck.Init_Oil_Gas_Rate_2P_2C = strtod(strings[i].c_str(), NULL) * MM; i++;
                    deck.Init_Oil_Gas_Rate_3P_3C = strtod(strings[i].c_str(), NULL) * MM; i++;
                    deck.Aband_Oil_Gas_Rate_1P_1C = strtod(strings[i].c_str(), NULL) * MM; i++;
                    deck.Aband_Oil_Gas_Rate_2P_2C = strtod(strings[i].c_str(), NULL) * MM; i++;
                    deck.Aband_Oil_Gas_Rate_3P_3C = strtod(strings[i].c_str(), NULL) * MM; i++;
                }
                

                deck.Init_BSW_WGR = strtod(strings[i].c_str(), NULL); i++;
                deck.Aband_BSW_WGR_1P_1C = strtod(strings[i].c_str(), NULL); i++;
                deck.Aband_BSW_WGR_2P_2C = strtod(strings[i].c_str(), NULL); i++;
                deck.Aband_BSW_WGR_3P_3C = strtod(strings[i].c_str(), NULL); i++;
                deck.Init_GOR_CGR = strtod(strings[i].c_str(), NULL); i++;
                deck.Aband_GOR_CGR_1P_1C = strtod(strings[i].c_str(), NULL); i++;
                deck.Aband_GOR_CGR_2P_2C = strtod(strings[i].c_str(), NULL); i++;
                deck.Aband_GOR_CGR_3P_3C = strtod(strings[i].c_str(), NULL); i++;
                deck.lift_Gas_Rate = strtod(strings[i].c_str(), NULL); i++;
                deck.Plateau_Oil_Gas = strtod(strings[i].c_str(), NULL); i++;
                deck.In_year_Booking = strings[i]; i++;
                deck.LE_LV = strings[i]; i++;
                deck.PRCS = strings[i]; i++;
                deck.On_stream_Date_1P_1C = strings[i]; i++;
                deck.On_stream_Date_2P_2C = strings[i]; i++;
                deck.On_stream_Date_3P_3C = strings[i]; i++;
                deck.Remarks = strings[i]; i++;
                deck.TRANCHE = strings[i]; i++;

                tm tm1, tm2, tm3;
                sscanf_s(deck.On_stream_Date_1P_1C.c_str(), "%d/%d/%d", &tm1.tm_mday, &tm1.tm_mon, &tm1.tm_year);
                sscanf_s(deck.On_stream_Date_2P_2C.c_str(), "%d/%d/%d", &tm2.tm_mday, &tm2.tm_mon, &tm2.tm_year);
                sscanf_s(deck.On_stream_Date_3P_3C.c_str(), "%d/%d/%d", &tm3.tm_mday, &tm3.tm_mon, &tm3.tm_year);

                deck.Date_1P_1C.day = tm1.tm_mday; deck.Date_1P_1C.month = tm1.tm_mon; deck.Date_1P_1C.year = tm1.tm_year;
                deck.Date_2P_2C.day = tm1.tm_mday; deck.Date_2P_2C.month = tm1.tm_mon; deck.Date_2P_2C.year = tm1.tm_year;
                deck.Date_3P_3C.day = tm1.tm_mday; deck.Date_3P_3C.month = tm1.tm_mon; deck.Date_3P_3C.year = tm1.tm_year;


               

                ValidateDeck(deck);

                if (deck.Description  == "no error")
                {
                    InputDecks.push_back(deck);
                }
               
            }


        }

        myfile.close();

    }

    else cout << "Unable to open file";

    return InputDecks;
}


 void Inputdeck::ValidateDeck(InputDeckStruct& extendedInputDeck)
{
     string Description = "no error";
    string newline = "\n";

    if (extendedInputDeck.Hydrocarbon_Stream.empty() == true)
    {
        Description = Description + "Hydrocarbon stream cannot be undefined" + newline;
        extendedInputDeck.Description = Description;
        return;
    }

    bool check_DGOR_CGR_1P1C = false;
    bool check_DGOR_CGR_2P2C = false;
    bool check_DGOR_CGR_3P3C = false;
    bool check_DBSW_WGR_1P1C = false;
    bool check_DBSW_WGR_2P2C = false;
    bool check_DBSW_WGR_3P3C = false;
    bool check_Rate_1P1C = false;
    bool check_Rate_2P2C = false;
    bool check_Rate_3P3C = false;
    bool check_UR_1P1C = false;
    bool check_UR_2P2C = false;
    bool check_UR_3P3C = false;

    if (extendedInputDeck.Hydrocarbon_Stream == "oil")
    {
        if (extendedInputDeck.URo_1P_1C <= 0)
        {
            check_UR_1P1C = true;
            Description = Description + "Ultimate oil recovery cannot be less than or equal zero (1P/1C)" + newline;
        }

        if (extendedInputDeck.URo_2P_2C <= 0)
        {
            check_UR_2P2C = true;
            Description = Description + "Ultimate oil recovery cannot be less than or equal zero (2P/2C)" + newline;
        }

        if (extendedInputDeck.URo_3P_3C <= 0)
        {
            check_UR_3P3C = true;
            Description = Description + "Ultimate oil recovery cannot be less than or equal zero (3P/3C)" + newline;
        }

        if (extendedInputDeck.Init_Oil_Gas_Rate_1P_1C <= 0)
        {
            check_Rate_1P1C = true;
            Description = Description + "Initial oil rate cannot be less than or equal zero (1P/1C)" + newline;
        }

        if (extendedInputDeck.Init_Oil_Gas_Rate_2P_2C <= 0)
        {
            check_Rate_2P2C = true;
            Description = Description + "Initial oil rate cannot be less than or equal zero (2P/2C)" + newline;
        }

        if (extendedInputDeck.Init_Oil_Gas_Rate_3P_3C <= 0)
        {
            check_Rate_2P2C = true;
            Description = Description + "Initial oil rate cannot be less than or equal zero (3P/3C)" + newline;
        }

        if (extendedInputDeck.Init_Oil_Gas_Rate_1P_1C <= extendedInputDeck.Aband_Oil_Gas_Rate_1P_1C)
        {
            check_Rate_1P1C = true;
            Description = Description + "Initial oil rate cannot be less than or equal abandonment oil rate (1P/1C)" + newline;
        }

        if (extendedInputDeck.Init_Oil_Gas_Rate_2P_2C <= extendedInputDeck.Aband_Oil_Gas_Rate_2P_2C)
        {
            check_Rate_2P2C = true;
            Description = Description + "Initial oil rate cannot be less than or equal abandonment oil rate (2P/2C)" + newline;
        }

        if (extendedInputDeck.Init_Oil_Gas_Rate_3P_3C <= extendedInputDeck.Aband_Oil_Gas_Rate_3P_3C)
        {
            check_Rate_3P3C = true;
            Description = Description + "Initial oil rate cannot be less than or equal abandonment oil rate (3P/3C)" + newline;
        }

        if (extendedInputDeck.Np >= extendedInputDeck.URo_1P_1C)
        {
            check_DGOR_CGR_1P1C = true;
            check_DBSW_WGR_1P1C = true;
            Description = Description + "Cumulative oil in place cannot be greater than or equal to ulimate oil recovery (1P/1C)" + newline;
        }
        if (extendedInputDeck.Np >= extendedInputDeck.URo_2P_2C)
        {
            check_DBSW_WGR_2P2C = true;
            check_DGOR_CGR_2P2C = true;
            Description = Description + "Cumulative oil in place cannot be greater than or equal to ulimate oil recovery (2P/2C)" + newline;
        }
        if (extendedInputDeck.Np >= extendedInputDeck.URo_3P_3C)
        {
            check_DBSW_WGR_3P3C = true;
            check_DGOR_CGR_3P3C = true;
            Description = Description + "Cumulative oil in place cannot be greater than or equal to ulimate oil recovery (3P/3C)" + newline;
        }

        if (extendedInputDeck.Init_BSW_WGR >= extendedInputDeck.Aband_BSW_WGR_1P_1C)
        {
            check_DBSW_WGR_1P1C = true;
            Description = Description + "Initial BSW cannot be greater than or equal to abandonment BSW (1P/1C)" + newline;

        }
        if (extendedInputDeck.Init_BSW_WGR >= extendedInputDeck.Aband_BSW_WGR_2P_2C)
        {
            check_DBSW_WGR_2P2C = true;
            Description = Description + "Initial BSW cannot be greater than or equal to abandonment BSW (2P/2C)" + newline;
        }
        if (extendedInputDeck.Init_BSW_WGR >= extendedInputDeck.Aband_BSW_WGR_3P_3C)
        {
            check_DBSW_WGR_3P3C = true;
            Description = Description + "Initial BSW cannot be greater than or equal to abandonment BSW (3P/3C)" + newline;
        }

        if (extendedInputDeck.Init_GOR_CGR >= extendedInputDeck.Aband_GOR_CGR_1P_1C)
        {
            check_DGOR_CGR_1P1C = true;
            Description = Description + "Initial GOR cannot be greater than or equal to abandonment GOR (1P/1C)" + newline;
        }
        if (extendedInputDeck.Init_GOR_CGR >= extendedInputDeck.Aband_GOR_CGR_2P_2C)
        {
            check_DGOR_CGR_2P2C = true;
            Description = Description + "Initial GOR cannot be greater than or equal to abandonment GOR (2P/2C)" + newline;
        }
        if (extendedInputDeck.Init_GOR_CGR >= extendedInputDeck.Aband_GOR_CGR_3P_3C)
        {
            check_DGOR_CGR_3P3C = true;
            Description = Description + "Initial GOR cannot be greater than or equal to abandonment GOR (3P/3C)" + newline;
        }
    }

    if (extendedInputDeck.Hydrocarbon_Stream == "gas")
    {
        if (extendedInputDeck.URg_1P_1C <= 0)
        {
            check_UR_1P1C = true;
            Description = Description + "Ultimate gas recovery cannot be less than or equal zero (1P/1C)" + newline;
        }

        if (extendedInputDeck.URg_2P_2C <= 0)
        {
            check_UR_2P2C = true;
            Description = Description + "Ultimate gas recovery cannot be less than or equal zero (2P/2C)" + newline;
        }

        if (extendedInputDeck.URg_3P_3C <= 0)
        {
            check_UR_3P3C = true;
            Description = Description + "Ultimate gas recovery cannot be less than or equal zero (3P/3C)" + newline;
        }


        if (extendedInputDeck.Init_Oil_Gas_Rate_1P_1C <= 0)
        {
            check_Rate_1P1C = true;
            Description = Description + "Initial gas rate cannot be less than or equal zero (1P/1C)" + newline;
        }

        if (extendedInputDeck.Init_Oil_Gas_Rate_2P_2C <= 0)
        {
            check_Rate_2P2C = true;
            Description = Description + "Initial gas rate cannot be less than or equal zero (2P/2C)" + newline;
        }

        if (extendedInputDeck.Init_Oil_Gas_Rate_3P_3C <= 0)
        {
            check_Rate_3P3C = true;
            Description = Description + "Initial gas rate cannot be less than or equal zero (3P/3C)" + newline;
        }

        if (extendedInputDeck.Init_Oil_Gas_Rate_1P_1C <= extendedInputDeck.Aband_Oil_Gas_Rate_1P_1C)
        {
            check_Rate_1P1C = true;
            Description = Description + "Initial gas rate cannot be less than or equal abandonment gas rate (1P/1C)" + newline;
        }

        if (extendedInputDeck.Init_Oil_Gas_Rate_2P_2C <= extendedInputDeck.Aband_Oil_Gas_Rate_2P_2C)
        {
            check_Rate_2P2C = true;
            Description = Description + "Initial gas rate cannot be less than or equal abandonment gas rate (2P/2C)" + newline;
        }

        if (extendedInputDeck.Init_Oil_Gas_Rate_3P_3C <= extendedInputDeck.Aband_Oil_Gas_Rate_3P_3C)
        {
            check_Rate_3P3C = true;
            Description = Description + "Initial gas rate cannot be less than or equal abandonment gas rate (3P/3C)" + newline;
        }

        if (extendedInputDeck.Gp >= extendedInputDeck.URg_1P_1C)
        {
            check_DGOR_CGR_1P1C = true;
            check_DBSW_WGR_1P1C = true;
            Description = Description + "Cumulative gas in place cannot be greater than or equal to ulimate gas recovery (1P/1C)" + newline;
        }
        if (extendedInputDeck.Gp >= extendedInputDeck.URg_2P_2C)
        {
            check_DBSW_WGR_2P2C = true;
            check_DGOR_CGR_2P2C = true;
            Description = Description + "Cumulative gas in place cannot be greater than or equal to ulimate gas recovery (2P/2C)" + newline;
        }
        if (extendedInputDeck.Gp >= extendedInputDeck.URg_3P_3C)
        {
            check_DBSW_WGR_3P3C = true;
            check_DGOR_CGR_3P3C = true;
            Description = Description + "Cumulative gas in place cannot be greater than or equal to ulimate gas recovery (3P/3C)" + newline;
        }


        if (extendedInputDeck.Init_BSW_WGR >= extendedInputDeck.Aband_BSW_WGR_1P_1C)
        {
            check_DBSW_WGR_1P1C = true;
            Description = Description + "Initial WGR cannot be greater than or equal to abandonment WGR (1P/1C)" + newline;
        }
        if (extendedInputDeck.Init_BSW_WGR >= extendedInputDeck.Aband_BSW_WGR_2P_2C)
        {
            check_DBSW_WGR_2P2C = true;
            Description = Description + "Initial WGR cannot be greater than or equal to abandonment WGR (2P/2C)" + newline;
        }
        if (extendedInputDeck.Init_BSW_WGR >= extendedInputDeck.Aband_BSW_WGR_3P_3C)
        {
            check_DBSW_WGR_3P3C = true;
            Description = Description + "Initial WGR cannot be greater than or equal to abandonment WGR (3P/3C)" + newline;
        }

        if (extendedInputDeck.Init_GOR_CGR <= extendedInputDeck.Aband_GOR_CGR_1P_1C)
        {
            check_DGOR_CGR_1P1C = true;
            Description = Description + "Initial CGR cannot be less than or equal to abandonment CGR (1P/1C)" + newline;
        }
        if (extendedInputDeck.Init_GOR_CGR <= extendedInputDeck.Aband_GOR_CGR_2P_2C)
        {
            check_DGOR_CGR_2P2C = true;
            Description = Description + "Initial CGR cannot be less than or equal to abandonment CGR (2P/2C)" + newline;
        }
        if (extendedInputDeck.Init_GOR_CGR <= extendedInputDeck.Aband_GOR_CGR_3P_3C)
        {
            check_DGOR_CGR_3P3C = true;
            Description = Description + "Initial CGR cannot be less than or equal to abandonment CGR (3P/3C)" + newline;
        }
    }

    extendedInputDeck.Description = Description;

    double MM = 1000000.0;
    double x1 = 0, x2 = 0, y1 = 0, y2 = 0;

    if (extendedInputDeck.Hydrocarbon_Stream == "oil")
    {
        if (check_DBSW_WGR_1P1C == false && check_UR_1P1C == false)
        {
            x1 = extendedInputDeck.Np * MM;
            x2 = extendedInputDeck.URo_1P_1C * MM;

            extendedInputDeck.Rate_Of_Rate_BSW_WGR_1P1C = fractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                x1, x2, extendedInputDeck.Init_BSW_WGR,
                extendedInputDeck.Aband_BSW_WGR_1P_1C);
        }
        if (check_DBSW_WGR_2P2C == false && check_UR_2P2C == false)
        {
            x1 = extendedInputDeck.Np * MM;
            x2 = extendedInputDeck.URo_2P_2C * MM;

            extendedInputDeck.Rate_Of_Rate_BSW_WGR_2P2C = fractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                x1, x2, extendedInputDeck.Init_BSW_WGR,
                extendedInputDeck.Aband_BSW_WGR_2P_2C);
        }
        if (check_DBSW_WGR_3P3C == false && check_UR_3P3C == false)
        {
            x1 = extendedInputDeck.Np * MM;
            x2 = extendedInputDeck.URo_3P_3C * MM;

            extendedInputDeck.Rate_Of_Rate_BSW_WGR_3P3C = fractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                x1, x2, extendedInputDeck.Init_BSW_WGR,
                extendedInputDeck.Aband_BSW_WGR_3P_3C);
        }

        if (check_DGOR_CGR_1P1C == false && check_UR_1P1C == false)
        {
            x1 = extendedInputDeck.Np * MM;
            x2 = extendedInputDeck.URo_1P_1C * MM;

            extendedInputDeck.Rate_Of_Rate_GOR_CGR_1P1C = fractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                x1, x2, extendedInputDeck.Init_GOR_CGR,
                extendedInputDeck.Aband_GOR_CGR_1P_1C);
        }
        if (check_DGOR_CGR_2P2C == false && check_UR_2P2C == false)
        {
            x1 = extendedInputDeck.Np * MM;
            x2 = extendedInputDeck.URo_2P_2C * MM;

            extendedInputDeck.Rate_Of_Rate_GOR_CGR_2P2C = fractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                x1, x2, extendedInputDeck.Init_GOR_CGR,
                extendedInputDeck.Aband_GOR_CGR_2P_2C);
        }
        if (check_DGOR_CGR_3P3C == false && check_UR_3P3C == false)
        {
            x1 = extendedInputDeck.Np * MM;
            x2 = extendedInputDeck.URo_3P_3C * MM;

            extendedInputDeck.Rate_Of_Rate_GOR_CGR_3P3C = fractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                x1, x2, extendedInputDeck.Init_GOR_CGR,
                extendedInputDeck.Aband_GOR_CGR_3P_3C);
        }

        if (check_Rate_1P1C == false && check_UR_1P1C == false)
        {
            x1 = extendedInputDeck.Np * MM;
            x2 = extendedInputDeck.URo_1P_1C * MM;

            extendedInputDeck.Rate_of_Change_Rate_1P_1C = decline_Curve_Analysis.Get_DeclineFactor_Exponential(
                extendedInputDeck.Init_Oil_Gas_Rate_1P_1C, extendedInputDeck.Aband_Oil_Gas_Rate_1P_1C,
                x1, x2);
        }
        if (check_Rate_2P2C == false && check_UR_2P2C == false)
        {
            x1 = extendedInputDeck.Np * MM;
            x2 = extendedInputDeck.URo_2P_2C * MM;

            extendedInputDeck.Rate_of_Change_Rate_2P_2C = decline_Curve_Analysis.Get_DeclineFactor_Exponential(
                extendedInputDeck.Init_Oil_Gas_Rate_2P_2C, extendedInputDeck.Aband_Oil_Gas_Rate_2P_2C,
                x1, x2);
        }
        if (check_Rate_3P3C == false && check_UR_3P3C == false)
        {
            x1 = extendedInputDeck.Np * MM;
            x2 = extendedInputDeck.URo_3P_3C * MM;

            extendedInputDeck.Rate_of_Change_Rate_3P_3C = decline_Curve_Analysis.Get_DeclineFactor_Exponential(
                extendedInputDeck.Init_Oil_Gas_Rate_3P_3C, extendedInputDeck.Aband_Oil_Gas_Rate_3P_3C,
                x1, x2);
        }
    }

    if (extendedInputDeck.Hydrocarbon_Stream == "gas")
    {
        if (check_DBSW_WGR_1P1C == false && check_UR_1P1C == false)
        {
            x1 = extendedInputDeck.Gp * MM;
            x2 = extendedInputDeck.URg_1P_1C * MM;

            extendedInputDeck.Rate_Of_Rate_BSW_WGR_1P1C = fractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                x1, x2, extendedInputDeck.Init_BSW_WGR,
                extendedInputDeck.Aband_BSW_WGR_1P_1C);
        }
        if (check_DBSW_WGR_2P2C == false && check_UR_2P2C == false)
        {
            x1 = extendedInputDeck.Gp * MM;
            x2 = extendedInputDeck.URg_2P_2C * MM;

            extendedInputDeck.Rate_Of_Rate_BSW_WGR_2P2C = fractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                x1, x2, extendedInputDeck.Init_BSW_WGR,
                extendedInputDeck.Aband_BSW_WGR_2P_2C);
        }
        if (check_DBSW_WGR_3P3C == false && check_UR_3P3C == false)
        {
            x1 = extendedInputDeck.Gp * MM;
            x2 = extendedInputDeck.URg_3P_3C * MM;

            extendedInputDeck.Rate_Of_Rate_BSW_WGR_3P3C = fractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                x1, x2, extendedInputDeck.Init_BSW_WGR,
                extendedInputDeck.Aband_BSW_WGR_3P_3C);
        }

        if (check_DGOR_CGR_1P1C == false && check_UR_1P1C == false)
        {
            x1 = extendedInputDeck.Gp * MM;
            x2 = extendedInputDeck.URg_1P_1C * MM;

            extendedInputDeck.Rate_Of_Rate_GOR_CGR_1P1C = fractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                x1, x2, extendedInputDeck.Init_GOR_CGR,
                extendedInputDeck.Aband_GOR_CGR_1P_1C);
        }
        if (check_DGOR_CGR_2P2C == false && check_UR_2P2C == false)
        {
            x1 = extendedInputDeck.Gp * MM;
            x2 = extendedInputDeck.URg_2P_2C * MM;

            extendedInputDeck.Rate_Of_Rate_GOR_CGR_2P2C = fractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                x1, x2, extendedInputDeck.Init_GOR_CGR,
                extendedInputDeck.Aband_GOR_CGR_2P_2C);
        }
        if (check_DGOR_CGR_3P3C == false && check_UR_3P3C == false)
        {
            x1 = extendedInputDeck.Gp * MM;
            x2 = extendedInputDeck.URg_3P_3C * MM;

            extendedInputDeck.Rate_Of_Rate_GOR_CGR_3P3C = fractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                x1, x2, extendedInputDeck.Init_GOR_CGR,
                extendedInputDeck.Aband_GOR_CGR_3P_3C);
        }

        if (check_Rate_1P1C == false && check_UR_1P1C == false)
        {
            x1 = extendedInputDeck.Gp * MM;
            x2 = extendedInputDeck.URg_1P_1C * MM;

            extendedInputDeck.Rate_of_Change_Rate_1P_1C = decline_Curve_Analysis.Get_DeclineFactor_Exponential(
                extendedInputDeck.Init_Oil_Gas_Rate_1P_1C, extendedInputDeck.Aband_Oil_Gas_Rate_1P_1C,
                x1, x2);
        }
        if (check_Rate_2P2C == false && check_UR_2P2C == false)
        {
            x1 = extendedInputDeck.Gp * MM;
            x2 = extendedInputDeck.URg_2P_2C * MM;

            extendedInputDeck.Rate_of_Change_Rate_2P_2C = decline_Curve_Analysis.Get_DeclineFactor_Exponential(
                extendedInputDeck.Init_Oil_Gas_Rate_2P_2C, extendedInputDeck.Aband_Oil_Gas_Rate_2P_2C,
                x1, x2);
        }
        if (check_Rate_3P3C == false && check_UR_3P3C == false)
        {
            x1 = extendedInputDeck.Gp * MM;
            x2 = extendedInputDeck.URg_3P_3C * MM;

            extendedInputDeck.Rate_of_Change_Rate_3P_3C = decline_Curve_Analysis.Get_DeclineFactor_Exponential(
                extendedInputDeck.Init_Oil_Gas_Rate_3P_3C, extendedInputDeck.Aband_Oil_Gas_Rate_3P_3C,
                x1, x2);
        }
    }



}

bool Inputdeck::IsContains(vector<string>& Faclities, string& Facility)
{
    bool check = false;
    for (int i = 0; i < Faclities.size(); i++)
    {
        if (Faclities[i] == Facility)
        {
            check = true; break;
        }
    }

    return check;
}


vector<string> Inputdeck::GetFacilities(InputDeckStruct* inputdecks, int size)
{
    vector<string> Faclities;

    for (int i = 0; i < size; i++)
    {
        if (IsContains(Faclities, inputdecks->Flow_station) ==  false)
        {
            Faclities.push_back(inputdecks->Flow_station);
        }

        inputdecks++;
    }

   /* for (int i = 0; i < Faclities.size(); i++)
    {

        cout << Faclities[i] << endl;
        
    }*/

    return Faclities;
}


vector<vector<InputDeckStruct>> Inputdeck::GetModulesByFacility(vector<string>& Faclities, vector<InputDeckStruct>& _inputdecks, int size)
{
    vector<vector<InputDeckStruct>> Facilities;
   
    vector<InputDeckStruct> Facility;

    for (int j = 0; j < Faclities.size(); j++)
    {

        Facility.clear();
        for (int i = 0; i < size; i++)
        {
            if (Faclities[j] == _inputdecks[i].Flow_station)
            {
                Facility.push_back(_inputdecks[i]);
            }
        }

        Facilities.push_back(Facility);
    }

    return Facilities;
}
