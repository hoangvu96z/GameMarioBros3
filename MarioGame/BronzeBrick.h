
#pragma once
#include "GameObject.h"
#include "BrokenBrickUnit.h"

#define BRONZE_BRICK_ANI		0
#define IDLE_COIN_ANI			1
#define ROTATING_COIN			2
#define TRANSFORMATION_TIME		7000 //8000
#define STATE_TRANSFORMATION	100
#define STATE_NORMAL			200
#define BRICK_BBOX_SIDE_LENGTH	16
#define STATE_DESTROYED			99
#define BRONZE_BRICK_HORIZONTAL_SEPARATION_LINE	367

class CBronzeBrick : public CGameObject
{
public:
	vector<LPGAMEOBJECT> listPiece;
	DWORD transformationTime;
	bool vanish;
	int transformation;

	CBronzeBrick(int transformation);
	virtual void Update(DWORD dt, vector<LPGAMEOBJECT>* coObjects);
	virtual void Render();
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);
	virtual void SetState(int state);
};