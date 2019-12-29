using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityMapBuilder : MonoBehaviour
{   
    private static int[,] OutlineMatrix = new int[,] {  {0,0,0,0,0,0,0,1,1,1},
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
        string _finalMatrix = "";

        for (int i = 0; i < OutlineMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < OutlineMatrix.GetLength(1); j++)
            {
                CombinedMatrix [i, j] = OutlineMatrix[i,j] + ObstacleMatrix[i,j];
                BuildCity(ref CombinedMatrix[i,j], i , j);

                _finalMatrix += CombinedMatrix [i, j].ToString();
            }

            _finalMatrix += "\n";
        }
        print("final_matrix: "+_finalMatrix);
    }

    protected virtual void BuildCity(ref int _val, int x, int z)
    {   
        GameObject _road = Instantiate(RoadPrefab, new Vector3(x,0,z), RoadPrefab.transform.rotation) as GameObject;
        _road.transform.parent = GameObject.FindWithTag("road_root").transform;

        if(_val == 1) 
        {   
           CreateBuilding().transform.localPosition = new Vector3(x, 0, z);
        }  
        else if(_val > 1)
        {
            CreateObstacle(x, z).transform.localPosition = new Vector3(x, 0, z);
        }

        UIController.Instance.InitScore();
    }

    protected virtual GameObject CreateBuilding()
    {   
        int _rand = Random.Range(0,BuildingPrefabs.Length);
        GameObject _obj = Instantiate(BuildingPrefabs[_rand], BuildingPrefabs[_rand].transform.position,
                                      BuildingPrefabs[_rand].transform.rotation) as GameObject;
        _obj.transform.parent = GameObject.FindWithTag("obstacle_root").transform;

        return _obj;
    }

    protected virtual GameObject CreateObstacle(int x, int z)
    {   
        int _rand = Random.Range(0,ObstaclePrefabs.Length);
        GameObject _obj = Instantiate(ObstaclePrefabs[_rand], ObstaclePrefabs[_rand].transform.position,
                                      ObstaclePrefabs[_rand].transform.rotation) as GameObject;
        _obj.transform.parent = GameObject.FindWithTag("obstacle_root").transform;

        _obj.GetComponent<Obstacle>().ObstacleCounter = CombinedMatrix[x,z] - 1;
        UIMgr.Instance.TargetCount += CombinedMatrix[x,z] - 1;

        return _obj;
    }
}
