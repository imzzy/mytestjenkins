package cn.leanpro.pageobjects;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

public class DeletePostPage {

	WebDriver driver;
	@FindBy(how=How.LINK_TEXT,using="À¬»øÏä")
	WebElement moveToTrash;
	
	public DeletePostPage(WebDriver driver){
		this.driver = driver;
	}
	
	public void deleteAPost(){
		moveToTrash.click();
	}
	
	
}
