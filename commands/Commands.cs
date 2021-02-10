using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;

namespace GorgeousBot.commands
{
    public class Commands
    {
        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }

        [Command("add")]
        [Description("Adds two numbers together")]
        [RequireUserPermissions(DSharpPlus.Permissions.ChangeNickname)]
        public async Task Add(CommandContext ctx, int one, int two)
        {
            await ctx.Channel.SendMessageAsync((one + two).ToString()).ConfigureAwait(false);
        }

        [Command("respondmessage")]
        public async Task RespondMessage(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivityModule();

            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(message.Message.Content);
        }

        [Command("respondreaction")]
        public async Task RespondReaction(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivityModule();

            var message = await interactivity.WaitForReactionAsync(x => true).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(message.Emoji);
        }
    }
}
