#include "TailEffect.h"
#include "Tail.h"

CTailEffect::CTailEffect(D3DXVECTOR2 position, int nx)
{
	effectTime = TAIL_EFFECT_TIME;

	if (nx > 0) {
		x = position.x;
		y = position.y - 6;
	} else {
		x = position.x - (TAIL_EFFECT_WIDTH - TAIL_BBOX_WIDTH);
		y = position.y - 6;
	}

	this->SetAnimationSet(CAnimationSets::GetInstance()->Get(12));
}

void CTailEffect::Render()
{
	animation_set->at(0)->Render(x, y);
}
