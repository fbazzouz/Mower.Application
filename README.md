# Mower.Application
## Description
Program used to get mowers position after set of mouvement from an input file 

## Approach and implementation 
### Multithreading 
Using the parallel class to run the processing into different threads, also the use of ConcurrentDictionary to be able to store the result in the same order of input file
### Tests 
The tests were implemented using  xUnit and FluentAssertions 

## How to run 
Replace the input file content with your mowers initial state and lawn top corner coordinates
### Using Docker 
Using the command `docker-compose up` (Docker and Docker-compose need to be installed on the machine)
### Using Dotnet Cli
Before running the command, when need to switch directory to ./src, then run `dotnet run` (Dotnet cli need to be installed on the machine, and also .net sdk)
### Running tests 
Using `dotnet test build.sln` on the root folder or `dotnet test Mower.Application.Tests.csproj` on ./tests folder

## Samples
Input file : 

```
5 5
1 2 N
LFLFLFLFF
3 3 E
FFRFFRFRRF
```

Output : 

```
1 3 N
5 1 E
```