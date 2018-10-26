﻿using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerBehaviour : MonoBehaviour {

    public bool mainPlayer = false;
    [Space(20)]
    public float baseMaxEnergy = 2;
    public float energyCostRate = 1;
    public float energyCostMin = 0.1f;
    public float energyRegenRate = 2;
    public float gracePeriod = 0.1f;
    public float airChargeRate = 0.05f;
    [Space(10)]
    public float chargeMax = 0.9f; //The maximal amount of time in which the player can charge
    public float chargeMin = 0.15f; //A bonus length aplied to all charges
    public float pushForce = 10;    //The amount of force with which the player pushes other objects
    public float walkSpeed = 1; //The amount of speed with which the player "walks"
    public float dashForce = 25;    //The amount of force with which the player dashes
    public float chargeParachuteFactor = 2;
    public float respawnTime = 2;
    [Space(20)]
    public Rigidbody body;  //The object's Rigidbody
    public Collider collision;  //The object's collider
    public GameObject main;
    [Space(20)]
    public Vector3 spawn; //The spawn location for the player
    public float chargeDir = 90; //The direction in which the currently charging dash is pointed
    [Space(20)]
    public bool charging = false;   //A boolean that keeps track of whether the player is charging
    public bool onGround = false;   //A boolean that keeps track of whether the player is on the ground
    public float chargeStart = 0;   //A boolean that keeps track of when the player started charging their dash
    public float energy;
    public float timeOfLastTouch = 0;
    public float timeOfLastDash = 0;
    public bool alive = true;
    public float timeOfDeath = 0;
    public float maxEnergy = 2;
    public bool doomed = false;
    [Space(20)]
    public PlayerSounds sound;
    public InputController inputController;
    public ChargeUp chargeUpSoundManager;
    [Space(20)]
    public GameObject smokeBombEffect;
    public ParticleSystem chargeEffect;
    [Space(20)]
    public Color spawnColor;



    void Awake ()
    {
        maxEnergy = baseMaxEnergy;
        body = GetComponent<Rigidbody>();   //Sets the Rigidbody
        spawn = transform.position; //Sets the spawn position to the start position
        energy = maxEnergy;
        timeOfLastTouch = 0;
        timeOfLastDash = 0;
        alive = true;
        timeOfDeath = Time.time - main.GetComponent<Main>().respawnTime;
    }

	// Use this for initialization
	void Start ()
    {

        SetChargeEffectIntensity(0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (alive)
        {
            Charge();   //Run the charge command
            RegenerateEnergy();
            CheckIfDoomed();
        }
        //chargeEffect.transform.position = transform.position;
    }

    void FixedUpdate()  //Runs 50 times per second
    {
        if (alive)
        {
            if (!charging)
            {
                Move(walkSpeed);    //Run the walk command with the object's walk speed
            }
            else
            {
                if (body.velocity.y < 0)
                {
                    body.velocity = (new Vector3(body.velocity.x, body.velocity.y / chargeParachuteFactor, body.velocity.z));
                }
            }

            if (KOCheck()) KO();    //Checks if the player is KO'd, and if they are, KO them
        }
    }

    public void OnCollisionEnter(Collision col)    //Runs when initiating contact with other objects
    {
        if (col.gameObject.CompareTag(gameObject.tag))  //Checks if the other object's tag matches the current tag (is the object another player?)
        {
            if (mainPlayer) //only does this on one of the players
            {
                
                Rigidbody other = col.gameObject.GetComponent<Rigidbody>(); //Stores the collision object's Rigidbody in other

                Vector2 colSpeed = body.velocity - other.velocity;

                sound.HitPlayer(colSpeed.magnitude);

                Vector3 selfForce = Vector3.zero;
                Vector3 otherForce = Vector3.zero;

                if (other.velocity.magnitude < body.velocity.magnitude) //Checks if the current object moves slower than the other object
                {
                    selfForce = (body.position - other.position).normalized * pushForce * other.velocity.magnitude; //Shoots self away from the other player

                    otherForce = (other.position - body.position).normalized * pushForce * body.velocity.magnitude / (main.GetComponent<Main>().suddenDeath ? 10 : 2.5f);
                }
                else if (other.velocity.magnitude > body.velocity.magnitude)
                {
                    otherForce = other.velocity + (other.position - body.position).normalized * pushForce * body.velocity.magnitude; //Shoots self away from the other player
                    
                    selfForce = (body.position - other.position).normalized * pushForce * other.velocity.magnitude / (main.GetComponent<Main>().suddenDeath ? 10 : 2.5f);
                }

                body.velocity += selfForce;
                other.velocity += otherForce;
                
            }
        }
        else
        {
            switch (col.gameObject.tag)
            {
                case "Arena":
                    onGround = true;    //Inform's the game that the player is on the ground
                    timeOfLastTouch = Time.time;
                    break;
            }
            sound.HitGround(System.Math.Abs(body.velocity.y));
        }
    }


    public void OnCollisionStay(Collision col) //Runs while in contact with other object
    {
        if (!col.gameObject.CompareTag(gameObject.tag)) //Checks if the tags DO NOT match
        {
            switch (col.gameObject.tag)
            {
                case "Arena":
                    onGround = true;    //Informs the game that the player is on the ground
                    timeOfLastTouch = Time.time;
                    break;
            }
        }
    }

    public void OnCollisionExit(Collision col) //Runs when leaving contact with other objects
    {
        if (!col.gameObject.CompareTag(gameObject.tag)) //Checks if the tags DO NOT match
        {
            onGround = false;   //Informs the game that the player is not on ground
        }
    }


    //=====================================================================
    // UNITY BUILD IN ABOVE, OWN FUNCTIONS BELOW
    //=====================================================================


    public void Charge()    //Charge up a dash
    {
        if (mainPlayer)
        {
            if (inputController.IsPlayerCharging(1)) //Check if the charge/dash buttons are being held
            {
                if (!charging && energy >= energyCostMin)  //Check if already charging
                {
                    chargeStart = Time.time;    //Set the start time of the charge
                    charging = true;    //Inform the system that the charge has started

                    SetChargeEffectIntensity(0);

                }
                chargeDir = SetChargeDirection(inputController.Player1Dir());

                SetChargeEffectIntensity(GetChargeFraction());
            }
            else
            {
                chargeDir = SetChargeDirection(inputController.Player1Dir());
                if (charging)   //Check if previously charging
                {
                    Dash(); //Launch dash
                    charging = false;   //Inform the system that the charge has ended
                }
            }
        }
        else
        {
            if (inputController.IsPlayerCharging(2)) //Check if the charge/dash buttons are being held
            {
                if (!charging && energy >= energyCostMin)  //Check if already charging
                {
                    chargeStart = Time.time;    //Set the start time of the charge
                    charging = true;    //Inform the system that the charge has started


                    SetChargeEffectIntensity(0);

                }
                chargeDir = SetChargeDirection(inputController.Player2Dir());
                SetChargeEffectIntensity(GetChargeFraction());
            }
            else
            {
                chargeDir = SetChargeDirection(inputController.Player2Dir());
                if (charging)   //Check if already charging
                {
                    Dash(); //Launch dash
                    charging = false;   //Inform the system that the charge has ended
                }
            }
        }
    }

    //returns a value between 0 and 1 determining how much has been charged as a fraction of max charge.
    public float GetChargeFraction() {
        return Mathf.Min(Time.time - chargeStart, chargeMax, CalculateMaxCharge()) / chargeMax;
    }
    
    public float CalculateMaxCharge()
    {
        return ((energy - energyCostMin) / energyCostRate);
    }


    private void SetChargeEffectIntensity(float rate) //number must be between 0 and 1
    {
        var emission = chargeEffect.emission;
        emission.rateOverTime = rate * 20;
        var main = chargeEffect.main;
        main.startSpeed = 5f + 3f*rate;
        chargeUpSoundManager.PlayChargeSound(rate);
    }
    
    public void CheckIfDoomed() //Checks if doomed, whatever that means
    {
        if(!Physics.Raycast(transform.position, Vector3.down, 50))
        {
            if ((transform.position.x > 0 && body.velocity.x > 0) || (transform.position.x < 0 && body.velocity.x < 0))
            {
                if (energy < energyCostMin)
                {
                    if (!doomed)
                    {
                        print("DAMMIT");
                    }
                    doomed = true;
                }
            }
        }
        else
        {
            doomed = false;
        }
    }

    public void Dash() //Dashes the player in direction chargeDir
    {
        SetChargeEffectIntensity(0);
        if (energy >= energyCostMin && chargeDir >= 0)
        {
            sound.Dash();
            energy -= energyCostMin;
            float chargeTime = Mathf.Min(chargeMax, Time.time - chargeStart, energy / energyCostRate);
            energy -= chargeTime * energyCostRate;
            
            chargeTime += chargeMin;
            
            body.velocity = body.velocity + new Vector3(Mathf.Cos(chargeDir / 180 * Mathf.PI) * dashForce * chargeTime, Mathf.Sin(chargeDir / 180 * Mathf.PI) * dashForce * chargeTime, 0);
            timeOfLastDash = Time.time;
        }
    }

    public float FindDirection(Vector2 vector) //converts vector2 to angle
    {
        float angle = Vector2.Angle(vector, Vector2.right);
        if (vector.y < 0) angle = 360 - angle;
        return (angle);
    }

    public void KO()    //KOs a player and respawns them
    {
        
        CancelCharge();
        energy = 0;
        main.GetComponent<Main>().KOD(gameObject, this);
    }

    public void CancelCharge() //Cancels charge
    {
        charging = false;
        SetChargeEffectIntensity(0);
    }

    public bool KOCheck()   //Checks if the player is KO'd
    {
        return (transform.position.y < -15 || transform.position.y > 40 || transform.position.x > 40 || transform.position.x < -40);    //If the player is not within a box, they're out of bounds and dies
    }

    public void Move(float speed)   //Standard Movement
    {
        if (onGround)   //Check if on ground
        {
            //Accelerate the current speed
            if (mainPlayer) //TODO probably not the most elegant implementation
                body.velocity = new Vector3(body.velocity.x + speed * inputController.Player1Dir().x, body.velocity.y, body.velocity.z);
            else
                body.velocity = new Vector3(body.velocity.x + speed * inputController.Player2Dir().x, body.velocity.y, body.velocity.z);
        }
    }

    public void RegenerateEnergy() //called each update to recharge energy as appropriate
    {
        if (Time.time - timeOfLastDash >= gracePeriod)
        {
            if (Time.time - timeOfLastTouch <= gracePeriod)
            {
                energy = Mathf.Min(energy + energyRegenRate * Time.deltaTime, maxEnergy);
            }
            else
            {
                energy += airChargeRate * Time.deltaTime;
            }
        }
    }

    public void Respawn() //respawn a player
    {
        // Spawn smoke.
        ParticleSystem ps = smokeBombEffect.GetComponent<ParticleSystem>();

        var main = ps.main;
        main.startColor = spawnColor;

        ps.Play();
        /*
        Vector3 smokePos = body.transform.position;
        smokePos.z = -2;
        GameObject smoke = (GameObject) Instantiate(smokePrefab, smokePos, Quaternion.identity);
        var main = smoke.GetComponent<ParticleSystem>().main;
        main.startColor = spawnColor;
        */
        body.velocity = new Vector3(0, 0, 0);   //Sets the current speed to be 0
        body.angularVelocity = new Vector3(0, 0, 0);    //Stops the current rotation
        energy = maxEnergy;
        charging = false;
    }

    public float SetChargeDirection(Vector2 dir)
    {
        if (dir.x == 0 && dir.y == 0)
        {
            return (-1);
        }
        else
        {
            return (FindDirection(new Vector2(dir.x, dir.y)));
        }
    }

}
