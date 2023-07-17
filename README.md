# Resources:
    - This code is based on: https://learn.microsoft.com/en-us/azure/azure-signalr/signalr-quickstart-dotnet-core
    - Troubleshooting SignalR: https://learn.microsoft.com/en-us/azure/azure-signalr/signalr-howto-troubleshoot-guide
    - Samples: https://github.com/aspnet/AzureSignalR-samples
    - Server Side Code concepts: https://learn.microsoft.com/en-us/aspnet/core/signalr/hubs?view=aspnetcore-7.0
    - 

# Build & Run:
## Create Azure Signal R Service
1) Create Azure Signal R Service via the Portal
2) For simplicity, add CORS "*"

## Build & Run the Code locally:
1) Go to "src" folder
2) run: dotnet user-secrets set Azure:SignalR:ConnectionString "<your connection string>"
3) run: dotnet run
4) Open 2 browsers pointing to the local server endpoint and start playing

## Build & Run from Azure Web App
1) Create Web App from Portal or Publish the Application via Visual Studio
   1.1) Enable "Basic" Authentication from Web App to enable manual publishing
2) Make sure WebSockets and ARR Affinity are set to "On" in the Web App settings  