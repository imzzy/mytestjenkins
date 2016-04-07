package cn.leanpro.pageobjects;

import java.util.List;


import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;
import org.testng.Assert;


public class BBSEditeAPost {

	WebDriver driver;
	
	@FindBy(how=How.CLASS_NAME,using="editp")
	WebElement editLink;
	
	@FindBy(how = How.ID, using="subject")
	public WebElement newtitlearea;
	
	@FindBy(how=How.ID, using="e_iframe")
	public WebElement newContioner;
	
	@FindBy(how=How.TAG_NAME,using="body")
	public WebElement newdescContent;
	
	@FindBy(how=How.ID,using="postsubmit")
	WebElement submitBtn;
	@FindBy(how=How.ID,using="wp")
	WebElement bodycontainer;
	
	//新的标题
	@FindBy(how=How.ID,using="thread_subject")
	WebElement newTitle;
	
	public BBSEditeAPost(WebDriver driver) {

		this.driver = driver;
	}
	
	public void editAPost(String newtitle,String newcontent) throws InterruptedException{
		editLink.click();
		Thread.sleep(3000);
		
		newtitlearea.click();
		newtitlearea.clear();
		newtitlearea.sendKeys(newtitle);
		driver.switchTo().frame(newContioner);
		newdescContent.click();
		newdescContent.clear();
		newdescContent.sendKeys(newcontent);
		driver.switchTo().defaultContent();
		submitBtn.click();
		Thread.sleep(3000);
		
		Assert.assertTrue(newTitle.getText().equals(newtitle));
	}
	
	public boolean isResponse(String responseContent){
 		Boolean isrelust  = false;
 		List<WebElement> response = bodycontainer.findElements(By.className("pct").className("t_f"));
 		for(WebElement res:response){
 			System.out.println(res.getText());
 			System.out.println(responseContent);
 			if(res.getText().equals(responseContent)){
 				isrelust = true;
 			}
 		}	
 		return isrelust;
	}
	
}
