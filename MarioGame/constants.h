#pragma once
enum class ObjectType
{
	PORTAL = 55,
	MARIO = 0,
	QUESTION_BRICK = 1,
	GOOMBA = 2,
	KOOPA = 3,
	PLATFORM = 4,
	BIGBOX = 5,
	FIREBALL = 7,
	TAIL = 8,
	BRONZE_BRICK = 9,
	COIN = 10
};

enum class ObjectCategory
{
	PLAYER,
	ENEMY,
	MISC,
	ITEM,
	WEAPON,
	EFFECT,
	SCENE,
};

enum ItemOfBrick
{
	ITEM_RANDOM = 0,
	ITEM_MONEY = 1
};

enum BrickTransformation
{
	BRICK_TRANSFORM = 1,
	COIN_TRANSFORM = 2
};

#define ENEMY_STATE_ATTACKED_BY_TAIL			188  // lead to die or sleep
#define ENEMY_STATE_DIE_BY_WEAPON				199
#define ENEMY_STATE_MOVE						200
#define ENEMY_STATE_IDLE						201
#define ENEMY_DEFECT_SPEED_X_CAUSED_BY_TAIL		0.035f
#define ENEMY_DEFECT_SPEED_Y_CAUSED_BY_TAIL		0.28f

#define MARIO_GRAVITY				0.0006f

#define HIT_EFFECT_TIME	150

#define ENEMY_STATE_DIE	199