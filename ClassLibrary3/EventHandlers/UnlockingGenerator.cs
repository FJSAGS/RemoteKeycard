using Exiled.Events.EventArgs.Player;
using static Exiled.API.Enums.KeycardPermissions;
using Exiled.API.Features;

namespace ClassLibrary3.EventHandlers
{
    public static class UnlockingGenerator
    {
        public static void OnGeneratorUnlock(UnlockingGeneratorEventArgs args)
        {
            bool Allow = false;
            if (args.Player.HasItem(ItemType.KeycardMTFPrivate) || args.Player.HasItem(ItemType.KeycardMTFOperative) 
                || args.Player.HasItem(ItemType.KeycardMTFCaptain) || args.Player.HasItem(ItemType.KeycardChaosInsurgency) || args.Player.HasItem(ItemType.KeycardO5))
            {
                Allow = true;
            }
            if (Allow) { args.IsAllowed = true; }
        }
    }
}
