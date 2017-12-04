using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGeneratorManager : MonoBehaviour {


    public Texture2D map;
    public Transform tileParent;
    public GameObject BlackPixelTile;
    Color black = Color.black;

	// Use this for initialization
	void Start () {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                Color pixelColor = map.GetPixel(x, y);
                if (pixelColor == black)
                    Instantiate<GameObject>(BlackPixelTile, new Vector2(x*10, y*10), Quaternion.identity, tileParent);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {


        


	}
}
