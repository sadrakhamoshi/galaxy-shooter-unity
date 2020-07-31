using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.0f;

    [SerializeField]
    private int powerupID;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (powerupID == 0)
                {
                    player.StartPowerUpTripleShoot();
                }
                else if (powerupID == 1)
                {
                    player.StartSpeedPowrUp();
                }
                else if (powerupID == 2)
                {
                    //  enable shield
                    player.StartSheildPowerUp();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
