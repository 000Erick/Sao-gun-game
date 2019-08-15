using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
    public static GameMaster current;
    public GameObject Player;
    public GameObject BackGround;
    public GameObject Plataformas;
    public GameObject[] spawner;
    public GameObject panel;
    private Text puntuationEndtxt;
    private Text municionText;
    private Text puntuationText;
    private Slider HPbarra;
    private Vector3 startPosition;
    private int puntuation;
    private float timeWest;
    private float timeEast;
    private float timeOut;
	// Use this for initialization
	void Start () {
        this.Player.SendMessage("crearPlayer", 1);
        this.BackGround.SendMessage("ModificarBackground", 2);
        //this.Plataformas.SendMessage("MyPlataform");
        GameMaster.current = this;
        this.municionText = GameObject.FindGameObjectWithTag("txtMunition").GetComponent<Text>();
        this.puntuationText = GameObject.FindGameObjectWithTag("txtPuntuation").GetComponent<Text>();
        this.HPbarra = GameObject.FindGameObjectWithTag("HP").GetComponent<Slider>();
        this.puntuationEndtxt = GameObject.FindGameObjectWithTag("txtPuntuationEnd").GetComponent<Text>();
        this.panel = GameObject.FindGameObjectWithTag("PanelDead");
        // this.startPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        this.UpdateTextPuntuation();
        this.spawner[1].SetActive(false);
        this.timeOut = 3;
        this.panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!this.spawner[0].activeSelf)
        {
            this.timeEast += Time.deltaTime;
            if (this.timeEast > this.timeOut)
            {
                this.timeEast = 0;
                this.spawner[0].SetActive(true);
            }
        }
		if(!this.spawner[1].activeSelf)
        {
            this.timeWest += Time.deltaTime;
            if (this.timeWest > this.timeOut)
            {
                this.timeWest = 0;
                this.spawner[1].SetActive(true);
            }
        }
	}


    void UpdateTextPuntuation()
    {
        this.puntuationText.text = "-- " + this.puntuation + " --";
    }
    public void AddPuntuation(int cantidad)
    {
        this.puntuation += cantidad;
        this.UpdateTextPuntuation();
    }



    public void UpdateTextMunition(int munition)
    {
        this.municionText.text = "Municion: " + munition;
    }


    public void UpdateSliderHp(float hp)
    {
        this.HPbarra.value = hp;
    }

    public void GamerOver()
    {
        this.panel.SetActive(true);
        this.puntuationEndtxt.text = "Puntuacion End :" + this.puntuation;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    public void OutScene()
    {
        SceneManager.LoadScene(1);
    }
}
