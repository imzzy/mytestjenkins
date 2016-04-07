package cn.leanpro.TestSuiteBase;

import java.util.Arrays;
import java.util.HashMap;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.ie.InternetExplorerDriver;
import org.openqa.selenium.remote.CapabilityType;
import org.openqa.selenium.remote.DesiredCapabilities;

public enum DriverType implements DriverSetup{


	FIREFOX{
		@Override
		public WebDriver getWebdriverObject(DesiredCapabilities desiredcapabilities) {

			return new FirefoxDriver(desiredcapabilities);
		}
		@Override
		public DesiredCapabilities getDesiredCapabilites() {

			DesiredCapabilities desiredcapabilites = DesiredCapabilities.firefox();
			
			return desiredcapabilites;
		}
	},
	
	CHROME{
		@Override
		public WebDriver getWebdriverObject(DesiredCapabilities desiredcapabilities) {

			
			return new ChromeDriver(desiredcapabilities);
		}
		@Override
		public DesiredCapabilities getDesiredCapabilites() {

			DesiredCapabilities capabilities = DesiredCapabilities.chrome();
			capabilities.setCapability("chrome.switches", Arrays.asList("--no-default-browser-check"));
			HashMap<String, String> chromePreference = new HashMap<>();
			chromePreference.put("profile.password_manager_enabled", "false");
			capabilities.setCapability("chrome.prefs", chromePreference);
			
			
			return capabilities;
		}
	},
	IE{
		@Override
		public WebDriver getWebdriverObject(DesiredCapabilities desiredcapabilities) {

			return new InternetExplorerDriver(desiredcapabilities);
		}
		@Override
		public DesiredCapabilities getDesiredCapabilites() {

			DesiredCapabilities desiredcapbilities = DesiredCapabilities.internetExplorer();
			desiredcapbilities.setCapability(CapabilityType.
					ForSeleniumServer.ENSURING_CLEAN_SESSION, true);
			desiredcapbilities.setCapability(InternetExplorerDriver.ENABLE_PERSISTENT_HOVERING, true);
			desiredcapbilities.setCapability("requireWindowFocus", true);
			
			return desiredcapbilities;
		}
	};
	
}
