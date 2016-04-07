package cn.leanpro.TestSuiteBase;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.remote.DesiredCapabilities;

public class WebdriverThread {

	private WebDriver driver;
	
	private DriverType selectedDriverType;
	
	private final DriverType defaultDriverType = DriverType.FIREFOX;
	private final String browser = 
			System.getProperty("browser").toUpperCase();
	private final String operatingSystem = 
			System.getProperty("os.name").toUpperCase();
	private final String systemArchitecture = 
			System.getProperty("os.arch");
	
	public WebDriver getDriver() {
		if (null == driver){
			selectedDriverType = determineEffectiveDriverType();
			DesiredCapabilities desiredcapabilites = selectedDriverType.getDesiredCapabilites();
			instantiateWebDriver(desiredcapabilites);
		}
		return driver;
	}
	
	
	public DriverType determineEffectiveDriverType(){
		DriverType driverType = defaultDriverType;
		try {
			driverType = DriverType.valueOf(browser);
		} catch (IllegalArgumentException ignored) {
			System.err.println("Unknown driver specified, defaulting to '" + driverType + "'...");
		} catch (NullPointerException ignored) {
			System.err.println("No driver specified, defaulting to '" + driverType + "'...");
		}
		return driverType;
	}
	
	public void instantiateWebDriver(DesiredCapabilities desiredcapabilites){
		driver = selectedDriverType.getWebdriverObject(desiredcapabilites);
	}
}
