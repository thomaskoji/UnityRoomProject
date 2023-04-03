using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // 疲労ポイント
    public float exhaustionPoint;
    // 疲労限界値（敵によって疲労限界値をインスペクターから設定）
    public float exhaustionLimit;
    public SpriteRenderer spriteRenderer;
    // exhaustionPointバー
    public Slider epBar;
    public Text enemyName;

    Tweener _shakeTweener;
    Vector3 _initPosition;

    private void Start() {
        // 初期位置を保持
        _initPosition = transform.position;
        epBar.value = 0;
        epBar.maxValue = exhaustionLimit;
        enemyName.text = this.gameObject.name;
    }

    private void Update() {
        ExhaustionCheck();
    }
    
    public void Damage(int damage)
    {
        StartCoroutine(Flashing());
        StartShake(0.5f, 0.25f, 30);
        exhaustionPoint += damage;
        epBar.value += damage;
    }

    //　疲労が限界にきたら・・・
    public void ExhaustionCheck()
    {
        if (exhaustionPoint == epBar.maxValue)
        {
            Debug.Log("隙あり！！！！！！！！致命の一撃だ！！！！！");
        }
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
    IEnumerator Flashing()
    {
        var color = spriteRenderer.color;

        for (int i = 0; i < 2; i++)
        {
            color.g = 0.5f;
            color.b = 0.5f;
            spriteRenderer.color = color;
            yield return new WaitForSeconds(0.1f);
            color.g = 0.2f;
            color.b = 0.2f;
            spriteRenderer.color = color; 
            yield return new WaitForSeconds(0.1f);
        }           
    }

    #endregion
}
