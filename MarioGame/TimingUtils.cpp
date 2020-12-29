#include "TimingUtils.h"

CTimingUtils::CTimingUtils(ULONGLONG limitedTime)
{
	startTime = 0;
	this->limitedTime = limitedTime;
}

void CTimingUtils::Start()
{
	startTime = GetTickCount64();
}

void CTimingUtils::Stop()
{
	startTime = 0;
}

bool CTimingUtils::IsTimeUp()
{
	return (startTime && GetTickCount64() - startTime > limitedTime);
}

bool CTimingUtils::IsStopped()
{
	return startTime == 0;
}

ULONGLONG CTimingUtils::GetElapsedTime()
{
	return GetTickCount64() - startTime;
}

CTimingUtils::~CTimingUtils()
{
}
