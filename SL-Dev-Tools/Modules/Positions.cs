namespace SL_Dev_Tools.Modules
{
    using Exiled.API.Features;
    using ServerLog = Exiled.API.Features.Log;
    using UnityEngine;

    public class Positions
    {
        public static void Log(Player plr, string msg, string id)
        {
            plr.SendConsoleMessage(id, "purple");
            plr.SendConsoleMessage(msg, "purple");
            ServerLog.Info(id);
            ServerLog.Info(msg);
        }

        public static void GetPos(Player plr)
        {
            // player position / local position
            Log(plr, plr.Position.ToString(), "Player Pos");

            // player rotation
            Log(plr, plr.Rotation.ToString(), "Player Rotation");

            Room room = Room.Get(plr.Position);
            Log(plr, room.Position.ToString(), "Room Pos");

            // room rotation
            Log(plr, room.Rotation.ToString(), "Room Rotation");

            // world position
            Log(plr, room.WorldPosition(new(0.0f, 0.0f, 0.0f)).ToString(), "Room World Pos");

            // x,y,z rotation based on quaternion return
            Log(plr, (room.Rotation * new Vector3(1, 2, 3)).ToString(), "Rotation value (x,y,z) = (1,2,3)");

            // room type name
            Log(plr, room.Type.ToString(), "Room type enum");
        }
    }
}
