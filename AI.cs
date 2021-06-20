using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//Window -> AI -> Navigation
//ant platformos, Object, navigation static
//bake map
//ant NPC kubo uzdet NavMeshAgent component

public class agent : MonoBehaviour
{
    public Transform destiantion;

    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(destiantion.transform.position);
    }
}
