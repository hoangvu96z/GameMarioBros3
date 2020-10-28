#include"Platform.h"

CPlatform::CPlatform(float l, float t, float r, float b)
{
	x = l;
	y = t;
	width = r - l;
	height = b - t;
}

void CPlatform::Render()
{
	RenderBoundingBox();
}

void CPlatform::GetBoundingBox(float& l, float& t, float& r, float& b)
{
	l = x;
	t = y;
	r = x + width;
	b = y + height;
}