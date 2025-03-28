using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField] //0 = Triple Shot 1 = Speed 2 = Shields
    private int powerupID;
    private string[] tripleshottext =
   {
        "Triple shot BABY!!!",
        "Say hello to my little friends!",
        "Time to light you up!"
    };


    // Start is called before the first frame update
    void Start()
    {
        float randomx = Random.Range(-16.5f, 13.5f);
        transform.position = new Vector3(randomx, 16f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        

        if (transform.position.y < -7f)
        {
            Destroy(this.gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
               switch(powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        int randomIndex = Random.Range(0, tripleshottext.Length);
                        Debug.Log(tripleshottext[randomIndex]);
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        Debug.Log("I’m faster than my Wi-Fi!");
                        break;
                    case 2:
                        player.ShieldsActive();
                        Debug.Log("I eat Spaceships for breakfast now");
                        break;
                    default:
                        Debug.Log("Default Value");
                        break;
                }
            }
            
            Destroy(this.gameObject);
        }
    }

  
}

