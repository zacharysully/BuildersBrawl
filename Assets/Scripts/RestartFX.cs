using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartFX : MonoBehaviour
{
    public GameObject[] particleFX;

    public bool checkToRestart = false;

    private void Update()
    {
        if (checkToRestart)
        {
            checkToRestart = false;
            Restart();
        }
    }

    private void Restart()
    {
        foreach(GameObject particle in particleFX)
        {
            particle.GetComponent<ParticleSystem>().Play();
        }
    }

}
