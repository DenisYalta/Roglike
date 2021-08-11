using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapons : MonoBehaviour
{
    public float Damage;
    public float BulletSpeed;
    public float SpeedAttack;
    public float MaxBullets;
    public float CurrentBullets;

    public Transform Firepoint;
    public GameObject BulletPrefab;

    public AmmountOfBullets AmmountOfBulletsVariable;

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
        StartCoroutine("ShootDelay");    
    }

    public IEnumerator ShootDelay()
    {
        if (CurrentBullets > 0)
        {
            CurrentBullets--;
            AmmountOfBulletsVariable.SetAmmountOfBullets(CurrentBullets, MaxBullets);
            GameObject Bullet = Instantiate(BulletPrefab, Firepoint.position, Firepoint.rotation);
            Rigidbody RigidbodyVariable = Bullet.GetComponent<Rigidbody>();
            RigidbodyVariable.AddForce(Firepoint.right * BulletSpeed, ForceMode.Impulse);
            if (CurrentBullets <= 0)
            {
                yield return new WaitForSeconds(3f);
                CurrentBullets = MaxBullets;
                AmmountOfBulletsVariable.SetAmmountOfBullets(CurrentBullets, MaxBullets);
            }
        }    
    }

    private void Awake()
    {
        RogLikeInputActionsWeapons = new RogLike();
        CurrentBullets = MaxBullets;

    }
    private void Update()
    {

      
            
    }


}
