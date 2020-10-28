#pragma once
#include"GameObject.h"
class CPlatform : public CGameObject
{
	int width;
	int height;
public:
	CPlatform(float l, float t, float r, float b);
	virtual void Render();
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);
};