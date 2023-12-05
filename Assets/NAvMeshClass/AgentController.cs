using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent _agent;
    private LineRenderer _lineRenderer;
    public Transform obj;
    public int positions = 0;
    void Start()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _lineRenderer = gameObject.GetComponent<LineRenderer>();
        StartCoroutine(DrawLines());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            var camera = Camera.main;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out var hit, 10000f))
            {
                Debug.DrawLine(camera.transform.position, hit.point, Color.green);
                Debug.Log(hit.transform);
                _agent.SetDestination(hit.point);
            }
        }
    }

    IEnumerator DrawLines()
    {

        while (true)
        {
            if (_lineRenderer != null)
            {
                _lineRenderer.positionCount = positions;
                positions = (positions + 1) % 3;
                _lineRenderer.SetPosition(positions, gameObject.transform.position);
            }
            yield return new WaitForSeconds(1f);
        }
    }


}
