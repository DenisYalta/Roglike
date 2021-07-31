using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class Heroes : Mobs
{

    public float HealthRegen;
    public float MaxHealth;
    public float GettingDamageDelay;

    public bool IsEnemyHittingHero;

    public Enemies EnemiesVariable;
    public HealthBar HealthbarVariable;

   
    public InputAction WASD; // Movement
    public CharacterController Controller;




    private void OnEnable()
    {
        WASD.Enable();
    }
    private void OnDisable()            //Input Movement
    {
        WASD.Disable();
    }

    protected void Movement()
    {

        Vector2 InputVector = WASD.ReadValue<Vector2>();
        Vector3 FinalFector = new Vector3();

        FinalFector.x = InputVector.x;  //  Changing 2D Vector into 3D
        FinalFector.z = InputVector.y;

        Controller.Move(FinalFector * Time.deltaTime * Speed);

    }

    public IEnumerator Regen()
    {
        yield return new WaitForSeconds(1f);
        if (CurrentHealth + HealthRegen > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        else CurrentHealth = CurrentHealth + HealthRegen;

        HealthbarVariable.SetHealthBar(CurrentHealth, MaxHealth);
        StopCoroutine("Regen");
    }


    public IEnumerator HeroTakeDamage(float EnemyDamage)
    {
        
        if (IsEnemyHittingHero) 
         { 
            CurrentHealth -= EnemyDamage;
            HealthbarVariable.SetHealthBar(CurrentHealth, MaxHealth);
            if (CurrentHealth <= 0)
            {
                IsEnemyHittingHero = false;
                Destroy(gameObject);
            }
           
            yield return new WaitForSeconds(1f);

            StopCoroutine("HeroTakeDamage");
            StartCoroutine(HeroTakeDamage(EnemiesVariable.Damage));
          
         }       
    }


    public void OnTriggerEnter (Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IsEnemyHittingHero = true;

            EnemiesVariable = collision.GetComponent<Enemies>();
            StartCoroutine (HeroTakeDamage(EnemiesVariable.Damage));
            StopCoroutine("HeroTakeDamage");
        }  
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IsEnemyHittingHero = false;
        }
    }





    void Start()
    {
        GettingDamageDelay = 0.5f;
        IsEnemyHittingHero = false;
        Controller = GetComponent<CharacterController>();
        MaxHealth = CurrentHealth;
        HealthbarVariable.SetMaxHealth(MaxHealth);
    }
}
