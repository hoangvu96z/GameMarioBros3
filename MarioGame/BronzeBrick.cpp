#include "BronzeBrick.h"

CBronzeBrick::CBronzeBrick(int transformation)
{
	if (transformation == BrickTransformation::BRICK_TRANSFORM)
	{
		type = ObjectType::BRONZE_BRICK;
		category = ObjectCategory::MISC;
	}
	else if (transformation == BrickTransformation::COIN_TRANSFORM)
	{
		type = ObjectType::COIN;
		category = ObjectCategory::ITEM;
	}
	this->transformation = transformation;
}

void CBronzeBrick::Update(DWORD dt, vector<LPGAMEOBJECT>* coObjects)
{
	int num_vanishPiece = 0;

	for (LPGAMEOBJECT piece : listPiece)
	{
		piece->Update(dt, coObjects);
		if (piece->isFinishedUsing)
			num_vanishPiece++;
	}

	if (num_vanishPiece == 4)
		isFinishedUsing = true;

	if (transformationTime && GetTickCount64() - transformationTime > TRANSFORMATION_TIME)
		SetState(STATE_NORMAL);
}

void CBronzeBrick::Render()
{
	if (type == ObjectType::BRONZE_BRICK)
		aniId = BRONZE_BRICK_ANI;
	else if (type == ObjectType::COIN)
	{
		if (y > BRONZE_BRICK_HORIZONTAL_SEPARATION_LINE)
			aniId = IDLE_COIN_ANI;
		else
			aniId = ROTATING_COIN;
	}

	if (!vanish)
		animation_set->at(aniId)->Render(x, y);

	for (LPGAMEOBJECT piece : listPiece)
		piece->Render();
}

void CBronzeBrick::GetBoundingBox(float& left, float& top, float& right, float& bottom)
{
	if (vanish)
		return;
	left = x;
	top = y;
	right = x + BRICK_BBOX_SIDE_LENGTH;
	bottom = y + BRICK_BBOX_SIDE_LENGTH;
}

void CBronzeBrick::SetState(int state)
{
	CGameObject::SetState(state);

	if (state == STATE_DESTROYED)
	{
		CBrokenBrickUnit* topLeftPiece = new CBrokenBrickUnit({ x - 1, y - 2 }, -1, 2);
		CBrokenBrickUnit* topRightPiece = new CBrokenBrickUnit({ x + BRICK_BBOX_SIDE_LENGTH - BROKEN_BRICK_UNIT_WIDTH + 1, y - 2 }, 1, 2);
		CBrokenBrickUnit* bottomLeftPiece = new CBrokenBrickUnit({ x - 1, y + BRICK_BBOX_SIDE_LENGTH - BROKEN_BRICK_UNIT_HEIGHT }, -1);
		CBrokenBrickUnit* bottomRightPiece = new CBrokenBrickUnit({ x + BRICK_BBOX_SIDE_LENGTH - BROKEN_BRICK_UNIT_WIDTH + 1, y + BRICK_BBOX_SIDE_LENGTH - BROKEN_BRICK_UNIT_HEIGHT }, 1);

		listPiece = { topLeftPiece, topRightPiece, bottomLeftPiece, bottomRightPiece };
		vanish = true;
	}
	else if (state == STATE_NORMAL)
	{
		if (transformation == BrickTransformation::BRICK_TRANSFORM)
		{
			type = ObjectType::BRONZE_BRICK;
			category = ObjectCategory::MISC;
		}
		else if (transformation == BrickTransformation::COIN_TRANSFORM)
		{
			type = ObjectType::COIN;
			category = ObjectCategory::ITEM;
		}
	}
	else if (state == STATE_TRANSFORMATION)
	{
		if (transformation == BrickTransformation::BRICK_TRANSFORM)
		{
			type = ObjectType::COIN;
			category = ObjectCategory::ITEM;
		}
		else if (transformation == BrickTransformation::COIN_TRANSFORM)
		{
			type = ObjectType::BRONZE_BRICK;
			category = ObjectCategory::MISC;
		}
		transformationTime = GetTickCount64();
	}
	
}
