using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationChangePoint : MonoBehaviour
{
    public Loader.Scene scene;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (other.CompareTag("Player"))
        {
            Debug.Log("By Player");
            Loader.Load(scene);
        }
    }
}
