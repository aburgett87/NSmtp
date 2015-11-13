@ECHO OFF
SETLOCAL
IF [%1] == [] (SET CONFIGURATION=Release) ELSE (SET CONFIGURATION=%1)
IF [%2] == [] (SET PLATFORM=x64) ELSE (SET PLATFORM=%2)
REM Create a 'GeneratedReports' folder if it does not exist
if not exist "%~dp0\GeneratedReports" mkdir "%~dp0\GeneratedReports"

REM Run the tests against the targeted output
call :RunOpenCoverUnitTestMetrics
REM Generate the report output based on the test results
if %errorlevel% equ 0 (
 call :RunReportGeneratorOutput
)
exit /b %errorlevel%

:RunOpenCoverUnitTestMetrics
"%~dp0\packages\OpenCover.4.6.166\tools\OpenCover.Console.exe" ^
-register:Path64 ^
-target:"%~dp0\packages\NUnit.Runners.2.6.4\tools\nunit-console.exe" ^
-targetargs:"%~dp0\NSmtpUnitTests\bin\%CONFIGURATION%\NSmtpUnitTests.dll /noshadow /result=GeneratedReports\TestResult.xml" ^
-mergebyhash ^
-skipautoprops ^
-filter:"+[NSmtp]* -[NSmtpUnitTest]*" ^
-output:"%~dp0\GeneratedReports\CoverageReport.xml"
exit /b %errorlevel%

:RunReportGeneratorOutput
"%~dp0\packages\ReportGenerator.2.3.4.0\tools\ReportGenerator.exe" ^
-reports:"%~dp0\GeneratedReports\CoverageReport.xml" ^
-targetdir:"%~dp0\GeneratedReports\ReportGeneratorOutput" ^
exit /b %errorlevel%

