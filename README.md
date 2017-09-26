# Cygn.us
A Discord Bot written in C# using Discord.NET

Cygnus is a Discord Bot I'm writing to familiarize myself with the C# language, and the utilities provided by .NET

It's currently in a primitive state, and is published here only because I believe all non-proprietary code should be opensource.  I'll be posting updates to the readme as more development comes around.  Currently the bot is rather primitive.

# Commands
All commands are accessed via the prefix of c! or a mention on the bot running the code.

Current commands are as follows:

    c!o || c!osu (username) (mode : defaults to standard)

Returns a user profile for mania formatted with Discord's Embed Border.
    
    c!av || c!avatar (username || usermention : defaults to bot)

Embeds an image of the selected users avatar at the resolution of 1024x1024.  Handles .png and .gif for nitro users.
