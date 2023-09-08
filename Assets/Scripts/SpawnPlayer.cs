using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private void Awake()
    {
        if(player != null)
        {
            Instantiate(player, transform.position, transform.rotation);
        }
    }
}
