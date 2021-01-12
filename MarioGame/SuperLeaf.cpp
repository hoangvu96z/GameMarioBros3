﻿#include "SuperLeaf.h"

CSuperLeaf::CSuperLeaf(float brickX, float brickY)
{
	type = ObjectType::SUPER_LEAF;
	category = ObjectCategory::ITEM;

	this->x = brickX;
	this->y = brickY - SUPER_LEAF_POSITION_ADJUSTMENT_NUM_Y;
	vy = -SUPER_LEAF_DEFLECT_SPEED_Y;
	minPosY = brickY - SUPER_LEAF_MAX_DISTANCE_FROM_BRICK;
	leftLimit = brickX;
	rightLimit = brickX + SUPER_LEAF_RIGHT_LIMIT_FROM_BRICK;
	this->SetAnimationSet(CAnimationSets::GetInstance()->Get(5));
}

void CSuperLeaf::Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects)
{
	if (y > CGame::GetInstance()->GetCamPosY() + SCREEN_HEIGHT / 2)
		isFinishedUsing = true;

	x += vx;
	y += vy;

	if (y <= minPosY)
		isFalling = true;

	if (isFalling)
	{
		if (x <= leftLimit)
		{
			vy = SUPER_LEAF_SPEED_Y;
			vx = 0.3 * pow(35, vy);
		}

		if (x >= rightLimit)
		{
			vy = SUPER_LEAF_SPEED_Y;
			vx = -0.3 * pow(35, vy);
		}
	}
}

void CSuperLeaf::Render()
{
	if (vx > 0)
		aniId = SUPER_LEAF_ANI_RIGHT;
	else
		aniId = SUPER_LEAF_ANI_LEFT;
	animation_set->at(aniId)->Render(x, y);
	RenderBoundingBox(2);
}

void CSuperLeaf::GetBoundingBox(float& l, float& t, float& r, float& b)
{
	l = x;
	t = y;
	r = x + SUPER_LEAF_BBOX_WIDTH;
	b = y + SUPER_LEAF_BBOX_HEIGHT;
}
