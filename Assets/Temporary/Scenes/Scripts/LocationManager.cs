using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    //LocationManager script is in every scene,
    //all parts of the scene that the player will go to in order to switch their location
    //should be attached to this script as a "sceneSwitchLocation"

    public static LocationManager Instance {  get; private set; }

    [Tooltip("Places in the scene that trigger a location switch")]
    [SerializeField] private Transform[] sceneSwitchLocations;

    private void Start()
    {
        Instance = this;
    }

    public Transform[] GetSwitchLocations()
    {
        return sceneSwitchLocations;
    }
}
