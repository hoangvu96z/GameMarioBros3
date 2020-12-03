#pragma once
#include "Effect.h"
#define	TAIL_EFFECT_TIME	100
#define	TAIL_EFFECT_WIDTH	16
#define	TAIL_EFFECT_HEIGHT	16

class CTailEffect : public CEffect
{
public:
	CTailEffect(D3DXVECTOR2 position, int nx);
	void Render();
};