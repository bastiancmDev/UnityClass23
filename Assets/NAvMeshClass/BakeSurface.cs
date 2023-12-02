
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor.AI;

public class BakeSurface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NavMeshSurface navMesh = gameObject.GetComponent<NavMeshSurface>();
        navMesh.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            NavMeshSurface navMesh = gameObject.GetComponent<NavMeshSurface>();
            navMesh.BuildNavMesh();
        }
    }
}
