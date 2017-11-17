// コルーチン
// 参考資料：http://developer.wonderpla.net/entry/blog/engineer/Unity_Co-routine/
// 参考資料：https://cfm-art.sakura.ne.jp/sys/archives/419

// スクリプトでprefabからオブジェクトを生成
// 参考資料：https://qiita.com/2dgames_jp/items/8a28fd9cf625681faf87
// 参考資料：http://masutech.hatenablog.com/entry/2016/11/05/232443


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ＵＩを使えるようにする（これを書き忘れるとGetComponent()でエラーになる）
using UnityEngine.UI;
// シーン遷移に利用
using UnityEngine.SceneManagement;


/// <summary>
/// シーン遷移
/// </summary>
public class SceneChanger : Singleton<SceneChanger> 
{
    /// <summary>
    /// 赤要素
    /// </summary>
    private float r;
    /// <summary>
    /// 緑要素
    /// </summary>
    private float g;
    /// <summary>
    /// 青要素
    /// </summary>
    private float b;
    /// <summary>
    /// アルファ値
    /// </summary>
    private float a;
    /// <summary>
    /// フェード中か？
    /// </summary>
    private bool isFading;
    /// <summary>
    /// カウンタ
    /// </summary>
    private float cnt;
    /// <summary>
    /// パネルの色
    /// </summary>
    private Image panelImageComponent;
    /// <summary>
    /// 子供のパネル
    /// </summary>
    private GameObject panelPrefabChild;

    /// <summary>
    /// フェードフラグのプロパティ
    /// </summary>
    public bool IsFading
    {
        // 取得
        get
        {
            // フラグの取得
            return isFading;
        }
    }

    /// <summary>
    /// オブジェクトが唯一であるか
    /// </summary>
    public void Awake()
    {
        // 自分のポインタはシングルトンでなかったら
        if(this != Instance)
        {
            // スクリプトの削除
            Destroy(this);
            // 関数を抜ける
            return;
        }

        // Panelを取得
        panelPrefabChild = this.gameObject.transform.Find("Panel").gameObject;
        // nullチェック
        if (panelPrefabChild == null)
        {
            // プレハブの生成に失敗した
            Debug.Log("not Create PrefabChild");
            // スクリプトの削除
            Destroy(this);
        }

        // Panelの中のコンポーネントを取得
        panelImageComponent = panelPrefabChild.GetComponent<Image>();
        // nullチェック
        if (panelImageComponent == null)
        {
            // プレハブの生成に失敗した
            Debug.Log("not Create ImageComponent");
            // スクリプトの削除
            Destroy(this);
        }
        // 自分の持つゲームオブジェクトを次のシーンに引き継ぐ
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// フェード用のパネルの初期化
    /// </summary>
    public void InitPanel()
    {
        // Panelの色を取得
        this.r = panelImageComponent.color.r;
        this.g = panelImageComponent.color.g;
        this.b = panelImageComponent.color.b;
    }

    /// <summary>
    /// フェード処理
    /// </summary>
    /// <param name="spd">フェードする速度</param>
    void Fade(float spd)
    {
        // アルファ値を変更する（Unity上では0 ~ 255で設定するけど、スクリプト上では0 ~ 1で設定する）
        a = spd;
        // パネルの色を設定
        panelImageComponent.color = new Color(this.r, this.g, this.b, this.a);
    }

    /// <summary>
    /// コルーチンを実行
    /// </summary>
    public void ExecuteCoroutine(string nextScene,float interval = 1.75f)
    {
        IEnumerator sceneCoroutine = ChangeScene(nextScene, interval);
        // コルーチンを開始する
        StartCoroutine(sceneCoroutine);
    }

    /// <summary>
    /// シーン遷移
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator ChangeScene(string nextScene, float interval)
    {
       // フラグをＯＮにする
       this.isFading = true;

       // タイマーの初期化
       float timer = 0.0f;
        // タイマーになるまでの間
        while (timer <= interval)
        {
            // カウンタを算出
            cnt = timer / interval;
            // フェードイン処理
            Fade(cnt);
            // タイマーを加算
            timer += Time.deltaTime;
            // 中断条件
            yield return 0;
        }

        // シーン遷移
        SceneManager.LoadScene(nextScene);

        // タイマーを0に戻す
        timer = 0.0f;
       // タイマーが0になるまでの間
       while (timer <= interval)
       {
            // カウンタを算出(０～１になるようにする計算)
            cnt = ((timer / interval) - 1.0f) * -1.0f;
            // フェードアウト処理
            Fade(cnt);
           // タイマーを減算
           timer += Time.deltaTime;
           // 中断条件
           yield return 0;
        }
        // フラグを切り替える
        this.isFading = false;
    }

    // Use this for initialization
    void Start()
    {
        InitPanel();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
