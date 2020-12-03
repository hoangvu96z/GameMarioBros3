#include"BigBox.h"

CBigBox::CBigBox(int widthUnit, int heightUnit) : CGameObject::CGameObject()
{
	type = BIGBOX;
	category = MISC;
	this->width = widthUnit * 16;
	this->height = heightUnit * 16;
}

void CBigBox::Render()
{
	//RenderBoundingBox(1);
}

void CBigBox::GetBoundingBox(float& l, float& t, float& r, float& b)
{
	l = x;
	t = y;
	r = x + width;
	b = y + height;
}