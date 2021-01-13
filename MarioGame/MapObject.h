#pragma once
#include "GameObject.h"

// Overworld map
#define MAP_OBJECT_ANI_TUSSOCK				0
#define MAP_OBJECT_ANI_HELP_BUBBLE			1
#define MAP_OBJECT_ANI_GATEKEEPER_RIGHT		2
#define MAP_OBJECT_ANI_GATEKEEPER_LEFT		3

#define GATEKEEPER_SPEED_X		0.015f
#define GATEKEEPER_LEFT_LIMIT	153.0f
#define GATEKEEPER_RIGHT_LIMIT	168.0f

#define POINT_SIDE_LENGTH	4.0f

#define ALLOWED_TO_GO_LEFT	0
#define ALLOWED_TO_GO_RIGHT	1
#define ALLOWED_TO_GO_UP	2
#define ALLOWED_TO_GO_DOWN	3

#define START_POINT_X	32
#define START_POINT_Y	48

class CMapObject : public CGameObject
{
public:
	CMapObject();
	virtual void Render();
	virtual void Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects);
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);
};

