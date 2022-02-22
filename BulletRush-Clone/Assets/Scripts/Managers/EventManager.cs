using System;
using UnityEngine;
/* Eventleri kullanarak oyun bitimi, skor  de�i�imi gibi olaylar� s�rekli update i�erisinde g�ncellemek zorunda kalm�yoruz.
 * Triggerland���nda abone olan s�n�flar �a�r�l�p gerekli i�lemleri ger�ekle�tiriyor.
  */
public static class EventManager
{
    public static event Action OnGameOver;
    public static void Fire_OnGameOver() { OnGameOver?.Invoke(); }

    public static event Action<float> OnScoreChanged;
    public static void Fire_OnScoreChanged(float currentScore) { OnScoreChanged?.Invoke(currentScore); }

    public static event Action<int> OnSimpleEnemyCountChanged;
    public static void Fire_OnSimpleEnemyCountChanged(int simpleEnemyCount) { OnSimpleEnemyCountChanged?.Invoke(simpleEnemyCount); }
    
    public static event Action<int> OnBigEnemyCountChanged;
    public static void Fire_OnBigEnemyCountChanged(int bigEnemyCount) { OnBigEnemyCountChanged?.Invoke(bigEnemyCount); }

}
