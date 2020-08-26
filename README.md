# SeoTrack

1. Loads mock pages of two search engines (google and bing)
2. Parses those pages to find what positions in the search results is held by https://www.infotrack.com.au
3. Presents results on a web page

# building and running
## from Visual Studio
1. Right click solution and select Restore nuget packages for solution
2. Right click solution and select Restore client side libraries
3. Rebuild solution
4. Run SeoTrack project

## from command line
1. from the root folder of the repository run "dotnet restore"
2. from the SeoTrack folder run "libman restore" (if libman is not istalled first run "dotnet tool install -g Microsoft.Web.LibraryManager.Cli")
3. from the SeoTrack folder run "dotnet run"
4. to run tests from the root of the repository run "dotnet test"

## using docker WIP



# Points of interest

## class structure
Arguably excessive for this task built as a model for more complicated project. Optimized towards extesibility, dependency injection and mockability/testability.

## tchnologies/Libraries
1. Jquery for ajax call
2. libman to keep jquery (and potentially aother libs in the future) from git repository to keep it light
3. dependency injection
4. ASP.net core to be able to wrap build/exection in a lightweight linux docker container
5. NUnit, moq to make sure that classes meet requirements that were set

