using Exiled.Events.EventArgs.Player;
using static Exiled.API.Enums.KeycardPermissions;
using Exiled.API.Features;

namespace ClassLibrary3.EventHandlers
{
    public static class InteractingLocker
    {
        public static void LockerInteraction(InteractingLockerEventArgs args)
        {

            bool SCPLockers = false;
            bool ExpWeapons = false;
            bool Armory2 = false;
            bool Armory1 = false;
            if (args.Player.HasItem(ItemType.KeycardMTFCaptain) || args.Player.HasItem(ItemType.KeycardChaosInsurgency) || args.Player.HasItem(ItemType.KeycardO5))
            {
                SCPLockers = true;
                ExpWeapons = true;
                Armory2 = true;
                Armory1 = true;
            }
            else if (args.Player.HasItem(ItemType.KeycardMTFPrivate) || args.Player.HasItem(ItemType.KeycardMTFOperative))
            {
                SCPLockers = true;
                Armory2 = true;
                Armory1 = true;
            }
            else if (args.Player.HasItem(ItemType.KeycardGuard))
            {
                Armory1 = true;
            }
            if (args.Player.HasItem(ItemType.KeycardResearchCoordinator) || args.Player.HasItem(ItemType.KeycardContainmentEngineer) || args.Player.HasItem(ItemType.KeycardFacilityManager))
            {
                SCPLockers = true;
            }
            // 0 - unknown; 1 - SCP Pedestal; 2 - Large locker; 3 - Experimental Weapons; 4 - Weapon Racks.
            int ChamberType = 0;
            // 0 - unknown; 1 - Small; 2 - Large
            if (args.InteractingChamber.RequiredPermissions.HasFlag(ArmoryLevelOne)) { ChamberType = 1; Log.Info("Locker: Armory1"); }
            else if (args.InteractingChamber.RequiredPermissions.HasFlag(ArmoryLevelTwo)) { ChamberType = 2; Log.Info("Locker: Armory2"); }
            else if (args.InteractingChamber.RequiredPermissions.HasFlag(ArmoryLevelThree)) { ChamberType = 3; Log.Info("Locker: ExpWeapons"); }
            else if (args.InteractingChamber.RequiredPermissions.HasFlag(Checkpoints) && args.InteractingChamber.RequiredPermissions.HasFlag(ContainmentLevelTwo)) { ChamberType = 0; Log.Info("Locker: SCPLocker"); }
            else { Log.Warn("Couldn't determine locker to unlock. Aborting"); return; }
            if (args.IsAllowed == false)
            {
                if (ChamberType == 0) 
                {
                    if (SCPLockers) { args.IsAllowed = true; }
                    else { Log.Info("No SCPLocker permissions"); }
                }
                else if (ChamberType == 1)
                {
                    if (Armory1) { args.IsAllowed = true; }
                    else { Log.Info("No Armory1 permissions"); }
                }
                else if (ChamberType == 2)
                {
                    if (Armory2) { args.IsAllowed = true; } 
                    else { Log.Info("No Armory2 Permissions"); }
                }
                else if (ChamberType == 3) 
                { 
                    if (ExpWeapons) { args.IsAllowed = true; }
                    else { Log.Info("No ExpWeapons permissions"); }
                }

            }
        }
    }
}
