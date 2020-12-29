#include "PiranhaFireball.h"

CPiranhaFireball::CPiranhaFireball(D3DXVECTOR2 piranhaPos, OperationArea playerArea, CMario* player)
{
	this->x = piranhaPos.x + 4;
	this->y = piranhaPos.y + 4;
	this->player = player;

	Routing(playerArea);
	SetNx(playerArea);

	this->SetAnimationSet(CAnimationSets::GetInstance()->Get(9));
}

void CPiranhaFireball::GetBoundingBox(float& l, float& t, float& r, float& b)
{
	l = x;
	t = y;
	r = x + FIREBALL_BBOX_WIDTH;
	b = y + FIREBALL_BBOX_HEIGHT;
}

void CPiranhaFireball::Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects)
{
	CGameObject::Update(dt);

	if (y > CGame::GetInstance()->GetCamPosY() + SCREEN_HEIGHT / 2 || y < CGame::GetInstance()->GetCamPosY())
		isFinishedUsing = true;

	if (listEffect.empty())
	{
		x += dx;
		y += dy;
	}

	for (LPGAMEOBJECT effect : listEffect)
	{
		if (effect->isFinishedUsing)
			listEffect.erase(listEffect.begin());
	}

	for (LPGAMEOBJECT effect : listEffect)
		effect->Update(dt, coObjects);

	float ml, mt, mr, mb, pl, pt, pr, pb; // main object - fireball (m) and the player (p)
	GetBoundingBox(ml, mt, mr, mb);
	player->GetBoundingBox(pl, pt, pr, pb);

	if (CGameObject::CheckCollisionAABB(ml, mt, mr, mb, pl, pt, pr, pb))
	{
		if (!player->GetUntouchable())
		{
			CreateFireballs();
			player->WhenCollidingWithEnemy();
		}
	}
}



void CPiranhaFireball::Render()
{
	if (nx > 0)
		animation_set->at(FIREBALL_TO_RIGHT)->Render(x, y);
	else
		animation_set->at(FIREBALL_TO_LEFT)->Render(x, y);

	for (LPGAMEOBJECT effect : listEffect)
		effect->Render();

	//RenderBoundingBox();
}

void CPiranhaFireball::SetNx(OperationArea playerArea)
{
	switch (playerArea)
	{
	case OperationArea::TOP_LEFT_FAR:
	case OperationArea::TOP_LEFT_NEAR:
	case OperationArea::BOTTOM_LEFT_FAR:
	case OperationArea::BOTTOM_LEFT_NEAR:
		nx = -1;
		break;
	case OperationArea::TOP_RIGHT_FAR:
	case OperationArea::TOP_RIGHT_NEAR:
	case OperationArea::BOTTOM_RIGHT_FAR:
	case OperationArea::BOTTOM_RIGHT_NEAR:
		nx = 1;
		break;
	}
}

void CPiranhaFireball::Routing(OperationArea playerArea)
{
	switch (playerArea)
	{
	case OperationArea::TOP_LEFT_FAR:
		vx = -PIRANHA_FIREBALL_SPEED_X;
		vy = vx / 2.8f;
		break;
	case OperationArea::TOP_LEFT_NEAR:
		vx = -PIRANHA_FIREBALL_SPEED_X;
		vy = vx;
		break;
	case OperationArea::TOP_RIGHT_FAR:
		vx = PIRANHA_FIREBALL_SPEED_X;
		vy = -vx / 2.8f;
		break;
	case OperationArea::TOP_RIGHT_NEAR:
		vx = PIRANHA_FIREBALL_SPEED_X;
		vy = -vx;
		break;
	case OperationArea::BOTTOM_LEFT_FAR:
		vx = -PIRANHA_FIREBALL_SPEED_X;
		vy = -vx / 2.8f;
		break;
	case OperationArea::BOTTOM_LEFT_NEAR:
		vx = -PIRANHA_FIREBALL_SPEED_X;
		vy = -vx;
		break;
	case OperationArea::BOTTOM_RIGHT_FAR:
		vx = PIRANHA_FIREBALL_SPEED_X;
		vy = vx / 2.8f;
		break;
	case OperationArea::BOTTOM_RIGHT_NEAR:
		vx = PIRANHA_FIREBALL_SPEED_X;
		vy = vx;
		break;
	}
}

void CPiranhaFireball::CreateFireballs()
{
	CHitEffect* effect = new CHitEffect({ x, y }, nx);
	listEffect.push_back(effect);
}
