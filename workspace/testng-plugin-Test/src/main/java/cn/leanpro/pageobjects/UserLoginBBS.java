package cn.leanpro.pageobjects;


import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.LoadableComponent;
import org.testng.Assert;


public class UserLoginBBS extends LoadableComponent<UserLoginBBS>{

	WebDriver driver;
	
	@FindBy(how=How.LINK_TEXT,using="登录")
	WebElement loginLink;
	
	@FindBy(how=How.ID, using="username")
	WebElement usernameFiled;
	
	@FindBy(how=How.ID, using="password")
	WebElement passwordFiled;
	
	@FindBy(how=How.NAME, using="submit01")
	WebElement loginBtn;
	
	public UserLoginBBS(WebDriver driver){
		this.driver = driver;
		driver.get("http://www.leanpro.cn/bbs/forum.php");
		
	}
	
	public BBSAllPagePost loginBBS(String username,String password) {
		loginLink.click();
		
			
			
			usernameFiled.click();
			usernameFiled.clear();
			usernameFiled.sendKeys(username);
			passwordFiled.click();
			passwordFiled.clear();
			passwordFiled.sendKeys(password);
			loginBtn.click();
		
		return PageFactory.initElements(driver, BBSAllPagePost.class);
		
	}

	@Override
	protected void load() {
		driver.get("http://www.leanpro.cn/bbs/forum.php");
		
	}

	@Override
	protected void isLoaded() throws Error {
		String url = driver.getCurrentUrl();
		Assert.assertTrue(url.endsWith("forum.php"));
		
	}
}
