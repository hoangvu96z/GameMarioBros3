#pragma once
#include "GameObject.h"
#include "TimingUtils.h"

#define ICE_FLOWER_BBOX_WIDTH			16
#define ICE_FLOWER_BBOX_HEIGHT			16
#define ICE_FLOWER_DEFLECT_SPEED_Y		0.3f
#define ICE_FLOWER_MAX_EXISTING_TIME	2500

class CIceFlower : public CGameObject
{
public:
	CTimingUtils* existingTime = new CTimingUtils(ICE_FLOWER_MAX_EXISTING_TIME);
	float minPosY;

	CIceFlower(float brickX, float brickY);
	virtual void Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects);
	virtual void Render();
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);
};