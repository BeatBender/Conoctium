using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace serialize
{
    class Portal : EditorObject
    {
        public Vector3 position2;
        public Vector3 scale1;
        public Vector3 scale2;
        public Portal(Vector3 pos1, Vector3 pos2, Vector3 sc1, Vector3 sc2)
        {
            this.position = pos1;
            this.position2 = pos2;
            this.scale1 = sc1;
            this.scale2 = sc2;
        }
    }
}
