#include "Background.h"

void CBackground::Render()
{
	x = 0;
	y = 0;
	animation_set->at(0)->Render(x, y);
}

void CBackground::GetBoundingBox(float& l, float& t, float& r, float& b)
{
	l = x;
	t = y;
	r = x + BACKGROUND_BBOX_WIDTH;
	b = y + BACKGROUND_BBOX_HEIGHT;
}