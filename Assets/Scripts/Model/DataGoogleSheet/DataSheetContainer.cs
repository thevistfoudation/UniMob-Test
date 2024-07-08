using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NorskaLib.Spreadsheets;

namespace jinLab.Model
{
    [CreateAssetMenu(fileName = "SpreadsheetsContainer", menuName = "SpreadsheetsContainer")]
    public class DataSheetContainer : SpreadsheetsContainerBase
    {
        [SpreadsheetContent]
        [SerializeField] SpreadsheetContent content;
        public SpreadsheetContent Content => content;
    }

    [System.Serializable]
    public class SpreadsheetContent
    {
        [SpreadsheetPage("quest")]
        public List<QuestData> ListQuestData;
        [SpreadsheetPage("priceUnLock")]
        public List<PriceUnlock> ListPriceUnlock;
        [SpreadsheetPage("treeData")]
        public List<TreeData> ListTreeData;
        [SpreadsheetPage("fruit")]
        public List<Fruit> ListFruit;
    }


    [System.Serializable]
    public class QuestData
    {
        public int numberRequire;
    }

    [System.Serializable]
    public class PriceUnlock
    {
        public int id;
        public float price;
    }

    [System.Serializable]
    public class TreeData
    {
        public string name;
        public int id;
        public float time;
        public int number;
    }

    [System.Serializable]
    public class Fruit
    {
        public string name;
        public int id;
        public int value;
    }
}

