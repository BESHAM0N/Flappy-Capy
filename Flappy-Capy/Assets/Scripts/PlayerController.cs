using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer _sr;
    public Sprite[] sprites;
    private int _spriteIndex;

    private Vector3 _direction;
    public float gravity = -9.8f;
    public float strength = 7.0f;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();    
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {       
        
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }
    

    // ������ �������� ����������� ������� ����� �������� ����
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        _direction = Vector3.zero;
    }

    // ��� ������� �� ������ ��� ��� ���������� ������ (��������� �������) � ����������� �� ���������� � ���� ��������
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) _direction = Vector3.up * strength;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) _direction = Vector3.up * strength;
        }
        
        _direction.y += gravity * Time.deltaTime;
        transform.position += _direction * Time.deltaTime;
    }

    //���� ����������� ������ ������� �������� ��� ��������
    private void AnimateSprite()
    {
        _spriteIndex++;

        if (_spriteIndex >= sprites.Length) _spriteIndex = 0;

        _sr.sprite = sprites[_spriteIndex];
    }

    // ��������� ���������� �������� � �������, ����� � ������ ������� 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {            
            audioManager.PlaySFX(audioManager.death);
            audioManager.StopSFX();
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            audioManager.PlaySFX(audioManager.score);            
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }



}
