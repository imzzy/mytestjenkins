package cn.leanpro.pageobjects.Test;

import java.io.IOException;

import org.testng.annotations.AfterTest;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.Test;

import cn.leanpro.TestSuiteBase.SuiteBases;
import cn.leanpro.util.ScreenShotUtils;

public class TestABC extends SuiteBases{

	@BeforeTest
	public void initsuite() throws IOException{
		init();
		loadBrowser();
	}
	@Test
	public void testSuiteWeb() throws InterruptedException{
		
		driver.get("http://www.leanpro.cn");
		
		
	}
	
	
	@Test
	public void testSuiteBBS() throws IOException{
		SuiteBases sb = new SuiteBases();
		sb.init();
		System.out.println(sb.filedir);
		String aaa=SuiteBases.Param.getProperty("screenShotOnFail");
		System.out.println(aaa);
	
	}
	
	@Test
	public void testPath(){


		System.out.println(SuiteBases.datafiledir);
	}
	
	@AfterTest
	public void teardown(){
		closeWebDriver();
	}
}
