using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameCube;

    public Material grass;
    public Material water;
    public Material sand;

    public int size;

    void Start()
    {
        PerlinNoise pn = GetComponent<PerlinNoise>();

        for(int x = 0; x < size; x++)
        {
            for (int z = 0; z < size; z++)
            {
                GameObject go = Instantiate(gameCube, new Vector3(x, 0, z), Quaternion.identity);
                go.transform.parent = this.transform;
                MeshRenderer mr = go.GetComponent<MeshRenderer>();
                switch (pn.noise.GetPixel(x, z).maxColorComponent)
                {
                    case 1:
                        {
                            mr.material = grass;
                            break;
                        }
                    case 0:
                        {
                            mr.material = water;
                            break;
                        }
                    default:
                        {
                            mr.material = sand;
                            break;
                        }
                }
            }
        }
    }
}
