#include"Platform.h"

CPlatform::CPlatform(int width, int height) : CGameObject::CGameObject()
{
	type = PLATFORM;
	category = MISC;
	this->width = width;
	this->height = height;
}

void CPlatform::Render()
{
	RenderBoundingBox(2);
}

void CPlatform::GetBoundingBox(float& l, float& t, float& r, float& b)
{
	l = x;
	t = y;
	r = x + 16 * width;
	b = y + 16 * height;
}