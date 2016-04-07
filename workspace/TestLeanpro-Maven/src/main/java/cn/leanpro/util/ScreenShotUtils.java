package cn.leanpro.util;

import java.io.File;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

import org.apache.commons.io.FileUtils;
import org.openqa.selenium.OutputType;
import org.openqa.selenium.TakesScreenshot;
import org.openqa.selenium.WebDriver;
import org.testng.ITestContext;
import org.testng.ITestListener;
import org.testng.ITestResult;
import org.testng.Reporter;

import com.relevantcodes.extentreports.ExtentReports;
import com.relevantcodes.extentreports.ExtentTest;

import cn.leanpro.TestSuiteBase.BaseTest;
import cn.leanpro.TestSuiteBase.SuiteBases;

public class ScreenShotUtils implements ITestListener{

	SuiteBases sbase;
	
	
	
	/**
	 * 1.testcase运行完毕整理报告
	 */
	@Override
	public void onFinish(ITestContext arg0) {
		//完成报告
		System.out.println("结束测试");
		
	}

	/**
	 * 1.在开始运行的test的时候生成报告
	 * 
	 */
	@Override
	public void onStart(ITestContext icontext) {
		//开始生成报告
		System.out.println("开始测试");
		
	}

	@Override
	public void onTestFailedButWithinSuccessPercentage(ITestResult arg0) {
		System.out.println("onTestFailedButWithinSuccessPercentage");		
	}

	@Override
	public void onTestFailure(ITestResult itr) {
		try {
			if(SuiteBases.getParam().getProperty("screenShotOnFail").equalsIgnoreCase("yes")){
				capturescreenShot(itr, "fail");
			}
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}		
	}

	@Override
	public void onTestSkipped(ITestResult arg0) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onTestStart(ITestResult arg0) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onTestSuccess(ITestResult itr) {
		try {
			if(SuiteBases.getParam().getProperty("screenShotOnPass").equalsIgnoreCase("yes")){
				//capturescreenShot(itr, "success");
				System.out.println("yes");
				capturescreenShot(itr, "success");
			}
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
	}
	//屏幕截屏
	public void capturescreenShot(ITestResult result,String status){
		Object currentclass = result.getInstance();
		WebDriver driver = ((BaseTest) currentclass).getDriver();
		String destdir = "";
		String runtimeMethod = result.getMethod().getRealClass().getSimpleName()+"."+result.getMethod().getMethodName();
		File fireSrc = ((TakesScreenshot)driver).getScreenshotAs(OutputType.FILE);
		DateFormat dateformat = new SimpleDateFormat("yyyy-MM-dd-hh-mm-ss");
		if (status.equals("fail")){
			destdir="screenshot/Failures";
			
		}else if(status.equals("success")){
			destdir = "screenshot/Success";
		}
		String shotpngdir="target/surefire-reports/"+destdir;
		new File(shotpngdir).mkdirs();
		String destFile = runtimeMethod+"."+dateformat.format(new Date())+".png";
		try {
			FileUtils.copyFile(fireSrc, new File(shotpngdir+"/"+destFile));
			System.out.println(shotpngdir+"/"+destFile);
			Reporter.log("<a href='"+destdir+"/"+destFile+"'><img width='200px' height='160px'  src="+destdir+"/"+destFile+"></a>");
		} catch (IOException e) {
			System.out.println("scren capture is wrong");
			e.printStackTrace();
		}
		Reporter.setCurrentTestResult(null);
		
	}

}
