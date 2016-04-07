package cn.leanpro.pageobjects;


import java.util.List;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Action;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.LoadableComponent;
import org.testng.Assert;




public class AllPostsPage extends LoadableComponent<AllPostsPage>{
	
	WebDriver driver;
	@FindBy(how=How.ID, using="the-list")
	WebElement postContainer;
	
	@FindBy(how=How.ID, using="post-search-input")
	WebElement searchPosts;
	@FindBy(how=How.ID, using="search-submit")
	WebElement searchBtn;
	
	@FindBy(how=How.LINK_TEXT, using="写文章")
	WebElement addNewPost;
	
	public AllPostsPage(WebDriver driver){
		this.driver = driver;
		PageFactory.initElements(driver, this);
		//driver.get("http://www.leanpro.cn/wp-admin/edit.php");

	}
	
	public void createANewPost(String title, String descContent){
		addNewPost.click();
		//driver.get("http://www.leanpro.cn/wp-admin/post-new.php");
		AddNewPostPage newPost = PageFactory.initElements(driver, AddNewPostPage.class);
		newPost.addNewPost(title, descContent);
		
	}
	public void editAPost(String title, String newtitle,String descContent) throws InterruptedException{
		gotoParticularPostPage(title);
		EditPostPage epostPage = PageFactory.initElements(driver, EditPostPage.class);
		epostPage.editpost(newtitle, descContent);
	}
	public void deleAPost(String title){
		gotoParticularPostPage(title);
		DeletePostPage deletePage = PageFactory.initElements(driver, DeletePostPage.class);
		deletePage.deleteAPost();
	}
	public void searchAPost(String title){
		SearchPostPage searchPg = PageFactory.initElements(driver, SearchPostPage.class);
		searchPg.searchaPost(title);
	}
	
	private void gotoParticularPostPage(String title){
		List<WebElement> allPosts = postContainer.findElements(By.className("row-title"));
		for(WebElement ele:allPosts ){
			if (ele.getText().equals(title)){
				Actions builder = new Actions(driver);
				builder.moveToElement(ele);
				builder.click(driver.findElement(By.cssSelector(".edit>a")));
				Action compositeAction = builder.build();
				compositeAction.perform();
				break;
			}
		}
	}

	@Override
	protected void load() {
		driver.get("http://www.leanpro.cn/wp-admin/edit.php");
	}

	@Override
	protected void isLoaded() throws Error {
		String url = driver.getCurrentUrl();
		Assert.assertTrue(url.contains("edit.php"));
	}

	
	
}
