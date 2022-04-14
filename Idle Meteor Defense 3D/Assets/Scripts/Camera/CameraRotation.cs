using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Camera mainCamera;
    [Range(0.1f, 5f)]
    [Tooltip("How sensitive the mouse drag to camera rotation")]
    public float mouseRotateSpeed = 0.8f;
    [Range(0.01f, 100)]
    [Tooltip("How sensitive the touch drag to camera rotation")]
    public float touchRotateSpeed = 17.5f;
    [Tooltip("Smaller positive value means smoother rotation, 1 means no smooth apply")]
    public float slerpValue = 0.25f;
    public enum RotateMethod { Mouse, Touch };
    [Tooltip("How do you like to rotate the camera")]
    public RotateMethod rotateMethod = RotateMethod.Mouse;


    private Vector2 swipeDirection; //swipe delta vector2
    private Quaternion cameraRot; // store the quaternion after the slerp operation
    private Touch touch;
    private float distanceBetweenCameraAndTarget;

    private float minXRotAngle = -80; //min angle around x axis
    private float maxXRotAngle = 80; // max angle around x axis

    //Mouse rotation related
    private float rotX; // around x
    private float rotY; // around y
    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        rotateMethod = RotateMethod.Mouse;
#elif UNITY_ANDROID
        rotateMethod = RotateMethod.Touch;
#endif

        distanceBetweenCameraAndTarget = Vector3.Distance(mainCamera.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        RotateAroundObject();
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distanceBetweenCameraAndTarget);

        Quaternion newQ; 
        if (rotateMethod == RotateMethod.Mouse)
            newQ = Quaternion.Euler(rotX, rotY, 0); 
        else
            newQ = Quaternion.Euler(swipeDirection.y, -swipeDirection.x, 0);


        cameraRot = Quaternion.Slerp(cameraRot, newQ, slerpValue);  
        mainCamera.transform.position = transform.position + cameraRot * dir;
        mainCamera.transform.LookAt(transform.position);
    }

    private void RotateAroundObject()
    {
        if (rotateMethod == RotateMethod.Mouse)
        {
            if (Input.GetMouseButton(0))
            {
                rotX += -Input.GetAxis("Mouse Y") * mouseRotateSpeed; // around X
                rotY += Input.GetAxis("Mouse X") * mouseRotateSpeed;
            }

            rotX = Mathf.Clamp(rotX, minXRotAngle, maxXRotAngle);
        }
        else if (rotateMethod == RotateMethod.Touch)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                    swipeDirection -= touch.deltaPosition * Time.deltaTime * touchRotateSpeed;
            }

            swipeDirection.y = Mathf.Clamp(swipeDirection.y, minXRotAngle, maxXRotAngle);
        }
    }
}