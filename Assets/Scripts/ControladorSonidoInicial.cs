using UnityEngine;

public class ControladorSonidoInicial : MonoBehaviour
{
    private PAJARO scriptPajaro;
    private InteraccionCarpincho scriptCarpincho;
    private ObjectInteraction scriptCiervo;
    private INTERACCION_TORTUGA scriptTortuga;

    public AudioSource audioSource;
    public AudioClip sonidoAMBIENTE;
    public AudioSource audioSourceTRISTE;
    public AudioClip sonidoInicial;

    private void Start()
    {
        scriptPajaro = FindObjectOfType<PAJARO>();
        scriptTortuga = FindObjectOfType<INTERACCION_TORTUGA>();
        scriptCarpincho = FindObjectOfType<InteraccionCarpincho>();
        scriptCiervo = FindObjectOfType<ObjectInteraction>();

        audioSourceTRISTE = GetComponent<AudioSource>();
        audioSourceTRISTE.clip = sonidoInicial;
        audioSourceTRISTE.Play();

        audioSource.PlayOneShot(sonidoAMBIENTE);
    }

    void Update()
    {
        if (scriptPajaro.pajaroCompletado && scriptTortuga.tortugaCompletado && scriptCarpincho.carpinchoCompletado && scriptCiervo.ciervoCompletado)
        {


            audioSourceTRISTE.Stop();

        }
    }
}
