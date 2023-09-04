using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectTransparency : MonoBehaviour
{
    private MeshRenderer hideMesh;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            hideMesh = other.GetComponent<MeshRenderer>();
            hideMesh.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Building"))
            hideMesh.enabled = true;
    }
}