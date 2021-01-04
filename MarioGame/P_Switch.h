#pragma once
#include "GameObject.h"

#define P_SWITCH_BBBOX_SIDE_LENGTH	16
#define P_SWITCH_NORMAL_ANI			0
#define P_SWITCH_PRESSED_ANI		1
#define P_SWITCH_POS_X				2032
#define P_SWITCH_POS_Y				352

class CP_Switch : public CGameObject
{
public:
	bool readyToPerform = true;

	CP_Switch();
	virtual void Render();
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);

	void PerformBricksTransformation(vector<LPGAMEOBJECT>* listBricks);
};