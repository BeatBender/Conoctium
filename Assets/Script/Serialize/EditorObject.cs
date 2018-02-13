using System;
using UnityEngine;

namespace serialize
{
    abstract class EditorObject
    {
        public Vector3 position;
        public Vector3 GetPos()
        {
            return this.position;
        }
        public void SetPos(Vector3 newPos)
        {
            this.position = newPos;
        }
    }
}
