#!/bin/sh
cd TuneSearch/TuneSearch
dotnet build
cd ../TuneSearch.Core.Tests
dotnet test
cd ../TuneSearch.Infrastructure.Tests
dotnet test