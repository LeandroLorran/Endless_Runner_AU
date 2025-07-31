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

        CheckDestroyGround();
    }

    private void MoveGround()
    {
        transform.Translate(Vector3.left * _gameController._chaoVelocidade * Time.deltaTime);
    }

    private void CheckSpawnNextGround()
    {
        if (!_spawnedNextGround && transform.position.x <= 0)
        {
            _spawnedNextGround = true;
            SpawnNextGround();
        }
    }

    private void SpawnNextGround()
    {
        GameObject newGround = Instantiate(_gameController._chaoPrefab);
        newGround.transform.position = new Vector3(transform.position.x + _gameController._chaoTamanho, transform.position.y, transform.position.z);
    }

    private void CheckDestroyGround()
    {
        if (transform.position.x <= _gameController._chaoDestruido)
        {
            Destroy(gameObject);
        }
    }
}
