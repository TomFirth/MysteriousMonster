using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementInput, stick, dpad;
    private Vector3 move;
    public float moveSpeed = 5f;
    public float movementThreshold = 0.5f;

    private string sceneName;

    [SerializeField]
    public SceneInfo sceneInfo;

    public Transform movePoint;
    public LayerMask whatStopsMovement;

    private Gamepad gamepad;

    private OpenDoor openDoor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        openDoor = FindObjectOfType<OpenDoor>();
    }

    private void Start()
    {
        movePoint.parent = null;
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    private void OnEnable()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
        Debug.Log(transform.position);
        transform.position = sceneInfo.worldPosition;
    }

    private void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (change == InputDeviceChange.Added && device is Gamepad)
        {
            gamepad = (Gamepad)device;
        }
    }

    private void FixedUpdate()
    {
        gamepad = Gamepad.current;
        if (gamepad == null) return;

        stick = gamepad.leftStick.ReadValue();
        dpad = gamepad.dpad.ReadValue();
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if ((stick.y > movementThreshold || dpad.y > movementThreshold) && sceneName == "Main")
            {
                openDoor.checkDoor();
            }
            else if ((stick.y < -movementThreshold || dpad.y < -movementThreshold) && sceneName != "Main")
            {
                openDoor.checkDoor();
            }
            if (Mathf.Abs(movementInput.x) == 1f || Mathf.Abs(stick.x) > 0.05f)
            {
                move = new Vector3(Mathf.Round(movementInput.x), 0f, 0f);
                if (!Physics2D.OverlapCircle(movePoint.position + move, .2f, whatStopsMovement))
                {
                    movePoint.position += move;
                }
            } else if (Mathf.Abs(movementInput.y) == 1f || Mathf.Abs(stick.y) > 0.05f)
            {
                move = new Vector3(0f, Mathf.Round(movementInput.y), 0f);
                if (!Physics2D.OverlapCircle(movePoint.position + move, .2f, whatStopsMovement))
                {
                    movePoint.position += move;
                }
            }
        }
    }

    private void OnMovement(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}