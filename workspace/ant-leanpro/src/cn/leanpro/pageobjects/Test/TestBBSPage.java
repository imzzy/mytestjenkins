package cn.leanpro.pageobjects.Test;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.PageFactory;
import org.testng.annotations.AfterClass;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import cn.leanpro.TestSuiteBase.SuiteBases;
import cn.leanpro.model.BBSPostModle;
import cn.leanpro.pageobjects.BBSAllPagePost;
import cn.leanpro.pageobjects.UserLoginBBS;
import cn.leanpro.util.ExOM;


public class TestBBSPage extends SuiteBases{

	WebDriver mydriver;
	UserLoginBBS userlbbs;
	BBSAllPagePost bbspage;
	@BeforeTest
	public  void initBrower() throws InterruptedException, IOException{
	
		init();
		mydriver = loadBrowser();
		
		userlbbs = PageFactory.initElements(mydriver, UserLoginBBS.class);
		bbspage = userlbbs.loginBBS("imzack", "123456");
		Thread.sleep(3000);
	}	
	//发帖
	@Test(dataProvider="datawithbbspost")
	public void testCreateANewPost(BBSPostModle post) throws InterruptedException{
		bbspage = PageFactory.initElements(mydriver, BBSAllPagePost.class);
		bbspage.get();
		bbspage.createAPost(post.getSection(), post.getTitle(), post.getContent());
		//Thread.sleep(4000);
	}
	
	//编辑帖子
	@Test(dataProvider="datawithbbspost")
	public void testEditAPost(BBSPostModle post) throws InterruptedException{
		bbspage = PageFactory.initElements(mydriver, BBSAllPagePost.class);
		bbspage.get();
		bbspage.editAPost(post.getSection(), post.getTitle(), post.getNewtitle(),post.getNewcontent());
		//Thread.sleep(4000);
	}
	//回帖
		@Test(dataProvider="datawithbbspost")
		public void  testResponseAPost(BBSPostModle post) throws InterruptedException{
			bbspage = PageFactory.initElements(mydriver, BBSAllPagePost.class);
			bbspage.get();
			bbspage.responseAPost(post.getSection(), post.getNewtitle(), post.getResport());
			Thread.sleep(4000);
		}
	
	

	
	@DataProvider
	public Iterator<Object[]> datawithbbspost() throws Throwable{
		//System.out.println("hi is finding the data");
		//String testdata = System.getProperty("user.dir")+"/src/testdata.xlsx";
		//System.out.println("this is data file"+System.getProperty("user.dir")+"/src/testdata.xlsx");
		//System.out.println("this is the file "+getClass().getResource("/testdata.xlsx").getPath());
		File file = new File(SuiteBases.datafiledir);
		
		List<BBSPostModle> bbspost = ExOM.mapFromExcel(file).to(BBSPostModle.class).map("bbspost");
		System.out.println(bbspost);
		List<Object[]> datatobeReturned = new ArrayList<Object[]>();
		for(BBSPostModle user:bbspost){
			datatobeReturned.add(new Object[]{user});
		}
		return datatobeReturned.iterator();
	}
	
	@AfterClass
	public void tearDown(){
		this.mydriver.quit();
	}
}
