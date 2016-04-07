package cn.leanpro.TestSuiteBase;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.remote.DesiredCapabilities;

public interface DriverSetup {

	
	WebDriver getWebdriverObject(DesiredCapabilities desiredcapabilities);
	DesiredCapabilities getDesiredCapabilites();
}
