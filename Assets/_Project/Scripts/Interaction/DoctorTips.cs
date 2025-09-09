using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class DoctorTips : MonoBehaviour
{
    public TMP_Text balloonText;

    private string[] consigli = new string[]
    {
    "Se il tuo glucosio a digiuno � sopra i 126 mg/dL, potresti avere il diabete. Parla col tuo medico.",
    "Un valore tra 100 e 125 mg/dL indica prediabete: � un campanello d�allarme.",
    "Glicemia normale? Tienila tra 70 e 99 mg/dL con una dieta sana e attivit� fisica.",
    "Un valore sotto i 70 mg/dL pu� indicare ipoglicemia: attenzione ai sintomi come tremori e debolezza.",
    "Valori alti di insulina possono indicare resistenza insulinica, un possibile precursore del diabete.",
    "Il sovrappeso � uno dei principali fattori di rischio per il diabete di tipo 2.",
    "Un BMI superiore a 30 � considerato obesit�: anche perdere il 5% del peso aiuta moltissimo.",
    "Un BMI compreso tra 18.5 e 24.9 � ideale per la salute generale.",
    "Il colesterolo HDL, il cosiddetto 'buono', protegge cuore e arterie: sopra 60 � l�obiettivo!",
    "HDL sotto i 40 mg/dL negli uomini o sotto i 50 mg/dL nelle donne � considerato basso.",
    "HDL basso � spesso associato a diabete e resistenza all'insulina.",
    "Una dieta ricca di fibre aiuta a mantenere sotto controllo la glicemia.",
    "Frutta, verdura, legumi e cereali integrali sono ottime fonti di fibre.",
    "Riduci gli zuccheri aggiunti: leggi sempre le etichette dei cibi confezionati.",
    "Preferisci carboidrati complessi come pane integrale, avena e riso basmati.",
    "I grassi saturi e trans peggiorano la sensibilit� all�insulina: limita burro, fritti e salumi.",
    "Attivit� fisica regolare migliora la sensibilit� all�insulina e riduce il rischio di diabete.",
    "Camminare 30 minuti al giorno pu� fare la differenza per la tua salute metabolica.",
    "Stare troppo tempo seduti pu� favorire l�insulino-resistenza: alzati ogni ora!",
    "Anche 20 minuti di attivit� fisica vigorosa alla settimana migliorano il controllo glicemico.",
    "Controllare la glicemia ogni tanto � utile anche se ti senti bene.",
    "Molte persone scoprono il diabete per caso: meglio prevenirlo che curarlo.",
    "Essere 'borderline' non vuol dire essere al sicuro: � il momento di cambiare abitudini.",
    "Chi ha casi di diabete in famiglia dovrebbe controllarsi pi� spesso.",
    "Il colesterolo totale dovrebbe restare sotto i 200 mg/dL per ridurre i rischi cardiaci.",
    "Valori di colesterolo sopra i 240 mg/dL aumentano il rischio cardiovascolare.",
    "Il livello di zuccheri nella dieta � spesso troppo alto: limita bevande zuccherate e dolci.",
    "La combinazione di glicemia alta, HDL basso e BMI elevato � molto rischiosa.",
    "Chi ha un'istruzione pi� alta tende a conoscere meglio i rischi del diabete.",
    "Anche chi ha poche risorse pu� prendersi cura della propria salute con piccoli gesti quotidiani."
    };

    private Coroutine hideCoroutine; // riferimento all'ultima coroutine attiva

    public void OnSelect()
    {
        int index = Random.Range(0, consigli.Length);
        balloonText.text = consigli[index];

        // Se esiste gi� una coroutine attiva, fermala
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        // Avvia una nuova coroutine e tieni il riferimento
        hideCoroutine = StartCoroutine(HideTextAfterDelay(10f));
    }

    private IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        balloonText.text = "";
        hideCoroutine = null; // reset per sicurezza
    }
}
