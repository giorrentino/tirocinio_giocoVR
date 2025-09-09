using System;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class DatasetLoader : MonoBehaviour
{
    public List<CartellaClinica> pazienti = new List<CartellaClinica>();

    void Start()
    {
        TextAsset file = Resources.Load<TextAsset>("filteredDataset");
        if (file == null)
        {
            Debug.LogError("File non trovato in Resources.");
            return;
        }

        string[] righe = file.text.Split('\n');

        for (int i = 1; i < righe.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(righe[i])) continue;

            string[] col = righe[i].Split(',');

            if (col.Length < 25)
            {
                Debug.LogWarning($"Riga {i + 1} ha solo {col.Length} colonne.");
                continue;
            }

            try
            {
                CartellaClinica c = new CartellaClinica();

                c.SEQN = float.Parse(col[0], CultureInfo.InvariantCulture);
                c.DIQ010 = Convert.ToInt32(float.Parse(col[1], CultureInfo.InvariantCulture));
                c.LBXGLU = float.Parse(col[2], CultureInfo.InvariantCulture);
                c.LBXIN = float.Parse(col[3], CultureInfo.InvariantCulture);
                c.BMXWT = float.Parse(col[4], CultureInfo.InvariantCulture);
                c.BMXHT = float.Parse(col[5], CultureInfo.InvariantCulture);
                c.BMXBMI = float.Parse(col[6], CultureInfo.InvariantCulture);
                c.LBDHDD = float.Parse(col[7], CultureInfo.InvariantCulture);
                c.LBXTC = float.Parse(col[8], CultureInfo.InvariantCulture);
                c.DR1TKCAL = float.Parse(col[9], CultureInfo.InvariantCulture);
                c.DR1TPROT = float.Parse(col[10], CultureInfo.InvariantCulture);
                c.DR1TCARB = float.Parse(col[11], CultureInfo.InvariantCulture);
                c.DR1TSUGR = float.Parse(col[12], CultureInfo.InvariantCulture);
                c.DR1TFIBE = float.Parse(col[13], CultureInfo.InvariantCulture);
                c.DR1TTFAT = float.Parse(col[14], CultureInfo.InvariantCulture);
                c.DR1TSFAT = float.Parse(col[15], CultureInfo.InvariantCulture);
                c.PAD680 = float.Parse(col[16], CultureInfo.InvariantCulture);
                c.PAD800 = float.Parse(col[17], CultureInfo.InvariantCulture);
                c.PAD820 = float.Parse(col[18], CultureInfo.InvariantCulture);
                c.WHQ070 = float.Parse(col[19], CultureInfo.InvariantCulture);
                c.RIDAGEYR = float.Parse(col[20], CultureInfo.InvariantCulture);
                c.RIAGENDR = Convert.ToInt32(float.Parse(col[21], CultureInfo.InvariantCulture));
                c.RIDRETH1 = float.Parse(col[22], CultureInfo.InvariantCulture);
                c.DMDEDUC2 = float.Parse(col[23], CultureInfo.InvariantCulture);
                c.INDFMPIR = float.Parse(col[24], CultureInfo.InvariantCulture);

                pazienti.Add(c);

                Debug.Log($"Paziente OK - ID: {c.SEQN}, Sesso: {(c.RIAGENDR == 1 ? "M" : "F")}, Et�: {c.RIDAGEYR}, BMI: {c.BMXBMI:F1}");
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"Errore parsing riga {i + 1}: {ex.Message}");
            }
        }

        Debug.Log($"Totale pazienti caricati: {pazienti.Count}");
    }
}
