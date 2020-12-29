#pragma once
#include "GameObject.h"
#include "Mario.h"
#include "HitEffect.h"

#define PIRANHA_FIREBALL_SPEED_X				0.05f

class CPiranhaFireball : public CGameObject
{
public:
	vector<LPGAMEOBJECT> listEffect;

	CMario* player;

	CPiranhaFireball(D3DXVECTOR2 piranhaPos, OperationArea playerArea, CMario* player);
	virtual void Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects);
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);
	virtual void Render();

	void Routing(OperationArea playerArea);
	void SetNx(OperationArea playerArea);
	void CreateFireballs();
};