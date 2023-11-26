using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AcabarJogo : MonoBehaviour
{
    public static int perguntasResp = 0;
    public static bool chegouNoFim;
    public static int qntdCertas = 0;
    [SerializeField] int qntdPergNecTotal = 10;

    [SerializeField] GameObject qntdPerguntas;
    [SerializeField] GameObject GanhouTela;
    [SerializeField] TextMeshProUGUI QntdCertasText;
    // Start is called before the first frame update
    void Start()
    {
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
        }
    }
}
