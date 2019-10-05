using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWT_dev_server.CWTNet
{
    public class Vector3<T>
    {
        public T X;
        public T Y;
        public T Z;

        public Vector3(T x, T y, T z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3()
        {
        }

        public virtual void Serialize(ref BinaryWriter wtr)
        {
            throw new NotImplementedException();
        }

        public virtual void Deserialize(ref BinaryReader rdr)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("<X: {0}, Y: {1}, Z: {2}>", X, Y, Z);
        }
    }

    public class Vector3Int64 : Vector3<Int64>
    {
        public Vector3Int64(Int64 x, Int64 y, Int64 z) : base(x, y, z)
        {
        }

        public Vector3Int64(ref BinaryReader rdr)
        {
            Deserialize(ref rdr);
        }

        public override void Serialize(ref BinaryWriter wtr)
        {
            wtr.Write(X);
            wtr.Write(Y);
            wtr.Write(Z);
        }

        public override void Deserialize(ref BinaryReader rdr)
        {
            X = rdr.ReadInt64();
            Y = rdr.ReadInt64();
            Z = rdr.ReadInt64();
        }
    }

    public class Vector3Float32 : Vector3<float>
    {
        public Vector3Float32(float x, float y, float z) : base(x, y, z)
        {
        }

        public Vector3Float32(ref BinaryReader rdr)
        {
            Deserialize(ref rdr);
        }

        public override void Serialize(ref BinaryWriter wtr)
        {
            wtr.Write(X);
            wtr.Write(Y);
            wtr.Write(Z);
        }

        public override void Deserialize(ref BinaryReader rdr)
        {
            X = rdr.ReadSingle();
            Y = rdr.ReadSingle();
            Z = rdr.ReadSingle();
        }
    }

    public class Vector2<T>
    {
        public T X;
        public T Y;

        public Vector2(T x, T y)
        {
            X = x;
            Y = y;
        }

        public Vector2()
        {

        }

        public Vector2(ref BinaryReader rdr)
        {
            Deserialize(ref rdr);
        }

        public virtual void Serialize(ref BinaryWriter wtr)
        {
            throw new NotImplementedException();
        }

        public virtual void Deserialize(ref BinaryReader rdr)
        {
            throw new NotImplementedException();
        }
    }

    public class Vector2Int32 : Vector2<Int32>
    {
        public Vector2Int32()
        {

        }

        public Vector2Int32(Int32 x, Int32 y) : base(x, y)
        {
        }

        public Vector2Int32(ref BinaryReader rdr)
        {
            Deserialize(ref rdr);
        }

        public override void Serialize(ref BinaryWriter wtr)
        {
            wtr.Write(X);
            wtr.Write(Y);
        }

        public override void Deserialize(ref BinaryReader rdr)
        {
            X = rdr.ReadInt32();
            Y = rdr.ReadInt32();
        }
    }

}
