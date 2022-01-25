using System.ComponentModel.Design;
using System.Net.Mime;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public class Form1 : Form
{
    private Font mainFont;
    List<string> wordList = new List<string>();
    List<char> bannedChars = new List<char>();
    Dictionary<int, char> correctPlaceChars = new Dictionary<int, char>();
    List<char> incorrectPlaceChars = new List<char>();
    Dictionary<char, int> letterUsedCount = new Dictionary<char, int>();
    public void FormLayout()
    {
        mainFont = new Font("Segoe UI", 12);
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.Name = "Worlde Solver";
        this.Text = "Worlde Solver";
        this.Size = new Size(800, 800);

        ClearDictAndAddLetters();
        for (int i = 0; i <= 4; i++)
        {
            correctPlaceChars.Add(i, '?');
        }

        using(StreamReader reader =  new StreamReader(".\\words.txt"))
        {
            string currLine;
            while((currLine = reader.ReadLine()) != null)
            {
                wordList.Add(currLine);
            }
        }

        CheckForBannedChars();
        CheckForCorrectPlaceChars();
        CheckForIncorrectPlaceChars();
        FindCommonLetters();
        FindBestWord();
    }

    private void FindBestWord()
    {
        /* List<int> commonLetters = new List<int>();
        int lettersLeftToFind = correctPlaceChars.Count + incorrectPlaceChars.Count;

        foreach(char lett in letterUsedCount.Keys)
        {
            if(!bannedChars.Contains(lett))
            {

            }
        }
        for (int i = 1; i <= lettersLeftToFind; i++)
        {
            
        } */
        Random random = new Random();
        int num = random.Next(0, wordList.Count);
        Console.WriteLine(wordList.Count);
        string word = wordList[num];
    }

    private void ClearDictAndAddLetters()
    {
        letterUsedCount.Clear();

        for (int i = 97; i <= 122; i++)
        {
            letterUsedCount.Add((char)i, 0);
        }
    }

    private void FindCommonLetters()
    {
        foreach(string currWord in wordList)
        {
            foreach(char currLetter in currWord)
                letterUsedCount[currLetter] += 1;
        }
    }

    private void CheckForCorrectPlaceChars()
    {
        List<string> toRemove = new List<string>();

        foreach(string word in wordList)
        {
            foreach(int num in correctPlaceChars.Keys)
            {
                //Console.WriteLine(correctPlaceChars[num]);
                if(word.IndexOf(correctPlaceChars[num]) == num)
                {
                    toRemove.Add(word);
                    break;
                }
            }
        }

        foreach(string word in toRemove)
            wordList.Remove(word);
    }

    private void CheckForIncorrectPlaceChars()
    {
        List<string> toRemove = new List<string>();

        foreach(string word in wordList)
        {
            foreach(char lett in incorrectPlaceChars)
            {
                if(word.Contains(lett.ToString()))
                {
                    continue;
                }
                toRemove.Add(word);
            }
        }

        foreach(string word in toRemove)
            wordList.Remove(word);
    }

    private void CheckForBannedChars()
    {
        List<string> toRemove = new List<string>();
        foreach(string word in wordList)
        {
            foreach(char letter in bannedChars)
            {
                if(word.Contains(letter.ToString()))
                {
                    toRemove.Add(word);
                    break;
                }
            }
        }

        foreach(string word in toRemove)
            wordList.Remove(word);
    }
}

    
