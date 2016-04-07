package cn.leanpro.TestSuiteBase;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.Properties;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;

public class SuiteBases {

	public static Properties Param = null;
	public  WebDriver driver = null;
	public static String filedir = System.getProperty("user.dir")+"/src/resources/Param.properties";
	public static String datafiledir = System.getProperty("user.dir")+"/src/testdata.xlsx";
	public  WebDriver ExistingchromeBrowser;
	public  WebDriver ExistingfirefoxBrower;

	public  void init() throws IOException{
		Param = new Properties();
		FileInputStream fil = new FileInputStream(filedir);
		Param.load(fil);
		//System.out.println(Param.getProperty("testBrowser"));
	}
	
	public  WebDriver loadBrowser(){
		
		System.out.println(Param.getProperty("testBrowser"));
		if(Param.getProperty("testBrowser").equalsIgnoreCase("Mozilla") && ExistingfirefoxBrower != null){
			driver = ExistingfirefoxBrower;
		}
		
		if(Param.getProperty("testBrowser").equalsIgnoreCase("Mozilla")){
			driver = new FirefoxDriver();
			ExistingfirefoxBrower = driver;
			driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
			driver.manage().window().maximize();
		}
		return driver;
	}
	
	public void closeWebDriver(){
		driver.close();
	
		ExistingchromeBrowser=null;
		
		ExistingfirefoxBrower=null;
		
	}
}
