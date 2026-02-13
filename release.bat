@echo off
dotnet build src/Limbo.MetaData --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget