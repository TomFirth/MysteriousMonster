using UnityEngine;
using UnityEngine.InputSystem;

public class BasicMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementInput, stick;
    private Vector3 move;
    public float moveSpeed = 5f;

    public Transform movePoint;
    public LayerMask whatStopsMovement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        movePoint.parent = null;
    }

    private void FixedUpdate()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
            return; // No gamepad connected.

        stick = gamepad.leftStick.ReadValue();
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(movementInput.x) == 1f || Mathf.Abs(stick.x) > 0.05f)
            {
                move = new Vector3(Mathf.Round(movementInput.x), 0f, 0f);
                if (!Physics2D.OverlapCircle(movePoint.position + move, .2f, whatStopsMovement))
                {
                    movePoint.position += move;
                }
            }
            else if (Mathf.Abs(movementInput.y) == 1f || Mathf.Abs(stick.y) > 0.05f)
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