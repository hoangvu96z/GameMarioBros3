#include "BrokenBrickUnit.h"

CBrokenBrickUnit::CBrokenBrickUnit(D3DXVECTOR2 position, int nx, int deflectFactorY)
{
	x = position.x;
	y = position.y;
	vx = BROKEN_BRICK_UNIT_DEFLECT_SPEED_X * nx;
	vy = -BROKEN_BRICK_UNIT_DEFLECT_SPEED_Y * deflectFactorY;
	this->SetAnimationSet(CAnimationSets::GetInstance()->Get(12));
}

void CBrokenBrickUnit::GetBoundingBox(float& left, float& top, float& right, float& bottom)
{
	left =  0;
	top = 0;
	right = 0;
	bottom = 0;
}

void CBrokenBrickUnit::Render()
{
	animation_set->at(0)->Render(x, y);
}

void CBrokenBrickUnit::Update(DWORD dt, vector<LPGAMEOBJECT>* coObjects)
{
	CGameObject::Update(dt);

	vy += BROKEN_BRICK_UNIT_GRAVITY * dt;
	x += dx;
	y += dy;

	if (y > CGame::GetInstance()->GetCamPosY() + SCREEN_HEIGHT / 2) {
		isFinishedUsing = true;
	}
}
