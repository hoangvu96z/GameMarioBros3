#pragma once
class RedPiranha
{
};

#pragma once
#include "GameObject.h"
#include "Mario.h"
#include "PiranhaFireball.h"
#include "MoneyEffect.h"
#include "TimingUtils.h"

#define	FIRE_PIRANHA_STATE_MOVE_UP			10
#define	FIRE_PIRANHA_STATE_MOVE_DOWN		11
#define	FIRE_PIRANHA_STATE_ATTACK			12
#define FIRE_PIRANHA_MOVE_SPEED_Y			0.06f
#define FIRE_PIRANHA_MAX_Y					369

#define FIRE_PIRANHA_DELAY_TIME				1500
#define	FIRE_PIRANHA_DELAY_TO_ATTACK_TIME	700

#define FIRE_PIRANHA_ANI_FACE_UP_LEFT		0
#define FIRE_PIRANHA_ANI_FACE_DOWN_LEFT		1
#define FIRE_PIRANHA_ANI_FACE_UP_RIGHT		2
#define FIRE_PIRANHA_ANI_FACE_DOWN_RIGHT	3
#define FIRE_PIRANHA_ANI_ATTACK_UP_LEFT		4
#define FIRE_PIRANHA_ANI_ATTACK_DOWN_LEFT	5
#define FIRE_PIRANHA_ANI_ATTACK_UP_RIGHT	6
#define FIRE_PIRANHA_ANI_ATTACK_DOWN_RIGHT	7

#define GREEN_FIRE_PIRANHA_MIN_Y			344
#define GREEN_FIRE_PIRANHA_BBOX_WIDTH		16
#define GREEN_FIRE_PIRANHA_BBOX_HEIGHT		24
#define GREEN_FIRE_PIRANHA_FAR_LEFT_START	1728
#define GREEN_FIRE_PIRANHA_NEAR_LEFT_START	1802
#define GREEN_FIRE_PIRANHA_NEAR_RIGHT_START	1872
#define GREEN_FIRE_PIRANHA_FAR_RIGHT_START	1956	
#define GREEN_FIRE_PIRANHA_FAR_RIGHT_END	2012
#define GREEN_FIRE_PIRANHA_SAFE_ZONE_LEFT	1852
#define GREEN_FIRE_PIRANHA_SAFE_ZONE_RIGHT	1891
#define GREEN_FIRE_PIRANHA_SAFE_ZONE_BOTTOM	415

#define RED_FIRE_PIRANHA_MIN_Y				336
#define RED_FIRE_PIRANHA_BBOX_WIDTH			16
#define RED_FIRE_PIRANHA_BBOX_HEIGHT		32
#define RED_FIRE_PIRANHA_FAR_LEFT_START		191
#define RED_FIRE_PIRANHA_NEAR_LEFT_START	296	
#define RED_FIRE_PIRANHA_NEAR_RIGHT_START	368	
#define RED_FIRE_PIRANHA_FAR_RIGHT_START	440	
#define RED_FIRE_PIRANHA_FAR_RIGHT_END		535
#define RED_FIRE_PIRANHA_SAFE_ZONE_LEFT		348
#define RED_FIRE_PIRANHA_SAFE_ZONE_RIGHT	387
#define RED_FIRE_PIRANHA_SAFE_ZONE_BOTTOM	415

#define PIRANHA_MAX_EXISTING_TIME_AFTER_DEATH	500

class CFirePiranha : public CGameObject
{
public:
	vector<LPGAMEOBJECT> listFireball;

	CTimingUtils* attackTime = new CTimingUtils(FIRE_PIRANHA_DELAY_TIME);
	CTimingUtils* sleepTime = new CTimingUtils(FIRE_PIRANHA_DELAY_TIME);
	CTimingUtils* delayToAttackTime = new CTimingUtils(FIRE_PIRANHA_DELAY_TO_ATTACK_TIME);
	CTimingUtils* deadTime = new CTimingUtils(PIRANHA_MAX_EXISTING_TIME_AFTER_DEATH);

	int last_face_ani = FIRE_PIRANHA_ANI_FACE_DOWN_LEFT;
	int last_attack_ani = FIRE_PIRANHA_ANI_ATTACK_DOWN_LEFT;

	float playerLeft, playerTop, playerRight, playerBottom;
	float farLeftStart, nearLeftStart, nearRightStart, farRightStart, farRightEnd;
	float safeZoneLeft, safeZoneRight, safeZoneBottom;

	int piranhaType;
	OperationArea playerArea;
	CMario* player;
	CMoneyEffect* effect;
	float minPosY;
	bool vanish = false;

	CFirePiranha(CMario* mario, int piranhaType);
	virtual void Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects);
	virtual void Render();
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);
	virtual void SetState(int state);

	OperationArea GetCurrentPlayerArea();
	void CreateFireball();
	void SetAreaLimit();
	bool CheckPlayerInSafeZone(float pl, float pt, float pr, float pb);
};

