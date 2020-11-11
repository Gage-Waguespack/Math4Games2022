using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{

    public class Vector4
    {
        private float _w;
        private float _x;
        private float _y;
        private float _z;

        public float W
        {
            get
            {
                return _w;
            }
            set
            {
                _w = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public float Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
            }
        }

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
            }
        }

        public Vector4 Normalized
        {
            get
            {
                return Normalize(this);
            }
        }



        public Vector4()
        {
            _w = 0;
            _x = 0;
            _y = 0;
            _z = 0;
        }

        public Vector4(float w, float x, float y, float z)
        {
            _w = w;
            _x = x;
            _y = y;
            _z = z;
        }
        public static Vector4 Normalize(Vector4 vector)
        {
            if (vector.Magnitude == 0)
                return new Vector4();

            return vector / vector.Magnitude;
        }
        public static float DotProduct(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.W * rhs.W) + (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * rhs.Z);
        }

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.W + rhs.W, lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        }

        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.W - rhs.W, lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }

        public static Vector4 operator *(Vector4 lhs, float scaler)
        {
            return new Vector4(lhs.W * scaler, lhs.X * scaler, lhs.Y * scaler, lhs.Z * scaler);
        }

        public static Vector4 operator /(Vector4 lhs, float scalar)
        {
            return new Vector4(lhs.W / scalar, lhs.X / scalar, lhs.Y / scalar, lhs.Z / scalar);
        }
    }
}
