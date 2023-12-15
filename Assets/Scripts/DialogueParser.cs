using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Mono.Data.Sqlite;

public class DialogueParser : MonoBehaviour
{
    public class Dialogue {
        public string id;
        public string text;
        public List<DialogueOption> options;
        public string[] variable = new string[2];
    }
    public class DialogueOption {
        public string text;
        public string target;
        public string condition;
    }

    private static Dictionary<string, bool> variables = new Dictionary<string, bool>();

    static class TweeParser {
        public static List<Dialogue> Parse(string filename) {
            var dialogues = new List<Dialogue>();
            var currentDialogue = new Dialogue();
            currentDialogue.options = new List<DialogueOption>();

            foreach (var line in File.ReadLines(filename)) {
                if (line.StartsWith(":: ")) {
                    if (currentDialogue.id != null) {
                        dialogues.Add(currentDialogue);
                    }
                    currentDialogue = new Dialogue();
                    currentDialogue.id = line.Substring(3).Trim();
                    if (currentDialogue.id.Contains('{'))
                        currentDialogue.id = currentDialogue.id.Substring(0,currentDialogue.id.IndexOf('{') - 1);
                    currentDialogue.options = new List<DialogueOption>();
                } else if (line.StartsWith("[[")) {
                    // Handle dialogue options
                    var parts = line.Substring(2, line.Length - 4);
                    var option = new DialogueOption();
                    if (parts.Contains("->"))
                    {
                        int t = parts.IndexOf('>');
                        option.text = parts.Substring(0,t-1);
                        option.target = parts.Substring(t + 1, parts.Length - t - 1);
                    }
                    else
                        option.text = parts;
                    currentDialogue.options.Add(option);
                } else if (line.Contains("set:"))
                {
                    string[] w = line.Split();
                    string key = w[1];//.Substring(1);
                    try
                    {
                        variables.Add(key, false);
                        currentDialogue.variable[0] = key;
                        currentDialogue.variable[1] = w[3].Substring(0,w[3].Length - 1);
                    }
                    catch (ArgumentException)
                    {
                        variables[key] = false;
                        currentDialogue.variable[0] = key;
                        currentDialogue.variable[1] = w[3].Substring(0,w[3].Length - 1);
                    }
                } else if (line.Contains("if:"))
                {
                    var option = new DialogueOption();
                    option.condition = line.Substring(4, line.IndexOf(')') - 4);
                    int c = line.IndexOf('[');
                    string nline = line.Substring(c + 3, line.Length - c - 6);
                    int t = nline.IndexOf('>');
                    option.text = nline.Substring(0,t-1);
                    option.target = nline.Substring(t + 1, nline.Length - t - 1);
                    currentDialogue.options.Add(option);
                }
                else
                {
                    // Handle dialogue text
                    currentDialogue.text += line + "\n";
                }
            }

            if (currentDialogue.id != null) {
                dialogues.Add(currentDialogue);
            }

            return dialogues;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //No DB
        GameObject gameObject = GameObject.Find("dialogbox");
        DialogContainer dc = gameObject.GetComponent<DialogContainer>();
        //
        dc.list = TweeParser.Parse("../Mocion/Assets/Dialogues/Mocions.twee");
        //Si DB
        String connectionString = "URI=file:" + Application.dataPath +"/mociondialogues";
        IDbConnection dbConnection = new SqliteConnection(connectionString);
        dbConnection.Open();
        IDbCommand query;
        
        query = dbConnection.CreateCommand();
        string createTable = "CREATE TABLE IF NOT EXISTS dialogos (id TEXT, text TEXT, variables TEXT, opcions TEXT, UNIQUE(id))";

        query.CommandText = createTable;
        query.ExecuteNonQuery();

        createTable = "CREATE TABLE IF NOT EXISTS variables (nombre TEXT, estado NUMERIC, UNIQUE(nombre))";
        query.CommandText = createTable;
        query.ExecuteNonQuery();

        foreach (var kvp in DialogueParser.variables)
        {
            if (kvp.Value)
            {
                query.CommandText = "INSERT OR REPLACE INTO variables (nombre, estado) VALUES (@nombre, @estado)";
                query.Parameters.Add(new SqliteParameter("@nombre", kvp.Key));
                query.Parameters.Add(new SqliteParameter("@estado", 1));
                query.ExecuteNonQuery();
            }
            else
            {
                query.CommandText = "INSERT OR REPLACE INTO variables (nombre, estado) VALUES (@nombre, @estado)";
                query.Parameters.Add(new SqliteParameter("@nombre", kvp.Key));
                query.Parameters.Add(new SqliteParameter("@estado", 0));
                query.ExecuteNonQuery();
            }
            
        }


        String id, text;

        foreach (Dialogue dig in dc.list)
        {
            id = dig.id;
            text = dig.text;
            String variables = null;
            if (dig.variable[0] != null)
            {
                variables = "[" + dig.variable[0] + ", " + dig.variable[1] + "]";
            }
            String options = "";
            if (dig.options.Count != 0)
            {
                foreach (DialogueOption op in dig.options)
                {
                    if (op.condition != null)
                    {
                        options += op.target + ":" + op.text + ":" + op.condition + ",";
                    }
                    else
                    {
                        options += op.target + ":" + op.text + ",";
                    }
                }

                options = options.Substring(0, options.Length - 1);

                query.CommandText = "INSERT OR REPLACE INTO dialogos (id, text, variables, opcions) VALUES (@id, @text, @variables, @options)";
                query.Parameters.Add(new SqliteParameter("@id",id));
                query.Parameters.Add(new SqliteParameter("@text",text));
                query.Parameters.Add(new SqliteParameter("@variables", variables));
                query.Parameters.Add(new SqliteParameter("@options", options));
                query.ExecuteNonQuery();

            }

        }
        query.Dispose();
        dbConnection.Close();
    }
    
    /*
    string text = "key1:value1,key2:value2,key3:value3";
    Dictionary<string, string> dictionary = new Dictionary<string, string>();

    foreach (string pair in text.Split(','))
    {
        string[] keyValue = pair.Split(':');
        dictionary.Add(keyValue[0], keyValue[1]);
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
