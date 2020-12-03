#pragma once
#include "GameObject.h"
#include "TailEffect.h"

#define TAIL_BBOX_WIDTH			9
#define TAIL_BBOX_HEIGHT		6

class CTail : public CGameObject
{
public:
	vector<LPGAMEOBJECT> listEffect;
	bool appearance = false;
	
	virtual void Render();
	virtual void Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects);
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);
	void CreateEffect();
};

class Tail {};
