using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class GrillageEditor : MonoBehaviour {

    public Vector2Int resolution;
    public GameObject Carre_Prefab;

    private float carreSize;
	private float decalage = .05f;    

    private void Awake() {
        carreSize = .9f;
        for (int i = 0, y = 0; y < resolution.y; y++) {
            for (int x = 0; x < resolution.x; x++, i++) {
                CreateVoxel(x, y);
            }
        }       
    }

    private void CreateVoxel(int x, int y) {
        GameObject o = Instantiate(Carre_Prefab) as GameObject;
        o.transform.parent = transform;
		o.transform.localPosition = new Vector3(x + (x - 1) * decalage, y + (y - 1) * decalage);
        o.transform.localScale = Vector3.one * carreSize;
    }
}
