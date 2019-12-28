using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityMapBuilder : MonoBehaviour
{   
    private static int[,] OutlineMatrix = new int[,] { {0,0,0,0,0,0,0,1,1,1},
                                                {0,0,1,1,1,1,1,1,0,1},
                                                {1,1,1,0,0,0,0,0,0,1},
                                                {0,0,1,0,0,0,0,1,1,1},
                                                {0,0,1,1,0,0,0,1,0,0},
                                                {0,0,0,1,1,1,1,1,0,0},
                                                {0,0,0,1,0,0,1,0,0,0},
                                                {0,0,0,1,0,0,1,1,1,1},
                                                {1,1,1,1,0,0,1,0,0,0},
                                                {0,0,0,0,0,0,1,0,0,0},  };

    private static int[,] ObstacleMatrix = new int[,] { {0,0,0,0,0,0,0,0,0,0},
                                                 {0,0,4,0,0,6,0,0,0,0},
                                                 {0,3,0,0,0,5,5,5,0,0},
                                                 {0,0,0,0,0,0,0,0,2,0},
                                                 {0,0,0,0,0,0,0,0,7,0},
                                                 {0,0,2,0,0,0,0,0,0,0},
                                                 {0,0,0,0,0,1,0,0,0,0},
                                                 {9,0,0,0,0,1,1,1,1,1},
                                                 {0,0,0,0,0,2,0,0,0,0},
                                                 {0,0,0,0,0,2,0,0,0,0},  };

    private int[,] CombinedMatrix = new int[OutlineMatrix.GetLength(0),OutlineMatrix.GetLength(1)];

    public GameObject RoadPrefab;
    public GameObject[] BuildingPrefabs;
    public GameObject[] ObstaclePrefabs;

    void Start()
    {
        CombineMatrices();
    }

    protected virtual void CombineMatrices()
    {
        for (int i = 0; i < OutlineMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < OutlineMatrix.GetLength(1); j++)
            {
                CombinedMatrix [i, j] = OutlineMatrix[i,j] + ObstacleMatrix[i,j];
                BuildCity(ref CombinedMatrix[i,j], i , j);
            }
        }
    }

    protected virtual void BuildCity(ref int _val, int x, int z)
    {   
        GameObject _road = Instantiate(RoadPrefab, new Vector3(x,0,z), RoadPrefab.transform.rotation);
        _road.transform.parent = GameObject.FindWithTag("road_root").transform;

        if(_val == 1) 
        {

        }  
    }

    protected virtual GameObject CreateBuilding()
    {
        //GameObject _obj = Instantiate();
        return null;
    }
}
