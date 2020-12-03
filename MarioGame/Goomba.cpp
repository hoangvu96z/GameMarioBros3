
#include "Goomba.h"
CGoomba::CGoomba()
{
	type = GOOMBA;
	category = ENEMY;
	SetState(ENEMY_STATE_MOVE);
}

void CGoomba::GetBoundingBox(float& left, float& top, float& right, float& bottom)
{
	if (died)
		return;
	left = x;
	right = x + GOOMBA_BBOX_WIDTH;
	bottom = y + GOOMBA_BBOX_HEIGHT;

	if (state == GOOMBA_STATE_DIE_BY_KICK) 
	{
		top = y + (GOOMBA_BBOX_HEIGHT - GOOMBA_BBOX_HEIGHT_DIE_BY_KICK);
	}
	else
	{
		top = y;
	}

}

void CGoomba::Update(DWORD dt, vector<LPGAMEOBJECT>* coObjects)
{
	CGameObject::Update(dt, coObjects);
	vy += MARIO_GRAVITY * dt;

	float camPosY = CGame::GetInstance()->GetCamPosY();
	if (camPosY && y > camPosY + SCREEN_HEIGHT / 2)
		isFinishedUsing = true;

	if (deadTime && GetTickCount64() - deadTime >= GOOMBA_MAX_EXISTING_TIME_AFTER_DEATH)
	{
		isFinishedUsing = true;
	}

	vector<LPCOLLISIONEVENT> coEvents;
	vector<LPCOLLISIONEVENT> coEventsResult;

	coEvents.clear();
	CalcPotentialCollisions(coObjects, coEvents);

	if (coEvents.size() == 0)
	{
		x += dx;
		y += dy;
	}
	else
	{
		float min_tx, min_ty, nx = 0, ny = 0;
		float rdx = 0;
		float rdy = 0;

		// TODO: This is a very ugly designed function!!!!
		FilterCollision(coEvents, coEventsResult, min_tx, min_ty, nx, ny, rdx, rdy);

		// block every object first!
		y += min_ty * dy + ny * 0.4f;
		x += min_tx * dx + nx * 0.4f;

		if (ny != 0)
		{
			vy = 0;
		}
		//
		// Collision logic with other objects
		//
		for (UINT i = 0; i < coEventsResult.size(); i++)
		{
			LPCOLLISIONEVENT e = coEventsResult[i];

			if (state == ENEMY_STATE_MOVE)
			{
				if (e->obj->type == ObjectType::BIGBOX)
				{
					if (e->nx != 0)
						x += dx;
				}
				else if (e->obj->category == ObjectCategory::MISC || e->obj->category == ObjectCategory::ENEMY)
				{
					if (e->nx != 0)
					{
						vx = -vx;
					}
				}
			}
		}
	}

	for (UINT i = 0; i < coEvents.size(); i++) delete coEvents[i];
}

void CGoomba::Render()
{
	if (state == ENEMY_STATE_DIE_BY_WEAPON || state == ENEMY_STATE_ATTACKED_BY_TAIL)
		aniId = GOOMBA_ANI_DIE_BY_ATTACK_TOOL;
	else if (state == GOOMBA_STATE_DIE_BY_KICK)
		aniId = GOOMBA_ANI_DIE_BY_KICK;
	else
		aniId = GOOMBA_ANI_MOVE;

	animation_set->at(aniId)->Render(x, y);

	//RenderBoundingBox();
}

void CGoomba::SetState(int state)
{
	CGameObject::SetState(state);
	switch (state)
	{
	case ENEMY_STATE_DIE_BY_WEAPON:
		vx = GOOMBA_DEFLECT_SPEED_X * object_colliding_nx;
		vy = -GOOMBA_DEFLECT_SPEED_Y;
		died = true;
		break;
	case ENEMY_STATE_ATTACKED_BY_TAIL:
		vx = ENEMY_DEFECT_SPEED_X_CAUSED_BY_TAIL * object_colliding_nx;
		vy = -ENEMY_DEFECT_SPEED_Y_CAUSED_BY_TAIL;
		died = true;
		break;
	case ENEMY_STATE_MOVE:
		vx = -GOOMBA_MOVE_SPEED_X;
		nx = -1;
		break;
	case GOOMBA_STATE_DIE_BY_KICK:
		vx = 0;
		deadTime = GetTickCount64();
		break;
	}
}

CGoomba::~CGoomba()
{
}
