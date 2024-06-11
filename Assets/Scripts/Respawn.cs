using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject Spawnpoint;
    [SerializeField] private GameObject Player;

    public void Restart()
    {
        Debug.Log("Respawned Player");
        Player.transform.position = Spawnpoint.transform.position;
    }

}
