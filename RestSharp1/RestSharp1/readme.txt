
1. Use vstest.console.exe (Run on dotnet Framework)
Run from console:
- Set env path to: C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\Extensions\TestPlatform for exe file vstest.console.exe
- Go to debug folder of dll and run:

	vstest.console.exe "C:\Users\Huy\source\repos\restsharp_dotnet\RestSharp1\RestSharp1\bin\Debug\netcoreapp3.1\RestSharp1.dll" /logger:trx

	or 

	vstest.console.exe "C:\Users\Huy\source\repos\restsharp_dotnet\RestSharp1\RestSharp1\bin\Debug\netcoreapp3.1\RestSharp1.dll" /logger:html

	And go to below folder to view log:
	C:\Users\Huy\source\repos\restsharp_dotnet\RestSharp1\RestSharp1\bin\Release\netcoreapp3.1\TestResults
	If export trx file, and use additional app to parse and view: https://archive.codeplex.com/?p=trx2html



Note:
Use MSTest.exe (only run on dotnet core, The older, now deprecated tool is mstest.exe)
If you want to use mstest.exe, you need following reference in your project file:

- Set env path to: C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE
	MSTest.exe /testcontainer:"C:\Users\Huy\source\repos\restsharp_dotnet\RestSharp1\RestSharp1\bin\Debug\netcoreapp3.1\RestSharp1.dll"

