package cn.leanpro.pageobjects.Test;


import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Properties;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.ie.InternetExplorerDriver;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.remote.RemoteWebDriver;
import org.openqa.selenium.remote.server.handler.GetPageSource;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import cn.leanpro.TestSuiteBase.SuiteBases;
import cn.leanpro.model.Browers;
import cn.leanpro.util.ExOM;

public class TestABC {

	public WebDriver driver;
	
	
	
	
	
	@Test(dataProvider="datawithBrower")
	public void testSuiteBBS(Browers browser) throws IOException{
//		SuiteBases sb = new SuiteBases();
//		sb.init();
//		System.out.println(sb.filedir);
//		String aaa=SuiteBases.Param.getProperty("screenShotOnFail");
//		System.out.println(aaa);
	    //System.setProperty("webdriver.ie.driver", "D:\\dev\\tools\\webdrivers\\IEDriverServer.exe");
	    //WebDriver driver = new InternetExplorerDriver();
	    //driver.get("https://www.baidu.com");
		DesiredCapabilities capabilities = new DesiredCapabilities();
		capabilities.setBrowserName(browser.getBrowser());
		System.out.println(browser.getBrowser());
		//capabilities.setBrowserName("chrome");
		RemoteWebDriver remoteWD=null;
		
		remoteWD = new RemoteWebDriver(new URL("http://192.168.1.5:4444/wd/hub"),capabilities);
		remoteWD.get("https://www.baidu.com");
		
	}
	
	@DataProvider
	public Iterator<Object[]> datawithBrower() throws Throwable{
		File file = new File(getClass().getResource("/testdata.xlsx").getPath());
		List<Browers> browser = ExOM.mapFromExcel(file).to(Browers.class).map("browser");
		List<Object[]> datareturned = new ArrayList<>();
		for(Browers brw:browser){
			datareturned.add(new Object[]{brw});
		}
		return datareturned.iterator();
	}
	
	@Test
	public void testAAA(){
		System.out.println(System.getProperty("user.dir"));
		System.out.println(System.getProperty("user.dir")+"\\src\\main\\resourece\\drivers\\chromedriver.exe");
	}
}
