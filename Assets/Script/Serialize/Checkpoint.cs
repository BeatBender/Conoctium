using System;
using UnityEngine;

namespace serialize
{
    class Checkpoint: EditorObject
    {
        public Vector3 scale;
        public Checkpoint(Vector3 pos, Vector3 sc)
        {
            this.position = pos;
            this.scale = sc;
        }
    }
}
