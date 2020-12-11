#pragma once
#include "GameObject.h"

#define BROKEN_BRICK_UNIT_GRAVITY			0.0009f
#define BROKEN_BRICK_UNIT_WIDTH			8
#define	BROKEN_BRICK_UNIT_HEIGHT			8
#define	BROKEN_BRICK_UNIT_DEFLECT_SPEED_X	0.07f
#define	BROKEN_BRICK_UNIT_DEFLECT_SPEED_Y	0.16f

class CBrokenBrickUnit : public CGameObject
{
public:
	CBrokenBrickUnit(D3DXVECTOR2 position, int nx, int deflectFactorY = 1);
	virtual void Update(DWORD dt, vector<LPGAMEOBJECT>* coObjects);
	virtual void Render();
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);
};