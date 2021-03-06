#pragma once
#include "GameObject.h"

#define BBOX_WIDTH  16
#define BBOX_HEIGHT 16

class CPlatform : public CGameObject
{
public:

	CPlatform(float widthUnit, float heightUnit);
	virtual void Render();
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);
};
