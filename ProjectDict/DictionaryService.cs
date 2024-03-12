using DictionaryMAin;

namespace DictionaryServices
{

    public class DictionaryService
    {

        private string _filePath;
        private List<Dictionary> _dictionaries;

        public DictionaryService(string filePath)
        {
            _filePath = filePath;
            LoadDictionaries();
        }
        public void DrawSmiley(char face, char eye, char mouth, char nose)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(face);
                Console.SetCursorPosition(10, i);
                Console.Write(face);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(face);
                Console.SetCursorPosition(i, 9);
                Console.Write(face);
            }

            Console.SetCursorPosition(2, 2);
            Console.Write(eye);
            Console.SetCursorPosition(8, 2);
            Console.Write(eye);
            Console.SetCursorPosition(5, 4);
            Console.Write(nose);

            for (int i = 2; i < 9; i++)
            {
                Console.SetCursorPosition(i, 5);
                Console.Write(mouth);
            }
        }
        public void DrawSadSmiley(char face, char eye, char mouth, char nose)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(face);
                Console.SetCursorPosition(8, i);
                Console.Write(face);
            }
            for (int i = 0; i < 8; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(face);
                Console.SetCursorPosition(i, 9);
                Console.Write(face);
            }

            Console.SetCursorPosition(3, 2);
            Console.Write(eye);
            Console.SetCursorPosition(5, 2);
            Console.Write(eye);


            Console.SetCursorPosition(4, 3);
            Console.Write(nose);

            Console.SetCursorPosition(2, 4);
            Console.Write("/");
            Console.SetCursorPosition(3, 4);
            Console.Write("--");
            Console.SetCursorPosition(5, 4);
            Console.Write("-");
            Console.SetCursorPosition(6, 4);
            Console.Write("\\");

        }








        private void SaveDictionaries()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    foreach (var dictionary in _dictionaries)
                    {
                        writer.WriteLine($"Dictionary: {dictionary.Name}");
                        writer.WriteLine($"Language From: {dictionary.LanguageFrom}, Language To: {dictionary.LanguageTo}");
                        foreach (var entry in dictionary.Words)
                        {
                            writer.WriteLine($"{entry.Key} - {string.Join(", ", entry.Value)}");
                        }
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving dictionaries: {ex.Message}");
            }
        }
        public void Grasshoper()
        {
            Console.Beep(440, 300);
            Console.Beep(330, 300);
            Console.Beep(440, 300);
            Console.Beep(330, 300);
            Console.Beep(440, 300);
            Console.Beep(415, 300);
            Console.Beep(415, 300);
            Thread.Sleep(600);
            Console.Beep(415, 300);
            Console.Beep(330, 300);
            Console.Beep(415, 300);
            Console.Beep(330, 300);
            Console.Beep(415, 300);
            Console.Beep(440, 300);
            Console.Beep(440, 300);
            Thread.Sleep(600);
            Console.Beep(440, 300);
            Console.Beep(494, 300);
            Console.Beep(494, 100);
            Console.Beep(494, 100);
            Console.Beep(494, 300);
            Console.Beep(494, 300);
            Console.Beep(523, 300);
            Console.Beep(523, 100);
            Console.Beep(523, 100);
            Console.Beep(523, 300);
            Console.Beep(523, 300);
            Console.Beep(523, 300);
            Console.Beep(494, 300);
            Console.Beep(440, 300);
            Console.Beep(415, 300);
            Console.Beep(440, 800);
        }

        public void CreateDictionary(string name, string languageFrom, string languageTo)
        {
            if (_dictionaries.Any(d => d.Name == name))
            {
                Console.WriteLine("Dictionary with this name already exists.");
                return;
            }

            var newDictionary = new Dictionary
            {
                Name = name,
                LanguageFrom = languageFrom,
                LanguageTo = languageTo
            };

            _dictionaries.Add(newDictionary);
            SaveDictionaries();
            Console.WriteLine($"Dictionary '{name}' created successfully.");
        }

        public void AddWord(string dictionaryName, string word, List<string> translations)
        {
            var dictionary = GetDictionary(dictionaryName);
            if (dictionary == null)
            {
                Console.WriteLine("Dictionary not found.");
                return;
            }

            if (dictionary.Words.ContainsKey(word))
            {
                dictionary.Words[word].AddRange(translations);
            }
            else
            {
                dictionary.Words.Add(word, translations);
            }

            SaveDictionaries();
            Console.WriteLine($"Word '{word}' added successfully to dictionary '{dictionaryName}'.");
        }

        public void ReplaceWord(string dictionaryName, string oldWord, string newWord, List<string> translations)
        {
            var dictionary = GetDictionary(dictionaryName);
            if (dictionary == null)
            {
                Console.WriteLine("Dictionary not found.");
                return;
            }

            if (dictionary.Words.ContainsKey(oldWord))
            {
                dictionary.Words.Remove(oldWord);
                dictionary.Words.Add(newWord, translations);
                SaveDictionaries();
                Console.WriteLine($"Word '{oldWord}' replaced with '{newWord}' in dictionary '{dictionaryName}'.");
            }
            else
            {
                Console.WriteLine($"Word '{oldWord}' not found in dictionary '{dictionaryName}'.");
            }
        }


        public void RemoveWordCompletely(string dictionaryName, string word)
        {
            var dictionary = GetDictionary(dictionaryName);
            if (dictionary == null)
            {
                Console.WriteLine("Dictionary not found.");
                return;
            }

            if (!dictionary.Words.ContainsKey(word))
            {
                Console.WriteLine($"Word '{word}' not found in dictionary '{dictionaryName}'.");
                return;
            }

            dictionary.Words.Remove(word);
            SaveDictionaries();
            Console.WriteLine($"Word '{word}' removed completely from dictionary '{dictionaryName}'.");
        }
        public void RemoveTranslation(string dictionaryName, string word, string translation)
        {
            var dictionary = GetDictionary(dictionaryName);
            if (dictionary == null)
            {
                Console.WriteLine("Dictionary not found.");
                return;
            }

            if (!dictionary.Words.ContainsKey(word))
            {
                Console.WriteLine($"Word '{word}' not found in dictionary '{dictionaryName}'.");
                return;
            }

            var translations = dictionary.Words[word];
            if (!translations.Contains(translation))
            {
                Console.WriteLine($"Translation '{translation}' not found for word '{word}' in dictionary '{dictionaryName}'.");
                return;
            }

            translations.Remove(translation);
            if (translations.Count == 0)
            {
                dictionary.Words.Remove(word);
                Console.WriteLine($"Word '{word}' removed completely from dictionary '{dictionaryName}'.");
            }
            else
            {
                Console.WriteLine($"Translation '{translation}' removed from word '{word}' in dictionary '{dictionaryName}'.");
            }

            SaveDictionaries();
        }

        public void SearchWord(string dictionaryName, string word)
        {
            var dictionary = GetDictionary(dictionaryName);
            if (dictionary == null)
            {
                Console.WriteLine("Dictionary not found.");
                return;
            }

            if (dictionary.Words.ContainsKey(word))
            {
                var translations = dictionary.Words[word];
                Console.WriteLine($"Translations of '{word}' in dictionary '{dictionaryName}':");
                foreach (var translation in translations)
                {
                    Console.WriteLine("- " + translation);
                }
            }
            else
            {
                Console.WriteLine($"Word '{word}' not found in dictionary '{dictionaryName}'.");
            }
        }

        public void ExportDictionary(string dictionaryName, string exportFilePath)
        {
            var dictionary = GetDictionary(dictionaryName);
            if (dictionary == null)
            {
                Console.WriteLine("Dictionary not found.");
                return;
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(exportFilePath))
                {
                    writer.WriteLine($"Dictionary: {dictionary.Name}");
                    writer.WriteLine($"Language From: {dictionary.LanguageFrom}, Language To: {dictionary.LanguageTo}");
                    foreach (var entry in dictionary.Words)
                    {
                        writer.WriteLine($"{entry.Key} - {string.Join(", ", entry.Value)}");
                    }
                }
                Console.WriteLine($"Dictionary '{dictionary.Name}' exported successfully to file '{exportFilePath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting dictionary: {ex.Message}");
            }
        }

        public void ExportAllDictionaries()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    foreach (var dictionary in _dictionaries)
                    {
                        writer.WriteLine($"Dictionary: {dictionary.Name}");
                        writer.WriteLine($"Language From: {dictionary.LanguageFrom}, Language To: {dictionary.LanguageTo}");
                        foreach (var entry in dictionary.Words)
                        {
                            writer.WriteLine($"{entry.Key} - {string.Join(", ", entry.Value)}");
                        }
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving dictionaries: {ex.Message}");
            }
        }
        public void ShowOnlyNameOfDictionaries()
        {
            foreach (var dictionary in _dictionaries)
            {
                Console.WriteLine($"Dictionary: {dictionary.Name}");
                Console.WriteLine($"Language From: {dictionary.LanguageFrom}, Language To: {dictionary.LanguageTo}");
                Console.WriteLine();
            }
        }
        public void ShowAllDictionaries()
        {
            foreach (var dictionary in _dictionaries)
            {
                Console.WriteLine();
                Console.WriteLine($"Dictionary: {dictionary.Name}");
                Console.WriteLine($"Language From: {dictionary.LanguageFrom}, Language To: {dictionary.LanguageTo}");
                Console.WriteLine("Words and Translations:");
                foreach (var entry in dictionary.Words)
                {
                    Console.WriteLine($"  - {entry.Key}: {string.Join(", ", entry.Value)}");
                }
            }
        }


        private void LoadDictionaries()
        {
            try
            {
                _dictionaries = new List<Dictionary>();
                if (File.Exists(_filePath))
                {
                    using (StreamReader reader = new StreamReader(_filePath))
                    {
                        string line;
                        Dictionary currentDictionary = null;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.StartsWith("Dictionary:"))
                            {
                                if (currentDictionary != null)
                                {
                                    _dictionaries.Add(currentDictionary);
                                }
                                currentDictionary = new Dictionary();
                                string[] nameParts = line.Split(':');
                                if (nameParts.Length >= 2)
                                {
                                    currentDictionary.Name = nameParts[1].Trim();
                                }
                            }
                            else if (line.StartsWith("Language From:"))
                            {
                                string langLine = line.Split(':')[1].Trim();
                                string[] langParts = langLine.Split(',');
                                if (langParts.Length >= 2)
                                {
                                    currentDictionary.LanguageFrom = langParts[0];
                                    currentDictionary.LanguageTo = langParts[1];
                                }
                            }
                            else if (!string.IsNullOrWhiteSpace(line))
                            {
                                string[] wordEntry = line.Split('-');
                                if (wordEntry.Length == 2)
                                {
                                    string word = wordEntry[0].Trim();
                                    string[] translations = wordEntry[1].Split(',').Select(t => t.Trim()).ToArray();
                                    currentDictionary.Words.Add(word, new List<string>(translations));
                                }
                            }
                        }

                        if (currentDictionary != null)
                        {
                            _dictionaries.Add(currentDictionary);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading dictionaries: {ex.Message}");
                _dictionaries = new List<Dictionary>();
            }
        }


        private Dictionary GetDictionary(string dictionaryName)
        {
            return _dictionaries.FirstOrDefault(d => d.Name == dictionaryName);
        }
    }
}
