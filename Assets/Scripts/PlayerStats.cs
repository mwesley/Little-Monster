using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {


	private int currentCheckpoint;
	private Vector2 respawnLocation;
    public static bool killed;
    private float respawnTimer = 0f;

	public GameObject player;
    private ParticleSystem particles;
	PlayerMovement playerMove;
    AudioManager audioManager;

	// Use this for initialization
	void Start () {
		playerMove = player.GetComponent<PlayerMovement> ();
        particles = player.GetComponent<ParticleSystem>();
        //audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        killed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (killed)
        {
            respawnTimer += Time.deltaTime;
            player.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
            particles.Play();
            if (respawnTimer >= 1.0f)
            {
                killed = false;
                player.renderer.enabled = true;
                respawnTimer = 0f;
                particles.Stop();
            }
        }
	}
	
	public void UpdateCheckpoint(int checkpoint, Vector2 loc)
	{
		currentCheckpoint = checkpoint;
		respawnLocation = loc;
        //audioManager.SuccessMessage(currentCheckpoint);
	}

	public void killPlayer()
	{
        player.transform.localScale = Vector3.zero;
        player.rigidbody2D.transform.position = respawnLocation;
		player.rigidbody2D.velocity = Vector3.zero;
        killed = true;

	}
}