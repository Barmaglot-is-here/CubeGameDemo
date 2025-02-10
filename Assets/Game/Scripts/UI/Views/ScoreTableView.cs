using System.Collections.Generic;
using UnityEngine;

public class ScoreTableView : MonoBehaviour
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private ScoreTableRecordView _prefab;

    public void Fill(IEnumerable<ScoreTableRecordData> datas)
    {
        foreach (var data in datas)
            CreateView(data);
    }

    private ScoreTableRecordView CreateView(ScoreTableRecordData data)
    {
        var instance    = Instantiate(_prefab, _content);
        var view        = instance.GetComponent<ScoreTableRecordView>();
        
        view.Init(data);

        return instance;
    }
}