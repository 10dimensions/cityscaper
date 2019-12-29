using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{   
    public int ObstacleCounter;

    void OnCollisionEnter(Collision other)
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

    void OnTriggerExit(Collider other)
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
        //print("hit!");
        UIController.Instance.ChangeScore();



    }

}