using UnityEngine;

public class Enemy : MonoBehaviour 
{
    #region Variables (private)
    private float Distance;
    private float lookAtDistance = 25f;
    #endregion

    #region Properties (public)
    public float moveSpeed = 5f;
    public Transform target;
    public float Damping = 4f;
    #endregion

    #region Unity event functions

    void Start ()
    {
        
    }
	
    void Update ()
    {
        Distance = Vector3.Distance(target.position, transform.position);

        if (Distance < lookAtDistance)
        {
            lookAt();
            Move();
        }
    }

    #endregion

    #region Methods
    public void lookAt()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
    }

    public void Move()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    #endregion Methods
}
