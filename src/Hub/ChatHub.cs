using Microsoft.AspNetCore.SignalR;

public class ChatSampleHub : Hub
{

    [LanguageFilter(FilterArgument = 1)]
    public Task BroadcastFilteredMessage(string name, string message) =>
        Clients.All.SendAsync("broadcastMessage", name, message);


    public Task BroadcastMessage(string name, string message) =>
        Clients.All.SendAsync("broadcastMessage", name, message);

    public Task Echo(string name, string message) =>
        Clients.Client(Context.ConnectionId)
                .SendAsync("echo", name, $"{message} (echo from server)");

    public override Task OnConnectedAsync(){
            return Clients.All.SendAsync("broadcastMessage", "api", $"Connection '{Context.ConnectionId}' is connected.");
    }

    public override Task OnDisconnectedAsync(Exception? exception){
            return Clients.All.SendAsync("broadcastMessage", "api", $"Connection '{Context.ConnectionId}' is disconnected.");
    }

}