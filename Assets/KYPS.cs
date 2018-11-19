using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KYPS : MonoBehaviour {
    public InputField monthField;
    public InputField dayField;
    public InputField yearField;
    public GameObject KYPSGen;
    public GameObject Results;
    public Text results;
    public GameObject menuBackground;
    private int months;
    private int days;
    private int years;
    public int[] monthDigits = new int [2];
    public int[] dayDigits = new int[2];
    public int[] yearDigits = new int[4];
    public int[] karmicYear = new int[4];
    public int[] increaseValue = new int[2];
    int personalityNumber;
    int soulNumber;
    public float speed = 5.0f;

    public GameObject MainMenu;
    public GameObject TR;
    public GameObject TR_TheCut;
    public GameObject TR_Reading;
    public void MainMenuClick()
    {
        MainMenu.SetActive(true);
        KYPSGen.SetActive(false);
        Results.SetActive(false);
    }
    public void ReadingClick()
    {
        KYPSGen.SetActive(false);
        Results.SetActive(false);
        TR.SetActive(true);
        TR_TheCut.SetActive(true);
        TR_Reading.SetActive(false);
}
    public void resultDisplay()
    {
        results.text = ("Your Karmic Year is " + karmicYear[0] + karmicYear[1] + karmicYear[2] + karmicYear[3] + "\n" +
                        "Your Personality Number is " + personalityNumber + "\n" +
                        "Your Soul Number is " + soulNumber);
    }

    private void Update()
    {
        //backgroundSwirl();
       // Quaternion q = menuBackground.transform.rotation;
      //  q.eulerAngles += new Vector3(0, 0, Time.deltaTime * speed);
       // menuBackground.transform.rotation = q;
        //menuBackground.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, (transform.rotation.z + speed * Time.deltaTime), transform.rotation.w);
    }
    public void zeroOut()
    {
        months = 0;
        days = 0;
        years = 0;
        personalityNumber = 0;
        soulNumber = 0;
        for (int i = 0; i >= 2; i++)
            monthDigits[i] = 0;
        for (int j = 0; j >= 2; j++)
            dayDigits[j] = 0;
        for (int k = 0; k >= 4; k++)
            yearDigits[k] = 0;
        for (int l = 0; l >= 4; l++)
            karmicYear[l] = 0;
        monthField.text = "";
        dayField.text = "";
        yearField.text = "";

    }
    public void getDigits()
    {
        monthDigits[0] = (int)(months / 10);
        monthDigits[1] = (int)(months % 10);
        dayDigits[0] = (int)(days / 10);
        dayDigits[1] = (int)(days % 10);
        yearDigits[0] = (int)(years / 1000);
        yearDigits[1] = (int)((years - (yearDigits[0]*1000))/ 100);
        yearDigits[2] = (int)((years- (yearDigits[0]*1000 + yearDigits[1]*100)) / 10);
        yearDigits[3] = (int)(years % 10);
    }
    public void karmicYearCalculator()
    {
        //int[] increaseValue = new int[2];
        increaseValue[0] = monthDigits[0] + dayDigits[0];
        increaseValue[1] = monthDigits[1] + dayDigits[1];
        if (increaseValue[1] >= 10)
        {
            increaseValue[1] = (int)(increaseValue[1] % 10);
            increaseValue[0] += 1;
        }

        karmicYear[0] = yearDigits[0];
        karmicYear[1] = yearDigits[1];
        karmicYear[2] = yearDigits[2];
        karmicYear[3] = yearDigits[3];
        karmicYear[3] = karmicYear[3] + increaseValue[1];
        if (karmicYear[3] >= 10)
        {
            karmicYear[3] = karmicYear[3] % 10;
            karmicYear[2] += 1;
        }
        karmicYear[2] = karmicYear[2] + increaseValue[0];
        if (karmicYear[2] >= 10)
        {
            karmicYear[2] = karmicYear[2] % 10;
            karmicYear[1] += 1;
        }
        if (karmicYear[1] >= 10)
        {
            karmicYear[1] = karmicYear[1] % 10;
            karmicYear[0] += 1;
        }
    }
    public void personalityNumberCalculator()
    {
        int[] tempReduce = new int[2];

        personalityNumber = karmicYear[0] + karmicYear[1] + karmicYear[2] + karmicYear[3];
        if (personalityNumber >= 23)
        {
            tempReduce[0] = (int)(personalityNumber / 10);
            tempReduce[1] = personalityNumber % 10;
            personalityNumber = tempReduce[0] + tempReduce[1];
        }
    }
    public void soulNumberCalculator()
    {
        int[] tempReduce = new int[2];
        if (personalityNumber >= 10)
        {
            tempReduce[0] = (int)(personalityNumber / 10);
            tempReduce[1] = personalityNumber % 10;
            soulNumber = tempReduce[0] + tempReduce[1];
        }
        else
            soulNumber = personalityNumber;


    }
    // Use this for initialization

    public void OnSubmit()
    {
        months = int.Parse(monthField.text);
        days = int.Parse(dayField.text);
        years = int.Parse(yearField.text);

        getDigits();
        karmicYearCalculator();
        Debug.Log("Your Karmic Year is " + karmicYear[0]+ karmicYear[1]+ karmicYear[2]+ karmicYear[3]);
        personalityNumberCalculator();
        Debug.Log("Your Personality Number is " + personalityNumber);
        soulNumberCalculator();
        Debug.Log("Your Soul Number is " + soulNumber);
        resultDisplay();
        zeroOut();
        KYPSGen.SetActive(false);
        Results.SetActive(true);
        
    }
}
