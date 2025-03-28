using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour



{
    [SerializeField]
    private float _verticalspeed = 4.0f;

    private Player _player;
    

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //mmove down 4 meters per second
        //respawn at top with a new random x position
        transform.Translate(Vector3.down * _verticalspeed * Time.deltaTime);

        //Instantiate(_enemyprefab,transform.position + new Vector3 (0, 16.5f, 0), Quaternion.identity);

        if (transform.position.y < -11.5f)
        {
            float randomX = Random.Range(-16.7f, 13.5f);
            transform.position = new Vector3(randomX, 16.5f, 0);
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {

     if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);


        }

     if (other.tag == "Laser")
        {
            Destroy(other.gameObject);

            if(_player != null)
            {
                _player.AddScore(10);
            }

            Destroy(this.gameObject);
        }
    }
}
