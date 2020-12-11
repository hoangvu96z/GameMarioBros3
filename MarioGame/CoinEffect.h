#pragma once
#include "Effect.h"
#include "MoneyEffect.h"

#define COIN_EFFECT_TIME					1300
#define COIN_EFFECT_SPEED_Y					0.14f
#define COIN_EFFECT_X_ADDEND				4
#define COIN_EFFECT_Y_SUBTRAHEND			14
#define COIN_EFFECT_MIN_Y_SUBTRAHEND		65
#define COIN_EFFECT_MAX_Y_SUBTRAHEND		20

class CCoinEffect : public CEffect
{
public:
	float minPosY;
	float maxPosY;
	D3DXVECTOR2 moneyStartingPos;

	bool isFalling = false;
	bool vanish = false;

	CMoneyEffect* effect;

	CCoinEffect(float brickX, float brickY);
	void Update(ULONGLONG dt, vector<LPGAMEOBJECT>* coObjects);
	void Render();
	~CCoinEffect();
};

