#include "Koopas.h"

CKoopas::CKoopas()
{
	type = KOOPA;
	category = ENEMY;
	SetState(ENEMY_STATE_MOVE);
}

void CKoopas::GetBoundingBox(float &left, float &top, float &right, float &bottom)
{
	if (died)
		return;
	left = x;
	right = x + KOOPA_BBOX_WIDTH;
	bottom = y + KOOPA_BBOX_HEIGHT;

	if (state == ENEMY_STATE_MOVE)
		top = y;
	else
		top = y + (KOOPA_BBOX_HEIGHT - KOOPA_BBOX_HEIGHT_LAY_VIBRATE_SPIN);
}

void CKoopas::Update(DWORD dt, vector<LPGAMEOBJECT> *coObjects)
{
	CGameObject::Update(dt, coObjects);
	vy += MARIO_GRAVITY * dt;

	float camPosY = CGame::GetInstance()->GetCamPosY();
	if (camPosY && y > camPosY + SCREEN_HEIGHT / 2)
		isFinishedUsing = true;

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

			if (state == ENEMY_STATE_MOVE || state == KOOPA_STATE_SPIN_AND_MOVE)
			{
				if (e->obj->type == ObjectType::BIGBOX)
				{
					if (e->nx != 0)
						x += dx;
				}
				if (e->obj->category == ObjectCategory::MISC)
				{
					if (e->nx != 0 && e->obj->type != ObjectType::BIGBOX)
					{
						vx = -vx;
					}
					if (e->ny != 0 && state == ENEMY_STATE_MOVE && (x <= e->obj->x || x >= e->obj->x + e->obj->width - KOOPA_BBOX_WIDTH))
					{
						vx = -vx;
					}
				}
			}
		}
	}

	for (UINT i = 0; i < coEvents.size(); i++) delete coEvents[i];
}

void CKoopas::Render()
{
	if (state == ENEMY_STATE_DIE_BY_WEAPON)
		aniId = KOOPA_ANI_LAY_SUPINE;
	else if (state == KOOPA_STATE_SPIN_AND_MOVE)
		aniId = KOOPA_ANI_SPIN_AND_MOVE_PRONE;
	else if (state == ENEMY_STATE_IDLE)
		aniId = KOOPA_ANI_LAY_PRONE;
	else if (state == ENEMY_STATE_MOVE)
	{
		if (vx > 0)
			aniId = KOOPA_ANI_MOVE_RIGHT;
		else
			aniId = KOOPA_ANI_MOVE_LEFT;
	}

	animation_set->at(aniId)->Render(x, y);

	//RenderBoundingBox();
}

void CKoopas::SetState(int state)
{
	CGameObject::SetState(state);
	switch (state)
	{
	case ENEMY_STATE_DIE_BY_WEAPON:
		vx = KOOPA_DEFLECT_SPEED_X * object_colliding_nx;
		vy = -KOOPA_DEFLECT_SPEED_Y;
		died = true;
		break;
	case ENEMY_STATE_MOVE:
		vx = -KOOPA_MOVE_SPEED_X;
		break;
	case ENEMY_STATE_IDLE:
		vx = 0;
		vy = 0;
		break;
	case KOOPA_STATE_SPIN_AND_MOVE:
		vx = KOOPA_SPIN_AND_MOVE_SPEED_X * object_colliding_nx;
		break;
	}
}
