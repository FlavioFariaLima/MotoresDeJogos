using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{

    public AudioClip clipAtaqueAereo;
    public AudioClip clipBicadaCascaAbrindo;
    public AudioClip clipBicadaCasca;
    public AudioClip clipConchaSai;
    public AudioClip clipConchaEntra;
    public AudioClip clipDecolagem2;
    public AudioClip clipDecolagem3;
    public AudioClip clipDecolagem4;
    public AudioClip clipDecolagem5;
    public AudioClip clipPousoAve;
    public AudioClip clipHeremitAndando;
    public AudioClip clipHeremitMorrendo;
    public AudioClip clipMinhocaComida;
    public AudioClip clipCanudoEngolindo;
    public AudioClip clipHeremitAndarLento;
     public AudioClip clipHeremitPetroleo;

    private AudioSource ataqueAereo;
    private AudioSource bicadaCascaAbrindo;
    private AudioSource bicadaCasca;
    private AudioSource conchaSai;
    private AudioSource conchaEntra;
    private AudioSource decolagem2;
    private AudioSource decolagem3;
    private AudioSource decolagem4;
    private AudioSource decolagem5;
    private AudioSource pousoAve;
    private AudioSource heremitAndando;
    private AudioSource heremitAndarLento;
    private AudioSource heremitMorrendo;
    private AudioSource minhocaComida;
    private AudioSource canudoEngolindo;
    private AudioSource heremitPetroleo;


    //DataKeeper dataKeeper;

    public void Awake()
    {
        //Gaivota

        decolagem2 = AddAudio(clipDecolagem2, false, false, 1.0f);
        decolagem3 = AddAudio(clipDecolagem3, false, false, 1.0f);
        decolagem4 = AddAudio(clipDecolagem4, false, false, 1.0f);
        decolagem5 = AddAudio(clipDecolagem5, false, false, 1.0f);
        pousoAve = AddAudio(clipPousoAve, false, false, 1.0f);
        ataqueAereo = AddAudio(clipAtaqueAereo, false, true, 1.0f);
        bicadaCascaAbrindo = AddAudio(clipBicadaCascaAbrindo, false, true, 1.0f);
        bicadaCasca = AddAudio(clipBicadaCasca, false, true, 1.0f);
     

        //Heremit
        conchaSai = AddAudio(clipConchaSai, false, true, 1.0f);
        conchaEntra = AddAudio(clipConchaEntra, false, true, 1.0f);
        heremitAndando = AddAudio(clipHeremitAndando, true, false, 1.0f);
        heremitAndarLento = AddAudio(clipHeremitAndarLento, true, false, 1.0f);
        heremitMorrendo = AddAudio(clipHeremitMorrendo, false, false, 1.0f);
        minhocaComida = AddAudio(clipMinhocaComida, false, false, 1.0f);
        canudoEngolindo = AddAudio(clipCanudoEngolindo, false, false, 1.0f);
        heremitPetroleo = AddAudio(clipHeremitPetroleo, true, false, 1.0f);


        // dataKeeper = FindObjectOfType<DataKeeper>();
    }

    public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
    {

        AudioSource newAudio = gameObject.AddComponent<AudioSource>();

        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;

        return newAudio;

    }

    //Execulta os audios

    //Gaivota

    public void PlayAtaqueAereo()
    {
        //if(dataKeeper.SfxStatus())
        ataqueAereo.Play();
    }

    public void PlayBicadaCascaAbrindo()
    {
        //if(dataKeeper.SfxStatus())
        bicadaCascaAbrindo.Play();
    }

    public void PlayBicadaCasca()
    {
        //if(dataKeeper.SfxStatus())
        bicadaCasca.Play();
    }

    public void PlayDecolagemGaivota()
    {
        //  if (dataKeeper.SfxStatus())
        {
            int randomNumber = Random.Range(1, 4);
            switch (randomNumber)
            {
                case 1:
                    decolagem2.Play();
                    break;
                case 2:
                    decolagem3.Play();
                    break;
                case 3:
                    decolagem4.Play();
                    break;
                case 4:
                    decolagem5.Play();
                    break;
                default:
                    print("number " + randomNumber);
                    break;
            }
        }
    }

     public void PlayPousoAve()
    {
        //if(dataKeeper.SfxStatus())
        pousoAve.Play();
    }


    //Heremit


    public void PlayHeremitMorrendo()
    {
        //if(dataKeeper.SfxStatus())
        heremitMorrendo.Play();
    }
    public void PlayHeremitAndando()
    {
        //if(dataKeeper.SfxStatus())
        heremitAndando.Play();
    }
    public void PlayHeremitAndandLento()
    {
        //if(dataKeeper.SfxStatus())
        heremitAndandoLento.Play();
    }

    public void PlayMinhocaComida()
    {
        //if(dataKeeper.SfxStatus())
        minhocaComida.Play();
    }
    public void PlayCanudoEngolindo()
    {
        //if(dataKeeper.SfxStatus())
        canudoEngolindo.Play();
    }
      public void PlayConchaSai()
    {
        //if(dataKeeper.SfxStatus())
        conchaSai.Play();
    }

    public void PlayConchaEntra()
    {
        //if(dataKeeper.SfxStatus())
        conchaEntra.Play();
    }
    public void PlayHeremitPetroleo()
    {
        //if(dataKeeper.SfxStatus())
        heremitPetroleo.Play();
    }



   

    //public void ButtonClick()
    //{
    //    dataKeeper = FindObjectOfType<DataKeeper>();
    //    if (dataKeeper.SfxStatus())
    //        buttonClick.Play();
    //}
}