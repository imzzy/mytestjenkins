// consoleApp.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#pragma warning (disable: 4278)

// To use managed-code servers like the C# server, 
// we have to import the common language runtime:
#import <mscorlib.tlb> raw_interfaces_only

#import "..\..\..\bin\Debug\LPWebObjects.tlb" no_namespace named_guids

int _tmain(int argc, _TCHAR* argv[])
{
	 
	IReplayHelper *replayHelper = NULL;
	int retval = 1;

	// Initialize COM and create an instance of the InterfaceImplementation class:
	CoInitialize(NULL);
	HRESULT hr = CoCreateInstance(CLSID_ReplayHelper,
		NULL, CLSCTX_INPROC_SERVER,
		IID_IReplayHelper, reinterpret_cast<void**>(&replayHelper));

	if (FAILED(hr))
	{
		printf("Couldn't create the instance!... 0x%x\n", hr);
	}
	else
	{
		replayHelper->LoadRepository(L"SeleniumModel1.json");
		IWebContainer *webContianer = NULL;
		hr = replayHelper->WebPage(L"Welcome: Mercury Tours").QueryInterface(IID_IWebContainer, &webContianer);

		if (SUCCEEDED(hr))
		{
			IWebEdit *pWebEditName = NULL;
			IWebEdit *pWebEditPwd = NULL;
			IWebControl *pWebImageSignIn = NULL;
			HRESULT hr1 = webContianer->WebEdit("userName").QueryInterface(IID_IWebEdit, &pWebEditName);
			HRESULT hr2 = webContianer->WebEdit("password").QueryInterface(IID_IWebEdit, &pWebEditPwd);
			HRESULT hr3 = webContianer->WebEdit("Sign-In").QueryInterface(IID_IWebControl, &pWebImageSignIn);
			if (SUCCEEDED(hr1) && SUCCEEDED(hr2) && SUCCEEDED(hr3))
			{
				pWebEditName->TypeText(L"yi-bin");
				pWebEditPwd->TypeText(L"123");
				pWebImageSignIn->Click(-1, -1);
			}


		}

		//_replayHelper.WebPage("Welcome: Mercury Tours").WebEdit("userName").TypeText("yi-bin");
		//_replayHelper.WebPage("Welcome: Mercury Tours").WebEdit("password").TypeText("123");
		//_replayHelper.WebPage("Welcome: Mercury Tours").WebImage("Sign-In").Click();
		//System.Threading.Thread.Sleep(2000);
		//_replayHelper.WebPage("Find a Flight: Mercury Tours:").WebList("fromPort").SelectByIndex(2);
		//_replayHelper.WebPage("Find a Flight: Mercury Tours:").WebList("fromMonth").SelectByName("August");
		////_replayHelper.WebPage("Find a Flight: Mercury Tours:").WebList("fromDay").SelectByName("25");
		//_replayHelper.WebPage("Find a Flight: Mercury Tours:").WebRadioGroup("servClass").Select(1);
		//_replayHelper.WebPage("Find a Flight: Mercury Tours:").WebImage("/images/forms/continue.gif").Click();
		//System.Threading.Thread.Sleep(2000);

		//_replayHelper.WebPage("Select a Flight: Mercury Tours").WebRadioGroup("outFlight").Select(2);
		//_replayHelper.WebPage("Select a Flight: Mercury Tours").WebImage("/images/forms/continue.gif_2").Click();

		replayHelper = NULL;
	}

	CoUninitialize();

	return 0;
}

