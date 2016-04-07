

var replayHelper = new ActiveXObject("LeanPro.ReplayHelper")
replayHelper.LoadRepository("SeleniumModel1.json")


replayHelper.WebPage("Welcome: Mercury Tours").WebEdit("userName").TypeText("yi-bin");
replayHelper.WebPage("Welcome: Mercury Tours").WebEdit("password").TypeText("123");
replayHelper.WebPage("Welcome: Mercury Tours").WebImage("Sign-In").Click();

replayHelper.WebPage("Find a Flight: Mercury Tours:").WebList("fromPort").SelectByIndex(2);
replayHelper.WebPage("Find a Flight: Mercury Tours:").WebList("fromMonth").SelectByName("August");
//_replayHelper.WebPage("Find a Flight: Mercury Tours:").WebList("fromDay").SelectByName("25");
replayHelper.WebPage("Find a Flight: Mercury Tours:").WebRadioGroup("servClass").Select(1);
replayHelper.WebPage("Find a Flight: Mercury Tours:").WebImage("/images/forms/continue.gif").Click();


replayHelper.WebPage("Select a Flight: Mercury Tours").WebRadioGroup("outFlight").Select(2);
replayHelper.WebPage("Select a Flight: Mercury Tours").WebImage("/images/forms/continue.gif_2").Click();

