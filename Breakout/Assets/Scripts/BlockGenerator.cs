using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class BlockGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject block;
    public GameObject block_solid;
    public string filename;
    List<List<int>> tileData = new List<List<int>>();
    void Start()
    {
        string fileloc = @"Assets/Levels/" + filename;
        using (StreamReader read = new StreamReader(fileloc))
        {
            string line;
            int ind = 0;
            while ((line = read.ReadLine()) != null)
            {
                tileData.Add(new List<int>());
                string[] strings = line.Split();
                foreach (string s in strings)
                {
                    tileData[ind].Add(Int32.Parse(s));
                }
                ++ind;
            }
        }

        Camera cam = Camera.main;
        float halfHeight = cam.orthographicSize;
        float halfWidth = cam.aspect * halfHeight;

        int height = tileData.Count;
        int width = tileData[0].Count;
        float block_height = halfHeight/height;
        float block_width = halfWidth*2/width;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (tileData[i][j] == 1)
                {
                    Vector3 new_pos = transform.position;
                    new_pos.x += block_width * j;
                    new_pos.y -= block_height * i;
                    GameObject bl = Instantiate(block_solid, new_pos, Quaternion.identity, transform);
                    bl.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.7f);
                    //bl.GetComponent<Transform>().localScale = new Vector3(0.85f, 0.48f, 0.0f);
                }
                else if (tileData[i][j] > 1)
                {
                    Vector3 new_pos = transform.position;
                    new_pos.x += block_width * j;
                    new_pos.y -= block_height * i;
                    GameObject bl = Instantiate(block, new_pos, Quaternion.identity, transform);
                    //bl.GetComponent<Transform>().localScale = new Vector3(0.85f, 0.5f, 0.0f);
                    if (tileData[i][j] == 2)
                    {
                        bl.GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.6f, 1.0f);
                    }
                    else if (tileData[i][j] == 3)
                    {
                        bl.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.7f, 0.0f);
                    }
                    else if (tileData[i][j] == 4)
                    {
                        bl.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.4f);
                    }
                    else if (tileData[i][j] == 5)
                    {
                        bl.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.5f, 0.0f);
                    }
                    ++GameData.NumBlocks;
                }
            }
        }
        //Instantiate(block, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
