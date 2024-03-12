using System;
using System.Collections.Generic;
using System.Threading;
using DictionaryMAin;
using DictionaryServices;
using System.Media;
using System.IO;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using DictionaryMAin;

namespace DictionaryApp
{
    class Program
    {

        static void Main(string[] args)
        {


            string dictionariesFilePath = "dictionary.txt";
            DictionaryService dictionaryService = new DictionaryService(dictionariesFilePath);


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            dictionaryService.DrawSmiley('*', '0', '_', '>');
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("░▒▓███████▓▒░░▒▓█▓▒░░▒▓██████▓▒░▒▓████████▓▒░▒▓█▓▒░░▒▓██████▓▒░░▒▓███████▓▒░ ░▒▓██████▓▒░░▒▓███████▓▒░░▒▓█▓▒░░▒▓█▓▒░");
            Console.WriteLine("░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░   ░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░");
            Console.WriteLine("░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░▒▓█▓▒░        ░▒▓█▓▒░   ░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ ");
            Console.WriteLine("░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░▒▓█▓▒░        ░▒▓█▓▒░   ░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓████████▓▒░▒▓███████▓▒░ ░▒▓██████▓▒░  ");
            Console.WriteLine("░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░▒▓█▓▒░        ░▒▓█▓▒░   ░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░  ░▒▓█▓▒░   ");
            Console.WriteLine("░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░   ░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░  ░▒▓█▓▒░    ");
            Console.WriteLine("░▒▓███████▓▒░░▒▓█▓▒░░▒▓██████▓▒░  ░▒▓█▓▒░   ░▒▓█▓▒░░▒▓██████▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░  ░▒▓█▓▒░     ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter ENTER to continue");
            Console.ReadLine();


            Console.Clear();



            while (true)
            {

                Console.WriteLine("\n=== Menu ===");
                Console.WriteLine("1. Create Dictionary");
                Console.WriteLine("2. Add Word to Dictionary");
                Console.WriteLine("3. Replace Word in Dictionary");
                Console.WriteLine("4. Remove Word from Dictionary");
                Console.WriteLine("5. Remove translation of the word");
                Console.WriteLine("6. Search Word in Dictionary");
                Console.WriteLine("7. Export Dictionary");
                Console.WriteLine("8. Show all dictionaries with words");
                Console.WriteLine("9. Show names of dictionaries");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.Clear();



                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Names of dictionaries : ");
                        dictionaryService.ShowOnlyNameOfDictionaries();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Enter dictionary name: ");
                        string dictName = Console.ReadLine();
                        Console.Write("Enter source language: ");
                        string langFrom = Console.ReadLine();
                        Console.Write("Enter target language: ");
                        string langTo = Console.ReadLine();
                        dictionaryService.CreateDictionary(dictName, langFrom, langTo);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Names of dictionaries : ");
                        dictionaryService.ShowOnlyNameOfDictionaries();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Enter dictionary name: ");
                        string dictName2 = Console.ReadLine();
                        Console.Write("Enter word to add: ");
                        string wordToAdd = Console.ReadLine();
                        Console.Write("Enter translation(s) separated by commas: ");
                        string translations = Console.ReadLine();
                        List<string> translationsList = new List<string>(translations.Split(','));
                        dictionaryService.AddWord(dictName2, wordToAdd, translationsList);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case "3":
                        dictionaryService.ShowAllDictionaries();
                        Console.WriteLine();
                        Console.Write("Enter dictionary name: ");
                        string dictName3 = Console.ReadLine();
                        Console.Write("Enter word to replace: ");
                        string oldWord = Console.ReadLine();
                        Console.Write("Enter new word: ");
                        string newWord = Console.ReadLine();
                        Console.Write("Enter new translation(s) separated by commas: ");
                        string newTranslations = Console.ReadLine();
                        List<string> newTranslationsList = new List<string>(newTranslations.Split(','));

                        dictionaryService.ReplaceWord(dictName3, oldWord, newWord, newTranslationsList);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case "4":
                        dictionaryService.ShowAllDictionaries();
                        Console.WriteLine();
                        Console.Write("Enter dictionary name: ");
                        string dictName4 = Console.ReadLine();
                        Console.Write("Enter word to remove: ");
                        string wordToRemove = Console.ReadLine();
                        dictionaryService.RemoveWordCompletely(dictName4, wordToRemove);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case "5":
                        dictionaryService.ShowAllDictionaries();
                        Console.WriteLine();
                        Console.WriteLine("Enter dictionary name:");
                        string dictName6 = Console.ReadLine();
                        Console.WriteLine("Enter word:");
                        string word = Console.ReadLine();
                        Console.WriteLine("Enter translation to remove:");
                        string translationToRemove = Console.ReadLine();
                        dictionaryService.RemoveTranslation(dictName6, word, translationToRemove);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case "6":
                        Console.WriteLine("Names of dictionaries : ");
                        dictionaryService.ShowOnlyNameOfDictionaries();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Enter dictionary name: ");
                        string dictName5 = Console.ReadLine();
                        Console.Write("Enter word to search: ");
                        string wordToSearch = Console.ReadLine();
                        dictionaryService.SearchWord(dictName5, wordToSearch);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case "7":
                        Console.WriteLine("Names of dictionaries : ");
                        dictionaryService.ShowOnlyNameOfDictionaries();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Enter dictionary name to export: ");
                        string dictToExport = Console.ReadLine();
                        Console.Write("Enter export file path: ");
                        string exportFilePath = Console.ReadLine();
                        dictionaryService.ExportDictionary(dictToExport, exportFilePath);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case "8":
                        Console.WriteLine("All dictionaries");
                        dictionaryService.ShowAllDictionaries();
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case "9":
                        Console.WriteLine("Names of dictionaries");
                        dictionaryService.ShowOnlyNameOfDictionaries();
                        Thread.Sleep(2000);
                        Console.Clear();

                        break;
                    case "0":

                        dictionaryService.DrawSadSmiley('*', '0', '_', 'v');
                        Console.WriteLine();
                        Console.WriteLine("░▒▓███████▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓████████▓▒░      ░▒▓███████▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓████████▓▒░");
                        Console.WriteLine("░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░             ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░        ");
                        Console.WriteLine("░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░             ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░        ");
                        Console.WriteLine("░▒▓███████▓▒░ ░▒▓██████▓▒░░▒▓██████▓▒░        ░▒▓███████▓▒░ ░▒▓██████▓▒░░▒▓██████▓▒░   ");
                        Console.WriteLine("░▒▓█▓▒░░▒▓█▓▒░  ░▒▓█▓▒░   ░▒▓█▓▒░             ░▒▓█▓▒░░▒▓█▓▒░  ░▒▓█▓▒░   ░▒▓█▓▒░        ");
                        Console.WriteLine("░▒▓█▓▒░░▒▓█▓▒░  ░▒▓█▓▒░   ░▒▓█▓▒░             ░▒▓█▓▒░░▒▓█▓▒░  ░▒▓█▓▒░   ░▒▓█▓▒░        ");
                        Console.WriteLine(" ░▒▓███████▓▒░   ░▒▓█▓▒░   ░▒▓████████▓▒░      ░▒▓███████▓▒░   ░▒▓█▓▒░   ░▒▓████████▓▒░ ");



                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();

                        Environment.Exit(0);
                        break;
                    default:

                        Console.Clear();
                        Console.WriteLine("Invalid input.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
