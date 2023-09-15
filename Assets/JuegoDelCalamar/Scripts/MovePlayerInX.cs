using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerInX : MonoBehaviour
{
    [SerializeField]
    private int _speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovePlayerInXCorrountine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MovePlayerInXCorrountine()
    {
        float initialPositionInX = transform.position.x;
        for(int i = 0; i < 10000; i++) {
            float t = (float)i / 10000f;
            float newX = Mathf.Lerp(initialPositionInX, initialPositionInX + 300, t);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }        
    }
}
