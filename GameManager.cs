using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // --- 1. SINGLETON ---
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // --- 2. VARIÁVEIS DE ESTADO E REFERÊNCIAS ---
    [Header("Estado e Score do Jogo")]
    public int RiscoJuridicoAtual = 10;
    public int EvidenciasColetadas = 0;
    private const int EvidenciasNecessarias = 3;

    [Header("Conexão UI")]
    public TextMeshProUGUI TextoCentralDeFeedback;

    [Header("Resultado Final")]
    public string ResultadoFinal;

    // --- 3. FUNÇÃO PRINCIPAL DE LÓGICA (Processa o clique de diálogo) ---
    public void ProcessarInteracao(OpcaoDialogo interacao)
    {
        if (EvidenciasColetadas < EvidenciasNecessarias)
        {
            // 1. Atualiza o estado
            RiscoJuridicoAtual += interacao.ImpactoNoRisco;

            if (interacao.RevelaEvidencia)
            {
                EvidenciasColetadas++;
            }

            // 2. Mostra o Feedback na UI
            if (TextoCentralDeFeedback != null)
            {
                TextoCentralDeFeedback.text = interacao.FeedbackParaJogador;
            }

            // 3. Verifica a Condição de Fim de Fase
            if (EvidenciasColetadas >= EvidenciasNecessarias)
            {
                MostrarSolucao();
                // Desativa o GameManager
                enabled = false;
            }
        }
    }

    // --- 4. FUNÇÃO DE SOLUÇÃO (Fim do Jogo) ---
    public void MostrarSolucao()
    {
        // 1. Cálculo Básico do Score
        int score = 1000;
        score += EvidenciasColetadas * 100;
        score -= RiscoJuridicoAtual * 10;

        string solucaoDeRH;

        // 2. Determina a Solução e o Feedback Narrativo
        if (RiscoJuridicoAtual > 40)
        {
            solucaoDeRH = "SOLUÇÃO DE RISCO: A investigação foi concluída com risco legal. A decisão é DEMISSÃO SEM JUSTA CAUSA.     O custo será alto, mas evita o processo. ";
        }
        else
        {
            solucaoDeRH = "SOLUÇÃO ÓTIMA: Com base nas evidências de sobrecarga, a decisão é MEDIAÇÃO e TRANSFERÊNCIA de João para outra equipe, mantendo-o na empresa. ";
        }

        // 3. Exibir o resultado final (Solução + Score)
        ResultadoFinal = solucaoDeRH + $"\nSeu Score Final (Gestão de Risco): {score}";
        TextoCentralDeFeedback.text = ResultadoFinal;
    }
}