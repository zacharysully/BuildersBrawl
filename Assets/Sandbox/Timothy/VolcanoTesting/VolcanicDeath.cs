using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanicDeath : MonoBehaviour
{
    public GameObject[] burningPlayers;
    private Vector3 deathPos;
    private bool instantiateBurningPlayer = true;
    private float forwardProjectionSpeedMultiplier = 200f;
    
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            deathPos = other.gameObject.transform.position;
            other.gameObject.GetComponent<PlayerDeath>().KillMe();
            if (instantiateBurningPlayer)
            {
                instantiateBurningPlayer = false;
                InstantiateBurningPlayer(other.gameObject, deathPos);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            deathPos = other.gameObject.transform.position;
            other.gameObject.GetComponent<PlayerDeath>().KillMe();
            if (instantiateBurningPlayer)
            {
                instantiateBurningPlayer = false;
                InstantiateBurningPlayer(other.gameObject, deathPos);
            }
        }
    }

    /*
    private void OnParticleTrigger(GameObject other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            deathPos = other.gameObject.transform.position;
            other.gameObject.GetComponent<PlayerDeath>().KillMe();
            InstantiateBurningPlayer(other.gameObject, deathPos);
        }
    }*/

    private void InstantiateBurningPlayer(GameObject player, Vector3 deathPos)
    {
        if (player == GameManager.S.player1)//Blue
        {
            GameObject burntPlayer = Instantiate(burningPlayers[0], deathPos + new Vector3(0, -1.1f, 0), GameManager.S.player1.transform.rotation);
            burntPlayer.GetComponent<Rigidbody>().AddForce(burntPlayer.transform.forward * forwardProjectionSpeedMultiplier);
            instantiateBurningPlayer = true;
        }
        //Instantiate(iceCubePrefab[0], deathPos, Quaternion.identity);
        else if (player == GameManager.S.player2)//Red
        {
            GameObject burntPlayer = Instantiate(burningPlayers[1], deathPos + new Vector3(0, -1.1f, 0), GameManager.S.player2.transform.rotation);
            burntPlayer.GetComponent<Rigidbody>().AddForce(burntPlayer.transform.forward * forwardProjectionSpeedMultiplier);
            instantiateBurningPlayer = true;
        }
        //Instantiate(iceCubePrefab[1], deathPos, Quaternion.identity);
        else if (player == GameManager.S.player3)//Yellow
        {
            GameObject burntPlayer = Instantiate(burningPlayers[2], deathPos + new Vector3(0, -1.1f, 0), GameManager.S.player3.transform.rotation);
            burntPlayer.GetComponent<Rigidbody>().AddForce(burntPlayer.transform.forward * forwardProjectionSpeedMultiplier);
            instantiateBurningPlayer = true;
        }
        //Instantiate(iceCubePrefab[2], deathPos, Quaternion.identity);
        else if (player == GameManager.S.player4)//Purple
        {
            GameObject burntPlayer = Instantiate(burningPlayers[3], deathPos + new Vector3(0, -1.1f, 0), GameManager.S.player4.transform.rotation);
            burntPlayer.GetComponent<Rigidbody>().AddForce(burntPlayer.transform.forward * forwardProjectionSpeedMultiplier);
            instantiateBurningPlayer = true;
        }
    }
}
