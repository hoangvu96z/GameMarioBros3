#pragma once
#include "Sprites.h"
#include "Textures.h"
#include "string"
#include "constants.h"
#include "map"

#define	NUM_0	1010
#define	NUM_1	1011
#define	NUM_2	1012
#define	NUM_3	1013
#define	NUM_4	1014
#define	NUM_5	1015
#define	NUM_6	1016
#define	NUM_7	1017
#define	NUM_8	1018
#define	NUM_9	1019

class CNumber
{
	LPSPRITE num;
	map<char, int> numSpriteID{ { '0', NUM_0 }, { '1', NUM_1 }, { '2', NUM_2 }, { '3', NUM_3 }, { '4', NUM_4 }, { '5', NUM_5 }, { '6', NUM_6 }, { '7', NUM_7 }, { '8', NUM_8 }, { '9', NUM_9 } };

public:
	CNumber() = default;
	string ConvertToCorrectNumString(int number, int max_num_size);
	void Render(float x, float y, int number, int max_num_size);
	~CNumber();
};

