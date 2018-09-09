using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    public int[] score = { 0, 0 };
    public GameObject[] player = new GameObject[2];
    private PlayerBehaviour[] playerBehaviour;
    public string[] playerName = { "P1", "P2" };
    public Vector3[] respawnPoints;

    public Vector3[] platformRespawn; //spawnpoints for the map with platforms
    public Vector3[] noPlatformRespawn; //spawnpoitns the map without platforms

    public float respawnTime = 2.5f;
    public Image[] playerUI = new Image[2];
    public GlobalVariables globalVariables;
    public float gameStart = 0; // time of the start of the game
    public bool suddenDeath = false;

    void Awake()
    {
        Cursor.visible = false;
        playerBehaviour = new PlayerBehaviour[player.Length];
        for (int i = 0; i < playerBehaviour.Length; i++)
        {
            playerBehaviour[i] = player[i].GetComponent<PlayerBehaviour>();
        }
        if(globalVariables == null)
        {
            globalVariables = GameObject.FindGameObjectWithTag("GLOBAL").GetComponent<GlobalVariables>();
        }
    }

	// Use this for initialization
	void Start ()
    {
        respawnPoints = globalVariables.platforms ? platformRespawn : noPlatformRespawn;
        
        for(int i = 0; i < player.Length; i++)
        {
            Respawn(i);
        }
        gameStart = Time.time;
        for (int i = 0; i < globalVariables.score.Length; i++)
        {
            globalVariables.score[i] = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //if any players are dead and respawn time has passed, respawn the players
        for (int i = 0; i < player.Length; i++)
        {
            if(!playerBehaviour[i].alive && Time.time - playerBehaviour[i].timeOfDeath >= respawnTime)
            {
                Respawn(i);
            }
        }

        //if the game has reached the time limit
        if (Time.time - gameStart > globalVariables.timeLimit && globalVariables.timed)
        {
            //one player has the most points; enter victory screen
            if (score[0] != score[1])
            {
                LoadVictoryScene();
            }
            else if (!suddenDeath) //no winner yet; enter sudden death
            {
                for (int p = 0; p < player.Length; p++)
                {
                    playerBehaviour[p].pushForce *= 6; // TODO push force is hardcoded; also maybe tweak value?
                    Respawn(p);
                }
                suddenDeath = true;
            }
        }

    }


    /// <summary>
    /// Called when a player dies
    /// </summary>
    /// <param name="victim"></param>
    /// <param name="victimScript"></param>
    public void KOD(GameObject victim, PlayerBehaviour victimScript)
    {

        //TODO horribly inefficient code; add int value to the victim script keeping track of the index instead of this?
        int deadIndex = 0;
        bool found = false;
        {
            for (int i = 0; i < player.Length && !found; i++)
            {
                if (player[i].Equals(victim) && playerBehaviour[i].Equals(victimScript))
                {
                    found = true;
                    deadIndex = i;
                }
            }
        }
        score[1 - deadIndex]++;

        player[deadIndex].transform.position = new Vector3(0, -100, 0); //move dead player outside screen
        playerBehaviour[deadIndex].timeOfDeath = Time.time;
        playerBehaviour[deadIndex].alive = false;
        playerUI[deadIndex].GetComponent<PlayerIcon>().UpdateIconAlive(false);

        //detect which player is ahead in points
        int ahead = 0;
        int highestScore = 0;
        for(int i = 0; i < score.Length; i++)
        {
            if(score[i] > highestScore)
            {
                highestScore = score[i];
                ahead = i;
            }
        }

        //apply handicap to winning player
        //TODO does this work for any number of players?
        //TODO does handicap even make sense?
        if (score[1 - ahead] <= highestScore - 5)
        {
            playerBehaviour[1 - ahead].maxEnergy = playerBehaviour[1 - ahead].baseMaxEnergy + Mathf.Floor((highestScore - score[1 - ahead]) / 5);
        }
        else
        {
            playerBehaviour[1 - ahead].maxEnergy = playerBehaviour[1 - ahead].baseMaxEnergy;
        }

        //if a player reached the score limit, end the game
        if(globalVariables.scored && highestScore >= globalVariables.scoreLimit || suddenDeath)
        {
            LoadVictoryScene();
        }
        else
        { //else play the death sound
            playerBehaviour[deadIndex].sound.DeathSound();
        }
    }

    public void LoadVictoryScene()
    {//TODO game freezes for a small amount of time when scenes are loaded
        globalVariables.score = score;
        globalVariables.gameTime = Time.time - gameStart;
        SceneManager.LoadScene("VictoryScene");
    }

    public void Respawn(int deadIndex)
    {
        player[deadIndex].SetActive(true);
        int attempts = 0;
        int spawnPoint = Random.Range(0, respawnPoints.Length);
        while ((respawnPoints[spawnPoint] - player[1 - deadIndex].transform.position).magnitude < 10 && attempts <= 30) //TODO hardcoded values 
            //TODO possible bug as no guarantee to find respawn point
        {
            spawnPoint = Random.Range(0, respawnPoints.Length);
            attempts++;
        }
        playerBehaviour[deadIndex].alive = true;
        player[deadIndex].transform.position = respawnPoints[spawnPoint];
        playerBehaviour[deadIndex].Respawn();
        playerUI[deadIndex].GetComponent<PlayerIcon>().UpdateIconAlive(true);

        playerBehaviour[deadIndex].sound.RespawnSound();
    }
}
