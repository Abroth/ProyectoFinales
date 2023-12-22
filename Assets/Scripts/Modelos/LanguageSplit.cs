using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSplit : MonoBehaviour
{
    public static Dictionary<Language, Dictionary<string, string>> LoadCodexFromString(string source, string sheet)
    {
        var codex = new Dictionary<Language, Dictionary<string, string>>();

        string[] rows = sheet.Split(new[] { '\n', '\r'}, System.StringSplitOptions.RemoveEmptyEntries);

        var columnToIndex = new Dictionary<string, int>();

        int lineNum = 0;

        bool isFirst = true;

        foreach (string row in rows)
        {
            lineNum++;

            string[] cells = row.Split(';');


            if (isFirst)
            {
                isFirst= false;

                for (int i = 0; i < cells.Length; i++)
                {
                    columnToIndex[cells[i]] = i;
                }

                continue;
            }

            if (cells.Length != columnToIndex.Count)
            {
                Debug.Log($"Parsing CSV file {source} at line {lineNum}, colums: {cells.Length}, shoud be {columnToIndex.Count}");
                continue;
            }

            string langName = cells[columnToIndex["Idioma"]];
            Language lang;

            #region Parsear el idioma string de la planilla al enum
            try
            {
                lang = (Language)Enum.Parse(typeof(Language), langName);
            }
            catch (Exception e)
            {
                Debug.Log($"Parsing CSV file {source}, at line {lineNum}, invalid language {langName}");
                Debug.Log(e.ToString());
                continue;
            }
            #endregion

            string idName = cells[columnToIndex["ID"]];
            string text = cells[columnToIndex["Texto"]];

            if (!codex.ContainsKey(lang))
            {
                codex[lang] = new Dictionary<string, string>();
            }

            codex[lang][idName] = text;
        }

        return codex;
    }
}
