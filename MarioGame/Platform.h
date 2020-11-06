#pragma once
#include"GameObject.h"
class CPlatform : public CGameObject
{
	int height;
	int width;
public:
	CPlatform(int width, int height);
	virtual void Render();
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);

};