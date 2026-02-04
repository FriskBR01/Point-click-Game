using UnityEngine;
using System; // Necessário para usar [Serializable]

[System.Serializable]
public class OpcaoDialogo
{
    [Header("Impacto no Jogo")]
    [Tooltip("Pontos que serão adicionados ou subtraídos do Risco Jurídico total do jogador.")]
    public int ImpactoNoRisco;

    [Tooltip("Se for True, esta escolha revela uma das 3 Evidências necessárias para o final.")]
    public bool RevelaEvidencia;

    [Header("Feedback para o Jogador")]
    [Tooltip("O texto que aparecerá na tela central de feedback após esta escolha.")]
    [TextArea(3, 5)]
    public string FeedbackParaJogador;

    [Header("Visual")]
    [Tooltip("O texto que aparece no botão de escolha (ex: 'Falar com o João').")]
    public string TextoDoBotao;
}