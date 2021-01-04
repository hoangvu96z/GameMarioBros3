#pragma once
#include "GameObject.h"
#include "Math.h"

#define SUPER_LEAF_ANI_LEFT						0
#define SUPER_LEAF_ANI_RIGHT					1
#define SUPER_LEAF_BBOX_WIDTH					16
#define SUPER_LEAF_BBOX_HEIGHT					14
#define SUPER_LEAF_DEFLECT_SPEED_Y				1.0f
#define SUPER_LEAF_SPEED_Y						0.35f
#define SUPER_LEAF_POSITION_ADJUSTMENT_NUM_Y	7
#define SUPER_LEAF_MAX_DISTANCE_FROM_BRICK		32
#define SUPER_LEAF_RIGHT_LIMIT_FROM_BRICK		32
#define SUPER_LEAF_SPEED_X_FACTOR				0.3 //
#define SUPER_LEAF_NUM_TO_THE_POWER_OF_SPEED_Y	35	//

class CSuperLeaf : public CGameObject
{
public:
	float minPosY;
	float leftLimit, rightLimit;
	bool isFalling = false;

	CSuperLeaf(float brickX, float brickY);
	virtual void Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects);
	virtual void Render();
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);
};

