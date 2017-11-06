using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHP : MonoBehaviour {

    public string gameover;

    public int hp = 100;
    public int starthp = 100;
    public GameObject tankexplosion;
    public AudioClip tankexplosionaudio;

    public Slider m_slider;
    public Image m_image;
    public Color m_full = Color.green;
    public Color m_zero = Color.red;

    private void OnEnable()
    {
        SethealthUI();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void take_damage()
    {
        SethealthUI();

        if (hp <= 0)
        {
            GameObject.Instantiate(tankexplosion, transform.position + Vector3.up, transform.rotation);
            AudioSource.PlayClipAtPoint(tankexplosionaudio,transform.position);
            GameObject.Destroy(this.gameObject);
            Application.LoadLevel(gameover);
        }
        hp -= Random.Range(5, 10);
    }

    private void SethealthUI()
    {
        m_slider.value = hp;
        m_image.color = Color.Lerp(m_zero, m_full, hp / starthp);
    }
}
