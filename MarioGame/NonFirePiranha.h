
#pragma once
#include "GameObject.h"
#include "Mario.h"
#include "MoneyEffect.h"

#define	NON_FIRE_PIRANHA_STATE_MOVE_UP			10
#define	NON_FIRE_PIRANHA_STATE_MOVE_DOWN		11
#define NON_FIRE_PIRANHA_BBOX_WIDTH			16
#define NON_FIRE_PIRANHA_BBOX_HEIGHT			24
#define NON_FIRE_PIRANHA_MOVE_SPEED_Y			0.06f
#define NON_FIRE_PIRANHA_MAX_Y					385
#define NON_FIRE_PIRANHA_MIN_Y					361
#define NON_FIRE_PIRANHA_SAFE_ZONE_LEFT		1788
#define NON_FIRE_PIRANHA_SAFE_ZONE_RIGHT		1827
#define NON_FIRE_PIRANHA_SAFE_ZONE_BOTTOM		415

#define NON_FIRE_PIRANHA_DELAY_TIME			820
#define PIRANHA_MAX_EXISTING_TIME_AFTER_DEATH	500

class CNonFirePiranha : public CGameObject
{
public:
	CTimingUtils* attackTime = new CTimingUtils(NON_FIRE_PIRANHA_DELAY_TIME);
	CTimingUtils* sleepTime = new CTimingUtils(NON_FIRE_PIRANHA_DELAY_TIME);
	CTimingUtils* deadTime = new CTimingUtils(PIRANHA_MAX_EXISTING_TIME_AFTER_DEATH);

	float playerLeft, playerTop, playerRight, playerBottom;
	bool vanish = false;

	CMario* player;
	CMoneyEffect* effect;

	CNonFirePiranha(CMario* mario);
	virtual void Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects);
	virtual void Render();
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);
	virtual void SetState(int state);
	bool CheckPlayerInSafeZone(float pl, float pt, float pr, float pb);
};

