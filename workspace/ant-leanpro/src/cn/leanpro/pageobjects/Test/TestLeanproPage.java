package cn.leanpro.pageobjects.Test;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.support.PageFactory;
import org.testng.annotations.AfterTest;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import cn.leanpro.TestSuiteBase.SuiteBases;
import cn.leanpro.model.PostContent;
import cn.leanpro.pageobjects.AdminLoginPage;
import cn.leanpro.pageobjects.AllPostsPage;
import cn.leanpro.util.ExOM;

public class TestLeanproPage extends SuiteBases{
	WebDriver mydriver;
	AdminLoginPage adminpage;
	AllPostsPage apg;
	@BeforeTest
	public  void initBrower() throws InterruptedException, IOException{
		init();
		mydriver = loadBrowser();
		adminpage = PageFactory.initElements(mydriver, AdminLoginPage.class);
		adminpage.get();
		Thread.sleep(3000);
		apg = adminpage.login("zack","ABCzzy123456");
		//Thread.sleep(5000);
		
	}
	//test add a post
		@Test(dataProvider="datawithpost")
		public void testAddnewPost(PostContent post) throws InterruptedException{
			apg.get();
			apg.createANewPost(post.getTitle(), post.getDescContent());
			Thread.sleep(3000);
		}
	// test edit a post
		@Test(dataProvider="datawithpost")
		public void testEditAPost(PostContent post) throws InterruptedException{
			apg.get();
			apg.editAPost(post.getTitle(), post.getNewtitle(), post.getNewdescContent());
			System.out.println(post.getTitle());
			Thread.sleep(3000);
		}
		
		//
	
		//test search a post
		@Test(dataProvider="datawithpost")
		public void testSearchAPost(PostContent post) throws InterruptedException{
			apg.get();
			apg.searchAPost(post.getTitle());
			Thread.sleep(3000);
		}
		//test delete a post
		
				@Test(dataProvider="datawithpost")
				public void testDeleteAPost(PostContent post) throws InterruptedException{
					apg.get();
					apg.deleAPost(post.getDeleteTitle());
					Thread.sleep(3000);
					
				}
	
	@DataProvider
	public Iterator<Object[]> datawithpost(){
		File file = new File(SuiteBases.datafiledir);
		List<PostContent> postcontent;
		List<Object[]> datatobeReturned = new ArrayList<Object[]>();
			try {
				postcontent = ExOM.mapFromExcel(file).to(PostContent.class).map("post");
				
				for(PostContent post:postcontent){
					datatobeReturned.add(new Object[]{post});
					}
			} catch (Throwable e) {
				
				e.printStackTrace();
			}
			return datatobeReturned.iterator();
		
		
	}
	@AfterTest
	public void teardown(){
		mydriver.close();
	}

}
