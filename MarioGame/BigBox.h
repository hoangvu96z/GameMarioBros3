#pragma once
#include"GameObject.h"
class CBigBox : public CGameObject
{
	int height;
	int width;
public:
	CBigBox(int width, int height);
	virtual void Render();
	virtual void GetBoundingBox(float& l, float& t, float& r, float& b);

};