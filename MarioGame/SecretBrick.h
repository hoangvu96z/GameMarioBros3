#pragma once
#include "GameObject.h"
#include "Mario.h"

#define BRICK_DEFLECT_SPEED_Y		0.1f
#define BRICK_BOUNCE_UP_TO			10

#define QUESTION_BRICK_ANI			0
#define NORMAL_BRICK_ANI			1
#define	DISGUISED_BRONZE_BRICK_ANI	2
#define	STATE_RAMMED				101
#define STATE_BEING_HIT_BY_TAIL		102

#define BRICK_VERTICAL_SEPARATION_LINE	1152

class CSecretBrick : public CGameObject
{
public:
	vector<LPGAMEOBJECT> listItem;
	CMario* player;

	int brickType;
	int itemType;

	float originalPosY;
	bool rammed;
	bool isAboutToDropItem;
	bool dropped;

	CSecretBrick(int brickType, int itemType, float originalPosY);
	virtual void Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects);
	virtual void Render();
	virtual void GetBoundingBox(float& left, float& top, float& right, float& bottom);
	virtual void SetState(int state);
};