using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    #region Singleton

    private static MouseManager instance = null;
    public static MouseManager Instance => instance;
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

    public Vector3 MousePos = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }




    Vector2 mousePos;
    Vector3 worldPoint;
    // Update is called once per frame
    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();

        worldPoint = Camera.main.ScreenToWorldPoint(mousePos);

        MousePos = new Vector3(worldPoint.x, worldPoint.y, transform.position.z);

        transform.position = MousePos;
    }
}
