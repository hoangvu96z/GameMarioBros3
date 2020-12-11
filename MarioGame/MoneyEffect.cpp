#include "MoneyEffect.h"

CMoneyEffect::CMoneyEffect(D3DXVECTOR2 position, int moneyAni)
{
	x = position.x;
	y = position.y;
	aniId = moneyAni;
	vy = -MONEY_EFFECT_SPEED_Y;
	this->SetAnimationSet(CAnimationSets::GetInstance()->Get(17));
}

void CMoneyEffect::Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects)
{
	CGameObject::Update(dt);
	y += dy;
}

void CMoneyEffect::Render()
{
	animation_set->at(aniId)->Render(x, y);
}

CMoneyEffect::~CMoneyEffect()
{
}
