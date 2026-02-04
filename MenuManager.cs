using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // FUNÇÃO QUE INICIA O JOGO (Chamada pelo botão)
    public void IniciarJogo()
    {
        // Carrega sua cena principal de investigação.
        SceneManager.LoadScene("Cena_Teste_Final");
    }

    // FUNÇÃO OPCIONAL PARA SAIR DO EXECUTÁVEL
    public void FecharJogo()
    {
        Application.Quit();
        Debug.Log("Saindo do Jogo...");
    }
}