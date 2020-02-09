using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameBlock;

    public GameObject[,] blockArray;
    private BlockFactory factory;

    public int size;

    [Range(1, 20)]
    public int scale;
    [Range(0, 1)]
    public float WaterSmooth;
    [Range(0, 1)]
    public float SandSmooth;

    int offset;

    Texture2D noise;

    void Start()
    {
        Initialization();
        GenerateTexture();
        GenerateTerrain();
    }

    private void Initialization()
    {
        blockArray = new GameObject[size, size];
        factory = GetComponent<BlockFactory>();
    }

    private void GenerateTerrain()
    {
        for (int x = 0; x < size; x++)
        {
            for (int z = 0; z < size; z++)
            {
                int type;
                switch (noise.GetPixel(x, z).maxColorComponent)
                {
                    case 1:
                        {
                            type = BlockFactory.GRASS;
                            break;
                        }
                    case 0:
                        {
                            type = BlockFactory.WATER;
                            break;
                        }
                    default:
                        {
                            type = BlockFactory.SAND;
                            break;
                        }
                }
                blockArray[x,z] = factory.createBlock(type, new Vector3(x, 0, z));
            }
        }
    }



    void GenerateTexture()
    {
        offset = Random.Range(10, 50);

        noise = new Texture2D(size, size);
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Color color = GenerateColor(x, y);
                noise.SetPixel(x, y, color);

            }
        }
    }
    Color GenerateColor(int x, int y)
    {
        float xCord = (float)x / size * scale + offset;
        float yCord = (float)y / size * scale + offset;

        float sample = Mathf.PerlinNoise(xCord, yCord);
        sample = sample > SandSmooth ? 1f : sample < WaterSmooth ? 0f : 0.5f;

        return new Color(sample, sample, sample);
    }
}
