package cn.leanpro.TestSuiteBase;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import org.openqa.selenium.WebDriver;
import org.testng.annotations.AfterClass;
import org.testng.annotations.BeforeClass;



public class BaseTest {

	private WebDriver driver;
	
	private static List<WebdriverThread> webDriverThreadPool = Collections.synchronizedList(new ArrayList<WebdriverThread>());
    private static ThreadLocal<WebdriverThread> driverThread;


	public WebDriver getDriver() {
		System.out.println("this is getting driver....");
		driver = driverThread.get().getDriver();
		driver.manage().window().maximize();
		System.out.println("hello world 123123123");
		return driver;
	}
	
	@BeforeClass
	public void createDriver(){
		System.out.println(" hi  creating driver....");
		driverThread = new ThreadLocal<WebdriverThread>() {
            @Override
            protected WebdriverThread initialValue() {
            	WebdriverThread webDriverThread = new WebdriverThread();
                webDriverThreadPool.add(webDriverThread);
                return webDriverThread;
            }
        };
		
		
	}
	

	@AfterClass
	public void teardownDriver(){
		if (driver != null){
			driver.close();
		}
	}
	
	
	
	
	
}
