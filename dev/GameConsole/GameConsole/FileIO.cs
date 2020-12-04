﻿using System;
using System.Collections.Generic;
using System.IO;

namespace GameConsole
{
    public static class FileIO
    {
        //USERS
        //
        //
        //Load Users
        public static List<User> LoadUsers(string filePath)
        {
            List<User> users = new List<User>();
            if (!File.Exists(filePath))
            {
                return users;
            }
            else
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lineSplit = line.Split(":");
                        string name = lineSplit[0];
                        string password = lineSplit[1];
                        int age = int.Parse(lineSplit[2]);
                        string theme = lineSplit[3];

                        User newUser = new User(name, password, age, theme);
                        users.Add(newUser);
                    }
                    return users;
                }
            }
        }
        //Save Users
        public static void SaveEmployees(string filePath, List<User> users)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                //Research how to do this conditionally based of the Employee's type.
                //Pretty sure this is built in somewhere with inheritance and abstract methods
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                for (int i = 0; i < users.Count; i++)
                {
                    string[] saveData = users[i].GetSaveData();
                    //string toWrite = $"{saveData[0]}:{saveData[1]}:{saveData[2]}:{saveData[3]}";
                    string toWrite = "";
                    foreach (string dataPoint in saveData)
                    {
                        if (toWrite == "")
                        {
                            toWrite = dataPoint;
                        }
                        else
                        {
                            toWrite = $"{toWrite}:{dataPoint}";
                        }

                    }
                    sw.WriteLine(toWrite);
                }
            }
        }
        



        //THEMES
        //
        //
        //Load Themes
        public static List<Theme> LoadThemes(string filePath)
        {
            List<Theme> themes = new List<Theme>();
            if (!File.Exists(filePath))
            {
                return themes;
            }
            else
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lineSplit = line.Split(":");
                        string name = lineSplit[0];
                        string text = lineSplit[1];
                        string background = lineSplit[2];
                        string title = lineSplit[3];
                        string success = lineSplit[4];
                        string error = lineSplit[5];
                        string info = lineSplit[6];

                        Theme newTheme = new Theme(name, text, background, title, success, error, info);
                        themes.Add(newTheme);
                    }
                    return themes;
                }
            }
        }
    }//end of class
}