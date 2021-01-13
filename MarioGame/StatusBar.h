﻿#pragma once
#include "Animations.h"
#include "Sprites.h"
#include "Mario.h"
#include "Number.h"
#include "P_Meter.h"
#include "TimingUtils.h"

class CStatusBar
{
	LPANIMATION_SET HUD;
	LPSPRITE blackBG;
	CNumber number;
	CP_Meter* p_meter;
	CTimingUtils* playTime = new CTimingUtils(MAX_PLAY_TIME * CLOCKS_PER_SEC);
	int countdown = 0;

public:
	CMario* player;

	CStatusBar(CMario* player);
	void Update();
	void Render(float camX, float camY);
	~CStatusBar();
};
