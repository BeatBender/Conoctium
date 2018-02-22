using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using serialize;

public class SaveManager : MonoBehaviour
{
    public bool saveNow = false;
    public bool loadNow = false;
    // Update is called once per frame
    void Update () {

        if (saveNow)
        {
            saveNow = false;
            Save("FirstMap");
        }
        if (loadNow)
        {
            loadNow = false;
            Load("FirstMap");
        }

    }

    public void Save(string saveName)
    {
        SceneSerializer scene = new SceneSerializer();

        foreach (Transform child in transform)
        {
            switch(child.gameObject.tag)
            {
                case "Sol":
                    scene.AddCube(new Cube(child.position, child.eulerAngles, child.localScale));
                    break;
                case "Radioactive":
                    scene.AddPiques(new Pique(child.position, child.eulerAngles, child.localScale));
                    break;
                case "checkpoint":
                    scene.AddCheckpoints(new Checkpoint(child.position));
                    break;
                case "Player1":
                    scene.player1 = new serialize.Player(child.position);
                    break;
                case "Player2":
                    scene.player2 = new serialize.Player(child.position);
                    break;
                default:

                    break;
            }
            
        }
        var jsonString = JsonConvert.SerializeObject(scene);
        Debug.Log(jsonString);
        System.IO.File.WriteAllText(@"Assets\Saves\" + saveName + ".txt", jsonString);

    }

    public void Load(string fileName)
    {
        //GameObject pique = Instantiate(Resources.Load("prefabPique") as GameObject);

        string text = System.IO.File.ReadAllText(@"Assets\Saves\" + fileName + ".txt");
        SceneSerializer scene = JsonConvert.DeserializeObject<SceneSerializer>(text);

        foreach (Cube cubi in scene.cubes)
        {
            GameObject block = Instantiate(Resources.Load("prefabCube") as GameObject);
            block.GetComponent<Transform>().localScale = cubi.scale;
            block.GetComponent<Transform>().eulerAngles = cubi.rotation;
            block.GetComponent<Transform>().position = cubi.position;
            
        }
        foreach (Pique piqui in scene.piques)
        {
            GameObject pique = Instantiate(Resources.Load("prefabPique") as GameObject);
            pique.GetComponent<Transform>().localScale = piqui.scale;
            pique.GetComponent<Transform>().eulerAngles = piqui.rotation;
            pique.GetComponent<Transform>().position = piqui.position;
        }
        foreach (Checkpoint checki in scene.checkpoints)
        {
            GameObject check = Instantiate(Resources.Load("prefabCheckpoint") as GameObject);
            check.GetComponent<Transform>().position = checki.position;
        }
        bool p1Present = false;
        bool p2Present = false;
        GameObject p1 = null;
        GameObject p2 = null;
        foreach (Transform child in transform)
        {
            if (child.tag == "Player1")
            {
                p1Present = true;
                p1 = child.gameObject;
            }
            if (child.tag == "Player2")
            {
                p2Present = true;
                p2 = child.gameObject;
            }
        }

        if (!p1Present)
        {
            p1 = Instantiate(Resources.Load("prefabPlayer1") as GameObject);
        }
        if (!p2Present)
        {
            p2 = Instantiate(Resources.Load("prefabPlayer2") as GameObject);
        }

        p1.GetComponent<Transform>().position = scene.player1.position;
        p2.GetComponent<Transform>().position = scene.player2.position;

    }
}
