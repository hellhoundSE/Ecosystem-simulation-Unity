using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory : MonoBehaviour
{
    // Start is called before the first frame update

    public const int GRASS = 1;
    public const int SAND = 2;
    public const int WATER = 3;

    public GameObject grass;
    public GameObject water;
    public GameObject sand;


    public GameObject createBlock(int type, Vector3 coordinates)
    {
        switch (type)
        {
            case GRASS:
                {
                    GameObject go = Instantiate(grass, coordinates, Quaternion.Euler(90, 0, 0));
                    go.transform.parent = this.transform;
                    return go;
                }
            case SAND:
                {
                    GameObject go = Instantiate(sand, coordinates, Quaternion.Euler(90, 0, 0));
                    go.transform.parent = this.transform;
                    return go;
                }
            case WATER:
                {
                    GameObject go = Instantiate(water, coordinates, Quaternion.Euler(90, 0, 0));
                    go.transform.parent = this.transform;
                    return go;
                }
            default:
                return null;
        }
    }
}
