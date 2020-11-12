#pragma once
#include "GameObject.h"
// Weapon
#define FIREBALL_BBOX_WIDTH		8
#define FIREBALL_BBOX_HEIGHT	8
#define FIREBALL_SPEED			0.15f
#define FIREBALL_TO_RIGHT		0
#define FIREBALL_TO_LEFT		1


class CFireball : public CGameObject
{
public:
	CFireball(D3DXVECTOR2 position, int nx);
	virtual void Update(DWORD dt, vector<LPGAMEOBJECT>* coObjects);
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);
	virtual void Render();
	~CFireball();
}; 