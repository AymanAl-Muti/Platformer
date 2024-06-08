using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public Camera MainCamera { get; private set; }
    public Vector2 CursorPos => MainCamera.ScreenToWorldPoint(new Vector2(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue()));
    
    [SerializeField] private Texture2D cursorTexture;

    private void Awake()
    {
        if(Instance is null)
        {
            Instance = this;
        }
    }
    
    private void Start()
    {
        MainCamera = FindObjectOfType<Camera>();
        
        Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 2f, cursorTexture.height / 2f), CursorMode.Auto);
    }
}