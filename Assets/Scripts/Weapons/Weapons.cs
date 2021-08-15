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

    public bool IsReloading = false;

    public Transform Firepoint;
    public GameObject BulletPrefab;

    public AmmountOfBullets AmmountOfBulletsVariable;

    private RogLike RogLikeInputActionsWeapons;



    private void OnEnable()
    {
        RogLikeInputActionsWeapons.Player.Shoot.performed += Shoot;
        RogLikeInputActionsWeapons.Player.Shoot.Enable();

        RogLikeInputActionsWeapons.Player.Reload.performed += ReloadOnButton;
        RogLikeInputActionsWeapons.Player.Reload.Enable();


    }
    private void OnDisable()
    {
        RogLikeInputActionsWeapons.Player.Shoot.Disable();
        RogLikeInputActionsWeapons.Player.Reload.Disable();
    }

    public void ReloadOnButton(InputAction.CallbackContext Context)
    {   
       if (!IsReloading)
       {
            StartCoroutine("Reload");
       }
        
    }
    public IEnumerator Reload()
    {
        IsReloading = true;
        CurrentBullets = 0;
        AmmountOfBulletsVariable.SetAmmountOfBullets(CurrentBullets, MaxBullets);
        yield return new WaitForSeconds(3f);
        CurrentBullets = MaxBullets;
        AmmountOfBulletsVariable.SetAmmountOfBullets(CurrentBullets, MaxBullets);
        IsReloading = false;
    }


    public void Shoot(InputAction.CallbackContext Context)
    {  
        StartCoroutine("ShootDelay");    
    }

    public IEnumerator ShootDelay()
    {
        if (CurrentBullets > 0 && !IsReloading)
        {
            CurrentBullets--;
            AmmountOfBulletsVariable.SetAmmountOfBullets(CurrentBullets, MaxBullets);
            GameObject Bullet = Instantiate(BulletPrefab, Firepoint.position, Firepoint.rotation);
            Rigidbody RigidbodyVariable = Bullet.GetComponent<Rigidbody>();
            RigidbodyVariable.AddForce(Firepoint.right * BulletSpeed, ForceMode.Impulse);
            if (CurrentBullets <= 0)
            {
                IsReloading = true;
                yield return new WaitForSeconds(3f);
                CurrentBullets = MaxBullets;
                AmmountOfBulletsVariable.SetAmmountOfBullets(CurrentBullets, MaxBullets);
                IsReloading = false;
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
