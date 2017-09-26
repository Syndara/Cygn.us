using System.Threading.Tasks;
using System.Reflection;
using System;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Newtonsoft.Json;
using System.IO;
using Cygnus;
using System.Collections.Generic;

public class Program
{
    private CommandService commands;
    private DiscordSocketClient client;
    private String json;

    static void Main(string[] args) => new Program().Start().GetAwaiter().GetResult();

    public async Task Start()
    {
        LoadJson();
        DiscordSocketConfig socketConf = new DiscordSocketConfig();
        socketConf.AlwaysDownloadUsers = true;
        client = new DiscordSocketClient(socketConf);
        CommandServiceConfig serviceConf = new CommandServiceConfig();
        serviceConf.DefaultRunMode = RunMode.Async;
        commands = new CommandService(serviceConf);

        await InstallCommands();
        client.Log += Log;

        await client.LoginAsync(TokenType.Bot, Keys.Discord_key);
        await client.StartAsync();

        await Task.Delay(-1);
    }
    public async Task InstallCommands()
    {
        // Hook the MessageReceived Event into our Command Handler
        client.MessageReceived += HandleCommand;
        // Discover all of the commands in this assembly and load them.
        await commands.AddModulesAsync(Assembly.GetEntryAssembly());
    }

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    public async Task HandleCommand(SocketMessage messageParam)
    {
        // Don't process the command if it was a System Message
        var message = messageParam as SocketUserMessage;
        if (message == null) return;
        // Create a number to track where the prefix ends and the command begins
        int argPos = 0;
        // Determine if the message is a command, based on if it starts with '!' or a mention prefix
        if (!(message.HasStringPrefix("c!", ref argPos) || message.HasMentionPrefix(client.CurrentUser, ref argPos))) return;
        // Create a Command Context
        var context = new CommandContext(client, message);
        // Execute the command. (result does not indicate a return value, 
        // rather an object stating if the command executed succesfully)
        var result = await commands.ExecuteAsync(context, argPos);
        if (!result.IsSuccess)
            await context.Channel.SendMessageAsync(result.ErrorReason);
    }

    public void LoadJson()
    {
        using (StreamReader r = new StreamReader("..\\..\\Keys.json"))
        {
            json = r.ReadToEnd();
        }
    }
}