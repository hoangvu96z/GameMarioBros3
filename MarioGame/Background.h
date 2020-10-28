#pragma once
#include "GameObject.h"
#define BACKGROUND_BBOX_WIDTH  2821
#define BACKGROUND_BBOX_HEIGHT 439
class CBackground : public CGameObject
{
public:
	virtual void Render();
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);
};