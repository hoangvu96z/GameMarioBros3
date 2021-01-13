#include "MapObject.h"

CMapObject::CMapObject()
{
	vx = -GATEKEEPER_SPEED_X;
}

void CMapObject::Render()
{
	if (type == ObjectType::TUSSOCK)
		aniId = MAP_OBJECT_ANI_TUSSOCK;
	else if (type == ObjectType::HELP_BUBBLE)
		aniId = MAP_OBJECT_ANI_HELP_BUBBLE;
	else
	{
		if (vx > 0)
			aniId = MAP_OBJECT_ANI_GATEKEEPER_RIGHT;
		else
			aniId = MAP_OBJECT_ANI_GATEKEEPER_LEFT;
	}

	animation_set->at(aniId)->Render(x, y);
}

void CMapObject::Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects)
{
	if (type == ObjectType::GATEKEEPER)
	{
		CGameObject::Update(dt, coObjects);

		x += dx;

		if ((x <= GATEKEEPER_LEFT_LIMIT && vx < 0) || (x >= GATEKEEPER_RIGHT_LIMIT && vx > 0))
			vx = -vx;
	}
}

void CMapObject::GetBoundingBox(float& l, float& t, float& r, float& b)
{
	l = t = r = b = 0;
}
