
#pragma once
#include "GameObject.h"
#include "MoneyEffect.h"
#include "TimingUtils.h"
#include "Mario.h"

#define GOOMBA_MOVE_SPEED_X				0.035f
#define GOOMBA_DEFLECT_SPEED_Y			0.15f
#define GOOMBA_DEFLECT_SPEED_X			0.03f

#define GOOMBA_BBOX_WIDTH				16
#define GOOMBA_BBOX_HEIGHT				16
#define GOOMBA_BBOX_HEIGHT_DIE_BY_KICK	9

#define GOOMBA_ANI_MOVE					0
#define GOOMBA_ANI_DIE_BY_KICK			1
#define GOOMBA_ANI_DIE_BY_ATTACK_TOOL		2
#define GOOMBA_STATE_DIE_BY_KICK		299
#define GOOMBA_MAX_EXISTING_TIME_AFTER_DEATH	250

#define GOOMBA_STATE_FLY_LOW					298
#define GOOMBA_STATE_FLY_HIGH					297

class CGoomba : public CGameObject
{
	virtual void GetBoundingBox(float &left, float &top, float &right, float &bottom);
	virtual void Update(DWORD dt, vector<LPGAMEOBJECT> *coObjects);
	virtual void Render();

public:
	bool died = false;
	CTimingUtils* deadTime = new CTimingUtils(GOOMBA_MAX_EXISTING_TIME_AFTER_DEATH);
	CMoneyEffect* effect;
	CMario* player;
	CGoomba(CMario* player);
	virtual void SetState(int state);
};