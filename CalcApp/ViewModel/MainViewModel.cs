using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcApp.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    public string calculation = "0";

    bool first;

    // For handling my button presses.
    [RelayCommand]
    void ButtonHandler(string character)
    {
        // To check if we should override the number or not.
        first = (Calculation == "0" || Calculation == "∞" || Calculation == "-∞" || Calculation == "NaN") ? true : false;
        // To set to 0 if we have gotten the result of infinite because it can not be calculated on.
        Calculation = (first) ? "0" : Calculation; 

        switch (character)
        {
            case "+": case "-": case "÷": case "X":
                shouldReplace(character);
                break;
            case "C":
                Calculation = "0";
                break;
            case "backspace":
                BackSpace();
                break;
            case "equals":
                equals();
                break;
            case ".":
                commaHandler(character);
                break;
            default:
                if (first)
                {
                    Calculation = character;
                } else
                {
                    Calculation += character;
                }
                break;
        }
    }

    private void commaHandler(string character)
    {
        if (Calculation.EndsWith(".")) { return; };


        bool isComma = false;

        foreach (char singleChar in Calculation)
        {
            string Char = singleChar.ToString();

            if (Char == ".")
            {
                isComma = true;
            }

            if (Char == "+" || Char == "-" || Char == "÷" || Char == "X")
            {
                isComma = false;
            }
        }
       

        if (!isComma)
        {
            Calculation += character;
        }
    }

    // Does some math with DataTable().Compute look it up if you want.
    private void equals()
    {
        if (Calculation.EndsWith("÷") ||
            Calculation.EndsWith("X") ||
            Calculation.EndsWith("-") ||
            Calculation.EndsWith("+"))
        {
            Calculation = Calculation.Remove(Calculation.Length - 1, 1);
        }

        Calculation = new DataTable().Compute(Calculation.Replace("X", "*").Replace("÷", "/").Replace(",", "."), null).ToString().Replace(",",".");
    }

    // Removes the last character in the calculation.
    void BackSpace()
    {
        Calculation = Calculation.Remove(Calculation.Length - 1, 1);

        if (Calculation.Length == 0)
        {
            Calculation = "0";
        }
    }

    // Checks if we can add the operator or should replace the existing selected one.
    private void shouldReplace(string character)
    {
        if (Calculation.EndsWith("÷") || 
            Calculation.EndsWith("X") || 
            Calculation.EndsWith("-") || 
            Calculation.EndsWith("+"))
        {
            Calculation = Calculation.Remove(Calculation.Length -1, 1) + character;
        } else
        {
            Calculation += character;
        }
    }
}

