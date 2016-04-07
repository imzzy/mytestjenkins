package cn.leanpro.pageobjects;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

public class AddNewPostPage {

	WebDriver driver;
	
	@FindBy(how=How.ID, using="content_ifr")
	WebElement newPostContentFrame;
	@FindBy(how=How.ID, using="tinymce")
	WebElement newPostBody;
	@FindBy(how=How.ID, using="title")
	WebElement newTitleFiled;
	@FindBy(how=How.ID,using="content")
	WebElement newConntent;
	@FindBy(how=How.ID, using="publish")
	WebElement newPublishBtn;
	
	public AddNewPostPage(WebDriver driver){
		this.driver = driver;
	}
	
	public void addNewPost(String title,String descContent){
		driver.switchTo().frame(newPostContentFrame);
		newPostBody.sendKeys(descContent);
		driver.switchTo().defaultContent();
		newTitleFiled.click();
		newTitleFiled.clear();
		newTitleFiled.sendKeys(title);
		newPublishBtn.click();
	}
	
//	public void addNewPost(String title,String descContent){
//		newTitleFiled.click();
//		newTitleFiled.clear();
//		newTitleFiled.sendKeys(title);
//		
//		newConntent.click();
//		newConntent.clear();
//		newConntent.sendKeys(descContent);
//		
//		newPublishBtn.click();
//		try {
//			Thread.sleep(3000);
//		} catch (InterruptedException e) {
//			// TODO Auto-generated catch block
//			e.printStackTrace();
//		}
//		newPublishBtn.click();
//		try {
//			Thread.sleep(4000);
//		} catch (InterruptedException e) {
//			// TODO Auto-generated catch block
//			e.printStackTrace();
//		}
//	}
}
