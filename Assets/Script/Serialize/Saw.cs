using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace serialize
{
    class Saw : EditorObject
    {
        public Vector3 position2;
        public Vector3 scale;
        public Saw(Vector3 pos1, Vector3 pos2, Vector3 sc1)
        {
            this.position = pos1;
            this.position2 = pos2;
            this.scale = sc1;
        }
    }
}
