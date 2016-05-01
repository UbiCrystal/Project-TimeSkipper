using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMotor : MonoBehaviour 
{
    #region Variables (private)
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    #endregion

    #region Properties (public)
    public Rigidbody rBody;
    public GameObject enemy;
    #endregion

    #region Unity event functions

    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        _Move();
        _Rotation();
    }

    #endregion

    #region Methods
    public void Move(Vector3 vel)
    {
        velocity = vel;
    }

    public void _Move()
    {
        if (velocity != Vector3.zero)
        {
            rBody.MovePosition(rBody.position + velocity * Time.fixedDeltaTime);
            enemy.gameObject.GetComponent<Enemy>().moveSpeed = 5f;
            enemy.gameObject.GetComponent<Enemy>().Damping = 4f;
        }
        else
        {
            enemy.gameObject.GetComponent<Enemy>().moveSpeed = 0.1f;
            enemy.gameObject.GetComponent<Enemy>().Damping = 0.09f;
        }
            
    }

    public void Rotation(Vector3 rot)
    {
        rotation = rot;
    }

    public void RotateCamera(Vector3 cameraRot)
    {
        cameraRotation = cameraRot;
    }

    void _Rotation()
    {
        rBody.MoveRotation(rBody.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            cam.transform.Rotate(cameraRotation);
        }
    }
    #endregion Methods
}
