#include "Platform.h"

CPlatform::CPlatform(int widthUnit, int heightUnit)
{
	type = PLATFORM;
	category = MISC;
	this->width = widthUnit * BBOX_WIDTH;
	this->height = heightUnit * BBOX_HEIGHT;
}

void CPlatform::Render()
{
	//RenderBoundingBox(3);
}

void CPlatform::GetBoundingBox(float& l, float& t, float& r, float& b)
{
	l = x;
	t = y;
	r = x + width;
	b = y + height;
}