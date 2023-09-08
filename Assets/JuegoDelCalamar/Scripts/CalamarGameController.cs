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
    private PlatformScript[][] _platforms = new PlatformScript[3][];

    [SerializeField]
    private List<PlatformScript> _platformsTemp;

    void Start()
    {
        _platformsTemp = new List<PlatformScript>(GameObject.FindObjectsOfType<PlatformScript>());
        _platformsTemp = _platformsTemp.OrderBy(_platform => _platform.GetId()).ToList();
        int currentObject = 0;
        for(int i = 0 ; i < _platforms.Length; i++)
        {
            _platforms[i] = new PlatformScript[3];
            for (int j = 0; j < _platforms[i].Length; j++)
            {
                _platforms[i][j] = _platformsTemp[currentObject];
                currentObject ++;
            }
        }
        for (int i = 0; i < _platforms.Length; i++)
        {
            for (int j = 0; j < _platforms[i].Length; j++)
            {
                Debug.Log("curren Object" + _platforms[i][j].GetId());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnPlataformClicked(int id)
    {
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

}

