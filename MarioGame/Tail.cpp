#include "Tail.h"

void CTail::Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects)
{
	for (LPGAMEOBJECT effect : listEffect)
	{
		if (effect->isFinishedUsing)
			listEffect.erase(listEffect.begin());
	}

	for (LPGAMEOBJECT effect : listEffect)
		effect->Update(dt, coObjects);

	float ol, ot, or, ob;
	float ml, mt, mr, mb;
	GetBoundingBox(ml, mt, mr, mb);

	for (UINT i = 0; i < coObjects->size(); i++)
	{
		LPGAMEOBJECT e = coObjects->at(i);
		e->GetBoundingBox(ol, ot, or , ob);
		if (CGameObject::CheckCollisionAABB(ml, mt, mr, mb, ol, ot, or , ob))
		{
			if (e->category == ObjectCategory::ENEMY)
			{
				CreateEffect();
				e->object_colliding_nx = this->nx;
				e->SetState(ENEMY_STATE_ATTACKED_BY_TAIL);
			}
		}
	}
}

void CTail::GetBoundingBox(float& left, float& top, float& right, float& bottom)
{
	if (!appearance)
		return;
	left = x;
	right = x + TAIL_BBOX_WIDTH;
	top = y;
	bottom = y + TAIL_BBOX_HEIGHT;
}

void CTail::Render()
{
	for (LPGAMEOBJECT effect : listEffect)
		effect->Render();

	RenderBoundingBox(2);
}

void CTail::CreateEffect()
{
	CTailEffect* effect = new CTailEffect({ x, y }, nx);
	listEffect.push_back(effect);
}
