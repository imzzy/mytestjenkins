package cn.leanpro.pageobjects;

import org.junit.Assert;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.LoadableComponent;






public class AdminLoginPage extends LoadableComponent<AdminLoginPage> {

	WebDriver driver;
	
	@FindBy(how=How.ID, using="username")
	WebElement usernameFiled;
	
	@FindBy(how=How.ID, using="password")
	WebElement passwordFiled;
	
	@FindBy(how=How.NAME, using="submit01")
	WebElement loginBtn;
	
	public AdminLoginPage(WebDriver driver){
		this.driver = driver;
		PageFactory.initElements(driver, this);
		driver.get("http://www.leanpro.cn/wp-admin/");
	}
	
	public AllPostsPage login(String username,String password){
		usernameFiled.click();
		usernameFiled.clear();
		usernameFiled.sendKeys(username);
		passwordFiled.click();
		passwordFiled.sendKeys(password);
		
		loginBtn.click();
		return PageFactory.initElements(driver, AllPostsPage.class);
	}

	@Override
	protected void load() {
		driver.get("http://www.leanpro.cn/wp-admin/");
	}

	@Override
	protected void isLoaded() throws Error {
		String url = driver.getCurrentUrl();
		Assert.assertTrue(url.contains("wp-admin"));
	}
}
