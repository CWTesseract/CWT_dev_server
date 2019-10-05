using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWT_dev_server.CWTNet.Packets.Shared
{
    public static class BitSetExtensions
    {
        public static bool IsBitSet(this UInt64 data, int bitPos)
        {
            return ((1UL << bitPos) & data) != 0;
        }
    };

    public class CreatureUpdateData
    {
        public UInt64 GUID;
        public Vector3Int64 Position;
        public Vector3Float32 Rotation;
        public Vector3Float32 Velocity;
        public Vector3Float32 Accel;
        public Vector3Float32 Retreat;
        public float? HeadRotation;
        public UInt32? PhysicsFlags;
        public byte? HostilityOrAIType;
        public UInt32? Race;
        public byte? ActionID;
        public float? ActionTimer;
        public UInt32? ComboHits;
        public float? TimeSinceLastComboHit;
        public byte[] AppearanceData; // byte[176]
        public UInt16? BinaryToggles;
        public float? RollTime;
        public float? StunTime;
        public float? SomeAnimationTime;
        public float? SpeedSlowedForTime;
        public float? SpeedBoostedForTime;
        public float? UnkFloat_0;
        public Int32? Level;
        public Int32? Exp;
        byte? Class;
        byte? Specialization;
        float? SomeFloat0to1MPCostPinkBarBackgroundFill;
        Vector3Float32 UnkVector3Float32_0;
        Vector3Float32 UnkVector3Float32_1;
        Vector3Float32 CameraLookingAtBlockOffset;
        public float? HP;
        public float? MP;
        public float? Stealth;
        float? UnkFloat_1;
        float? CurrentMovementTypeSpeed;
        float? LightDiameter;
        byte? UnkByte_0_ForCampfireParticles;
        byte? UnkByte_1;
        UInt64? UnkUint64_0;
        UInt64? UnkUint64_1;
        Vector2Int32 EagleFlyingToZonePos;
        Vector2Int32 SomeZonePos; // Maybe spawn zone?
        Vector3Int64 EagleFlyingFromCoords;
        byte[] UnkItem; // cube::Item, byte[0xA0]
        byte[] WornEquipment; // cube::Item[11], byte[0xA0*11]
        public byte[] name; // byte[16]
        public UInt64? ClientSteamID;
        byte? UnkByte_2;
        Int32? UnkInt32_0;
        UInt64? UnkUint64_2;

        public void CreatureUpdate()
        {

        }

        public void Serialize(ref BinaryWriter wtr)
        {
            var internalMs = new MemoryStream();
            var internalWtr = new BinaryWriter(internalMs);

            // Write the GUID
            internalWtr.Write(GUID);

            // Write bitfield, which will be overwritten later with real data
            var bitfieldPos = internalMs.Position;
            UInt64 bitfield = 0;
            internalWtr.Write(bitfield);


            // Write our optional data.
            if(Position != null)
            {
                bitfield &= (1u << 0);
                Position.Serialize(ref internalWtr);
            }
            if(Rotation != null)
            {
                bitfield &= (1u << 1);
                Rotation.Serialize(ref internalWtr);
            }
            if(Velocity != null)
            {
                bitfield &= (1u << 2);
                Velocity.Serialize(ref internalWtr);
            }
            if (Accel != null)
            {
                bitfield &= (1u << 3);
                Accel.Serialize(ref internalWtr);
            }
            if (Retreat != null)
            {
                bitfield &= (1u << 4);
                Retreat.Serialize(ref internalWtr);
            }
            if (HeadRotation != null)
            {
                bitfield &= (1u << 5);
                internalWtr.Write(HeadRotation.Value);
            }
            if (PhysicsFlags != null)
            {
                bitfield &= (1u << 6);
                internalWtr.Write(PhysicsFlags.Value);
            }
            if (HostilityOrAIType != null)
            {
                bitfield &= (1u << 7);
                internalWtr.Write(HostilityOrAIType.Value);
            }
            if (Race != null)
            {
                bitfield &= (1u << 8);
                internalWtr.Write(Race.Value);
            }
            if (ActionID != null)
            {
                bitfield &= (1u << 9);
                internalWtr.Write(ActionID.Value);
            }
            if (ActionTimer != null)
            {
                bitfield &= (1u << 10);
                internalWtr.Write(ActionTimer.Value);
            }
            if (ComboHits != null)
            {
                bitfield &= (1u << 11);
                internalWtr.Write(ComboHits.Value);
            }
            if (TimeSinceLastComboHit != null)
            {
                bitfield &= (1u << 12);
                internalWtr.Write(TimeSinceLastComboHit.Value);
            }
            if (AppearanceData != null && AppearanceData.Length == 176)
            {
                bitfield &= (1u << 13);
                internalWtr.Write(AppearanceData);
            }
            if (BinaryToggles != null)
            {
                bitfield &= (1u << 14);
                internalWtr.Write(BinaryToggles.Value);
            }
            if (RollTime != null)
            {
                bitfield &= (1u << 15);
                internalWtr.Write(RollTime.Value);
            }
            if (StunTime != null)
            {
                bitfield &= (1u << 16);
                internalWtr.Write(StunTime.Value);
            }
            if (SomeAnimationTime != null)
            {
                bitfield &= (1u << 17);
                internalWtr.Write(SomeAnimationTime.Value);
            }
            if (SpeedSlowedForTime != null)
            {
                bitfield &= (1u << 18);
                internalWtr.Write(SpeedSlowedForTime.Value);
            }
            if (SpeedBoostedForTime != null)
            {
                bitfield &= (1u << 19);
                internalWtr.Write(SpeedBoostedForTime.Value);
            }
            if (UnkFloat_0 != null)
            {
                bitfield &= (1u << 20);
                internalWtr.Write(UnkFloat_0.Value);
            }
            if (Level != null)
            {
                bitfield &= (1u << 21);
                internalWtr.Write(Level.Value);
            }
            if (Exp != null)
            {
                bitfield &= (1u << 22);
                internalWtr.Write(Exp.Value);
            }
            if (Class != null)
            {
                bitfield &= (1u << 23);
                internalWtr.Write(Class.Value);
            }
            if (Specialization != null)
            {
                bitfield &= (1u << 24);
                internalWtr.Write(Specialization.Value);
            }
            if (SomeFloat0to1MPCostPinkBarBackgroundFill != null)
            {
                bitfield &= (1u << 25);
                internalWtr.Write(SomeFloat0to1MPCostPinkBarBackgroundFill.Value);
            }
            if (UnkVector3Float32_0 != null)
            {
                bitfield &= (1u << 26);
                UnkVector3Float32_0.Serialize(ref internalWtr);
            }
            if (UnkVector3Float32_1 != null)
            {
                bitfield &= (1u << 27);
                UnkVector3Float32_1.Serialize(ref internalWtr);
            }
            if (CameraLookingAtBlockOffset != null)
            {
                bitfield &= (1u << 28);
                CameraLookingAtBlockOffset.Serialize(ref internalWtr);
            }
            if (HP != null)
            {
                bitfield &= (1u << 29);
                internalWtr.Write(HP.Value);
            }
            if (MP != null)
            {
                bitfield &= (1u << 30);
                internalWtr.Write(MP.Value);
            }
            if (Stealth != null)
            {
                bitfield &= (1u << 31);
                internalWtr.Write(Stealth.Value);
            }
            if (UnkFloat_1 != null)
            {
                bitfield &= (1u << 32);
                internalWtr.Write(UnkFloat_1.Value);
            }
            if (CurrentMovementTypeSpeed != null)
            {
                bitfield &= (1u << 33);
                internalWtr.Write(CurrentMovementTypeSpeed.Value);
            }
            if (LightDiameter != null)
            {
                bitfield &= (1u << 34);
                internalWtr.Write(LightDiameter.Value);
            }
            if (UnkByte_0_ForCampfireParticles != null)
            {
                bitfield &= (1u << 35);
                internalWtr.Write(UnkByte_0_ForCampfireParticles.Value);
            }
            if (UnkByte_1 != null)
            {
                bitfield &= (1u << 36);
                internalWtr.Write(UnkByte_1.Value);
            }
            if (UnkUint64_0 != null)
            {
                bitfield &= (1u << 37);
                internalWtr.Write(UnkUint64_0.Value);
            }
            if (UnkUint64_1 != null)
            {
                bitfield &= (1u << 38);
                internalWtr.Write(UnkUint64_1.Value);
            }
            if (EagleFlyingToZonePos != null)
            {
                bitfield &= (1u << 39);
                EagleFlyingToZonePos.Serialize(ref internalWtr);
            }
            if (SomeZonePos != null)
            {
                bitfield &= (1u << 40);
                SomeZonePos.Serialize(ref internalWtr);
            }
            if (EagleFlyingFromCoords != null)
            {
                bitfield &= (1u << 41);
                EagleFlyingFromCoords.Serialize(ref internalWtr);
            }
            if (UnkItem != null && UnkItem.Length == 0xA0)
            {
                bitfield &= (1u << 42);
                internalWtr.Write(UnkItem);
            }
            if (WornEquipment != null && WornEquipment.Length == (0xA0 * 11))
            {
                bitfield &= (1u << 43);
                internalWtr.Write(WornEquipment);
            }
            if (name != null && name.Length == 16)
            {
                bitfield &= (1u << 44);
                internalWtr.Write(name);
            }
            if (ClientSteamID != null)
            {
                bitfield &= (1u << 45);
                internalWtr.Write(ClientSteamID.Value);
            }
            if (UnkByte_2 != null)
            {
                bitfield &= (1u << 46);
                internalWtr.Write(UnkByte_2.Value);
            }
            if (UnkInt32_0 != null)
            {
                bitfield &= (1u << 47);
                internalWtr.Write(UnkInt32_0.Value);
            }
            if (UnkUint64_2 != null)
            {
                bitfield &= (1u << 48);
                internalWtr.Write(UnkUint64_2.Value);
            }

            internalWtr.Flush();


            // Now update the bitfield.
            var curPos = internalMs.Position;
            try
            {
                internalMs.Position = bitfieldPos;
                var bw = new BinaryWriter(internalMs);
                bw.Write(bitfield);
                bw.Flush();
            }
            finally
            {
                internalMs.Position = curPos;
            }

            var rawData = internalMs.ToArray();
            var compressedData = Util.Zlib.Compress(rawData);

            wtr.Write((UInt32)compressedData.Length);
            wtr.Write(compressedData);

        }

        public void Deserialize(ref BinaryReader rdr)
        {
            var size = rdr.ReadUInt32();
            var compressedData = rdr.ReadBytes((int)size);
            var data = Util.Zlib.Decompress(compressedData);

            var ms = new MemoryStream(data);
            var br = new BinaryReader(ms);

            var guid = br.ReadUInt64();
            var bitfield = br.ReadUInt64();

            if (bitfield.IsBitSet(0))
            {
                Position = new Vector3Int64(ref br);
            }
            else if (bitfield.IsBitSet(1))
            {
                Rotation = new Vector3Float32(ref br);
            }
            else if (bitfield.IsBitSet(2))
            {
                Velocity = new Vector3Float32(ref br);
            }
            else if (bitfield.IsBitSet(3))
            {
                Accel = new Vector3Float32(ref br);
            }
            else if (bitfield.IsBitSet(4))
            {
                Retreat = new Vector3Float32(ref br);
            }
            else if (bitfield.IsBitSet(5))
            {
                HeadRotation = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(6))
            {
                PhysicsFlags = br.ReadUInt32();
            }
            else if (bitfield.IsBitSet(7))
            {
                HostilityOrAIType = br.ReadByte();
            }
            else if (bitfield.IsBitSet(8))
            {
                Race = br.ReadUInt32();
            }
            else if (bitfield.IsBitSet(9))
            {
                ActionID = br.ReadByte();
            }
            else if (bitfield.IsBitSet(10))
            {
                ActionTimer = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(11))
            {
                ComboHits = br.ReadUInt32();
            }
            else if (bitfield.IsBitSet(12))
            {
                TimeSinceLastComboHit = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(13))
            {
                Console.WriteLine("GOT APPEARANCE DATA!!!!!!!!!!!");
                AppearanceData = br.ReadBytes(176);
            }
            else if (bitfield.IsBitSet(14))
            {
                BinaryToggles = br.ReadUInt16();
            }
            else if (bitfield.IsBitSet(15))
            {
                RollTime = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(16))
            {
                StunTime = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(17))
            {
                SomeAnimationTime = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(18))
            {
                SpeedSlowedForTime = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(19))
            {
                SpeedBoostedForTime = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(20))
            {
                UnkFloat_0 = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(21))
            {
                Level = br.ReadInt32();
            }
            else if (bitfield.IsBitSet(22))
            {
                Exp = br.ReadInt32();
            }
            else if (bitfield.IsBitSet(23))
            {
                Class = br.ReadByte();
            }
            else if (bitfield.IsBitSet(24))
            {
                Specialization = br.ReadByte();
            }
            else if (bitfield.IsBitSet(25))
            {
                SomeFloat0to1MPCostPinkBarBackgroundFill = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(26))
            {
                UnkVector3Float32_0 = new Vector3Float32(ref br);
            }
            else if (bitfield.IsBitSet(27))
            {
                UnkVector3Float32_1 = new Vector3Float32(ref br);
            }
            else if (bitfield.IsBitSet(28))
            {
                CameraLookingAtBlockOffset = new Vector3Float32(ref br);
            }
            else if (bitfield.IsBitSet(29))
            {
                HP = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(30))
            {
                MP = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(31))
            {
                Stealth = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(32))
            {
                UnkFloat_1 = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(33))
            {
                CurrentMovementTypeSpeed = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(34))
            {
                LightDiameter = br.ReadSingle();
            }
            else if (bitfield.IsBitSet(35))
            {
                UnkByte_0_ForCampfireParticles = br.ReadByte();
            }
            else if (bitfield.IsBitSet(36))
            {
                UnkByte_1 = br.ReadByte();
            }
            else if (bitfield.IsBitSet(37))
            {
                UnkUint64_0 = br.ReadUInt64();
            }
            else if (bitfield.IsBitSet(38))
            {
                UnkUint64_1 = br.ReadUInt64();
            }
            else if (bitfield.IsBitSet(39))
            {
                EagleFlyingToZonePos = new Vector2Int32(ref br);
            }
            else if (bitfield.IsBitSet(40))
            {
                SomeZonePos = new Vector2Int32(ref br);
            }
            else if (bitfield.IsBitSet(41))
            {
                EagleFlyingFromCoords = new Vector3Int64(ref br);
            }
            else if (bitfield.IsBitSet(42))
            {
                UnkItem = br.ReadBytes(0xA0);
            }
            else if (bitfield.IsBitSet(43))
            {
                WornEquipment = br.ReadBytes(0xA0 * 11);
            }
            else if (bitfield.IsBitSet(44))
            {
                name = br.ReadBytes(16);
            }
            else if (bitfield.IsBitSet(45))
            {
                ClientSteamID = br.ReadUInt64();
            }
            else if (bitfield.IsBitSet(46))
            {
                UnkByte_2 = br.ReadByte();
            }
            else if (bitfield.IsBitSet(47))
            {
                UnkInt32_0 = br.ReadInt32();
            }
            else if (bitfield.IsBitSet(48))
            {
                UnkUint64_2 = br.ReadUInt64();
            }
        }

        public string ChangesToString(int indent=0)
        {
            StringBuilder sb = new StringBuilder();
            string indents = "";
            for (int i = 0; i < indent; i++)
            {
                indents += "\t";
            }

            if (Position != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "Position", Position.ToString()));
            }
            if (Rotation != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "Rotation", Rotation.ToString()));
            }
            if (Velocity != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "Velocity", Velocity.ToString()));
            }
            if (Accel != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "Accel", Accel.ToString()));
            }
            if (Retreat != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "Retreat", Retreat.ToString()));
            }
            if (HeadRotation != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "HeadRotation", HeadRotation));
            }
            if (PhysicsFlags != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "PhysicsFlags", PhysicsFlags));
            }
            if (HostilityOrAIType != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "HostilityOrAIType", HostilityOrAIType));
            }
            if (Race != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "Race", Race));
            }
            if (ActionID != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "ActionID", ActionID));
            }
            if (ActionTimer != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "ActionTimer", ActionTimer));
            }
            if (ComboHits != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "ComboHits", ComboHits));
            }
            if (TimeSinceLastComboHit != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "TimeSinceLastComboHit", TimeSinceLastComboHit));
            }
            if (AppearanceData != null && AppearanceData.Length == 176)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "AppearanceData", "(176) bytes"));
            }
            if (BinaryToggles != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "BinaryToggles", BinaryToggles));
            }
            if (RollTime != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "RollTime", RollTime));
            }
            if (StunTime != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "StunTime", StunTime));
            }
            if (SomeAnimationTime != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "SomeAnimationTime", SomeAnimationTime));
            }
            if (SpeedSlowedForTime != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "SpeedSlowedForTime", SpeedSlowedForTime));
            }
            if (SpeedBoostedForTime != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "SpeedBoostedForTime", SpeedBoostedForTime));
            }
            if (UnkFloat_0 != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "UnkFloat_0", UnkFloat_0));
            }
            if (Level != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "Level", Level));
            }
            if (Exp != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "Exp", Exp));
            }
            if (Class != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "Class", Class));
            }
            if (Specialization != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "Specialization", Specialization));
            }
            if (SomeFloat0to1MPCostPinkBarBackgroundFill != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "SomeFloat0to1MPCostPinkBarBackgroundFill", SomeFloat0to1MPCostPinkBarBackgroundFill));
            }
            if (UnkVector3Float32_0 != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "UnkVector3Float32_0", UnkVector3Float32_0.ToString()));
            }
            if (UnkVector3Float32_1 != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "UnkVector3Float32_1", UnkVector3Float32_1.ToString()));
            }
            if (CameraLookingAtBlockOffset != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "CameraLookingAtBlockOffset", CameraLookingAtBlockOffset.ToString()));
            }
            if (HP != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "HP", HP));
            }
            if (MP != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "MP", MP));
            }
            if (Stealth != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "Stealth", Stealth));
            }
            if (UnkFloat_1 != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "UnkFloat_1", UnkFloat_1));
            }
            if (CurrentMovementTypeSpeed != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "CurrentMovementTypeSpeed", CurrentMovementTypeSpeed));
            }
            if (LightDiameter != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "LightDiameter", LightDiameter));
            }
            if (UnkByte_0_ForCampfireParticles != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "UnkByte_0_ForCampfireParticles", UnkByte_0_ForCampfireParticles));
            }
            if (UnkByte_1 != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "UnkByte_1", UnkByte_1));
            }
            if (UnkUint64_0 != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "UnkUint64_0", UnkUint64_0));
            }
            if (UnkUint64_1 != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "UnkUint64_1", UnkUint64_1));
            }
            if (EagleFlyingToZonePos != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "EagleFlyingToZonePos", EagleFlyingToZonePos.ToString()));
            }
            if (SomeZonePos != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "SomeZonePos", SomeZonePos.ToString()));
            }
            if (EagleFlyingFromCoords != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "EagleFlyingFromCoords", EagleFlyingFromCoords.ToString()));
            }
            if (UnkItem != null && UnkItem.Length == 0xA0)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "UnkItem", "(0xA0) bytes"));
            }
            if (WornEquipment != null && WornEquipment.Length == (0xA0 * 11))
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "WornEquipment", "(0xA0 * 11) bytes"));
            }
            if (name != null && name.Length == 16)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "Name", Encoding.Unicode.GetString(name)));
            }
            if (ClientSteamID != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "ClientSteamID", ClientSteamID));
            }
            if (UnkByte_2 != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "UnkByte_2", UnkByte_2));
            }
            if (UnkInt32_0 != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "UnkInt32_0", UnkInt32_0));
            }
            if (UnkUint64_2 != null)
            {
                sb.Append(string.Format("{0}{1}: {2}\n", indents, "UnkUint64_2", UnkUint64_2));
            }

            return sb.ToString();
        }
    }
}
