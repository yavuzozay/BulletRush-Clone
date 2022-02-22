using System;
using UnityEngine;
/* Eventleri kullanarak oyun bitimi, skor  deðiþimi gibi olaylarý sürekli update içerisinde güncellemek zorunda kalmýyoruz.
 * Triggerlandýðýnda abone olan sýnýflar çaðrýlýp gerekli iþlemleri gerçekleþtiriyor.
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
