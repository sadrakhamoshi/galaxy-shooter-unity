using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyExplosion;

    [SerializeField]
    private UiManager _displayScore;

    [SerializeField]
    private AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        _displayScore = GameObject.Find("Canvas").GetComponent<UiManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -7.0f)
        {
            float randomX = Random.Range(-8.2f, 8.2f);
            transform.position = new Vector3(randomX, 6.5f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "laser")
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
            _displayScore.UpdateScore();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.Damage();
        }
        Instantiate(_enemyExplosion, transform.position, Quaternion.identity);
        //transform.position is in background we should use main to ear it louder
        AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
        Destroy(this.gameObject);
    }
}
