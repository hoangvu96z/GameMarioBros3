#include "NonFirePiranha.h"
#include "FirePiranha.h"

CNonFirePiranha::CNonFirePiranha(CMario* mario)
{
	category = ObjectCategory::ENEMY;
	player = mario;
	SetState(FIRE_PIRANHA_STATE_MOVE_UP);
}

void CNonFirePiranha::Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects)
{
	CGameObject::Update(dt);
	y += dy;

	if (effect)
		effect->Update(dt, coObjects);

	if (deadTime->IsTimeUp())
		isFinishedUsing = true;

	if (attackTime->IsStopped() && y <= NON_FIRE_PIRANHA_MIN_Y)
	{
		y = NON_FIRE_PIRANHA_MIN_Y;
		vy = 0;
		attackTime->Start();
	}
	else if (sleepTime->IsStopped() && y >= NON_FIRE_PIRANHA_MAX_Y)
	{
		y = NON_FIRE_PIRANHA_MAX_Y;
		vy = 0;
		sleepTime->Start();
	}

	if (attackTime->IsTimeUp())
	{
		attackTime->Stop();
		SetState(NON_FIRE_PIRANHA_STATE_MOVE_DOWN);
	}

	if (sleepTime->IsTimeUp())
	{
		player->GetBoundingBox(playerLeft, playerTop, playerRight, playerBottom);

		if (!CheckPlayerInSafeZone(playerLeft, playerTop, playerRight, playerBottom))
		{
			sleepTime->Stop();
			SetState(NON_FIRE_PIRANHA_STATE_MOVE_UP);
		}
	}
}

void CNonFirePiranha::Render()
{
	if (!vanish)
		animation_set->at(0)->Render(x, y);

	if (effect)
		effect->Render();

	//RenderBoundingBox();
}

void CNonFirePiranha::GetBoundingBox(float& l, float& t, float& r, float& b)
{
	if (vanish)
		return;

	l = x;
	t = y;
	r = x + NON_FIRE_PIRANHA_BBOX_WIDTH;
	b = y + NON_FIRE_PIRANHA_BBOX_HEIGHT;
}

void CNonFirePiranha::SetState(int state)
{
	CGameObject::SetState(state);
	switch (state)
	{
	case NON_FIRE_PIRANHA_STATE_MOVE_UP:
		vy = -NON_FIRE_PIRANHA_MOVE_SPEED_Y;
		break;
	case NON_FIRE_PIRANHA_STATE_MOVE_DOWN:
		vy = NON_FIRE_PIRANHA_MOVE_SPEED_Y;
		break;
	case ENEMY_STATE_DIE_BY_WEAPON:
		effect = new CMoneyEffect({ x + 3, y - 7 });
		vanish = true;
		deadTime->Start();
		break;
	}
}

bool CNonFirePiranha::CheckPlayerInSafeZone(float pl, float pt, float pr, float pb)
{
	return (pl < NON_FIRE_PIRANHA_SAFE_ZONE_RIGHT
		&& pr > NON_FIRE_PIRANHA_SAFE_ZONE_LEFT
		&& pt < NON_FIRE_PIRANHA_SAFE_ZONE_BOTTOM
		&& pb > 0);
}
