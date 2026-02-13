@echo off
dotnet build src/Limbo.MetaData --configuration Debug /t:rebuild /t:pack -p:PackageOutputPath=c:/nuget