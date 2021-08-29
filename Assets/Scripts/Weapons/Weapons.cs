using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapons : MonoBehaviour
{
    public float BulletSpeed;
    public float MaxBullets;
    public float CurrentBullets;
    public float ReloadTime;

    public bool IsReloading = false;

    public Transform MainFirepoint;
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
        yield return new WaitForSeconds(ReloadTime);
        CurrentBullets = MaxBullets;
        AmmountOfBulletsVariable.SetAmmountOfBullets(CurrentBullets, MaxBullets);
        IsReloading = false;
    }


    public void Shoot(InputAction.CallbackContext Context)
    {
        if (CurrentBullets > 0 && !IsReloading)
        {
            CurrentBullets--;
            AmmountOfBulletsVariable.SetAmmountOfBullets(CurrentBullets, MaxBullets);
            SpawnBullets();
            if (CurrentBullets <= 0)
            {
                IsReloading = true;
                StartCoroutine("Reload");
            }
        }

    }
    public virtual void SpawnBullets()
    {
        GameObject Bullet = Instantiate(BulletPrefab, MainFirepoint.position, MainFirepoint.rotation);
        Rigidbody RigidbodyVariable = Bullet.GetComponent<Rigidbody>();
        RigidbodyVariable.AddForce(MainFirepoint.right * BulletSpeed, ForceMode.Impulse);
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
