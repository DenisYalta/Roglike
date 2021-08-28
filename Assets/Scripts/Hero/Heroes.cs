using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class Heroes : Mobs
{
    public float HealthRegen;
    public float MaxHealth;
    public float GettingDamageDelay;
    public float RotationSpeed;
    public float Speed;

    public bool IsEnemyHittingHero;

    public Enemies EnemiesVariable;
    public HealthBar HealthbarVariable;

    public InputAction WASD; // Movement
    public CharacterController Controller;
    public Transform MainHero;

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

    protected void HeroLookToMouse()
    {
        Plane PlayerPlane = new Plane(Vector3.up, transform.position);
        Ray RayVariable = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        float HitDistance = 0.0f;

        if (PlayerPlane.Raycast(RayVariable, out HitDistance))
        {
            Vector3 TargetPoint = RayVariable.GetPoint(HitDistance);
            Quaternion TargetRotation = Quaternion.LookRotation(TargetPoint - transform.position);
            TargetRotation.x = 0;
            TargetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, RotationSpeed * Time.deltaTime);
        }
    }

    public IEnumerator Regen()
    {
        yield return new WaitForSeconds(1f);

        if (CurrentHealth + HealthRegen > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        else CurrentHealth += HealthRegen;

        HealthbarVariable.SetHealthBar(MaxHealth, CurrentHealth);
        StopCoroutine("Regen");
    }


    public IEnumerator HeroTakeDamage(float EnemyDamage, float EnemyInfection)
    {
        if (IsEnemyHittingHero) 
         { 
            CurrentHealth -= EnemyDamage;
            MaxHealth -= EnemyInfection;
            HealthbarVariable.SetHealthBar(MaxHealth, CurrentHealth);

            if (CurrentHealth <= 0)
            {
                IsEnemyHittingHero = false;
                Destroy(gameObject);
            }
           
            yield return new WaitForSeconds(1f);

            StopCoroutine("HeroTakeDamage");
            StartCoroutine(HeroTakeDamage(EnemyDamage, EnemyInfection));        
         }       
    }


    public void OnTriggerEnter (Collider Collision)
    {
   
        if (Collision.gameObject.CompareTag("Enemy"))
        {
            IsEnemyHittingHero = true;
            EnemiesVariable = Collision.GetComponent<Enemies>();
            StartCoroutine (HeroTakeDamage(EnemiesVariable.Damage, EnemiesVariable.Infection));
            StopCoroutine("HeroTakeDamage");
        }  
    }


    public void OnTriggerExit(Collider Collision)
    {

        if (Collision.gameObject.CompareTag("Enemy") || Collision.gameObject.CompareTag("Spikes"))
        {
            IsEnemyHittingHero = false;
        }
    }


    void Start()
    {
        GettingDamageDelay = 0.5f;
        MaxHealth = CurrentHealth;
        IsEnemyHittingHero = false;
        Controller = GetComponent<CharacterController>();

        Debug.Log(HealthbarVariable);
        HealthbarVariable.SetHealthBar(MaxHealth, CurrentHealth);
    }

    public void Update()
    {

        Movement();
        if (MaxHealth > CurrentHealth)
        {
            StartCoroutine("Regen");
        }

        HeroLookToMouse();
    }


}
