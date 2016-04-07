package cn.leanpro.pageobjects.Test;

import java.io.File;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.support.PageFactory;
import org.testng.annotations.AfterClass;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import cn.leanpro.TestSuiteBase.BaseTest;
import cn.leanpro.model.Users;
import cn.leanpro.pageobjects.BBSAllPagePost;
import cn.leanpro.pageobjects.UserLoginBBS;
import cn.leanpro.util.ExOM;

public class TestBBS extends BaseTest{

	WebDriver driver;
	UserLoginBBS userlbbs;
	BBSAllPagePost bbspage;
	@BeforeClass
	public  void initBrower(){
		driver = getDriver();
	}
	
	@Test
	public void testchooseSection(){
		bbspage = PageFactory.initElements(driver, BBSAllPagePost.class);
		bbspage.get();
		bbspage.gotoSectionWithTitle("LeanFT");
		bbspage.get();
		bbspage.gotoSectionWithTitle("Selenium");
		bbspage.get();
	}
	
	@Test(dataProvider="datawithuser")
	public void testbbsLogin(Users user) throws InterruptedException{
		userlbbs = PageFactory.initElements(driver, UserLoginBBS.class);
		bbspage = userlbbs.loginBBS(user.getUsername(), user.getPassword());
		Thread.sleep(3000);
	}
	
	@DataProvider 
	public Iterator<Object[]> datawithuser() throws Throwable{
		File file = new File(getClass().getResource("/testdata.xlsx").getPath());
		List<Users> users = ExOM.mapFromExcel(file).to(Users.class).map("用户信息");
		List<Object[]> datatobeReturned = new ArrayList<Object[]>();
		for(Users user:users){
			datatobeReturned.add(new Object[]{user});
		}
		return datatobeReturned.iterator();
	}
//	@AfterClass
//	public void tearDown(){
//		driver.quit();
//	}
}