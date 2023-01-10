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

    [RelayCommand]
    void ButtonHandler(string character)
    {
        first = (Calculation == "0") ? true : false; 
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
            default:
                if (first && character != ".")
                {
                    Calculation = character;
                } else
                {
                    Calculation += character;
                }
                first = false;
                break;
        }
    }

    private void equals()
    {
        if (Calculation.EndsWith("÷") ||
            Calculation.EndsWith("X") ||
            Calculation.EndsWith("-") ||
            Calculation.EndsWith("+"))
        {
            Calculation = Calculation.Remove(Calculation.Length - 1, 1);
        }

        Calculation = new DataTable().Compute(Calculation.Replace("X", "*").Replace("÷", "/").Replace(",", "."), null).ToString();
    }

    void BackSpace()
    {
        Calculation = Calculation.Remove(Calculation.Length - 1, 1);

        if (Calculation.Length == 0)
        {
            Calculation = "0";
        }
    }

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

