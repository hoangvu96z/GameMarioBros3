#include <algorithm>
#include <assert.h>
#include "Utils.h"

#include "Mario.h"
#include "Game.h"

#include "Goomba.h"
#include "Portal.h"

CMario::CMario(float x, float y) : CGameObject()
{
	level = MARIO_LEVEL_SMALL;
	untouchable = 0;
	SetState(MARIO_STATE_IDLE);
	isOnGround = true;

	start_x = x; 
	start_y = y; 
	this->x = x; 
	this->y = y; 
}

void CMario::Update(DWORD dt, vector<LPGAMEOBJECT> *coObjects)
{
	// Calculate dx, dy 
	CGameObject::Update(dt);

	if (attackStartTime && GetTickCount() - attackStartTime < 375)
		SetState(MARIO_STATE_ATTACK);
	else
		attackStartTime = 0;

	if (waggingTailStartTime && GetTickCount() - waggingTailStartTime < 150)
		SetState(MARIO_STATE_JUMP_HIGH);
	else
	{
		waggingTailStartTime = 0;
		isWaggingTail = false;
	}

	// Simple fall down
	vy += MARIO_GRAVITY * dt;

	vector<LPCOLLISIONEVENT> coEvents;
	vector<LPCOLLISIONEVENT> coEventsResult;

	coEvents.clear();

	// turn off collision when die 
	if (state != MARIO_STATE_DIE)
		CalcPotentialCollisions(coObjects, coEvents);

	// reset untouchable timer if untouchable time has passed
	if (GetTickCount() - untouchable_start > MARIO_UNTOUCHABLE_TIME)
	{
		untouchable_start = 0;
		untouchable = 0;
	}

	if (isWaitingForAni && animation_set->at(aniId)->IsOver())
	{
		isWaitingForAni = false;
	}
	if (coEvents.size() == 0)
	{
		x += dx;
		y += dy;
		if (y > last_y)
		{
			isFalling = true;
			isOnGround = false;
		}
		else
			isFalling = false;
	}
	else
	{
		float min_tx, min_ty, nx = 0, ny;
		float rdx = 0;
		float rdy = 0;

		// TODO: This is a very ugly designed function!!!!
		FilterCollision(coEvents, coEventsResult, min_tx, min_ty, nx, ny, rdx, rdy);

		// how to push back Mario if collides with a moving objects, what if Mario is pushed this way into another object?
		//if (rdx != 0 && rdx!=dx)
		//	x += nx*abs(rdx); 

		// block every object first!
		x += min_tx * dx + nx * 0.4f;
		y += min_ty * dy + ny * 0.1f;
		if (nx != 0)
		{
			vx = last_vx;
			if (isSpeedingUp)
				vx = 0;
		}

		if (ny != 0)
		{
			if (ny < 0)
			{
				isFalling = false;
				isOnGround = true;
			}
			vy = 0;
		}

		//
		// Collision logic with other objects
		//
		for (UINT i = 0; i < coEventsResult.size(); i++)
		{
			LPCOLLISIONEVENT e = coEventsResult[i];

			if (dynamic_cast<CGoomba *>(e->obj)) // if e->obj is Goomba 
			{
				CGoomba* goomba = dynamic_cast<CGoomba *>(e->obj);

				// jump on top >> kill Goomba and deflect a bit 
				if (e->ny < 0)
				{
					if (goomba->GetState()!= GOOMBA_STATE_DIE)
					{
						goomba->SetState(GOOMBA_STATE_DIE);
						vy = -MARIO_JUMP_DEFLECT_SPEED;
					}
				}
				else if (e->nx != 0)
				{
					if (untouchable==0)
					{
						if (goomba->GetState()!=GOOMBA_STATE_DIE)
						{
							if (level > MARIO_LEVEL_SMALL)
							{
								level = MARIO_LEVEL_SMALL;
								StartUntouchable();
							}
							else
								SetState(MARIO_STATE_DIE);
						}
					}
				}
			}
		}
	}

	last_y = y;
	// clean up collision events
	for (UINT i = 0; i < coEvents.size(); i++) delete coEvents[i];
}

void CMario::Render()
{
	if (state == MARIO_STATE_DIE)
		aniId = MARIO_ANI_DIE;
	else if (level == MARIO_LEVEL_BIG)
	{
		switch (state)
		{
		case MARIO_STATE_DIE:
			aniId = MARIO_ANI_DIE;
			break;
		case MARIO_STATE_STOP:
			if (!isOnGround)
				goto CASE_BIG_IS_FALLING;
			if (nx > 0)
				aniId = MARIO_ANI_BIG_STOP_RIGHT;
			else
				aniId = MARIO_ANI_BIG_STOP_LEFT;
			break;

		case MARIO_STATE_WALKING_RIGHT:
			if (isSitting && !isOnGround)
				goto CASE_BIG_IS_SITTING;
			if (!isOnGround)
				goto CASE_BIG_IS_FALLING;
			aniId = MARIO_ANI_BIG_WALKING_RIGHT;
			break;

		case MARIO_STATE_WALKING_LEFT:
			if (isSitting && !isOnGround)
				goto CASE_BIG_IS_SITTING;
			if (!isOnGround)
				goto CASE_BIG_IS_FALLING;
			aniId = MARIO_ANI_BIG_WALKING_LEFT;
			break;

		case MARIO_STATE_RUNNING_RIGHT:
			if (isSitting)
				goto CASE_BIG_IS_SITTING;
			if (!isOnGround)
				goto CASE_BIG_IS_FALLING;
			if (vx < MARIO_RUNNING_SPEED)
				aniId = MARIO_ANI_BIG_WALKING_RIGHT;
			else
				aniId = MARIO_ANI_BIG_RUNNING_RIGHT;
			break;

		case MARIO_STATE_RUNNING_LEFT:
			if (isSitting)
				goto CASE_BIG_IS_SITTING;
			if (!isOnGround)
				goto CASE_BIG_IS_FALLING;
			if (vx > -MARIO_RUNNING_SPEED)
				aniId = MARIO_ANI_BIG_WALKING_LEFT;
			else
				aniId = MARIO_ANI_BIG_RUNNING_LEFT;
			break;

		case MARIO_STATE_JUMP_HIGH:
		case MARIO_STATE_JUMP_LOW:
			if (isSitting)
				goto CASE_BIG_IS_SITTING;
			if (isOnGround)
				goto CASE_BIG_IS_IDLING;
			if (vy < 0)
			{
				if (nx > 0)
					aniId = MARIO_ANI_BIG_JUMP_RIGHT;
				else
					aniId = MARIO_ANI_BIG_JUMP_LEFT;
			}
			else
			{
				if (nx > 0)
					aniId = MARIO_ANI_BIG_FALLING_RIGHT;
				else
					aniId = MARIO_ANI_BIG_FALLING_LEFT;
			}
			break;

		CASE_BIG_IS_SITTING:
		case MARIO_STATE_SIT_DOWN:
			if (nx > 0)
				aniId = MARIO_ANI_BIG_SITTING_RIGHT;
			else
				aniId = MARIO_ANI_BIG_SITTING_LEFT;
			break;

		CASE_BIG_IS_IDLING:
		case MARIO_STATE_IDLE:
			if (!isOnGround)
				goto CASE_BIG_IS_FALLING;
			if (vx > 0)
			{
				aniId = MARIO_ANI_BIG_WALKING_RIGHT;
			}
			else if (vx < 0)
			{
				aniId = MARIO_ANI_BIG_WALKING_LEFT;
			}
			else
			{
				if (nx > 0)
					aniId = MARIO_ANI_BIG_IDLE_RIGHT;
				else
					aniId = MARIO_ANI_BIG_IDLE_LEFT;
			}
			break;

		CASE_BIG_IS_FALLING:
		default:
			if (nx > 0)
				aniId = MARIO_ANI_BIG_FALLING_RIGHT;
			else
				aniId = MARIO_ANI_BIG_FALLING_LEFT;
		}
	}
	else if (level == MARIO_LEVEL_SMALL)
	{
		if (vx == 0)
		{
			if (nx>0) aniId = MARIO_ANI_SMALL_IDLE_RIGHT;
			else aniId = MARIO_ANI_SMALL_IDLE_LEFT;
		}
		else if (vx > 0)
			aniId = MARIO_ANI_SMALL_WALKING_RIGHT;
		else aniId = MARIO_ANI_SMALL_WALKING_LEFT;
	}

	int alpha = 255;
	if (untouchable) alpha = 128;

	animation_set->at(aniId)->Render(x, y, alpha);

	//RenderBoundingBox();
}

void CMario::SetState(int state)
{
	CGameObject::SetState(state);
	switch (state)
	{
	case MARIO_STATE_WALKING_RIGHT:
		vx += MARIO_WALKING_ACCELERATION * dt;
		if (vx > MARIO_MAX_WALKING_SPEED)
			vx = MARIO_MAX_WALKING_SPEED;
		nx = 1;
		last_vx = vx;
		break;

	case MARIO_STATE_WALKING_LEFT:
		vx -= MARIO_WALKING_ACCELERATION * dt;
		if (vx < -MARIO_MAX_WALKING_SPEED)
			vx = -MARIO_MAX_WALKING_SPEED;
		nx = -1;
		last_vx = vx;
		break;

	case MARIO_STATE_RUNNING_RIGHT:
		DebugOut(L"set state run right\n");
		vx += MARIO_RUNNING_ACCELERATION * dt;
		if (vx >= MARIO_RUNNING_SPEED)
		{
			vx = MARIO_RUNNING_SPEED;
			canFlyUpFromGround = true;
		}
		nx = 1;
		last_vx = vx;
		break;

	case MARIO_STATE_RUNNING_LEFT:
		DebugOut(L"set state run left\n");
		vx -= MARIO_RUNNING_ACCELERATION * dt;
		if (vx <= -MARIO_RUNNING_SPEED)
		{
			vx = -MARIO_RUNNING_SPEED;
			canFlyUpFromGround = true;
		}
		nx = -1;
		last_vx = vx;
		break;
	case MARIO_STATE_FLYING:
		if (vx > 0)
		{
			vx += MARIO_WALKING_ACCELERATION * dt;
			if (vx > MARIO_MAX_WALKING_SPEED)
				vx = MARIO_MAX_WALKING_SPEED;
			vy = -(MARIO_GRAVITY + 0.002f * 4) * dt;
			if (vy <= -0.1)
			{
				vy = -0.1;
			}
		}

	case MARIO_STATE_JUMP_LOW:
		if (isOnGround)
		{
			jumpStartTime = GetTickCount();
			vy = -MARIO_LOW_JUMP_SPEED_Y;
			isOnGround = false;
		}
		if (GetTickCount() - jumpStartTime >= 100 && !isFalling)
			vy += MARIO_LOW_JUMP_GRAVITY * dt;
		break;

	case MARIO_STATE_JUMP_HIGH:
		if (isWaggingTail)
			vy = -MARIO_GRAVITY * dt / 2;
		else if (isOnGround)
		{
			vy = -MARIO_HIGH_JUMP_SPEED_Y;
			isOnGround = false;
		}
		break;

	case MARIO_STATE_ATTACK:
		break;

	case MARIO_STATE_STOP:
		if (vx > 0)
			nx = -1;
		else
			nx = 1;
		DecelerateSharply();
		break;

	case MARIO_STATE_SIT_DOWN:

	case MARIO_STATE_IDLE:
		if (vx > 0) {
			vx -= MARIO_SMALL_ACCELERATION_SUBTRAHEND * dt;
			last_vx = vx;
			if (vx < 0)
				vx = 0;
		}
		if (vx < 0) {
			vx += MARIO_SMALL_ACCELERATION_SUBTRAHEND * dt;
			last_vx = vx;
			if (vx > 0)
				vx = 0;
		}
		break;

	case MARIO_STATE_DIE:
		vy = -MARIO_DIE_DEFLECT_SPEED;
		break;
	}
}

void CMario::GetBoundingBox(float &left, float &top, float &right, float &bottom)
{
	left = x;
	top = y; 

	if (level==MARIO_LEVEL_BIG)
	{
		bottom = y + MARIO_BIG_BBOX_HEIGHT;
		if (nx > 0)
		{
			left = x + MARIO_BIG_BBOX_L;
			right = x + MARIO_BIG_BBOX_WIDTH_RIGHT;
		}
		else
		{
			left = x;
			right = x + MARIO_BIG_BBOX_WIDTH;
		}

		if (GetAniId() == MARIO_ANI_BIG_SITTING_RIGHT
			|| GetAniId() == MARIO_ANI_BIG_SITTING_LEFT)
		{
			top = y + MARIO_SIT_BBOX;
			bottom = top + MARIO_BIG_SIT_BBOX_HEIGHT;
		}
	}
	else if (level == MARIO_LEVEL_SMALL)
	{
		right = x + MARIO_SMALL_BBOX_WIDTH;
		bottom = y + MARIO_SMALL_BBOX_HEIGHT;
	}
}

/*
	Reset Mario status to the beginning state of a scene
*/
void CMario::Reset()
{
	SetState(MARIO_STATE_IDLE);
	SetLevel(MARIO_LEVEL_SMALL);
	SetPosition(start_x, start_y);
	SetSpeed(0, 0);
}


void CMario::DecelerateSharply()
{
	if (vx > 0) {
		vx -= MARIO_LARGE_ACCELERATION_SUBTRAHEND * dt;
		last_vx = vx;
		if (vx < 0)
			vx = 0;
	}
	else if (vx < 0) {
		vx += MARIO_LARGE_ACCELERATION_SUBTRAHEND * dt;
		last_vx = vx;
		if (vx > 0)
			vx = 0;
	}
}

void CMario::ChangeToBigMario()
{
	if (level == MARIO_LEVEL_BIG)
		return;
	if (level == MARIO_LEVEL_SMALL)
		y += (MARIO_SMALL_BBOX_HEIGHT - MARIO_BIG_BBOX_HEIGHT);
	SetLevel(MARIO_LEVEL_BIG);
}

void CMario::SetIdling()
{
	SetState(MARIO_STATE_IDLE);
	isSitting = false;
}

void CMario::SetSitting()
{
	SetState(MARIO_STATE_SIT_DOWN);
	isSitting = true;
}
