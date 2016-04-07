package cn.leanpro.pageobjects;

import java.util.List;

import org.junit.Assert;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;


public class SearchPostPage {
	
	WebDriver driver;
	
	@FindBy(how=How.ID,using="post-search-input")
	WebElement searchInput;
	@FindBy(how=How.ID,using="search-submit")
	WebElement searchSubmit;
	@FindBy(how=How.ID,using="the-list")
	WebElement postContainer;
	
	public SearchPostPage(WebDriver driver) {

		this.driver = driver;
	}
	
	public void searchaPost(String title){
		searchInput.click();
		searchInput.clear();
		searchInput.sendKeys(title);
		searchSubmit.click();
		
		try {
			Thread.sleep(3000);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		Assert.assertTrue(getResult(title));
	}

	public boolean getResult(String title){
		List<WebElement> allPosts = postContainer.findElements(By.className("row-title"));
		boolean  isReslust = false;
		for (WebElement post:allPosts){
			if(post.getText().contains(title)){
				isReslust = true;
			}
			
		}
		
		return isReslust;
	}
	
}
