using AmongUs.Data;
using Discord;
using InnerNet;
using System;
using HarmonyLib;

namespace NEZZ.Patches
{
    // Originally from Town of Us Rewritten, by Det
    [HarmonyPatch(typeof(ActivityManager), nameof(ActivityManager.UpdateActivity))]
    public class DiscordRPC
    {
        private static string lobbycode = "";
        private static string region = "";
        public static void Prefix([HarmonyArgument(0)] Activity activity)
        {
            if (activity == null) return;

            var details = $"NEZZ v{Main.PluginDisplayVersion + Main.PluginDisplaySuffix}";
            activity.Details = details;

            activity.Assets = new ActivityAssets
            {
                LargeImage = "https://i.imgur.com/W6HMVgD.png"
            };

            try
            {
                if (activity.State != "In Menus")
                {
                    if (!DataManager.Settings.Gameplay.StreamerMode)
                    {
                        int maxSize = GameOptionsManager.Instance.CurrentGameOptions.MaxPlayers;
                        if (GameStates.IsLobby)
                        {
                            lobbycode = GameCode.IntToGameName(AmongUsClient.Instance.GameId);
                            region = Utils.GetRegionName();
                        }

                        if (lobbycode != "" && region != "")
                        {
                            if (GameStates.IsNormalGame)
                                details = $"NEZZ - {lobbycode} ({region})";

                            else if (GameStates.IsHideNSeek)
                                details = $"NEZZ Hide & Seek - {lobbycode} ({region})";
                        }

                        activity.Details = details;
                    }
                    else
                    {
                        if (GameStates.IsNormalGame)
                            details = $"NEZZ v{Main.PluginDisplayVersion + Main.PluginDisplaySuffix}";

                        else if (GameStates.IsHideNSeek)
                            details = $"NEZZ v{Main.PluginDisplayVersion + Main.PluginDisplaySuffix} - Hide & Seek";

                        else details = $"NEZZ v{Main.PluginDisplayVersion + Main.PluginDisplaySuffix}";

                        activity.Details = details;
                    }
                }
            }

            catch (ArgumentException ex)
            {
                Logger.Error("Error in updating discord rpc", "DiscordPatch");
                Logger.Exception(ex, "DiscordPatch");
                details = $"NEZZ v{Main.PluginDisplayVersion + Main.PluginDisplaySuffix}";
                activity.Details = details;
            }
        }
    }
}
