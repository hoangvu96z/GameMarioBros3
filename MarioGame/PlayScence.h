#pragma once
#include "Game.h"
#include "Scence.h"
#include "GameObject.h"
#include "Portal.h"
#include "SecretBrick.h"
#include "BronzeBrick.h"
#include "Mario.h"
#include "Goomba.h"
#include "Koopas.h"
#include "TileMap.h"
#include "FirePiranha.h"
#include "NonFirePiranha.h"
#include "SuperLeaf.h"
#include "IceFlower.h"
#include "CoinEffect.h"
#include "P_Switch.h"
#include "StatusBar.h"
#include "Camera.h"
#include "BigBox.h"


class CPlayScene : public CScene
{
protected:
	CMario* player;					// A play scene has to have player, right? 
	TileMap* map;
	Camera* cam;
	CStatusBar* HUD;
	int worldID = 1;

	vector<LPGAMEOBJECT> objects;
	vector<LPGAMEOBJECT> listBronzeBricks;
	vector<LPGAMEOBJECT> listItems;
	vector<LPGAMEOBJECT> priorityListItems;
	vector<LPGAMEOBJECT> listPipes;

	double colorSubtrahend;
	int alpha = 0;
	//bool darkeningIsDone = false;
	bool lighteningIsDone = false;

	void _ParseSection_TEXTURES(string line);
	void _ParseSection_SPRITES(string line);
	void _ParseSection_ANIMATIONS(string line);
	void _ParseSection_ANIMATION_SETS(string line);
	void _ParseSection_OBJECTS(string line);
	void _ParseSection_TileMap(string line);


public:
	CPlayScene(int id, LPCWSTR filePath);

	virtual void Load();
	virtual void Update(ULONGLONG dt);
	virtual void Render();
	virtual void Unload();

	void DropItem(int itemType, float x, float y);
	void DarkenTheScreen(CMario* player, Camera* cam);
	void LightenTheScreen(CMario* player);

	CMario* GetPlayer() { return player; }

	//friend class CPlayScenceKeyHandler;
};

class CPlaySceneKeyHandler : public CSceneKeyHandler
{
public:
	virtual void KeyState(BYTE* states);
	virtual void OnKeyDown(int KeyCode);
	virtual void OnKeyUp(int KeyCode);
	CPlaySceneKeyHandler(CScene* s) :CSceneKeyHandler(s) {};
};

