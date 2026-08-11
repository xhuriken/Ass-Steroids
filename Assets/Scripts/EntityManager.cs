using UnityEngine;

public class EntityManager : MonoBehaviour
{

    #region Singleton

    private static EntityManager instance = null;
    public static EntityManager Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }

    #endregion

    public GameObject Enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnEnemy()
    {
        // Instantier un enemy a une position aléatoire autour de la caméra.

        var spawnPos = Random.insideUnitCircle.normalized;
        var enemy = Instantiate(Enemy, spawnPos, Quaternion.identity);
    }
}
