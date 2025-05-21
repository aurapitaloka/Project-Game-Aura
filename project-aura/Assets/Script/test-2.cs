using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class praktikum : MonoBehaviour
{
    // Start is called before the first frame update
    //public int health = 100;
    //float speed = 5.5f;
    //bool isAlife = true;
    //string namaplayer = "ultramen tiga";
    //char grade = 'A';

    public int PlayerHealth = 100;
    public int PlayerArmor = 50;
    public int PlayerDamage = 200;
    bool isAlife = true;

    void Start()
    {
        //Debug.Log("Health player :" + health);

        //int damage = 20;
        //health = health - damage;
        //Debug.Log( "darah sekarang " + health );

        //bool isDead = (health <= 0);
        //Debug.Log("apakah player mati ? " + isDead );

        //if (isAlife && health > 0 )
        //{
        //    Debug.Log("Pemain masih hidup");
        //}
        //else
        //{
        //    Debug.Log("pemain sudah mati");
        //}

        //if (health > 50)
        //{
        //    Debug.Log(namaplayer + "Masih kuat");
        //}else if (health >0)
        //{
        //    Debug.Log("Hati hati");
        //}
        //else
        //{
        //    Debug.Log("player mati");
        //    isAlife = false;

        //}

        //for (int i = 1; 1 <= 5; i++)
        //{
        //    Debug.Log("hit ke" + i);
        //}

        //int scores = { 100, 80, 60, 40, 20 };
        //foreach (var scores in scores)
        //{
        //    Debug.Log("scor" + scores );
        //}

        //GetPlayerName();
        //GetPlayerStatus();
        //StartCorotine(contohCorotine());

        //string status = GetPlayerStatus(40);
        //Debug.Log("status pemain " + status);

        Debug.Log("Health player :" + PlayerHealth + "status |" + GetPlayerStatus());
        
        CalculateEffectiveDamage(PlayerDamage);
        Debug.Log("Health player :" + PlayerHealth + "status |" + GetPlayerStatus());
        Debug.Log("hasilnya adalah " + IsPlayerAlived());

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CalculateEffectiveDamage(int PlayerDamage)
    {
        
        
        if (PlayerArmor >= PlayerDamage)
        {
            PlayerArmor = ( PlayerArmor - PlayerDamage);
        }
        else
        {
            PlayerHealth = (PlayerHealth + PlayerArmor) - PlayerDamage;
        }
    }
    string GetPlayerStatus()
    {
        if (PlayerHealth > 50)
            return "hidup";
        else if (PlayerHealth > 0)
            return " sekarat ";
        else
            return "mati";
    }

    //public void IsPlayerAlived()
    //{
    //    if (isAlife && PlayerHealth > 0)
    //    {
    //        Debug.Log("Pemain masih hidup");
    //    }
    //    else
    //    {
    //        Debug.Log("pemain sudah mati");
    //    }
    //}

    bool IsPlayerAlived()
    {
        if (PlayerHealth > 0)
            return true;
        else
            return false;
    }


    //string GetPlayerStatus( int darah )
    //{
    //    if (darah > 50)
    //        return "hidup";
    //    else if (darah > 0)
    //        return " sekarat ";
    //    else
    //        return "mati";
    //}
    //public void GetPlayerName()
    //{
    //    Debug.Log(namaplayer);
    //}

    //public void GetPlayerStatus(int damage)
    //{
    //    health = health - damage;
    //    Debug.Log("getplayer" + health);
    //}

    //IEnumerator contohCorotine(float waktu)
    //{
    //    Debug.Log("Mulai Corotine");
    //    yield return new WaitForSeconds(waktu);
    //    Debug.Log("Corotine selesai");
    //}
}
