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
        public Portal(Vector3 pos1, Vector3 pos2)
        {
            this.position = pos1;
            this.position2 = pos2;
        }
    }
}
