using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    private bool _killMessage;
    public AudioClip[] _killMessages;
    public AudioClip[] successMessages;
    private AudioSource _audioManager;
    private float respawnTimer = 0f;

    // Initialize self
    void Awake ()
    {
        _audioManager = GetComponent<AudioSource>();
    }

    // Initialize references to others
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(PlayerStats.killed == true && _killMessage == false)
        {
            int random = Random.Range(0,3);
            _audioManager.clip = _killMessages[random];
            _audioManager.Play();
            _killMessage = true;
        }

        if(_killMessage == true)
        {
            respawnTimer += Time.deltaTime;
            if(respawnTimer >= 1.0f)
            {
                _killMessage = false;
                respawnTimer = 0f;
            }
        }

	
	}
    public void SuccessMessage(int waypoint)
    {
        _audioManager.clip = successMessages [waypoint];
        _audioManager.Play();
    }
}
