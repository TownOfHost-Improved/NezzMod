/* WILLS - v1.6.0
using static NEZZ.Utils;
using System;

namespace NEZZ.Modules;
internal class WillManager
{
    public static bool On = true;
    private static byte JournalistId;
    public static Dictionary<byte, string> Notes = [];
    private static bool Sent;

    public static void OnReportDeadBody(NetworkedPlayerInfo deadBody)
    {
        if (deadBody == null) return;
        if (Notes[deadBody.PlayerId] == null) return;
        if (Sent == true) return;
        SendMessage(Notes[deadBody.PlayerId], title: Translator.GetString("WillNotesTitle"));
        Sent = true;
    }
}
*/
