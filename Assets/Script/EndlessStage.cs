using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessStage : MonoBehaviour
{
    //マップの左右の長さ
    [SerializeField] int StageMapSize = 0;
                     private int CurrentMapIndex;
    [SerializeField] private Transform Player;
    [SerializeField] GameObject[] StageMaps;
    [SerializeField] int StartMapIndex;
    //マップの先読み数
    [SerializeField] int NextMapsIndex;
    //作ったステージチップの保持リスト
    [SerializeField] public List<GameObject> GeneratedStageList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //初期化処理
        CurrentMapIndex = StartMapIndex - 1;
        UpdateStage(NextMapsIndex);

    }

    // Update is called once per frame
    void Update()
    {
        //キャラクターの位置から現在のステージチップのインデックスを計算します
        int charaPositionIndex = (int)(Player.position.x / StageMapSize);
        //次のステージチップに入ったらステージの更新処理を行います。
        if (charaPositionIndex + NextMapsIndex > CurrentMapIndex)
        {
            UpdateStage(charaPositionIndex + NextMapsIndex);
        }
    }

    //指定のインデックスまでのステージチップを生成して、管理下におく
    void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= CurrentMapIndex) return;
        //指定のステージチップまで生成するよ
        for (int i = CurrentMapIndex + 1; i <= toTipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);
            GeneratedStageList.Add(stageObject);
        }
        while (GeneratedStageList.Count > NextMapsIndex + 2) DestroyOldestStage();
        CurrentMapIndex = toTipIndex;

    }

    //指定のインデックス位置にstageオブジェクトをランダムに生成
    GameObject GenerateStage(int tipIndex)
    {
        int nextStageTip = Random.Range(0, StageMaps.Length);

        GameObject stageObject = (GameObject)Instantiate(
            StageMaps[nextStageTip],
            new Vector3(tipIndex * StageMapSize, 0, 0), //今回はx軸方向に無限生成するのでこの書き方をしている
            Quaternion.identity) as GameObject;
        return stageObject;
    }

    //一番古いステージを削除します
    void DestroyOldestStage()
    {
        GameObject oldStage = GeneratedStageList[0];
        GeneratedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}

