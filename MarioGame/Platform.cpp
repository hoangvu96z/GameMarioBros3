#include "Platform.h"

CPlatform::CPlatform(float width, float height)
{
	type = PLATFORM;
	category = MISC;
	this->width = (int)width;
	this->height = (int)height;
}

void CPlatform::Render()
{
	RenderBoundingBox(3);
}

void CPlatform::GetBoundingBox(float& l, float& t, float& r, float& b)
{
	l = x;
	t = y;
	r = x + BBOX_WIDTH * width;
	b = y + BBOX_HEIGHT * height;
}