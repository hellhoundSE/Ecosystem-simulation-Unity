using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    // Start is called before the first frame update

    int size;
    [Range(1, 20)]
    public int scale;
    [Range(0, 1)]
    public float WaterSmooth;
    [Range(0, 1)]
    public float SandSmooth;

    int offset;

    public Texture2D noise;

    void Start()
    {
        size = GetComponent<LevelGenerator>().size;
        offset = Random.Range(10, 50);
        noise = GenerateTexture();
    }
    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(size, size);
        for(int x = 0;x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Color color = GenerateColor(x, y);
                texture.SetPixel(x,y,color);
                
            }
        }
        return texture;

    }
    Color GenerateColor(int x,int y)
    {
        float xCord = (float)x / size * scale + offset;
        float yCord = (float)y / size * scale + offset;

        float sample = Mathf.PerlinNoise(xCord, yCord);
        sample =  sample > SandSmooth ? 1f : sample < WaterSmooth ? 0f : 0.5f;
        //Debug.Log(sample);
        return new Color(sample,sample,sample);
    }
}
