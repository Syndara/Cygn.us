using System.Threading.Tasks;
using Discord;
using Discord.Commands;

public class Avatar : ModuleBase
{
    [Command("avatar"), Summary("Displays a user's avatar.")]
    [Alias("av", "pic")]
    public async Task GetAvatar([Remainder, Summary("Displays a user's avatar")] IUser user = null)
    {
        // ReplyAsync is a method on ModuleBase
        var userAvatar = user ?? Context.Client.CurrentUser;
        var avURL = userAvatar.GetAvatarUrl();
        avURL = avURL.Substring(0, avURL.Length - 9);
        if (avURL.Contains("png"))
            avURL = avURL.Insert(avURL.Length, "?size=1024");
               
        await ReplyAsync(avURL);
    }
}
