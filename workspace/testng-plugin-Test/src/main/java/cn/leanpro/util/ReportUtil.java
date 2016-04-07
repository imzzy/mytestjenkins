package cn.leanpro.util;

import java.io.File;
import java.util.List;
import java.util.Map;
import java.util.Set;

import org.testng.IReporter;
import org.testng.IResultMap;
import org.testng.ISuite;
import org.testng.ISuiteResult;
import org.testng.ITestContext;
import org.testng.ITestResult;
import org.testng.xml.XmlSuite;

import com.relevantcodes.extentreports.ExtentReports;
import com.relevantcodes.extentreports.ExtentTest;
import com.relevantcodes.extentreports.LogStatus;

public class ReportUtil implements IReporter {

	private ExtentReports reports;
	private ExtentTest logger;
	@Override
	public void generateReport(List<XmlSuite> xmlsuites, List<ISuite> suites, String outputDir) {
		
		reports = new ExtentReports(outputDir+File.separator+"report.html", true);
		System.out.println(outputDir+File.separator+"report.html");
		
		for(ISuite suite: suites){
			Map<String, ISuiteResult>  result = suite.getResults();
			
			for(ISuiteResult iresult:result.values()){
				
				ITestContext context = iresult.getTestContext();
				buildTestNodes(context.getPassedTests(), LogStatus.PASS);
				buildTestNodes(context.getFailedTests(), LogStatus.FAIL);
				buildTestNodes(context.getSkippedTests(), LogStatus.SKIP);
			}
		}
		reports.flush();
		reports.close();
		
	}
	
	private void buildTestNodes(IResultMap testcases,LogStatus status){
		
		if(testcases.size()>0){
			Set<ITestResult> iresults = testcases.getAllResults();
			
			for(ITestResult result:iresults){
				logger = reports.startTest(result.getMethod().getMethodName());
				
				for(String group:result.getMethod().getGroups()){
					logger.assignAuthor(group);
				}
				String message = "Test" + status.toString().toLowerCase()+"ed";
				if(result.getThrowable() != null){
					message = result.getThrowable().getMessage();
				}
				logger.log(status, message);
				reports.endTest(logger);
			}
		}
	}
	
	
	 
	

}
