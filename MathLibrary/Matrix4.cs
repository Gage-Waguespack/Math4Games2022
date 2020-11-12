using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{

    public class Matrix4
    {
        public float m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44;

        public Matrix4()
        {
            m11 = 1; m12 = 0; m13 = 0; m14 = 0;
            m21 = 0; m22 = 1; m23 = 0; m24 = 0;
            m31 = 0; m32 = 0; m33 = 1; m34 = 1;
            m41 = 0; m42 = 0; m43 = 0; m44 = 1;
        }

        public Matrix4(float m11, float m12, float m13, float m14,
                       float m21, float m22, float m23, float m24,
                       float m31, float m32, float m33, float m34,
                       float m41, float m42, float m43, float m44)
        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13; this.m14 = m14;
            this.m21 = m21; this.m22 = m22; this.m23 = m23; this.m24 = m24;
            this.m31 = m31; this.m32 = m32; this.m33 = m33; this.m34 = m34;
            this.m41 = m41; this.m42 = m42; this.m43 = m43; this.m44 = m44;
        }
    }

}
