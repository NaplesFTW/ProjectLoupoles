using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGeneratorManager : MonoBehaviour {


    public Texture2D map;
    public Texture2D mapCoins;
    public Transform tileParent;
    public GameObject BlackPixelTile;
    public GameObject YellowPixelTile;


	// Use this for initialization
	void Start () {
        Color empty = Color.clear;
        empty.a += 1;
        empty.b += 1;
        empty.g += 1;
        empty.r += 1;
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                Color pixelColor = map.GetPixel(x, y);
                if (pixelColor != empty)
                    Instantiate<GameObject>(BlackPixelTile, new Vector2(x*10, y*10), Quaternion.identity, tileParent);
            }
        }
        empty.b = 0;
        empty.a = 0;
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                Color pixelColor = mapCoins.GetPixel(x, y);
                if (pixelColor != empty)
                    Instantiate<GameObject>(YellowPixelTile, new Vector2(x * 10, y * 10), Quaternion.identity, tileParent);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {


        


	}
}
