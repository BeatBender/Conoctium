﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace serialize
{
    class SceneSerializer
    {
        public Player player1;
        public Player player2;
        public List<Cube> cubes;
        public List<Checkpoint> checkpoints;
        public List<Pique> piques;

        public SceneSerializer()
        {
            player1 = new Player(new UnityEngine.Vector3(0, 0, 0));
            player2 = new Player(new UnityEngine.Vector3(5, 0, 0));
            cubes = new List<Cube>();
            checkpoints = new List<Checkpoint>();
            piques = new List<Pique>();
        }
    
        public void SetP1(Player p1)
        {
            player1 = p1;
        }
        public void SetP2(Player p2)
        {
            player2 = p2;
        }
        public void AddCube(Cube cubi)
        {
            cubes.Add(cubi);
        }
        public void AddCheckpoints(Checkpoint checkpi)
        {
            checkpoints.Add(checkpi);
        }
        public void AddPiques(Pique piqui)
        {
            piques.Add(piqui);
        }

    }
}