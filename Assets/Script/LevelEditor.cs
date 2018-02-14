using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class LevelEditor : MonoBehaviour {

    public int resolution;
    public GameObject Carre_Prefab;

    private bool[] carre;
    private float carreSize;
    

    private void Awake()
    {
        carre = new bool[resolution * resolution];
        carreSize = 1f * resolution * 0.05f;

        for (int i = 0, y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++, i++)
            {
                CreateVoxel(i, x, y);
            }
        }
       
    }

    private void CreateVoxel(int i, int x, int y)
    {
        GameObject o = Instantiate(Carre_Prefab) as GameObject;
        o.transform.parent = transform;
        o.transform.localPosition = new Vector3((x + 0.5f) * carreSize, (y + 0.5f) * carreSize);
        o.transform.localScale = Vector3.one * carreSize * 0.95f;
    }


}
