using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{   
    public int ObstacleCounter;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ObstacleCounter--;
            print(ObstacleCounter);

            if(ObstacleCounter == 0)
                Destroy(this.gameObject);

            else
                FadeBack();

        }
    }

    private void FadeBack()
    {
        print("hit!");
    }

}