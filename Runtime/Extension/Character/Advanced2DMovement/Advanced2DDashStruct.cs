using System;
using UnityEngine;

namespace itismarciiExtansion.Runtime.Extension.Character.Advanced2DMovement
{
    public struct Advanced2DDashStruct
    {
        internal readonly Advanced2DDashParam Param;
        internal readonly Rigidbody2D Rgb;
        internal readonly Transform Transform;
        internal float Timer;
        public bool IsDashing { get; internal set; }
        internal Vector2 Forward;
        internal Vector2 StartPos;
        internal Vector2 EndPos;
        public Action OnInit, OnFinish;

        public Advanced2DDashStruct(in Rigidbody2D rgb, in Advanced2DDashParam param)
        {
            Rgb = rgb;
            Param = param;
            Transform = rgb.transform;
            
            Timer = 0;
            IsDashing = false;
            Forward = default;
            StartPos = default;
            EndPos = default;
            OnInit = null;
            OnFinish = null;
        }
    }
}
