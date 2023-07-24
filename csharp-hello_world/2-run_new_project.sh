#!/usr/bin/env bash

project_name="2-new_project"
mkdir "$project_name"

cd "$project_name"

dotnet new console
dotnet build
dotnet run
