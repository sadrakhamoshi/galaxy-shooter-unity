using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private const float _fireRate = 0.25f;

    public int _live = 1;

    public bool isSpeedUpPower;

    public bool isSheildPower;

    private float nextFire = 0.0f;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _shieldGameObject;

    [SerializeField]
    private GameObject _tripleShoot;

    [SerializeField]
    private GameObject _explosion;

    public bool canTripleShoot;

    [SerializeField]
    private float _speed;

    private float speedBooster = 3;

    private const float defaultSpeed = 5.0f;

    void Start()
    {
        //set position
        //variable with tag or drag in unity editor
        //laserPrefab = GameObject.Find("laser");

        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movment();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Time.time > nextFire)
        {
            if (canTripleShoot)
            {
                Instantiate(_tripleShoot, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            }
            nextFire = Time.time + _fireRate;
        }
    }

    private void Movment()
    {
        float vertaclInput = Input.GetAxis("Vertical");
        float HorizontalInput = Input.GetAxis("Horizontal");

        if (isSpeedUpPower)
            _speed = defaultSpeed * speedBooster;

        else
            _speed = defaultSpeed;

        transform.Translate(Vector3.right * Time.deltaTime * _speed * HorizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * _speed * vertaclInput);



        //check range of left and right and up and bottom
        if (transform.position.y > 0)
            transform.position = new Vector3(transform.position.x, 0, 0);
        else if (transform.position.y < -4.1f)
            transform.position = new Vector3(transform.position.x, -4.1f, 0);

        if (transform.position.x > 9.5f)
            transform.position = new Vector3(-9.5f, transform.position.y, 0);

        if (transform.position.x < -9.5f)
            transform.position = new Vector3(9.5f, transform.position.y, 0);
    }

    public void Damage()
    {

        if (isSheildPower)
        {
            isSheildPower = false;
            _shieldGameObject.SetActive(false);
            return;
        }
        else
        {
            _live--;
            if (_live < 1)
            {
                Instantiate(_explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }

    public void StartPowerUpTripleShoot()
    {
        canTripleShoot = true;
        StartCoroutine(TriplePowerUpDelay());
    }
    public IEnumerator TriplePowerUpDelay()
    {
        //wait 5 seconds and then do the rest
        yield return new WaitForSeconds(5.0f);
        canTripleShoot = false;
    }
    public void StartSpeedPowrUp()
    {
        isSpeedUpPower = true;
        StartCoroutine(PowerUpSpeedDelay());
    }

    public IEnumerator PowerUpSpeedDelay()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedUpPower = false;
    }

    public IEnumerator SheildPowerUP()
    {
        yield return new WaitForSeconds(5.0f);
        _shieldGameObject.SetActive(false);
        isSheildPower = false;
    }

    public void StartSheildPowerUp()
    {
        isSheildPower = true;
        _shieldGameObject.SetActive(true);
        StartCoroutine(SheildPowerUP());
    }
}
 