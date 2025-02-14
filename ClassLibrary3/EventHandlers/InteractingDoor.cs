using Exiled.Events.EventArgs.Player;
using static Exiled.API.Enums.KeycardPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using Exiled.API.Features.Items;
using Exiled.API.Extensions;
using Exiled.API.Features;

namespace ClassLibrary3.EventHandlers
{
    public static class InteractingDoor
    {
        public static void InteractDoor(InteractingDoorEventArgs args) 
        {
            bool Checkp = false;
            bool Cont1 = false;
            bool Cont2 = false;
            bool Cont3 = false;
            bool Armory1 = false;
            bool Armory2 = false;
            bool Armory3 = false;
            bool Exit = false;
            bool ICom = false;
            bool AWarhead = false;
            if (args.Player.HasItem(ItemType.KeycardJanitor)) 
            { 
                Cont1 = true;
                Log.Info("Janitor"); }

            if (args.Player.HasItem(ItemType.KeycardScientist)) 
            { 
                Cont1 = true; 
                Cont2 = true; 
                Log.Info("Scientist"); }

            if (args.Player.HasItem(ItemType.KeycardZoneManager)) 
            { 
                Checkp = true; 
                Cont1 = true;
                Log.Info("ZoneManager"); }

            if (args.Player.HasItem(ItemType.KeycardResearchCoordinator)) 
            { 
                Checkp = true; 
                Cont1 = true; 
                Cont2 = true; 
                Log.Info("ResearchCoordinator"); }

            if (args.Player.HasItem(ItemType.KeycardGuard)) 
            { 
                Checkp = true; 
                Cont1 = true; 
                Armory1 = true;
                Log.Info("Guard"); }

            if (args.Player.HasItem(ItemType.KeycardMTFPrivate)) 
            { 
                Checkp = true; 
                Cont1 = true; 
                Cont2 = true; 
                Armory1 = true;
                Armory2 = true;
                Log.Info("Private"); 
            }

            if (args.Player.HasItem(ItemType.KeycardMTFOperative)) 
            {   
                Checkp = true; 
                Cont1 = true; 
                Cont2 = true; 
                Armory1 = true;
                Armory2 = true;
                Log.Info("Operative"); }

            if (args.Player.HasItem(ItemType.KeycardMTFCaptain) || args.Player.HasItem(ItemType.KeycardChaosInsurgency)) 
            { Checkp = true; 
                Cont1 = true; 
                Cont2 = true; 
                Armory1 = true;
                Armory2 = true;
                Armory3 = true;
                Exit = true; 
                ICom = true; 
                Log.Info("Captain"); }

            if (args.Player.HasItem(ItemType.KeycardFacilityManager)) 
            {   
                Checkp = true;
                Cont1 = true; 
                Cont2 = true;
                Cont3 = true;
                Checkp = true;
                ICom = true; 
                AWarhead = true;
                Log.Info("FacilityManager"); 
            }

            if (args.Player.HasItem(ItemType.KeycardContainmentEngineer))
            {   Checkp = true; 
                Cont1 = true; 
                Cont2 = true; 
                Cont3 = true; 
                Log.Info("ContainmentManager"); }

            if (args.Player.HasItem(ItemType.KeycardO5)) 
            { 
                Checkp = true; 
                Cont1 = true; 
                Cont2 = true; 
                Cont3 = true; 
                Checkp = true;
                ICom = true;
                AWarhead = true;
                Armory1 = true;
                Armory2 = true;
                Armory3 = true;
                Log.Info("O5");
            }

            bool Allow;
            if (args.Door.KeycardPermissions.HasFlag(Checkpoints) && !Checkp) { Allow = false; Log.Info("No Checkpoints perms"); }
            else if (args.Door.KeycardPermissions.HasFlag(ContainmentLevelOne) && !Cont1) { Allow = false; Log.Info("No ContLvl1 perms"); }
            else if (args.Door.KeycardPermissions.HasFlag(ContainmentLevelTwo) && !Cont2) { Allow = false; Log.Info("No ContLvl2 perms"); }
            else if (args.Door.KeycardPermissions.HasFlag(ContainmentLevelThree) && !Cont3) { Allow = false; Log.Info("No Cont Lvl3 perms"); }
            else if (args.Door.KeycardPermissions.HasFlag(ExitGates) && !Exit) { Allow = false; Log.Info("No ExitGates perms"); }
            else if (args.Door.KeycardPermissions.HasFlag(Exiled.API.Enums.KeycardPermissions.Intercom) && !ICom) { Allow = false; Log.Info("No Intercom perms"); }
            else if (args.Door.KeycardPermissions.HasFlag(AlphaWarhead) && !AWarhead) { Allow = false; Log.Info("No AlphaWarhead perms"); }
            else if (args.Door.KeycardPermissions.HasFlag(ArmoryLevelOne) && !Armory1) { Allow = false; Log.Info("No ArmoryLvl1 perms"); }
            else if (args.Door.KeycardPermissions.HasFlag(ArmoryLevelTwo) && !Armory2) { Allow = false; Log.Info("No ArmoryLvl2 perms"); }
            else if (args.Door.KeycardPermissions.HasFlag(ArmoryLevelThree) && !Armory3) { Allow = false; Log.Info("No ArmoryLvl3 perms"); }
            else { Allow = true; Log.Info("Allowed access"); }

            if (Allow && args.Door.IsKeycardDoor && args.IsAllowed == false) { args.IsAllowed = true; }

        }
    }
}
