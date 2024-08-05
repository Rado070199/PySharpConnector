using Python.Runtime;

// Uruchomienie skryptu do tekstu
//RunScriptText("textscript");

// Uruchomienie skryptu do wykresów
RunScriptChart("chartscript");

// Uruchomienie skryptu do otwierania Notatnika
//RunScriptNotebookOpen();

static void RunScriptText(string scriptName)
{
    // Ścieżka do pliku DLL Pythona (zainstalowanego interpretera)
    Runtime.PythonDLL = @"C:\Users\rmazur\AppData\Local\Programs\Python\Python312\python312.dll";

    // Inicjalizacja silnika Pythona
    PythonEngine.Initialize();

    using (Py.GIL())
    {
        // Ścieżka do katalogu zawierającego skrypt Pythona
        string scriptPath = @"C:\Programy\MyProject\PySharpConnector\SharpApp";

        // Importowanie modułu sys i dodanie ścieżki do katalogu skryptu do sys.path
        dynamic sys = Py.Import("sys");
        sys.path.append(scriptPath);

        try
        {
            // Importowanie skryptu Pythona (module) na podstawie nazwy
            dynamic pythonScript = Py.Import(scriptName);

            // Wywołanie metody say_hello ze skryptu Pythona
            var result = pythonScript.say_hello();
            Console.WriteLine(result);

            // Utworzenie obiektu PyString i wywołanie metody test ze skryptu Pythona
            var message = new PyString("Message from Nick.");
            var result2 = pythonScript.test(message);
            Console.WriteLine(result2);
        }
        catch (PythonException ex)
        {
            // Obsługa wyjątków związanych z błędami Pythona
            Console.WriteLine($"Python error: {ex.Message}");
        }
    }
}


static void RunScriptChart(string scriptName)
{
    // Ścieżka do pliku DLL Pythona (zainstalowanego interpretera)
    Runtime.PythonDLL = @"C:\Users\rmazur\AppData\Local\Programs\Python\Python312\python312.dll";

    // Inicjalizacja silnika Pythona
    PythonEngine.Initialize();

    using (Py.GIL())
    {
        // Ścieżka do katalogu zawierającego skrypt Pythona
        string scriptPath = @"C:\Programy\MyProject\PySharpConnector\SharpApp";  // Zmień na rzeczywistą ścieżkę

        // Importowanie modułu sys i dodanie ścieżki do katalogu skryptu do sys.path
        dynamic sys = Py.Import("sys");
        sys.path.append(scriptPath);

        try
        {
            // Importowanie skryptu Pythona (module) na podstawie nazwy
            dynamic pythonScript = Py.Import(scriptName);

            // Wywołanie metody my_function ze skryptu Pythona, która generuje wykres
            pythonScript.my_function();
        }
        catch (PythonException ex)
        {
            // Obsługa wyjątków związanych z błędami Pythona
            Console.WriteLine($"Python error: {ex.Message}");
        }
    }
}

static void RunScriptNotebookOpen()
{
    // Ścieżka do skryptu Pythona, który uruchamia Notatnik
    string pythonScriptPath = @"C:\Programy\MyProject\PySharpConnector\SharpApp\opennotebookscript.py";

    // Ścieżka do pliku DLL Pythona (zainstalowanego interpretera)
    Runtime.PythonDLL = @"C:\Users\rmazur\AppData\Local\Programs\Python\Python312\python312.dll";

    // Inicjalizacja silnika Pythona
    PythonEngine.Initialize();

    try
    {
        using (Py.GIL())
        {
            // Odczytanie zawartości skryptu Pythona jako tekst
            string scriptContent = System.IO.File.ReadAllText(pythonScriptPath);

            // Wykonanie zawartości skryptu Pythona
            PythonEngine.RunString(scriptContent);
        }
    }
    catch (PythonException ex)
    {
        // Obsługa wyjątków związanych z błędami Pythona
        Console.WriteLine($"Python error: {ex.Message}");
    }
    finally
    {
        // Finalizacja działania silnika Pythona
        PythonEngine.Shutdown();
    }
}
