using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyLoaderScene : MonoBehaviour
{


    public string SceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneController.Instance.LoadSceneAditiveAsync(SceneToLoad);
    }
}
