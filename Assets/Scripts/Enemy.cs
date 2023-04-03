using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // 疲労限界値（敵によって疲労限界値をインスペクターから設定）
    public float exhaustionLimit;
    public SpriteRenderer spriteRenderer;
    // exhaustionPointバー
    public Slider epBar;
    public Text enemyName;

    public bool isExhausted;

    Tweener _shakeTweener;
    Vector3 _initPosition;

    private void Start() {
        // 初期位置を保持
        _initPosition = transform.position;
        epBar.value = 0;
        epBar.maxValue = exhaustionLimit;
        enemyName.text = this.gameObject.name;
        isExhausted = false;
    }

    private void Update() {
        ExhaustionCheck();
        epBar.value -= Time.deltaTime * 1.5f;
    }
    
    public void Damage(int damage)
    {
        Flashing(2, 0.1f);
        StartShake(0.5f, 0.25f, 30);
        epBar.value += damage;
    }

    //　疲労が限界にきたら・・・
    public void ExhaustionCheck()
    {
        if (epBar.value == exhaustionLimit)
        {
            isExhausted = true;
            Flashing(100, 0.1f);
            Debug.Log("隙あり！！！！！！！！致命の一撃だ！！！！！");
        }
    }

    public void Death()
    {
        StartShake(2f, 0.6f, 30);
        Destroy(this.gameObject, 2.0f);
    }

    #region 演出処理
    // 振動処理
    /// <param name="duration">時間</param>
    /// <param name="strength">揺れの強さ</param>
    /// <param name="vibrato">どのくらい振動するか</param>
    /// <param name="randomness">ランダム度合(0〜180)</param>
    /// <param name="fadeOut">フェードアウトするか</param>
    public void StartShake(float duration, float strength, int vibrato)
    {
        // 前回の処理が残っていれば停止して初期位置に戻す
        if (_shakeTweener != null)
        {
            _shakeTweener.Kill();
            gameObject.transform.position = _initPosition;
        }
        // 揺れ開始
        _shakeTweener = gameObject.transform.DOShakePosition(duration, strength, vibrato);
    }

    // ダメージを受けたらEnemyが点滅する処理
    void Flashing(int index, float waitingTime)
    {
        for (int i = 0; i < index; i++)
        {
            StartCoroutine(FlashDetail(waitingTime));
        }           
    }

    IEnumerator FlashDetail(float waitingTime)
    {
        var color = spriteRenderer.color;
        color.g = 0.5f;
        color.b = 0.5f;
        spriteRenderer.color = color;
        yield return new WaitForSeconds(waitingTime);
        color.g = 0.2f;
        color.b = 0.2f;
        spriteRenderer.color = color; 
        yield return new WaitForSeconds(waitingTime);
    }

    #endregion
}
