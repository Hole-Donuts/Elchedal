using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] GameObject _Player;
    private Rigidbody2D _RG2D;
    [SerializeField] StatSCharacter statSCharacter;

    float _timeToInactive = 0;
    // Start is called before the first frame update
    void Start()
    {
        _RG2D = GetComponent<Rigidbody2D>();
        _Player = GameObject.FindGameObjectWithTag("Player");
       

        
    }

    public void Update()
    {
        Vector3 _Direction = _Player.transform.position - transform.position;
        _RG2D.velocity = new Vector2(_Direction.x, _Direction.y).normalized * statSCharacter._Force;

        float _Rot = Mathf.Atan2(-_Direction.y, _Direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _Rot + 90);
        if (gameObject.active)
        {
            _timeToInactive += Time.deltaTime;
            if (_timeToInactive >= 2)
            {
                gameObject.SetActive(false);
                _timeToInactive = 0;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }

}
