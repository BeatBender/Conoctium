using System;
using UnityEngine;

namespace serialize
{
    class Pique : EditorObject
    {
        public Vector3 rotation;
        public Vector3 scale;

        public Pique(Vector3 pos, Vector3 rot, Vector3 scale)
        {
            this.position = pos;
            this.rotation = rot;
            this.scale = scale;
        }
    }
}
