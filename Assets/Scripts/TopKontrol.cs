using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    //Değişkenler
    Rigidbody2D rb; //Zıplama fiziksel işlem için
    public float ziplamaKuvveti = 3f; //Ne kadar zıplayacak onun kontrolü
    bool basildiMi = false; //Kullanıcı input yaptı mı onu anlamak için

    public string mevcutRenk;
    public Color topunRengi;
    public Color turkuaz, sari, pembe, mor;

    [SerializeField] Text scoreText;
    public static int score = 0;

    public GameObject halka, renkTekeri;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        scoreText.text = "Score: " + score;
        RastgeleRenkBelirle();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            basildiMi = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            basildiMi = false;
        }
    }
    private void FixedUpdate()
    {
        if (basildiMi)
        {
            rb.velocity = Vector2.up * ziplamaKuvveti;

        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RenkTekeri")
        {
            RastgeleRenkBelirle();
            Destroy(collision.gameObject);
            return;
        }
        if (collision.tag !=mevcutRenk && collision.tag != "PuanArttirici" && collision.tag != "RenkTekeri")
        {
            score = 0; //Eğer can sistemi yapılacaksa burası can sayısına entegre edilmeli. Yapılmayacaksa puan scoredaki statik kaldırılabilir.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.tag == "PuanArttirici")
        {
            score += 5;
            scoreText.text = "Score: " + score;
            Destroy(collision.gameObject);

            Instantiate(halka, new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z), Quaternion.identity);
            Instantiate(renkTekeri, new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z), Quaternion.identity);
        }
    }
    void RastgeleRenkBelirle()
    {
        int rastgeleSayi = Random.Range(0, 4); //0-1-2-3

        switch (rastgeleSayi)
        {
            case 0:
                mevcutRenk = "Turkuaz";
                topunRengi = turkuaz;
                break;

            case 1:
                mevcutRenk = "Sari";
                topunRengi = sari;
                break;

            case 2:
                mevcutRenk = "Pembe";
                topunRengi = pembe;
                break;

            case 3:
                mevcutRenk = "Mor";
                topunRengi = mor;
                break;
        }
        GetComponent<SpriteRenderer>().color = topunRengi;
    }

}//class
