using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using Cygnus;

public class Osu : ModuleBase
{

    HttpClient Client = new HttpClient();
    [Command("osu"), Summary("Retrieves user's osu information.")]
    [Alias("o")]
    public async Task Fetch([Summary("The text to echo")] string user, string mode = "0" )
    {
        // Handle possible user inputs.  Defaults to standard.
        switch (mode)
        {
            case "0":
            case "standard":
            case "std": mode = "0"; break;
            case "1":
            case "Taiko": mode = "1"; break;
            case "2":
            case "CtB":
            case "ctb":
            case "CTB": mode = "2"; break;
            case "3":
            case "mania": mode = "3"; break;
            default: mode = "0"; break;
        }

        // Send a request to the osu api using the user's information, then close the request.
        
        var uri = new Uri("https://osu.ppy.sh/api/get_user?u=" + user + "&k=" + Keys.Osu_key + "&m=" + mode);
        var content = await Client.GetStringAsync(uri);
        Client.Dispose();

        if (content.Equals("[]"))
        {
            await ReplyAsync("User: " + user + " not found.");

        }

        // Convert the returned JSON into an OsuPlayer object.
        var player = JsonConvert.DeserializeObject<List<OsuPlayer>>(content);

        // Build the embed to be pasted back to the user.
        var embed = new EmbedBuilder()
            .WithColor(new Color(239, 109, 168))
            .AddField("User Name", player[0].Username)
            .AddField("Play Count", player[0].Playcount)
            .AddField("PP Rank", player[0].PP_rank)
            .AddField("Accuracy", player[0].Accuracy.Substring(0, 5) + "%")
            .AddField($"{player[0].Country} Rank", player[0].PP_country_rank);

        // Send an empty string and the embed.
        await Context.Channel.SendMessageAsync("", false, embed);
    }
}
