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
    public Collect UseFirstAid;

    private RogLike InputHeal;

    public InputAction WASD; // Movement
    public CharacterController Controller;
    public Transform MainHero;
   
    

    private void OnEnable()
    {
        WASD.Enable();
        InputHeal.Player.Heal.performed += Heal;
        InputHeal.Player.Heal.Enable();
    }
    private void OnDisable()            //Input Movement
    {
        WASD.Disable();
        InputHeal.Player.Heal.Disable();
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



    public IEnumerator HeroTakeDamage(float EnemyDamage, float EnemyInfection)
    {
        System.Random RandomHeroDamageSound = new System.Random();
        if (IsEnemyHittingHero) 
         {
            FindObjectOfType<AudioManager>().PlaySounds("man-hurt-noises-" + RandomHeroDamageSound.Next(1, 7));
            CurrentHealth -= EnemyDamage;
            MaxHealth -= EnemyInfection;
            HealthbarVariable.SetHealthBar(MaxHealth, CurrentHealth);

            if (CurrentHealth <= 0)
            {
                Die();

            }
           
            yield return new WaitForSeconds(1f);

            StopCoroutine("HeroTakeDamage");
            StartCoroutine(HeroTakeDamage(EnemyDamage, EnemyInfection));        
         }       
    }


    public void Die()
    {
        IsEnemyHittingHero = false;
        Destroy(gameObject);
        Collect.CollectArray.Clear();
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

    public void Heal(InputAction.CallbackContext Context)
    {
        if (Collect.CollectArray.ContainsKey("FirstAid") && Collect.CollectArray["FirstAid"] > 0)
        {
            FindObjectOfType<AudioManager>().PlaySounds("FirstAidUse"); 
            Debug.Log("Used");
            Collect.CollectArray["FirstAid"]--;
            MaxHealth = StartHealth;
            StartCoroutine("Regen");
            HealthbarVariable.SetHealthBar(MaxHealth, CurrentHealth);
            
        }
        else
        {
            Debug.Log("No Aid");
        }

    }


    public IEnumerator Regen()
    {

        while (CurrentHealth != MaxHealth && IsEnemyHittingHero == false)
        {
            yield return new WaitForSeconds(1f);
            if (CurrentHealth + HealthRegen >= MaxHealth)
            {
                CurrentHealth = MaxHealth;
                StopCoroutine("Regen");
            }
            else
            {   
                CurrentHealth += HealthRegen;
            }

            HealthbarVariable.SetHealthBar(MaxHealth, CurrentHealth);
        }
        StopCoroutine("Regen");
    }




        private void Awake()
    {
        InputHeal = new RogLike();
        Collect UseFirstAid = new Collect();
    }

    void Start()
    {
        GettingDamageDelay = 0.5f;
        MaxHealth = CurrentHealth;
        IsEnemyHittingHero = false;
        Controller = GetComponent<CharacterController>();

        HealthbarVariable.SetHealthBar(MaxHealth, CurrentHealth);
    }


    public void Update()
    {

        Movement();
        HeroLookToMouse();
    }


}
