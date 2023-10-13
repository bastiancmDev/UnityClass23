using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update

    private List<string> _scenesLoaded;
    public List<string> ScenesLoaded { get => _scenesLoaded; }

    private List<string> _scenesToLoad;


    string _currentScene;

    public string CurrentScene { get => _currentScene; }

    public static SceneController Instance;



    private void Awake()
    {
        Init();
    }

    void Start()
    {
        
        DontDestroyOnLoad(gameObject);
        _scenesLoaded = new List<string>();       
        _scenesToLoad = new List<string>() { "City", "DemoScene" };
        _currentScene = "MainSceneToLoad";
        ScenesLoaded.Add(_currentScene);

        StartCoroutine(GetScenesToLoad());
    }

    SceneController()
    {
        
    }

    private void Init()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            BatchSceneLoader(_scenesToLoad);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            UnloadScene("City");
        }
    }


    public void LoadSceneAsync(string SceneName)
    {

        StartCoroutine(LoadSceneAsyncCoroutine(SceneName));
    }


    public void LoadScene(string SceneName)
    {
        _scenesLoaded.Add(SceneName);
        SceneManager.LoadScene(SceneName);
    }

    public void LoadSceneAditive(string SceneName)
    {
        _scenesLoaded.Add(SceneName);
       
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
    }

    public void LoadSceneAditiveAsync(string SceneName)
    {
        _scenesLoaded.Add(SceneName);
        
        StartCoroutine(LoadSceneAditiveAsyncCoroutine(SceneName));
    }

    IEnumerator LoadSceneAsyncCoroutine(string SceneName)
    {
        AsyncOperation loadingNewScene = SceneManager.LoadSceneAsync(SceneName);
        while (!loadingNewScene.isDone)
        {
            Debug.Log("Progres loaded of new scene " + loadingNewScene.progress + SceneName);
            yield return null;
        }

        if (_currentScene != SceneName)
        {
            UnloadScene(_currentScene);
        }
        _currentScene = SceneName;
    }


    IEnumerator LoadSceneAditiveAsyncCoroutine(string SceneName)
    {

        if(CurrentScene != SceneName)
        {
            AsyncOperation loadingNewScene = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
            while (!loadingNewScene.isDone)
            {
                Debug.Log("Progres loaded of new scene " + loadingNewScene.progress + SceneName);
                yield return null;
            }

            _currentScene = SceneName;
        }

       
    }

    public void BatchSceneLoader(List<string> scenesToLoad)
    {
        foreach (var sceneName in _scenesToLoad)
        {
            LoadSceneAditiveAsync(sceneName);
        }
    }


    public void UnloadScene(string SceneName) {
        if (ScenesLoaded.Contains(SceneName))
        {
            SceneManager.UnloadSceneAsync(SceneName);
            ScenesLoaded.Remove(SceneName);
        }            
    }


    public bool GetIfSceneIsAlive(string sceneName)
    {
        return ScenesLoaded.Contains(sceneName);
    }


    public IEnumerator GetScenesToLoad()
    {
        while (true)
        {
            var LoaderObjects = GameObject.FindObjectsOfType<NotifyLoaderScene> ();
            foreach (NotifyLoaderScene loader in LoaderObjects)
            {
                float distance = Vector3.Distance(Camera.main.transform.position, loader.transform.position);
                if(distance < 20)
                {
                    LoadSceneAditiveAsync(loader.SceneToLoad);
                }
            }
            yield return new WaitForSeconds(2);
        }        
    }
}
