using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using serialize;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public bool saveNow = false;
    public bool loadNow = false;
    public bool deleteNow = false;
    public bool isEditor = true;
    public int deletedSave = 1;
    // Update is called once per frame

    private void Start()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("LevelInfos");
        Load(temp.GetComponent<Loadinginformations>().LevelLoad);
    }


void Update()
    {

        if (saveNow)
        {
            saveNow = false;
            Save(-1);
        }
        if (loadNow)
        {
            loadNow = false;
            Load(-1);
        }
        if (deleteNow)
        {
            deleteNow = false;
            Delete(deletedSave);
        }

    }

    public void Save(int i)
    {
        SceneSerializer scene = new SceneSerializer();

        foreach (Transform child in transform)
        {
            switch (child.gameObject.tag)
            {
                case "Sol":
                    scene.AddCube(new Cube(child.position, child.eulerAngles, child.localScale));
                    break;
                case "Radioactive":
                    scene.AddPiques(new Pique(child.position, child.eulerAngles, child.localScale));
                    break;
                case "checkpoint":
                    scene.AddCheckpoints(new Checkpoint(child.position, child.localScale));
                    break;
                case "Player1":
                    scene.player1 = new serialize.Player(child.position);
                    break;
                case "Player2":
                    scene.player2 = new serialize.Player(child.position);
                    break;
                case "Portal":
                    scene.AddPortal(new serialize.Portal(child.GetChild(0).position, child.GetChild(1).position, child.GetChild(0).localScale, child.GetChild(1).localScale));
                    break;
                case "Saw":
                    scene.AddSaw(new serialize.Saw(child.GetChild(0).position, child.GetChild(1).position, child.GetChild(2).localScale));
                    break;
                case "Elevator":
                    scene.AddElevator(new serialize.Elevator(child.GetChild(0).position, child.GetChild(1).position, child.GetChild(2).localScale));
                    break;
                default:
                    break;
            }

        }
        var jsonString = JsonConvert.SerializeObject(scene);

        System.IO.File.WriteAllText(Application.dataPath + @"\Resources\Saves\" + i + ".txt", jsonString);

        Camera.main.GetComponent<PauseMenu>().Resume_btn();

        var folder = Directory.CreateDirectory(Application.dataPath + "/Resources/SavesMap");
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/Resources/SavesMap/map" + i + ".png");

#if UNITY_EDITOR
#else
        ScreenSave(1);
#endif
    }

#if UNITY_EDITOR
#else
    public void ScreenSave(int i)
    {
        var folder = Directory.CreateDirectory(Application.dataPath + "/Resources/SavesMap");
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/Resources/SaveMap/map" + i + ".png");
    }
#endif

    static public void Delete(int deleteFile)
    {

        int nbFiles;
        if (!System.Int32.TryParse(System.IO.File.ReadAllText(Application.dataPath + @"\Resources\Saves\SaveFile.txt"), out nbFiles))
        {
            nbFiles = 0;
        }
        System.IO.File.Delete(Application.dataPath + @"\Resources\Saves\" + deleteFile + ".txt");
        System.IO.File.Delete(Application.dataPath + @"\Resources\SavesMap\map" + deleteFile + ".png");
        for (int i = deleteFile + 1; i <= nbFiles; i++)
        {
            System.IO.File.Move(Application.dataPath + @"\Resources\Saves\" + i + ".txt", Application.dataPath + @"\Resources\Saves\" + (i - 1) + ".txt");
            System.IO.File.Move(Application.dataPath + @"\Resources\SavesMap\map" + i + ".png", Application.dataPath + @"\Resources\SavesMap\map" + (i - 1) + ".png");
        }
        System.IO.File.WriteAllText(Application.dataPath + @"\Resources\Saves\SaveFile.txt", (nbFiles - 1).ToString());
    }

    public void Load(int i)
    {
        //GameObject pique = Instantiate(Resources.Load("prefabPique") as GameObject);

        string text = System.IO.File.ReadAllText(Application.dataPath + @"\Resources\Saves\" + i + ".txt");
        SceneSerializer scene = JsonConvert.DeserializeObject<SceneSerializer>(text);

        foreach (Cube cubi in scene.cubes)
        {
            GameObject block = Instantiate(Resources.Load("prefabCube") as GameObject);
            block.GetComponent<Transform>().localScale = cubi.scale;
            block.GetComponent<Transform>().eulerAngles = cubi.rotation;
            block.GetComponent<Transform>().position = cubi.position;
            block.GetComponent<Transform>().parent = this.GetComponent<Transform>();

        }
        foreach (Pique piqui in scene.piques)
        {
            GameObject pique = Instantiate(Resources.Load("prefabPique") as GameObject);
            pique.GetComponent<Transform>().localScale = piqui.scale;
            pique.GetComponent<Transform>().eulerAngles = piqui.rotation;
            pique.GetComponent<Transform>().position = piqui.position;
            pique.GetComponent<Transform>().parent = this.GetComponent<Transform>();
        }
        foreach (Checkpoint checki in scene.checkpoints)
        {
            GameObject check = Instantiate(Resources.Load("flag") as GameObject);
            check.GetComponent<Transform>().position = checki.position;
            check.GetComponent<Transform>().localScale = checki.scale;
            check.GetComponent<Transform>().parent = this.GetComponent<Transform>();
        }
        foreach (serialize.Portal porti in scene.portals)
        {
            GameObject port = Instantiate(Resources.Load("DualPortal") as GameObject);
            port.GetComponent<Transform>().GetChild(0).position = porti.position;
            port.GetComponent<Transform>().GetChild(0).localScale = porti.scale1;
            port.GetComponent<Transform>().GetChild(1).localScale = porti.scale2;
            port.GetComponent<Transform>().GetChild(1).position = porti.position2;
            port.GetComponent<Transform>().parent = this.GetComponent<Transform>();
        }
        foreach (serialize.Saw sawi in scene.saws)
        {
            GameObject saw = Instantiate(Resources.Load("Saw") as GameObject);
            saw.GetComponent<Transform>().GetChild(0).position = sawi.position;
            saw.GetComponent<Transform>().GetChild(2).localScale = sawi.scale;
            saw.GetComponent<Transform>().GetChild(1).position = sawi.position2;
            saw.GetComponent<Transform>().parent = this.GetComponent<Transform>();
        }
        foreach (serialize.Elevator elevi in scene.elevators)
        {
            GameObject elev = Instantiate(Resources.Load("Elevator") as GameObject);
            elev.GetComponent<Transform>().GetChild(0).position = elevi.position;
            elev.GetComponent<Transform>().GetChild(2).localScale = elevi.scale;
            elev.GetComponent<Transform>().GetChild(1).position = elevi.position2;
            elev.GetComponent<Transform>().parent = this.GetComponent<Transform>();
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

        /*if(!isEditor)
        {
            p1.AddComponent<Player>();
            p2.AddComponent<Player>();
        }*/

    }
}
