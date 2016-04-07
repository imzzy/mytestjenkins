package cn.leanpro.pageobjects;

import java.util.ArrayList;
import java.util.List;

import org.junit.Assert;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;


public class BBSResponsePost {

	WebDriver driver;
	
	@FindBy(how=How.ID,using="fastpostmessage")
	WebElement fastPostMsg;
	@FindBy(how=How.ID,using="fastpostsubmit")
	WebElement fastPostBtn;
	@FindBy(how=How.ID,using="wp")
	WebElement bodycontainer;
	public BBSResponsePost(WebDriver driver) {
		this.driver = driver;
	}
	
	public void responseAPost(String responseContent) throws InterruptedException{
		fastPostMsg.click();
		fastPostMsg.clear();
		fastPostMsg.sendKeys(responseContent);
		fastPostBtn.click();
		Thread.sleep(5000);
		
		Assert.assertTrue(isResponse(responseContent));

	}
	
	//assert  respones
	public boolean isResponse(String responseContent){
 		Boolean isrelust  = false;
 		List<WebElement> response = bodycontainer.findElements(By.className("pct").className("t_f"));
 		for(WebElement res:response){
 			if(res.getText().equals(responseContent)){
 				isrelust = true;
 			}
 		}	
 		return isrelust;
	}
	
}
