package cn.leanpro.pageobjects.Test;

import java.io.File;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.support.PageFactory;
import org.testng.annotations.AfterTest;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import cn.leanpro.TestSuiteBase.BaseTest;
import cn.leanpro.model.PostContent;
import cn.leanpro.model.Users;
import cn.leanpro.pageobjects.AdminLoginPage;
import cn.leanpro.pageobjects.AllPostsPage;
import cn.leanpro.util.ExOM;


public class TestLogin extends BaseTest {
	
	WebDriver driver;
	AdminLoginPage adminpage;
	AllPostsPage apg;
	@BeforeClass
	public  void initBrower(){
		driver = getDriver();
	}
	
	//test login
	@Test(dataProvider="datawithuser")
	public void testAdminlogin(Users user) throws InterruptedException{
		adminpage = PageFactory.initElements(driver, AdminLoginPage.class);
		adminpage.get();
		Thread.sleep(3000);
		apg = adminpage.login(user.getUsername(),user.getPassword());
		Thread.sleep(3000);
		apg.get();
		//Thread.sleep(5000);
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
	
//	@AfterTest
//	public void teardown(){
//		driver.close();
//	}

}
