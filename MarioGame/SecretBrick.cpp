
#include "SecretBrick.h"

CSecretBrick::CSecretBrick(int brickType, int itemType, float originalPosY)
{
	category = ObjectCategory::MISC;
	this->brickType = brickType;
	this->itemType = itemType;
	this->originalPosY = originalPosY;
}

void CSecretBrick::SetState(int state)
{
	CGameObject::SetState(state);
	if (state == STATE_RAMMED)
	{
		if (!rammed)
			vy = -BRICK_DEFLECT_SPEED_Y;
	}
}

void CSecretBrick::Render()
{
	if (state == STATE_RAMMED) {
		aniId = NORMAL_BRICK_ANI;
	}
	else
	{
		if (brickType == TypeOfSecretBrick::QUESTION_BRICK)
			aniId = QUESTION_BRICK_ANI;
		else if (brickType == TypeOfSecretBrick::DISGUISED_BRONZE_BRICK)
			aniId = DISGUISED_BRONZE_BRICK_ANI;
	}
	animation_set->at(aniId)->Render(x, y);
}

void CSecretBrick::GetBoundingBox(float& left, float& top, float& right, float& bottom)
{
	left = x;
	top = y;
	right = x + BRICK_BBOX_SIDE_LENGTH;
	bottom = y + BRICK_BBOX_SIDE_LENGTH;
}

void CSecretBrick::Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects)
{
	CGameObject::Update(dt);

	y += dy;

	if (y < originalPosY - BRICK_BOUNCE_UP_TO)
	{
		vy = -vy;
		rammed = true;
	}

	if (rammed && y >= originalPosY)
	{
		y = originalPosY;
		vy = 0;
		isAboutToDropItem = true;
	}

}