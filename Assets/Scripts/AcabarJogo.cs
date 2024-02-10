using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AcabarJogo : MonoBehaviour
{
    public static int perguntasResp = 0;
    public static bool chegouNoFim;
    public static int qntdCertas = 0;
    public static int qntdTotal = 0;
    [SerializeField] int qntdPergNecTotal = 10;

    [SerializeField] GameObject qntdPerguntas;
    [SerializeField] GameObject GanhouTela;
    [SerializeField] GameObject PerdeuTela;
    [SerializeField] TextMeshProUGUI QntdCertasText;
    // Start is called before the first frame update
    void Start()
    {
        perguntasResp = 0;
        chegouNoFim = false;
        qntdCertas = 0; qntdTotal = 0;
        QntdCertasText.text = $"{qntdCertas}/{qntdPergNecTotal}";
    }

    // Update is called once per frame
    void Update()
    {
        QntdCertasText.text = $"{qntdCertas}/{qntdPergNecTotal}";
        if (qntdCertas == qntdPergNecTotal)
        {
            chegouNoFim = true;
            GanhouTela.SetActive(true);
            Time.timeScale = 0;
        }
        /*
        if(qntdTotal == qntdPergNecTotal)
        {
            PerdeuTela.SetActive(true);
            Time.timeScale = 0;
        }*/
    }
}
