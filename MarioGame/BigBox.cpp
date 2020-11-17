#include"BigBox.h"

CBigBox::CBigBox(int width, int height) : CGameObject::CGameObject()
{
	type = BIGBOX;
	category = MISC;
	this->width = width;
	this->height = height;
}

void CBigBox::Render()
{
	RenderBoundingBox(1);
}

void CBigBox::GetBoundingBox(float& l, float& t, float& r, float& b)
{
	l = x;
	t = y;
	r = x + 16 * width;
	b = y + 16 * height;
}