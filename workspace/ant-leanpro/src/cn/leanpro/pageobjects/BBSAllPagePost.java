package cn.leanpro.pageobjects;


import java.util.List;

import org.junit.Assert;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Action;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.LoadableComponent;


public class BBSAllPagePost extends  LoadableComponent<BBSAllPagePost>{

	WebDriver driver;
	@FindBy(how=How.ID,using="category_1")
	WebElement catagory;
	
	@FindBy(how=How.ID,using = "newspecial")
	WebElement newspecial;
	
	@FindBy(how=How.ID,using="moderate")
	WebElement allpostsTitle;
	
	public BBSAllPagePost(WebDriver driver) {
		this.driver = driver;
	}
	

	public void createAPost(String sectionName, String title,String content ) throws InterruptedException{
		gotoSectionWithTitle(sectionName);
		newPost();
		BBSNewPost post = PageFactory.initElements(driver, BBSNewPost.class);
		post.createANewPost(title, content);
	}

	public void responseAPost(String sectionName, String title,String responseText) throws InterruptedException{
		gotoSectionWithTitle(sectionName);
		clickPost(title);
		BBSResponsePost  bbsReps = PageFactory.initElements(driver, BBSResponsePost.class);
		bbsReps.responseAPost(responseText);
	}

	
	public void editAPost(String sectionName,String title,String newtitle,String newresponseText) throws InterruptedException{
		gotoSectionWithTitle(sectionName);
		clickPost(title);
		BBSEditeAPost bbseditp = PageFactory.initElements(driver, BBSEditeAPost.class);
		bbseditp.editAPost(newtitle, newresponseText);
	}
	
	
	
	@Override
	protected void load() {
		driver.get("http://www.leanpro.cn/bbs/forum.php");
	}
	@Override
	protected void isLoaded() throws Error {
		String url = driver.getCurrentUrl();
		Assert.assertTrue(url.endsWith("/forum.php"));
	}

	public void gotoSectionWithTitle(String title){
		catagory.findElement(By.linkText(title)).click();
	}

	public void newPost(){
		newspecial.click();
	}

	public void newPoll(){
		Actions builder = new Actions(driver);
		builder.moveToElement(newspecial);
		builder.click(driver.findElement(By.className("poll")));
		Action action = builder.build();
		action.perform();
	}
	
	public void clickPost(String title){
		allpostsTitle.findElement(By.className("common").linkText(title)).click();
	}
	
}
