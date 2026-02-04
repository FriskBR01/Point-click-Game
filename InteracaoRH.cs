using UnityEngine;

public class InteracaoRH : MonoBehaviour
{
    // A variável pública que armazena os dados de impacto (Risco, Evidência, Feedback)
    // Esses dados são preenchidos no Inspector, usando a classe OpcaoDialogo.
    public OpcaoDialogo DadosDaInteracao;

    // Variável para armazenar o Collider2D do objeto.
    private Collider2D meuCollider;

    void Start()
    {
        // Tenta pegar o Collider2D anexado a este GameObject.
        meuCollider = GetComponent<Collider2D>();

        // Verifica se o Collider foi encontrado. É crucial para o script funcionar.
        if (meuCollider == null)
        {
            Debug.LogError("ERRO: Collider 2D ausente em " + gameObject.name + ". O clique não funcionará!");
        }
    }

    void Update()
    {
        // 1. Verifica se o botão esquerdo do mouse foi pressionado neste frame.
        if (Input.GetMouseButtonDown(0))
        {
            // 2. Converte a posição do mouse na tela para um ponto no mundo 2D.
            Vector2 pontoDoClique = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 3. Verifica se o ponto do clique está SOBRE a área do Collider 2D.
            if (meuCollider != null && meuCollider.OverlapPoint(pontoDoClique))
            {
                // Verifica se há dados para enviar e se o GameManager está pronto.
                if (DadosDaInteracao != null && GameManager.Instance != null)
                {
                    // 4. Chama a função principal do GameManager, passando TODOS os dados.
                    GameManager.Instance.ProcessarInteracao(DadosDaInteracao);

                    // Opcional: Desativar o objeto após o clique para que não possa ser clicado novamente.
                    // gameObject.SetActive(false); 
                }
                else
                {
                    Debug.LogError("Interação falhou! Verifique se os DadosDaInteracao estão preenchidos ou se o GameManager está na cena.");
                }
            }
        }
    }
}