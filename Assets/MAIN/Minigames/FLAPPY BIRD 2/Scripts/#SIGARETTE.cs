using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class YarnVariableReader1 : MonoBehaviour
{
    public string yarnFileName = "AS HOMEBALCONY.yarn"; // Nome del file .yarn
    private string yarnFilePath;

    void Start()
    {
        // Percorso completo del file
        yarnFilePath = Path.Combine("C:/Users/matte/OneDrive - Politecnico di Milano/Documenti/POLIMI/LM - YEAR 2/SEMESTRE 1/E-HEALTH/PROJECT/e-health-project/Assets/SCENES/DAY 1/Avid Smoker/3. AS - Home Balcony/Scripts", "AS HOMEBALCONY.yarn");

        // Controlla se il file esiste
        if (File.Exists(yarnFilePath))
        {
            string fileContent = File.ReadAllText(yarnFilePath);
            int sigaretteValue = ExtractSigaretteValue(fileContent);

            if (sigaretteValue != -1)
            {
                Debug.Log("Valore di $sigarette trovato: " + sigaretteValue);
            }
            else
            {
                Debug.LogError("$sigarette non trovato nel file.");
            }
        }
        else
        {
            Debug.LogError("Il file .yarn non è stato trovato: " + yarnFilePath);
        }
    }

    int ExtractSigaretteValue(string content)
    {
        // Cerca il valore di $sigarette con una regex
        Regex regex = new Regex(@"\$sigarette\s*=\s*(\d+)");
        Match match = regex.Match(content);

        if (match.Success)
        {
            // Estrarre il valore intero
            int value;
            if (int.TryParse(match.Groups[1].Value, out value))
            {
                return value;
            }
        }

        // Se $sigarette non è trovato, restituisci -1
        return -1;
    }
    
    void UseSigaretteValue(int value)
    {
        if (value > 0)
        {
            Debug.Log("Hai abbastanza sigarette per continuare: " + value);
        }
        else
        {
            Debug.Log("Non hai abbastanza sigarette!");
        }
    }

}
