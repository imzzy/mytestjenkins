package cn.leanpro.pageobjects;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

public class BBSAddNewPostPage {

	WebDriver driver;
	public BBSAddNewPostPage(WebDriver driver) {
		this.driver = driver;
	}
	
	@FindBy(how = How.ID, using="subject")
	public WebElement newtitlearea;
	
	@FindBy(how=How.ID, using="e_iframe")
	public WebElement newContioner;
	
	@FindBy(how=How.TAG_NAME,using="body")
	public WebElement newdescContent;
	
	@FindBy(how=How.ID,using="postsubmit")
	WebElement submitBtn;
	
	public void addNewPost(String title,String descContent){
		newtitlearea.sendKeys(title);
		driver.switchTo().frame(newContioner);
		newdescContent.sendKeys(descContent);
		driver.switchTo().defaultContent();
		submitBtn.click();
	}
}
