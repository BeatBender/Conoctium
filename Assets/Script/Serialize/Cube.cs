using System;
using UnityEngine;

namespace serialize
{
    class Cube : EditorObject
    {
        public Vector3 rotation;
        public Vector3 scale;

        public Cube(Vector3 pos, Vector3 rot, Vector3 scale)
        {
            this.position = pos;
            this.rotation = rot;
            this.scale = scale;
        }
        
    }
}
