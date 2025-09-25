using UnityEngine;

public class RepetirGround : MonoBehaviour
{
    private GameController _gameController;

    [SerializeField] private bool _spawnedNextGround = false;

    private void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        MoveGround();
        CheckSpawnNextGround();
    }

    private void MoveGround()
    {
        transform.Translate(Vector3.left * _gameController._chaoVelocidade * Time.deltaTime);

        
        if (transform.position.x <= -40f)
        {
            _spawnedNextGround = true;
        }
    }

    private void CheckSpawnNextGround()
    {
        if (_spawnedNextGround)
        {
            SpawnNextGround();
            _spawnedNextGround = false;
        }
    }

    private void SpawnNextGround()
    {
        transform.position = new Vector2(transform.position.x + _gameController._chaoTamanho*2,transform.position.y);
    }
}
