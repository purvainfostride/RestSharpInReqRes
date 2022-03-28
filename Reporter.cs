using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpInReqRes
{
    public static class Reporter
    {
        public static ExtentReports extentReports;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest testCase;
        public static void SetupExtentReporter(string reportName, string documentTitle, dynamic path)
        {
            htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            htmlReporter.Config.DocumentTitle = documentTitle;
            htmlReporter.Config.ReportName = reportName;

            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extentReports = extent;
        }
        public static void CreateTest(string testName)
        {
            testCase = extentReports.CreateTest(testName);
        }
        public static void LogToReport(Status status, string message)
        {
            testCase.Log(status, message);
        }
        public static void FlushReport()
        {
            extentReports.Flush();
        }
        public static void TestStatus(string status)
        {
            if (status.Equals("Pass"))
            {
                testCase.Pass("Test is Passed");
            }
            else
            {
                testCase.Fail("Test is Failed");
            }
        }

    }
}
