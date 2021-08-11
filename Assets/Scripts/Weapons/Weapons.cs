using UnityEngine;
using UnityEngine.InputSystem;

public class Weapons : MonoBehaviour
{
    public float Damage;
    public float BulletSpeed;
    public float SpeedAttack;

    public Transform Firepoint;
    public GameObject BulletPrefab;

    private RogLike RogLikeInputActionsWeapons;



    private void OnEnable()
    {
        RogLikeInputActionsWeapons.Player.Shoot.performed += Shoot;
        RogLikeInputActionsWeapons.Player.Shoot.Enable();


    }
    private void OnDisable()
    {
        RogLikeInputActionsWeapons.Player.Shoot.Disable();
    }

    public void Shoot(InputAction.CallbackContext Context)
    {

        GameObject Bullet = Instantiate(BulletPrefab, Firepoint.position, Firepoint.rotation);
        Rigidbody RigidbodyVariable = Bullet.GetComponent<Rigidbody>();
        RigidbodyVariable.AddForce(Firepoint.right * BulletSpeed, ForceMode.Impulse);
    }

    private void Awake()
    {
        RogLikeInputActionsWeapons = new RogLike();


    }
    private void Update()
    {

      
            
    }


}
