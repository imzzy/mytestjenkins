package cn.leanpro.TestSuiteBase;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.testng.annotations.AfterClass;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.BeforeMethod;

public class BaseTest {

	private WebDriver driver;

	public WebDriver getDriver() {
		System.out.println("this is getting driver....");
		return driver;
	}
	
	@BeforeClass
	public void createDriver(){
		System.out.println(" hi  creating driver....");
		driver = new FirefoxDriver();
		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
		driver.manage().window().maximize();
	}
	

	@AfterClass
	public void teardownDriver(){
		if (driver != null){
			driver.close();
		}
	}
	
	
}
