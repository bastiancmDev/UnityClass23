using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> _pool;

    [SerializeField] GameObject _ballPrefab;

    [SerializeField] int _initialCountOfPool;
    private bool _creatingObject = false;

    void Start()
    {
        _pool = new List<GameObject>();

        for(int i = 0; i< _initialCountOfPool; i++)
        {
            var ballToShot = Instantiate(_ballPrefab);
            ballToShot.SetActive(false);
            _pool.Add(ballToShot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) {
            if (!_creatingObject)
            {
                _creatingObject = true;
                GameObject ballToShot = GetBallFromPool();
                ballToShot.SetActive(true);
                ballToShot.GetComponent<Rigidbody>().AddForce(ballToShot.transform.right * 12, ForceMode.VelocityChange);
                _creatingObject = false;
            }           
        }        
    }


    public GameObject GetBallFromPool() {
        
        GameObject ballToShot;
        if ( _pool.Count > 0 ) {            
            ballToShot =  _pool[0];
            _pool.RemoveAt(0);
        }
        else
        {
            ballToShot = Instantiate(_ballPrefab);                        
        }
        ballToShot.transform.position = new Vector3(-3, 0, 0);
        ballToShot.GetComponent<ShotBall>().NotifyCollision = OnBallCollosion;
        return ballToShot;
    }


    public void OnBallCollosion(GameObject ballToAddToPoll)
    {              
        _pool.Add(ballToAddToPoll);
    }
}
