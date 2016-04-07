package cn.leanpro.pageobjects;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

public class EditPostPage {

	WebDriver driver;
	@FindBy(how=How.ID, using="content_ifr")
	WebElement newPostContentFrame;
	@FindBy(how=How.ID, using="tinymce")
	WebElement newPostBody;
	@FindBy(how=How.ID, using="title")
	WebElement newTitleFiled;
	@FindBy(how=How.ID,using="content")
	WebElement newContent;
	@FindBy(how=How.ID, using="publish")
	WebElement newPublishBtn;
	
	public EditPostPage(WebDriver driver){
		this.driver = driver;
	}
	
	public void editpost(String newtitle,String descContent) throws InterruptedException{
		driver.switchTo().frame(newPostContentFrame);
		newPostBody.click();
		newPostBody.clear();
		newPostBody.sendKeys(descContent);
		driver.switchTo().defaultContent();
		newTitleFiled.click();
		newTitleFiled.clear();
		newTitleFiled.sendKeys(newtitle);
		newPublishBtn.click();
		Thread.sleep(2000);
		newPublishBtn.click();
		Thread.sleep(2000);
	}
	
//	public void editpost(String newtitle,String descContent){
//		newTitleFiled.click();
//		newTitleFiled.clear();
//		newTitleFiled.sendKeys(newtitle);
//		
//		newContent.click();
//		newContent.clear();
//		newContent.sendKeys(descContent);
//		
//		newPublishBtn.click();
//		try {
//			Thread.sleep(3000);
//		} catch (InterruptedException e) {
//			// TODO Auto-generated catch block
//			e.printStackTrace();
//		}
//
//	}
}
