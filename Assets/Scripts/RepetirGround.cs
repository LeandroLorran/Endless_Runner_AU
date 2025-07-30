using UnityEngine;

public class RepetirGround : MonoBehaviour
{

    private GameController _gamecontroller;

    [SerializeField] bool _chaoInstanciado = false;
    void Start()
    {
        _gamecontroller = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    
    void Update()
    {
        if(_chaoInstanciado == false) 
        {
            if(transform.position.x <= 0) 
            {
                _chaoInstanciado = true;
                GameObject ObjetoTemporarioChao = Instantiate(_gamecontroller._chaoPrefab);
                ObjetoTemporarioChao.transform.position = new Vector3(transform.position.x + _gamecontroller._chaoTamanho, transform.position.y, transform.position.z);
            }
        }
 
    }

    void FixedUpdate()
    {

        MoveChao();

    }
    void MoveChao()
    {
        transform.Translate(Vector3.left * _gamecontroller._chaoVelocidade * Time.deltaTime);

    }

}
