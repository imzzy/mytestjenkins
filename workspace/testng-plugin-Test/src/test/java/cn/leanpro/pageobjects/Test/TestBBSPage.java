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
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import cn.leanpro.TestSuiteBase.BaseTest;
import cn.leanpro.model.BBSPostModle;
import cn.leanpro.model.Users;
import cn.leanpro.pageobjects.BBSAllPagePost;
import cn.leanpro.pageobjects.UserLoginBBS;
import cn.leanpro.util.ExOM;

public class TestBBSPage extends BaseTest{

	WebDriver driver;
	UserLoginBBS userlbbs;
	BBSAllPagePost bbspage;
	@BeforeClass
	public  void initBrower() throws InterruptedException{
//		driver = new FirefoxDriver();
//		driver.manage().window().maximize();
//		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
		driver= getDriver();
		System.out.println();
		userlbbs = PageFactory.initElements(driver, UserLoginBBS.class);
		bbspage = userlbbs.loginBBS("imzack", "123456");
		Thread.sleep(3000);
	}	
	//发帖
	@Test(dataProvider="datawithbbspost")
	public void testCreateANewPost(BBSPostModle post) throws InterruptedException{
		bbspage = PageFactory.initElements(driver, BBSAllPagePost.class);
		bbspage.get();
		bbspage.createAPost(post.getSection(), post.getTitle(), post.getContent());
		//Thread.sleep(4000);
	}
	
	//编辑帖子
	@Test(dataProvider="datawithbbspost")
	public void testEditAPost(BBSPostModle post) throws InterruptedException{
		bbspage = PageFactory.initElements(driver, BBSAllPagePost.class);
		bbspage.get();
		bbspage.editAPost(post.getSection(), post.getTitle(), post.getNewtitle(),post.getNewcontent());
		//Thread.sleep(4000);
	}
	//回帖
		@Test(dataProvider="datawithbbspost")
		public void  testResponseAPost(BBSPostModle post) throws InterruptedException{
			bbspage = PageFactory.initElements(driver, BBSAllPagePost.class);
			bbspage.get();
			bbspage.responseAPost(post.getSection(), post.getNewtitle(), post.getResport());
			Thread.sleep(4000);
		}
	
	

	
	@DataProvider
	public Iterator<Object[]> datawithbbspost() throws Throwable{
		File file = new File(getClass().getResource("/testdata.xlsx").getPath());
		List<BBSPostModle> bbspost = ExOM.mapFromExcel(file).to(BBSPostModle.class).map("bbspost");
		List<Object[]> datatobeReturned = new ArrayList<Object[]>();
		for(BBSPostModle user:bbspost){
			datatobeReturned.add(new Object[]{user});
		}
		return datatobeReturned.iterator();
	}
	
//	@AfterClass
//	public void tearDown(){
//		driver.close();
//	}
}
