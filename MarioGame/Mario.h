
#pragma once
#include "Koopas.h"
#include "Fireball.h"
#include "HitEffect.h"
#include "Tail.h"
#include "MapPoint.h"
class CKoopas;
class CTail;

#define MARIO_WALKING_SPEED		0.15f 
//0.1f
#define MARIO_JUMP_SPEED_Y		0.5f
#define MARIO_JUMP_DEFLECT_SPEED 0.2f
#define MARIO_DIE_DEFLECT_SPEED	 0.5f
#define MARIO_RUNNING_SPEED						0.23f
#define MARIO_MAX_WALKING_SPEED					0.12f

#define MARIO_HIGH_JUMP_SPEED_Y		0.275f
#define MARIO_LOW_JUMP_SPEED_Y		0.2f
#define MARIO_JUMP_DEFLECT_SPEED	0.2f
#define MARIO_LOW_JUMP_GRAVITY		0.001f
#define MARIO_DIE_DEFLECT_SPEED		0.5f
#define MARIO_FLY_SPEED_Y			0.25f

#define MARIO_RUNNING_SPEED						0.23f
#define MARIO_MAX_WALKING_SPEED					0.12f
#define MARIO_RUNNING_ACCELERATION				0.0002f
#define MARIO_WALKING_ACCELERATION				0.00015f
#define MARIO_SMALL_ACCELERATION_SUBTRAHEND		0.00025f
#define MARIO_LARGE_ACCELERATION_SUBTRAHEND		0.0005f
#define INITIAL_LAST_Y							134.0f

// **STATE Definition
#define MARIO_STATE_IDLE			0
#define MARIO_STATE_WALKING_RIGHT	100
#define MARIO_STATE_WALKING_LEFT	200
#define MARIO_STATE_JUMP_LOW		300
#define MARIO_STATE_JUMP_HIGH		400
#define	MARIO_STATE_SIT_DOWN		500
#define MARIO_STATE_RUNNING_RIGHT	600
#define MARIO_STATE_RUNNING_LEFT	700
#define MARIO_STATE_FLYING			800
#define MARIO_STATE_STOP			900
#define MARIO_STATE_ATTACK			1000
#define MARIO_STATE_DIE				999
#define MARIO_WAG_TAIL_WHILE_FALLING		1112
#define MARIO_WALKING_WHILE_HOLDING_SHELL	1113
#define MARIO_IDLE_WHILE_HOLDING_SHELL		1114
#define MARIO_ON_AIR_WHILE_HOLDING_SHELL	1115

// **ANIMATION Definition

// - MARIO GENERAL

#define MARIO_ANI_SMALL_KICK_LEFT			70
#define MARIO_ANI_SMALL_KICK_RIGHT			69

// - MARIO BIG
#define MARIO_ANI_BIG_IDLE_RIGHT			0
#define MARIO_ANI_BIG_WALKING_RIGHT			1
#define MARIO_ANI_BIG_RUNNING_RIGHT			2
#define MARIO_ANI_BIG_JUMP_RIGHT			3
#define MARIO_ANI_BIG_SITTING_RIGHT			4
#define MARIO_ANI_BIG_STOP_RIGHT			5
#define MARIO_ANI_BIG_FALLING_RIGHT			6
#define MARIO_ANI_BIG_KICK_RIGHT			67
#define	MARIO_ANI_BIG_IDLE_HOLD_SHELL_RIGHT		75
#define	MARIO_ANI_BIG_WALKING_HOLD_SHELL_RIGHT	76
#define	MARIO_ANI_BIG_ON_AIR_HOLD_SHELL_RIGHT	77

#define MARIO_ANI_BIG_IDLE_LEFT				7
#define MARIO_ANI_BIG_WALKING_LEFT			8
#define MARIO_ANI_BIG_RUNNING_LEFT			9
#define MARIO_ANI_BIG_JUMP_LEFT				10
#define MARIO_ANI_BIG_SITTING_LEFT			11
#define MARIO_ANI_BIG_STOP_LEFT				12
#define MARIO_ANI_BIG_FALLING_LEFT			13
#define MARIO_ANI_BIG_KICK_LEFT				68
#define	MARIO_ANI_BIG_IDLE_HOLD_SHELL_LEFT		78
#define	MARIO_ANI_BIG_WALKING_HOLD_SHELL_LEFT	79
#define	MARIO_ANI_BIG_ON_AIR_HOLD_SHELL_LEFT	80

// - MARIO SMALL 

#define MARIO_ANI_SMALL_IDLE_RIGHT			14
#define MARIO_ANI_SMALL_WALKING_RIGHT		15
#define MARIO_ANI_SMALL_RUNNING_RIGHT		16
#define MARIO_ANI_SMALL_JUMP_RIGHT			17
#define MARIO_ANI_SMALL_STOP_RIGHT			18
#define MARIO_ANI_SMALL_IDLE_HOLD_SHELL_RIGHT		81
#define MARIO_ANI_SMALL_WALKING_HOLD_SHELL_RIGHT	82
#define MARIO_ANI_SMALL_ON_AIR_HOLD_SHELL_RIGHT		83

#define MARIO_ANI_SMALL_IDLE_LEFT			19
#define MARIO_ANI_SMALL_WALKING_LEFT		20
#define MARIO_ANI_SMALL_RUNNING_LEFT		21
#define MARIO_ANI_SMALL_JUMP_LEFT			22
#define MARIO_ANI_SMALL_STOP_LEFT			23
#define MARIO_ANI_SMALL_IDLE_HOLD_SHELL_LEFT		84
#define MARIO_ANI_SMALL_WALKING_HOLD_SHELL_LEFT		85
#define MARIO_ANI_SMALL_ON_AIR_HOLD_SHELL_LEFT		86

// - MARIO RACCON

#define MARIO_RACCOON_ANI_IDLE_RIGHT					24
#define MARIO_RACCOON_ANI_WALK_RIGHT					25
#define MARIO_RACCOON_ANI_RUNNING_RIGHT					26
#define MARIO_RACCOON_ANI_JUMP_RIGHT					27
#define MARIO_RACCOON_ANI_STOP_RIGHT					28
#define MARIO_RACCOON_ANI_SPIN_TAIL_IDLE_RIGHT			29
#define MARIO_RACCOON_ANI_SITTING_RIGHT					30
#define MARIO_RACCOON_ANI_FALLING_RIGHT					31
#define MARIO_RACCOON_ANI_FALLING_WAG_TAIL_RIGHT		32
#define MARIO_RACCOON_ANI_FLYING_UP_RIGHT				33
#define MARIO_RACCOON_ANI_FLYING_DOWN_RIGHT				63
#define MARIO_RACCOON_ANI_WAG_TAIL_WHILE_FLYING_RIGHT	64
#define MARIO_RACCOON_ANI_KICK_RIGHT					71
#define MARIO_RACCOON_ANI_IDLE_HOLD_SHELL_RIGHT			87
#define MARIO_RACCOON_ANI_WALKING_HOLD_SHELL_RIGHT		88
#define MARIO_RACCOON_ANI_ON_AIR_HOLD_SHELL_RIGHT		89

#define MARIO_RACCOON_ANI_IDLE_LEFT						34
#define MARIO_RACCOON_ANI_WALK_LEFT						35
#define MARIO_RACCOON_ANI_RUNNING_LEFT					36
#define MARIO_RACCOON_ANI_JUMP_LEFT						37
#define MARIO_RACCOON_ANI_STOP_LEFT						38
#define MARIO_RACCOON_ANI_SPIN_TAIL_IDLE_LEFT			39
#define MARIO_RACCOON_ANI_SITTING_LEFT					40
#define MARIO_RACCOON_ANI_FALLING_LEFT					41
#define MARIO_RACCOON_ANI_FALLING_WAG_TAIL_LEFT			42
#define MARIO_RACCOON_ANI_FLYING_UP_LEFT				43
#define MARIO_RACCOON_ANI_FLYING_DOWN_LEFT				65
#define MARIO_RACCOON_ANI_WAG_TAIL_WHILE_FLYING_LEFT	66
#define MARIO_RACCOON_ANI_KICK_LEFT						72
#define MARIO_RACCOON_ANI_IDLE_HOLD_SHELL_LEFT			90
#define MARIO_RACCOON_ANI_WALKING_HOLD_SHELL_LEFT		91
#define MARIO_RACCOON_ANI_ON_AIR_HOLD_SHELL_LEFT		92

// - MARIO FIRE

#define MARIO_FIRE_ANI_IDLE_RIGHT							44
#define MARIO_FIRE_ANI_WALK_RIGHT							45
#define MARIO_FIRE_ANI_RUNNING_RIGHT						46
#define MARIO_FIRE_ANI_JUMP_RIGHT							47
#define MARIO_FIRE_ANI_STOP_RIGHT							48
#define MARIO_FIRE_ANI_SHOOT_FIREBALL_RIGHT					49
#define MARIO_FIRE_ANI_SHOOT_FIREBALL_WHILE_JUMPING_RIGHT	50
#define MARIO_FIRE_ANI_SITTING_RIGHT						51
#define MARIO_FIRE_ANI_FALLING_RIGHT						52
#define MARIO_FIRE_ANI_KICK_RIGHT							73
#define MARIO_FIRE_ANI_IDLE_HOLD_SHELL_RIGHT				93
#define MARIO_FIRE_ANI_WALKING_HOLD_SHELL_RIGHT				94
#define MARIO_FIRE_ANI_ON_AIR_HOLD_SHELL_RIGHT				95

#define MARIO_FIRE_ANI_IDLE_LEFT							53
#define MARIO_FIRE_ANI_WALK_LEFT							54
#define MARIO_FIRE_ANI_RUNNING_LEFT							55
#define MARIO_FIRE_ANI_JUMP_LEFT							56
#define MARIO_FIRE_ANI_STOP_LEFT							57
#define MARIO_FIRE_ANI_SHOOT_FIREBALL_LEFT					58
#define MARIO_FIRE_ANI_SHOOT_FIREBALL_WHILE_JUMPING_LEFT	59
#define MARIO_FIRE_ANI_SITTING_LEFT							60
#define MARIO_FIRE_ANI_FALLING_LEFT							61
#define MARIO_FIRE_ANI_KICK_LEFT							74
#define MARIO_FIRE_ANI_IDLE_HOLD_SHELL_LEFT					96
#define MARIO_FIRE_ANI_WALKING_HOLD_SHELL_LEFT				97
#define MARIO_FIRE_ANI_ON_AIR_HOLD_SHELL_LEFT				98


#define MARIO_FIRE_BBOX_WIDTH	15
#define MARIO_FIRE_BBOX_HEIGHT	27
#define MARIO_FIRE_SIT_BBOX_HEIGHT		18


// - MARIO OTHER
#define MARIO_ANI_DIE				62
// ** LEVEL Defintion
#define	MARIO_LEVEL_SMALL	1
#define	MARIO_LEVEL_BIG		2
#define MARIO_RACCOON		3
#define MARIO_FIRE			4

// ** SIZE OF BBOX Definition

#define MARIO_BIG_BBOX_WIDTH		15
#define MARIO_BIG_BBOX_WIDTH_RIGHT	20
#define MARIO_BIG_BBOX_HEIGHT		27
#define MARIO_BIG_BBOX_L			5

#define MARIO_SMALL_BBOX_WIDTH  15
#define MARIO_SMALL_BBOX_HEIGHT 16

#define MARIO_RACCOON_BBOX_WIDTH 15
#define MARIO_RACCOON_BBOX_HEIGHT 28
#define MARIO_RACCOON_BBOX_SIT	9
#define MARIO_RACCOON_BBOX_WIDTH_RIGHT	15
#define MARIO_RACCOON_BBOX_LEFT 7

#define MARIO_SIT_BBOX					9
#define MARIO_BIG_SIT_BBOX_HEIGHT		18
#define MARIO_RACCOON_SIT_BBOX_HEIGHT	19

// ** OTHER Definition

#define MARIO_UNTOUCHABLE_TIME 1000
#define	MARIO_WAGGING_TAIL_TIME			150
#define	MARIO_SPINNING_TAIL_TIME		375
#define	MARIO_SHOOTING_FIREBALL_TIME	375
#define MARIO_KICK_TIME					200
#define MARIO_KICK						1100
#define MARIO_FLY_GRAVITY			0.00035f


#define MARIO_RUNNING_SPEED						0.23f
#define MARIO_MAX_WALKING_SPEED					0.12f
#define MARIO_RUNNING_ACCELERATION				0.00015f
#define MARIO_WALKING_ACCELERATION				0.00015f
#define MARIO_SMALL_ACCELERATION_SUBTRAHEND		0.00025f
#define MARIO_LARGE_ACCELERATION_SUBTRAHEND		0.0005f
#define MARIO_LARGEST_ACCELERATION_SUBTRAHEND	0.0008f
#define INITIAL_LAST_Y							134.0f

#define MARIO_READY_TO_OUT_OF_PIPE_POS_Y		466.0f
#define MARIO_READY_TO_OUT_OF_PIPE_POS_X		2095.0f
#define MARIO_UNDER_TOP_OF_PIPE					112.0f
#define MARIO_UNDER_END_OF_PIPE					490.0f // 496.0f
#define MARIO_AT_HIDDEN_AREA_ENTRANCE			111
#define MARIO_GO_INTO_PIPE_SPEED_Y				0.03f
#define MARIO_OUT_OF_PIPE_SPEED_Y				0.08f
#define MARIO_READY_TO_OUT_OF_HIDDEN_AREA_POS_Y	383.0f
#define MARIO_READY_TO_OUT_OF_HIDDEN_AREA_POS_X	2319.0f

// Mario time limit
#define	MARIO_WAGGING_TAIL_TIME			150
#define	MARIO_SPINNING_TAIL_TIME		375
#define	MARIO_SHOOTING_FIREBALL_TIME	300
#define MARIO_FLYING_TIME				5000
#define MARIO_KICK_TIME					200
#define MARIO_LOW_JUMP_TIME				100

#define MARIO_HIGH_JUMP_SPEED_Y		0.275f
#define MARIO_LOW_JUMP_SPEED_Y		0.2f
#define MARIO_JUMP_DEFLECT_SPEED	0.1f
#define MARIO_GRAVITY				0.0006f
#define MARIO_LOW_JUMP_GRAVITY		0.001f
#define MARIO_FLY_GRAVITY			0.00035f
#define MARIO_DIE_DEFLECT_SPEED		0.5f
#define MARIO_FLY_SPEED_Y			0.25f

#define MARIO_SPEED_ON_MAP	0.05f

#define MARIO_STATE_IDLE			0
#define MARIO_STATE_WALKING_RIGHT	100
#define MARIO_STATE_WALKING_LEFT	200
#define MARIO_STATE_JUMP_LOW		300
#define MARIO_STATE_JUMP_HIGH		400
#define	MARIO_STATE_SIT_DOWN		500
#define MARIO_STATE_RUNNING_RIGHT	600
#define MARIO_STATE_RUNNING_LEFT	700
#define MARIO_STATE_FLYING			800
#define MARIO_STATE_STOP			900
#define MARIO_STATE_ATTACK			1000
#define MARIO_STATE_GO_INTO_PIPE	1100
#define MARIO_STATE_OUT_OF_PIPE		1200
//#define MARIO_STATE_GO_LEFT_ON_MAP	1300
//#define MARIO_STATE_GO_RIGHT_ON_MAP	1400
//#define MARIO_STATE_GO_UP_ON_MAP	1500
//#define MARIO_STATE_GO_DOWN_ON_MAP	1600

#define MARIO_KICK							1111
#define MARIO_WAG_TAIL_WHILE_FALLING		1112
#define MARIO_WALKING_WHILE_HOLDING_SHELL	1113
#define MARIO_IDLE_WHILE_HOLDING_SHELL		1114
#define MARIO_ON_AIR_WHILE_HOLDING_SHELL	1115

#define MARIO_STATE_DIE				999

#define MARIO_ANI_BIG_IDLE_RIGHT				0
#define MARIO_ANI_BIG_WALKING_RIGHT				1
#define MARIO_ANI_BIG_RUNNING_RIGHT				2
#define MARIO_ANI_BIG_JUMP_RIGHT				3
#define MARIO_ANI_BIG_SITTING_RIGHT				4
#define MARIO_ANI_BIG_STOP_RIGHT				5
#define MARIO_ANI_BIG_FALLING_RIGHT				6
#define MARIO_ANI_BIG_KICK_RIGHT				67
#define	MARIO_ANI_BIG_IDLE_HOLD_SHELL_RIGHT		75
#define	MARIO_ANI_BIG_WALKING_HOLD_SHELL_RIGHT	76
#define	MARIO_ANI_BIG_ON_AIR_HOLD_SHELL_RIGHT	77

#define MARIO_ANI_BIG_IDLE_LEFT					7
#define MARIO_ANI_BIG_WALKING_LEFT				8
#define MARIO_ANI_BIG_RUNNING_LEFT				9
#define MARIO_ANI_BIG_JUMP_LEFT					10
#define MARIO_ANI_BIG_SITTING_LEFT				11
#define MARIO_ANI_BIG_STOP_LEFT					12
#define MARIO_ANI_BIG_FALLING_LEFT				13
#define MARIO_ANI_BIG_KICK_LEFT					68
#define	MARIO_ANI_BIG_IDLE_HOLD_SHELL_LEFT		78
#define	MARIO_ANI_BIG_WALKING_HOLD_SHELL_LEFT	79
#define	MARIO_ANI_BIG_ON_AIR_HOLD_SHELL_LEFT	80

#define MARIO_ANI_SMALL_IDLE_RIGHT					14
#define MARIO_ANI_SMALL_WALKING_RIGHT				15
#define MARIO_ANI_SMALL_RUNNING_RIGHT				16
#define MARIO_ANI_SMALL_JUMP_RIGHT					17
#define MARIO_ANI_SMALL_STOP_RIGHT					18
#define MARIO_ANI_SMALL_KICK_RIGHT					69
#define MARIO_ANI_SMALL_IDLE_HOLD_SHELL_RIGHT		81
#define MARIO_ANI_SMALL_WALKING_HOLD_SHELL_RIGHT	82
#define MARIO_ANI_SMALL_ON_AIR_HOLD_SHELL_RIGHT		83

#define MARIO_ANI_SMALL_IDLE_LEFT					19
#define MARIO_ANI_SMALL_WALKING_LEFT				20
#define MARIO_ANI_SMALL_RUNNING_LEFT				21
#define MARIO_ANI_SMALL_JUMP_LEFT					22
#define MARIO_ANI_SMALL_STOP_LEFT					23
#define MARIO_ANI_SMALL_KICK_LEFT					70
#define MARIO_ANI_SMALL_IDLE_HOLD_SHELL_LEFT		84
#define MARIO_ANI_SMALL_WALKING_HOLD_SHELL_LEFT		85
#define MARIO_ANI_SMALL_ON_AIR_HOLD_SHELL_LEFT		86

#define MARIO_RACCOON_ANI_IDLE_RIGHT					24
#define MARIO_RACCOON_ANI_WALK_RIGHT					25
#define MARIO_RACCOON_ANI_RUNNING_RIGHT					26
#define MARIO_RACCOON_ANI_JUMP_RIGHT					27
#define MARIO_RACCOON_ANI_STOP_RIGHT					28
#define MARIO_RACCOON_ANI_SPIN_TAIL_IDLE_RIGHT			29
#define MARIO_RACCOON_ANI_SITTING_RIGHT					30
#define MARIO_RACCOON_ANI_FALLING_RIGHT					31
#define MARIO_RACCOON_ANI_FALLING_WAG_TAIL_RIGHT		32
#define MARIO_RACCOON_ANI_FLYING_UP_RIGHT				33
#define MARIO_RACCOON_ANI_FLYING_DOWN_RIGHT				63
#define MARIO_RACCOON_ANI_WAG_TAIL_WHILE_FLYING_RIGHT	64
#define MARIO_RACCOON_ANI_KICK_RIGHT					71
#define MARIO_RACCOON_ANI_IDLE_HOLD_SHELL_RIGHT			87
#define MARIO_RACCOON_ANI_WALKING_HOLD_SHELL_RIGHT		88
#define MARIO_RACCOON_ANI_ON_AIR_HOLD_SHELL_RIGHT		89

#define MARIO_RACCOON_ANI_IDLE_LEFT						34
#define MARIO_RACCOON_ANI_WALK_LEFT						35
#define MARIO_RACCOON_ANI_RUNNING_LEFT					36
#define MARIO_RACCOON_ANI_JUMP_LEFT						37
#define MARIO_RACCOON_ANI_STOP_LEFT						38
#define MARIO_RACCOON_ANI_SPIN_TAIL_IDLE_LEFT			39			
#define MARIO_RACCOON_ANI_SITTING_LEFT					40
#define MARIO_RACCOON_ANI_FALLING_LEFT					41
#define MARIO_RACCOON_ANI_FALLING_WAG_TAIL_LEFT			42
#define MARIO_RACCOON_ANI_FLYING_UP_LEFT				43
#define MARIO_RACCOON_ANI_FLYING_DOWN_LEFT				65
#define MARIO_RACCOON_ANI_WAG_TAIL_WHILE_FLYING_LEFT	66
#define MARIO_RACCOON_ANI_KICK_LEFT						72
#define MARIO_RACCOON_ANI_IDLE_HOLD_SHELL_LEFT			90
#define MARIO_RACCOON_ANI_WALKING_HOLD_SHELL_LEFT		91
#define MARIO_RACCOON_ANI_ON_AIR_HOLD_SHELL_LEFT		92

#define MARIO_RACCOON_ANI_GO_PIPE						99

#define MARIO_FIRE_ANI_IDLE_RIGHT							44
#define MARIO_FIRE_ANI_WALK_RIGHT							45
#define MARIO_FIRE_ANI_RUNNING_RIGHT						46
#define MARIO_FIRE_ANI_JUMP_RIGHT							47
#define MARIO_FIRE_ANI_STOP_RIGHT							48
#define MARIO_FIRE_ANI_SHOOT_FIREBALL_RIGHT					49
#define MARIO_FIRE_ANI_SHOOT_FIREBALL_WHILE_JUMPING_RIGHT	50
#define MARIO_FIRE_ANI_SITTING_RIGHT						51
#define MARIO_FIRE_ANI_FALLING_RIGHT						52
#define MARIO_FIRE_ANI_KICK_RIGHT							73
#define MARIO_FIRE_ANI_IDLE_HOLD_SHELL_RIGHT				93
#define MARIO_FIRE_ANI_WALKING_HOLD_SHELL_RIGHT				94
#define MARIO_FIRE_ANI_ON_AIR_HOLD_SHELL_RIGHT				95

#define MARIO_FIRE_ANI_IDLE_LEFT							53
#define MARIO_FIRE_ANI_WALK_LEFT							54
#define MARIO_FIRE_ANI_RUNNING_LEFT							55
#define MARIO_FIRE_ANI_JUMP_LEFT							56
#define MARIO_FIRE_ANI_STOP_LEFT							57
#define MARIO_FIRE_ANI_SHOOT_FIREBALL_LEFT					58
#define MARIO_FIRE_ANI_SHOOT_FIREBALL_WHILE_JUMPING_LEFT	59
#define MARIO_FIRE_ANI_SITTING_LEFT							60
#define MARIO_FIRE_ANI_FALLING_LEFT							61
#define MARIO_FIRE_ANI_KICK_LEFT							74
#define MARIO_FIRE_ANI_IDLE_HOLD_SHELL_LEFT					96
#define MARIO_FIRE_ANI_WALKING_HOLD_SHELL_LEFT				97
#define MARIO_FIRE_ANI_ON_AIR_HOLD_SHELL_LEFT				98

#define MARIO_ANI_DIE		62

#define MARIO_ON_OVERWORLD_MAP_ANI_SMALL	0
#define MARIO_ON_OVERWORLD_MAP_ANI_BIG		1
#define MARIO_ON_OVERWORLD_MAP_ANI_RACCOON	2
#define MARIO_ON_OVERWORLD_MAP_ANI_FIRE		3

#define MARIO_ON_OVERWORLD_MAP_SMALL_BBOX_ADDEND	1
#define MARIO_ON_OVERWORLD_MAP_BIG_BBOX_ADDEND		5
#define MARIO_ON_OVERWORLD_MAP_RACCOON_BBOX_ADDEND	8
#define MARIO_ON_OVERWORLD_MAP_BBOX_SIDE_LENGTH		16

#define	MARIO_LEVEL_SMALL	1
#define	MARIO_LEVEL_BIG		2
#define MARIO_RACCOON		3
#define MARIO_FIRE			4

#define MARIO_BBOX_HEIGHT				30
#define MARIO_SIT_BBOX_DIFFERENCE_NUM	12

#define MARIO_BIG_BBOX_WIDTH			15
#define MARIO_BIG_TOP_ADDEND			3
#define MARIO_BIG_LEFT_SUBTRAHEND_R		10
#define MARIO_BIG_LEFT_SUBTRAHEND_L		9

#define MARIO_SMALL_BBOX_WIDTH			14
#define MARIO_SMALL_TOP_ADDEND			14
#define MARIO_SMALL_LEFT_SUBTRAHEND_R	11
#define MARIO_SMALL_LEFT_SUBTRAHEND_L	9

#define MARIO_RACCOON_BBOX_WIDTH		15
#define MARIO_RACCOON_TOP_ADDEND		2
#define MARIO_RACCOON_LEFT_SUBTRAHEND_R	10
#define MARIO_RACCOON_LEFT_SUBTRAHEND_L	8

#define MARIO_UNTOUCHABLE_TIME 2000


class CMario : public CGameObject
{
	static CMario* __instance;

	int level;
	int untouchable;
	ULONGLONG untouchable_start;

	float start_x;			// initial position of Mario at scene
	float start_y;
public:
	vector<LPGAMEOBJECT> listWeapon;
	vector<LPGAMEOBJECT> listEffect;

	CTail* tail = new CTail();

	ULONGLONG attackStartTime;
	ULONGLONG waggingTailStartTime;

	CTimingUtils* jumpTime = new CTimingUtils(MARIO_LOW_JUMP_TIME);
	CTimingUtils* flyTime = new CTimingUtils(MARIO_FLYING_TIME);
	CTimingUtils* kickTime = new CTimingUtils(MARIO_KICK_TIME);
	//CTimingUtils* stopTime = new CTimingUtils(200);

	int score = 0;
	int money = 0;
	int lives = INITIAL_PLAYER_LIVES;
	vector<ItemOfBox> itemsPickedUp;

	CMapPoint* currentPoint = new CMapPoint(START_POINT_X, START_POINT_Y, 1, 0, 1, 0, 0);
	CMapPoint* nextPoint = new CMapPoint(64, 48, 0, 1, 0, 1, 0);

	int GetScore() { return score; }
	int GetMoney() { return money; }
	int GetLives() { return lives; }

	bool isFalling, isSitting, isWaggingTail, isFlying, isAttacking, isRunning, isStopping;
	bool kickShell;
	bool isHoldingShell;
	bool canFly; // only for Raccoon
	bool grounded;
	bool isOnGround = true;
	bool immovable;
	bool unpressDown;
	bool onPressUp;
	bool renderBBOX;
	bool autoGoRight;
	bool inStartOfPipe;
	bool inEndOfPipe;
	bool readyToOutOfPipe;
	bool goHiddenArea;
	bool leaveHiddenArea;
	bool screenDim;
	bool onOverworldMap = true;
	bool isWaitingForAni;

	vector<bool> movementPermission{ 0, 1, 0, 0 };

	float last_y = INITIAL_LAST_Y;
	float last_vx;
	float last_vy;
	float y_when_started_to_jump;

	CMario(float x = 0.0f, float y = 0.0f);
	void UpdateAtOverworldMap(ULONGLONG dt, vector<LPGAMEOBJECT>* coPoints = NULL);
	void RenderAtOverworldMap();
	virtual void Update(ULONGLONG dt, vector<LPGAMEOBJECT>* colliable_objects = NULL);
	virtual void Render();

	static CMario* GetInstance();

	void SetState(int state);
	void SetLevel(int l) { level = l; }
	int GetLevel() { return level; }
	int GetUntouchable() { return untouchable; }
	void StartUntouchable() { untouchable = 1; untouchable_start = GetTickCount64(); }

	void Reset();
	int GetAni() { return aniId; }

	void CreateFireball();
	void WhenCollidingWithEnemy();
	void CheckCollisionWithItems(vector<LPGAMEOBJECT>* listItem);

	virtual void GetBoundingBox(float& left, float& top, float& right, float& bottom);
	float GetLeft();
	float GetTop();
	float GetBottom();

	void SetPositionAtCurrentPoint(float x, float y);

	void DecelerateSharply();
	void DecelerateSlightly();

	void Idle();
	void Sit();
	void Fly();
	void Attack();
};