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

    // Serializamos para poder verlo en el Editor
    [SerializeField]
    private PlayerMovementController _playerMovementController;
    [SerializeField]
    private PlatformScript[][] _platforms;


    [SerializeField]
    private GameObject _platformPrefab;


    [SerializeField]
    private GameObject _playerPrefab;


    private Coroutine _currentCoroutine;

    // Awake solo se llama una vez al ejecutar el programa o cuando se activa el gameobjecto
    private void Awake()
    {
        // Inicializamos el primer array de nuestra matriz de plataformas y Fijamos una Seed para los randoms
        _platforms  = new PlatformScript[3][];
        Random.InitState(3);
    }

    void Start()
    {
        // Inicializamos las variables (No es para nada bueno quemar los valores)
        int dimension = 4; 
        int currentObject = 0;
        for(int i = 0 ; i < _platforms.Length; i++)
        {
            // Inicializamos nuestra segunda parte de la matriz por iteracion y Creamos un random que va del 0 al 2. El numero que se coloca como maximo se excluye.
            // Es bueno que se excluya el maximo ya que si trabajamos con arrays estos siempre empiezan de 0, si creamos un array de 3 este esta conformado de 0, 1 y 2.
            _platforms[i] = new PlatformScript[3];
            int RandomNumber = Random.Range(0, 3);
            for (int j = 0; j < _platforms[i].Length; j++)
            {
                // Instanciamos nuestro prefab de la plataforma en orden y a una distancia segun en que iteracion estemos.
                PlatformScript currenPlatform = Instantiate(_platformPrefab,new Vector3(j*dimension,0,i*dimension),Quaternion.identity).GetComponent<PlatformScript>();
                // Se le asigna la ID
                currenPlatform.SetId(currentObject);
                // Asignamos el script a el lugar de la matriz que nos encontramos
                _platforms[i][j] = currenPlatform;
                // Aumentamos la ID por cada plataforma
                currentObject ++;
                // Si la interacion en J es igual al random que salio, hacemos que la plataforma no sea falsa.
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

    // Funcion que se llama al clickear una Plataforma
    public void OnPlataformClicked(int id)
    {
        Debug.Log("OnPlataformClicked || CalamarGameController || Click plataform with id " + id );
        TYPE_OF_PLATAFORM TypeOfPlataform = ValidatePosition(id); // Validamos si la posicion a la que nos queremos mover es accesible, fake o inaccesible.
        var currentPlataform = GetPlatformScriptFromMatrix(id); // Extraemos la plataforma de la matriz segun la ID y la asignamos a una variable.
        // Comprobamos si la plataforma a la que se trata de ir es fake, nos podemos mover o no.
        switch (TypeOfPlataform){
            case TYPE_OF_PLATAFORM.IS_FAKE:
                _playerMovementController.MovePlayer(currentPlataform.GetPosition()); // Movemos al player a la posicion de la plataforma.
                currentPlataform.SetColor(); // Le cambiamos el color.
                break;
            case TYPE_OF_PLATAFORM.CANT_MOVE:
                Debug.Log("Position invalid"); // Tiramos un log que no es posible moverse a esa plataforma.
                break;
            case TYPE_OF_PLATAFORM.CAN_MOVE:
                Debug.Log("OnPlataformClicked || CalamarGameController || Player move to plataform " + id + " with position " + currentPlataform.GetPosition()); 
                _playerMovementController.MovePlayer(currentPlataform.GetPosition()); // Movemos al Player a la plataforma.
                break;
        }
    }


    public PlatformScript GetPlatformScriptFromMatrix(int id)
    {
        // Recorremos la Matriz en busca de la plataforma con la ID correspondiente
        for (int i = 0; i < _platforms.Length; i++)
        {
            for (int j = 0; j < _platforms[i].Length; j++)
            {
                // Si la encontramos retornamos el script de la plataforma correspondiente
                if(_platforms[i][j].GetId() == id)
                {
                    return _platforms[i][j];
                }
            }
        }
        // En todo caso creamos un log que no se encontro y retornamos null o Vacio
        Debug.LogError("NO SE ENCONTRO LA PLATAFORMA");
        return null;
    }

    public TYPE_OF_PLATAFORM ValidatePosition(int id) 
    {
        // Extraemos la plataforma segun la ID y la asignamos a una variable.
        var CurrentPlataform =  GetPlatformScriptFromMatrix (id);
        if (CurrentPlataform.GetIsFake()) // comprobamos si es Fake y retornamos el type
        {
            return TYPE_OF_PLATAFORM.IS_FAKE;
        }
        else
        {
            var distance =Vector3.Distance( _playerMovementController.GetPosition(), CurrentPlataform.GetPosition()); // Seteamos la distancia entre el player y la plataforma.
            // comprobamos si la distancia es suficiente para poder moverse
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

    // Creamos Humanos usando Coorrutinas
    IEnumerator CreateHumans()
    {
        // esta coorrutina solo se ejecutara 10 veces
        for (int i = 0; i < 10; i++)
        {
            var human = Instantiate(_playerPrefab);
            // Yield Return hara que en ese punto se espere 1 segundo antes de seguir
            yield return new WaitForSeconds(1); 
            
        }
        Debug.Log("fin de la coroutina");
    }


    // Encapsulamos la coorrutina en una funcion para que pueda ser llamada de otro script
    public void CreateHumansF()
    {
        StartCoroutine(CreateHumans());
    }

    

}
