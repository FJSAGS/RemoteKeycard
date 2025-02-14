using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.API.Enums;
using System.ComponentModel;
using Player = Exiled.Events.Handlers.Player;

namespace ClassLibrary3
{
    public class RemoteKeycard : Plugin<Config>
    {
        public override string Name => "RemoteKeycard";
        public override string Prefix => "remotekeycard";
        public override string Author => "FJSAGS";
        public static RemoteKeycard Instance;
        public override void OnEnabled()
        {
            Log.Info("Plugin Enabled");
            Instance = this;
            Player.InteractingDoor += EventHandlers.InteractingDoor.InteractDoor;
            Player.InteractingLocker += EventHandlers.InteractingLocker.LockerInteraction;
            Player.UnlockingGenerator += EventHandlers.UnlockingGenerator.OnGeneratorUnlock;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Instance = null;
            Player.InteractingDoor -= EventHandlers.InteractingDoor.InteractDoor;
            Player.InteractingLocker -= EventHandlers.InteractingLocker.LockerInteraction;
            Player.UnlockingGenerator -= EventHandlers.UnlockingGenerator.OnGeneratorUnlock;
            base.OnDisabled();
        }
    }
}
