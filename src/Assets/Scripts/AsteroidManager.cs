﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : ObjectManager
{
    [SerializeField]
    GameObject asteroidPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnRandom(asteroidPrefab, 10, 10);
    }
}
