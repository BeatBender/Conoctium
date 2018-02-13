using System;
using UnityEngine;

namespace serialize
{
    class Checkpoint: EditorObject
    {
        public Checkpoint(Vector3 pos)
        {
            this.position = pos;
        }
    }
}
