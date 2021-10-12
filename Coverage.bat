@ECHO ON
SETLOCAL
:: WHERE
set COVER_FOLDER=%CD%
:: WHAT
set COVER_PROJECT=Models.Tests
:: Specify just the 'Models' namespace and all its classes
SET COVER_FILTER="+[Models]*"
:: Via
set COVER_CONSOLE="C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\CommonExtensions\Microsoft\TestWindow\VSTest.Console.exe"
:: Using pacakges
set COVER_NUGET_CACHE=%USERPROFILE%\.nuget\packages

:: Coverage 
SET COVER_EXECUTE="%COVER_NUGET_CACHE%\opencover\4.7.1221\tools\OpenCover.Console.exe"
:: Of
SET COVER_ARGUMENTS="%COVER_FOLDER%\%COVER_PROJECT%\bin\Debug\net5.0\%COVER_PROJECT%.dll"
:: Into
SET COVER_OUTPUT="%COVER_FOLDER%\CoverageResults.xml"

:: Report
SET COVER_REPORT="%COVER_NUGET_CACHE%\ReportGenerator\4.8.13\tools\net5.0\ReportGenerator.exe"
:: Into
SET COVER_REPORT_FOLDER="%COVER_FOLDER%\CoverageReport"
:: View Report
SET COVER_REPORT_FILE=%COVER_REPORT_FOLDER%\Index.html

:: Cover
%COVER_EXECUTE% -target:%COVER_CONSOLE% -targetargs:%COVER_ARGUMENTS% -output:%COVER_OUTPUT% -register:user -filter:%COVER_FILTER% 
:: Report
%COVER_REPORT%  -reports:%COVER_OUTPUT% -targetdir:%COVER_REPORT_FOLDER%
:: View
%COVER_REPORT_FILE%
ENDLOCAL

::C:\Users\Iain.Stevenson\.nuget\packages\reportgenerator\4.8.13\tools\net5.0