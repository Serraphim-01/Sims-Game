using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class AiMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private float movementSpeed;

    private float locationTimer;
    private float stateTimer;
    private float moveTimer;


    public enum State
    {
        walking,
        sleeping,
        studying,
        exercising
    }



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = movementSpeed;

        ScheduleLocationChange();
        ScheduleStateChange();
        ScheduleMoveChange();
    }

    // Update is called once per frame
    void Update()
    {
        locationTimer -= Time.deltaTime;
        if (locationTimer <= 0)
        {
            ChangeLocation();
            Debug.Log("Changign Location");
        }

        stateTimer -= Time.deltaTime;
        if (stateTimer <= 0)
        {
            ScheduleStateChange();
            Debug.Log("Changing State");
        }

        //moveTimer -= Time.deltaTime;
        //if (moveTimer <= 0) { ScheduleMoveChange(); MoveAround(); }

    }

    private void ScheduleLocationChange()
    {
        locationTimer = Random.Range(10, 11);
    }

    private void ScheduleStateChange()
    {
        stateTimer = Random.Range(2, 5);
    }

    private void ScheduleMoveChange()
    {
        moveTimer = Random.Range(2, 4);
    }

    private void ManageStates()
    {
        
    }


    private void MoveAround()
    {
        //Gives the AI a random rotation when it's running around
        float newRotation = Random.Range(transform.rotation.y + 100f, transform.rotation.y - 100f);
        transform.rotation = Quaternion.Euler(transform.rotation.x, newRotation, transform.rotation.z);

        //Moves the AI forward
        Vector3 forwardPosition = transform.position + transform.forward * 2f;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(forwardPosition, out hit, 2f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    private void ChangeLocation()
    {
        Debug.Log("Changing Location");

        Transform[] switchLocations = LocationManager.Instance.GetSwitchLocations();
        int index = Random.Range(0, switchLocations.Length);
        agent.SetDestination(switchLocations[index].position);


        //prepare to change location again
        ScheduleLocationChange();

    }

    
}
