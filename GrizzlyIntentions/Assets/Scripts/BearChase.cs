using UnityEngine;
using System.Collections;

public class BearChase : MonoBehaviour
{

    public Transform victim;
    private NavMeshAgent navComponent;

    // Use this for initialization
    void Start()
    {
        navComponent = this.transform.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (victim)
        {
            navComponent.SetDestination(victim.position);
        }
    }
}
