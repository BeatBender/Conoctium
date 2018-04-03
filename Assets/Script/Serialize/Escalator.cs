using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace serialize
{
    class Escalator : EditorObject
    {
        public Vector3 position2;
        public Vector3 scale;

        public Escalator(Vector3 pos1, Vector3 pos2, Vector3 sc)
        {
            this.position = pos1;
            this.position2 = pos2;
            this.scale = sc;
        }
    }
}
