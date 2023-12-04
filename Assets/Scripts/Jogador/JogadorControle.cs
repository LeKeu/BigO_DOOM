using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Burst.CompilerServices;

public class JogadorControle : MonoBehaviour
{
    public static JogadorControle instancia;
    Rigidbody2D rb;
    
    [SerializeField] public float vel = 5f;
    [SerializeField] float mouseSensibilidade = 1f;
    public Camera viewCam; 

    Vector2 movInput;
    Vector2 mouseInput;

    [SerializeField] GameObject balaImpacto;
    [SerializeField] Animator armaAnim;
    public int qntdBalas;
    bool morreu;
    public bool respondeu = false;

    //Vida player
    public int vidaAtual = 99;
    [SerializeField] public int vidaMax = 100;
    public GameObject telaMorte;

    [SerializeField] TextMeshProUGUI textVida, textBalas;

    Animator animator;

    [SerializeField] BuffDebuff buffDebuff;

    List<string> OpcsAssint = new List<string>() { "1", "log", "N", "N*log", "N^", "^N" };
    // Start is called before the first frame update
    private void Awake()
    {
        instancia = this;
        vidaAtual = vidaMax;
    }

    void Start()
    {
        //qntdBalas = 0;
        rb = gameObject.GetComponent<Rigidbody2D>();

        textVida.text = vidaAtual.ToString();
        textBalas.text = qntdBalas.ToString();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!morreu)
        {
            // Jogador hor ver
            movInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector3 movHor = transform.up * -movInput.x;
            Vector3 movVert = transform.right * movInput.y;

            rb.velocity = (movHor + movVert) * vel;

            // Jogador view controle
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensibilidade;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

            viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

            // Atirar
            if (Input.GetMouseButtonDown(0))
            {
                if (qntdBalas > 0)
                {
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Instantiate(balaImpacto, hit.point, transform.rotation);
                        if (hit.transform.tag == "Inimigo")
                        {
                            hit.transform.parent.GetComponent<InimigoController>().TirarVida();
                        }
                        ChecarAssint(hit);
                        /*
                        if (hit.transform.tag == "Omega")
                        {
                            porta.abrirPorraPorta = false;
                            AcabarJogo.perguntasResp++;
                            if(hit.transform.parent.GetComponent<ButCertoResp>().resp == 'o') 
                            {
                                respondeu = true;
                                buffDebuff.Buff();
                                hit.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.green;
                                IA_DAC.strike++;
                                hit.transform.GetComponent<BoxCollider>().enabled = false;
                                GameObject.FindGameObjectWithTag("BigO").transform.GetComponent<BoxCollider>().enabled = false;
                                AcabarJogo.qntdCertas++;
                            }
                            else { respondeu = true; hit.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red; buffDebuff.Debuff(); IA_DAC.strike = 0; }
                        }
                        if (hit.transform.tag == "BigO")
                        {
                            porta.abrirPorraPorta = false;
                            AcabarJogo.perguntasResp++;
                            if (hit.transform.parent.GetComponent<ButCertoResp>().resp == 'b') 
                            {
                                respondeu = true;
                                buffDebuff.Buff();
                                hit.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.green;
                                IA_DAC.strike++;
                                hit.transform.GetComponent<BoxCollider>().enabled = false;   
                                GameObject.FindGameObjectWithTag("Omega").transform.GetComponent<BoxCollider>().enabled = false;
                                AcabarJogo.qntdCertas++;
                            }
                            else { respondeu = true; hit.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red; buffDebuff.Debuff(); IA_DAC.strike = 0; }
                        }*/
                    }
                    qntdBalas--;
                    armaAnim.SetTrigger("atirar");
                    AtualizarBala();
                }
            }
            if(movInput != Vector2.zero)
            {
                animator.SetBool("taAndando", true);
            }
            else
            {
                animator.SetBool("taAndando", false);
            }
        }
        
    }

    public void ChecarAssint(RaycastHit hit)
    {
        Debug.Log("tag - "+hit.transform.tag);

        foreach(string a in OpcsAssint)
        {
            if (hit.transform.tag == a)
            {
                Debug.Log(hit.transform.tag + " atingido e a = "+ a);
                porta.abrirPorraPorta = false;
                AcabarJogo.perguntasResp++;

                Debug.Log("resposta - "+hit.transform.parent.GetComponent<ButCertoResp>().respAssint);
                if (hit.transform.parent.GetComponent<ButCertoResp>().respAssint == a)
                {
                    respondeu = true;
                    buffDebuff.Buff();
                    hit.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.green;
                    IA_DAC.strike++;
                    hit.transform.GetComponent<BoxCollider>().enabled = false;
                    GameObject.FindGameObjectWithTag(hit.transform.parent.GetComponent<ButCertoResp>().erradaAssint).transform.GetComponent<BoxCollider>().enabled = false;
                    AcabarJogo.qntdCertas++;
                }
                else { respondeu = true; hit.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red; buffDebuff.Debuff(); IA_DAC.strike = 0; }
                break;
            }
            
        }
    }

    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;
        if(vidaAtual <= 0)
        {
            telaMorte.SetActive(true);
            morreu = true;
            vidaAtual = 0;
        }
        textVida.text = vidaAtual.ToString() + "%";
    }

    public void CurarVida(int cura)
    {
        vidaAtual += cura;
        if(vidaAtual > vidaMax)
        {
            vidaAtual = vidaMax;
        }
        textVida.text = vidaAtual.ToString() + "%";
    }

    public void AtualizarBala()
    {
        textBalas.text = qntdBalas.ToString();
    }
}
