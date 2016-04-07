package cn.leanpro.pageobjects;


import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;
import org.testng.Assert;


public class BBSNewPost {

	WebDriver driver;
	@FindBy(how=How.ID,using="subject")
	WebElement newTitle;
	
	@FindBy(how=How.ID,using="e_iframe")
	WebElement newiframe;
	@FindBy(how=How.TAG_NAME,using="body")
	WebElement newTextarea;
	
	@FindBy(how=How.ID,using="postsubmit")
	WebElement newPublishBtn;
	//验证是否正确
	@FindBy(how=How.ID,using="thread_subject")
	WebElement currentTitle;
	
	public BBSNewPost(WebDriver driver) {

		this.driver = driver;
	}
	
	public void createANewPost(String title,String descContent) throws InterruptedException{
		driver.switchTo().frame(newiframe);
		newTextarea.sendKeys(descContent);
		driver.switchTo().defaultContent();
		newTitle.click();
		newTitle.clear();
		newTitle.sendKeys(title);
		newPublishBtn.click();
		//发表帖子之后会跳转到详情页面
		Thread.sleep(5000);
		
		Assert.assertEquals(title, currentTitle.getText());
	}
}
