#pragma once
#include "Windows.h"
class CTimingUtils
{
	ULONGLONG startTime, limitedTime;
public:
	CTimingUtils(ULONGLONG limitedTime);

	void Start();
	void Stop();
	bool IsTimeUp();
	bool IsStopped();
	ULONGLONG GetElapsedTime();

	~CTimingUtils();
};