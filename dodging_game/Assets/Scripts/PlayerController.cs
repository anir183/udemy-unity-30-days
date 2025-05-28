using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveSpeedCap = 20f;
    [SerializeField] private float moveSpeedIncrMod = 0.3f;
    [SerializeField] private float fallBoundary = -3f;
    [SerializeField] private string obstacleTag = "Obstacle";

    float xInput;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            moveSpeed *=  0.75f;
            moveSpeedCap *= 0.55f;
            moveSpeedIncrMod *= 0.25f;
        }

        Time.timeScale = 1;
    }

    public void OnMove(CallbackContext context)
    {
        if (Input.touchCount <= 0)
            xInput = context.ReadValue<Vector2>().x;
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private void Update()
    {
        if (moveSpeed <= moveSpeedCap)
            moveSpeed += (moveSpeedIncrMod * Time.deltaTime);

        if (Touch.activeTouches.Count > 0)
        {
            foreach (Touch touch in Touch.activeTouches)
            {
                if (touch.finger.index == 0 && touch.isInProgress)
                {
                    if (touch.screenPosition.x < (Screen.width / 2))
                        xInput = -0.55f;
                    else if (touch.screenPosition.x > (Screen.width / 2))
                        xInput = 0.55f;
                }
                else xInput = 0;
            }
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            xInput = 0;
        }

            transform.Translate(xInput * moveSpeed * Time.deltaTime, 0, 0);

        if (transform.position.y < fallBoundary)
        {
            Time.timeScale = 0;
            UIManager.instance.enterEndState();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == obstacleTag)
        {
            Time.timeScale = 0;
            UIManager.instance.enterEndState();
        }
    }
}
