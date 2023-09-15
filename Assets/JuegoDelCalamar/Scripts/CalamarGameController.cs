using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum TYPE_OF_PLATAFORM
{
    IS_FAKE,
    CAN_MOVE,
    CANT_MOVE,
}


public class CalamarGameController : MonoBehaviour
{

    public readonly int WidthOfPlataforms = 4;

    // Start is called before the first frame update
    [SerializeField]
    private PlayerMovementController _playerMovementController;
    [SerializeField]
    private PlatformScript[][] _platforms;


    [SerializeField]
    private GameObject _platformPrefab;


    [SerializeField]
    private GameObject _playerPrefab;


    private Coroutine _currentCoroutine;

    private void Awake()
    {

        _platforms  = new PlatformScript[3][];
        Random.InitState(3);
    }

    void Start()
    {
        int dimension = 4; 
        int currentObject = 0;
        for(int i = 0 ; i < _platforms.Length; i++)
        {
            _platforms[i] = new PlatformScript[3];
            int RandomNumber = Random.Range(0, 3);
            for (int j = 0; j < _platforms[i].Length; j++)
            {
                PlatformScript currenPlatform = Instantiate(_platformPrefab,new Vector3(j*dimension,0,i*dimension),Quaternion.identity).GetComponent<PlatformScript>();
                currenPlatform.SetId(currentObject);
                _platforms[i][j] = currenPlatform;
                currentObject ++;
                if(j == RandomNumber)
                {
                    _platforms[i][j].SetIsFake(false);
                }
            }
        }


       
    }

    // Update is called once per frame
    void Update()
    {
       //if(Input.GetKeyDown(KeyCode.Space)) {
       //     _currentCoroutine = StartCoroutine(CreateHumans());
       //}

       //if(Input.GetKeyDown(KeyCode.A))
       // {
       //     Debug.Log("STOP COROUNTINE");
       //     StopCoroutine(_currentCoroutine);
       // }
        
    }


    public void OnPlataformClicked(int id)
    {
        Debug.Log("OnPlataformClicked || CalamarGameController || Click plataform with id " + id );
        TYPE_OF_PLATAFORM TypeOfPlataform = ValidatePosition(id);
        var currentPlataform = GetPlatformScriptFromMatrix(id);
        switch (TypeOfPlataform){
            case TYPE_OF_PLATAFORM.IS_FAKE:
                _playerMovementController.MovePlayer(currentPlataform.GetPosition());
                currentPlataform.SetColor();
                break;
            case TYPE_OF_PLATAFORM.CANT_MOVE:
                Debug.Log("Position invalid");
                break;
            case TYPE_OF_PLATAFORM.CAN_MOVE:
                Debug.Log("OnPlataformClicked || CalamarGameController || Player move to plataform " + id + " with position " + currentPlataform.GetPosition());
                _playerMovementController.MovePlayer(currentPlataform.GetPosition());
                break;
        }
    }


    public PlatformScript GetPlatformScriptFromMatrix(int id)
    {
        for (int i = 0; i < _platforms.Length; i++)
        {
            for (int j = 0; j < _platforms[i].Length; j++)
            {
                if(_platforms[i][j].GetId() == id)
                {
                    return _platforms[i][j];
                }
            }
        }
        Debug.LogError("NO SE ENCONTRO LA PLATAFORMA");
        return null;
    }

    public TYPE_OF_PLATAFORM ValidatePosition(int id) 
    {
        var CurrentPlataform =  GetPlatformScriptFromMatrix (id);
        if (CurrentPlataform.GetIsFake())
        {
            return TYPE_OF_PLATAFORM.IS_FAKE;
        }
        else
        {
            var distance =Vector3.Distance( _playerMovementController.GetPosition(), CurrentPlataform.GetPosition());
            if(distance < WidthOfPlataforms * 1.8) {
                return TYPE_OF_PLATAFORM.CAN_MOVE;
            }
            else
            {
                return TYPE_OF_PLATAFORM.CANT_MOVE;
            }
        }

    }

    IEnumerator MoveCube()
    {
        yield return new WaitForSeconds(.1f);
    }


    IEnumerator CreateHumans()
    {
        for (int i = 0; i < 10; i++)
        {
            var human = Instantiate(_playerPrefab);
            yield return new WaitForSeconds(1); 
            
        }
        Debug.Log("fin de la coroutina");
    }



    public void CreateHumansF()
    {
        StartCoroutine(CreateHumans());
    }

    

}
