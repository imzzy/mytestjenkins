package cn.leanpro.TestSuiteBase;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.Properties;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.testng.annotations.BeforeClass;

public class SuiteBases {

	public static Properties Param = null;
	public static WebDriver driver = null;
	public static String filedir = System.getProperty("user.dir")+"/src/main/resources/Param.properties";
	
	
	public static Properties getParam() throws IOException{
		Param = new Properties();
		FileInputStream fil = new FileInputStream(filedir);
		Param.load(fil);
		return Param;
		//System.out.println(Param.getProperty("testBrowser"));
	}
	
//	public void loadBrowser(){
//		System.out.println(Param.getProperty("testBrowser"));
//		if(Param.getProperty("testBrowser").equalsIgnoreCase("Mozilla") && ExistingfirefoxBrower != null){
//			driver = ExistingfirefoxBrower;
//		}
//		
//		if(Param.getProperty("testBrowser").equalsIgnoreCase("Mozilla")){
//			driver = new FirefoxDriver();
//			ExistingfirefoxBrower = driver;
//			driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
//			driver.manage().window().maximize();
//		}
//		return driver;
//	}
}
