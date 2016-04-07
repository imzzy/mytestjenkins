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


import cn.leanpro.TestSuiteBase.SuiteBases;

public class ScreenShotUtils implements ITestListener{

	public WebDriver driver;
	public SuiteBases subase;
	@Override
	public void onFinish(ITestContext arg0) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onStart(ITestContext arg0) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onTestFailedButWithinSuccessPercentage(ITestResult itr) {
		if(SuiteBases.Param.getProperty("screenShotOnFailbutWithinSuccessPercentage").equalsIgnoreCase("yes")){
			capturescreenShot(itr, "failedButWithinSuccessPercentage");
		}
		
	}

	@Override
	public void onTestFailure(ITestResult itr) {
		System.out.println("ontestfail..........");
		System.out.println("hi  ontestfail is "+SuiteBases.Param.getProperty("screenShotOnFail"));
		if(SuiteBases.Param.getProperty("screenShotOnFail").equalsIgnoreCase("yes")){
			capturescreenShot(itr, "fail");
			System.out.println("Oh i have a error");
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
		System.out.println("it is scucess pass the test method.");
		if(SuiteBases.Param.getProperty("screenShotOnPass").equalsIgnoreCase("yes")){
			capturescreenShot(itr, "success");
			System.out.println("yes");
		}
		
	}
	
	public void capturescreenShot(ITestResult result,String status){
		Object currentClass = result.getInstance();
		driver = ((SuiteBases)currentClass).loadBrowser();
		String destdir = "";
		String runtimeMethod = result.getMethod().getRealClass().getSimpleName().getClass()+"."+result.getMethod().getMethodName();
		File fireSrc = ((TakesScreenshot)driver).getScreenshotAs(OutputType.FILE);
		DateFormat dateformat = new SimpleDateFormat("yyyy-MM-dd-hh-mm-ss");
		if (status.equals("fail")){
			destdir="screenshot/Failures";
		}else if(status.equals("success")){
			destdir = "screenshot/Success";
		}else if(status.equals("failedButWithinSuccessPercentage")){
			destdir = "screenshot/failedButWithinSuccessPercentage";
		}
		new File(destdir).mkdirs();
		String destFile = runtimeMethod+"."+dateformat.format(new Date())+".png";
		try {
			FileUtils.copyFile(fireSrc, new File(destdir+"/"+destFile));
		} catch (IOException e) {
			System.out.println("scren capture is wrong");
			e.printStackTrace();
		}
		
	}
	
	

}
