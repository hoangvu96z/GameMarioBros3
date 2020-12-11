#pragma once
#include "Effect.h"
#define MONEY_EFFECT_X_AT_BRICK_ADDEND		3
#define MONEY_EFFECT_Y_AT_BRICK_SUBTRAHEND	3
#define MONEY_EFFECT_SPEED_Y				0.04f

#define MONEY_EFFECT_100	0
#define MONEY_EFFECT_200	1
#define MONEY_EFFECT_400	2
#define MONEY_EFFECT_800	3
#define MONEY_EFFECT_1000	4
#define MONEY_EFFECT_2000	5
#define MONEY_EFFECT_4000	6
#define MONEY_EFFECT_8000	7

class CMoneyEffect : public CEffect
{
public:
	CMoneyEffect(D3DXVECTOR2 position, int moneyAni = MONEY_EFFECT_100);
	void Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects);
	void Render();
	~CMoneyEffect();
};