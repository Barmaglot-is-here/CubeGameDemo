using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class ScoreTableView : MonoBehaviour
    {
        [SerializeField]
        private Transform _content;
        [SerializeField]
        private GameObject _prefab;

        public void Fill(IEnumerable<ScoreRecordData> datas)
        {
            foreach (var data in datas)
                CreateView(data);
        }

        private ScoreRecordView CreateView(ScoreRecordData data)
        {
            var instance    = Instantiate(_prefab, _content);
            var view        = instance.GetComponent<ScoreRecordView>();

            view.Show(data);

            return view;
        }
    }
}