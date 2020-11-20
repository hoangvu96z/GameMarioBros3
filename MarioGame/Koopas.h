#pragma once
#include "GameObject.h"
#include "Mario.h"
class CMario;

#define KOOPA_MOVE_SPEED_X					0.025f
#define KOOPA_SPIN_AND_MOVE_SPEED_X			0.2f
#define KOOPA_DEFLECT_SPEED_Y				0.15f
#define KOOPA_DEFLECT_SPEED_X				0.03f
#define KOOPA_BBOX_WIDTH					16
#define KOOPA_BBOX_HEIGHT					27
#define KOOPA_BBOX_HEIGHT_LAY_VIBRATE_SPIN	16
#define KOOPA_BBOX_WIDTH_VIBRATE			18
#define KOOPA_ANI_MOVE_RIGHT				0
#define KOOPA_ANI_MOVE_LEFT					1
#define KOOPA_ANI_LAY_PRONE					2
#define KOOPA_ANI_LAY_SUPINE				3
#define KOOPA_ANI_VIBRATE_PRONE				4
#define KOOPA_ANI_VIBRATE_SUPINE			5
#define KOOPA_ANI_SPIN_AND_MOVE_PRONE		6
#define KOOPA_ANI_SPIN_AND_MOVE_SUPINE		7
#define KOOPA_STATE_SPIN_AND_MOVE			80
#define KOOPA_STATE_BEING_HELD				81

class CKoopas : public CGameObject
{
	virtual void GetBoundingBox(float &left, float &top, float &right, float &bottom);
	virtual void Update(DWORD dt, vector<LPGAMEOBJECT> *coObjects);
	virtual void Render();

public:
	bool died;
	bool isSupine;
	bool isBeingHeld;

	int startingPos;
	
	CMario* player = NULL;
	
	CKoopas(CMario* mario, int startingPos);
	virtual void SetState(int state);
	void SetPositionAccordingToPlayer();
	void Reset();
};