"NugetHelper.exe" dist/lib/net471/MechanicGrip.dll Package.nuspec
del package\*.* /F /Q
"nuget.exe" pack package.nuspec -OutputDirectory Package -BasePath dist
pause