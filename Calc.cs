using System;
using System.Linq;
using System.Data;
using System.Diagnostics;

namespace Kalkulačka_v2
{
    public class Calc
    {
        private string main_Text, calc_Text;
        private double result;

        private const char plusS = '+';
        private const char minusS = '-';
        private const char multiplyS = '*';
        private const char divideS = '÷';
        private const char divideS_Two = '/';

        private readonly char[] signs = { plusS, minusS, multiplyS, divideS, divideS_Two }; // symboly základních operací

        public Calc()
        {
            SetCalculationToNull();
        }

        public string GetResult()
        {
            //vrátí převedený result na string 
            return result.ToString();
        }

        public string GetCalculation()
        {
            // vrátí string pro zobrazeni zadaných hodnot
            return main_Text;
        }

        private void Calculate()
        {
            // zkusí provést výpočet z aktuálního stringu
            // pokud je posledni znak symbol operace odstraníme jej ze stringu a pote provedeme výpočet
            try
            {
                if (signs.Contains(calc_Text.Last()))
                {
                    calc_Text = calc_Text.RemoveLast(1);
                }

                result = Math.Round(Convert.ToDouble(new DataTable().Compute(calc_Text, "")) * 10000000) / 10000000;
            }
            catch {
            }
        }

        public void BackSpace()
        {
            // zkusí smazat jeden symbol ze zadaného stringu
            // upraví string pro výpočet podle zadaného stringu
            // spustí nový výpočet
            try
            {
                main_Text = main_Text.RemoveLast(1);
                if (main_Text == "") result = 0;
                SetCalcText();
                Calculate();
            }
            catch { }
        }

        private void CheckCharAndAdd(char c)
        {
            if (c == '%')
            { 
                if(main_Text != "") main_Text += c;
                string[] mtArr = main_Text.Split(signs);
                try
                {
                    if (main_Text[main_Text.Length - 2] == '%')
                    {
                        main_Text = main_Text.RemoveLast(1);
                    }
                }
                catch { }
            } 
            else if (signs.Contains(c))
            {
                if (main_Text == "") main_Text = "0";
                char last = main_Text.Last();
                if (signs.Contains(last))
                {
                    main_Text = main_Text.RemoveLast(1);
                }
                main_Text += c;
            } 
            else if(c == '.')
            {
                main_Text += c;
                string[] arrStr = main_Text.Split(signs);
                int lastIndex = arrStr.Count() - 1;
                try
                {
                    if (arrStr[lastIndex].Count(x => x == c) > 1)
                    {
                        main_Text = main_Text.RemoveLast(1);
                    }
                }
                catch { }
            } 
            else
            {
                if (main_Text != "")
                {
                    if (main_Text.Last() != '%') main_Text += c;
                }
                else main_Text += c;
            }
        }
        private string FormatPercent(ref int maxId) {
            string temp_first_Text = calc_Text.Substring(0, maxId); // vytvoří dočasný text končící před symbolem '%'

            int last = calc_Text.Length - maxId;    // počet znaků v textu které jsou za aktuálním znakem '%'

            string temp_last_Text = calc_Text.Substring(calc_Text.Length - last).Replace("%", string.Empty); // vytvoří dočasný text zbytkových znaků a nahradí znak ¨%¨ prádzným znakem

            string[] st = temp_first_Text.Split(signs); // rozdělí dočasný text 'temp_first_Text' podle symbolů operací
            int last_in_array = st.Count() - 1; // pozice posledního stringu v 'st[]'
            int lastlen = st[last_in_array].Length; // délka posledního stringu v 'st[]'

            int max = temp_first_Text.Length - lastlen; // délka dočasného textu 'temp_first_Text'

            temp_first_Text = temp_first_Text.Substring(0, max);    // odstraní z 'temp_first_Text' hodnotu která bude převedena na procenta

            char l = '\0';

            try
            {
                l = temp_first_Text.Last();  // zjistí symbol operace která bude použita pro procenta (+ - * /)
            }
            catch { }

            string perc;

            if (l == plusS || l == minusS)  // pokud je symbol '+' nebo '-' vypočíta procento z předchozího čísla
            {
                perc = (Convert.ToDouble(st[last_in_array - 1]) * Convert.ToDouble(st[last_in_array]) / 100).ToString();
            }
            else  // pokud je symbol '*' nebo '/' vydělí hodnotu posledního čísla stem
            {
                perc = (Convert.ToDouble(st[last_in_array]) / 100).ToString();
            }

            temp_first_Text += perc;    // přídá procentuální hodnotu do 'temp_first_Text'
            
            maxId = max + perc.Length - 1;  //upraví pozici v 'calc_Text'
           
            return temp_first_Text + temp_last_Text;    // vrátí složený string z 'temp_first_Text + temp_last_Text'
        }

        private void SetCalcText()
        {
            // nahradí symbol '÷' za '/'
            calc_Text = main_Text.Replace(divideS, '/');

            // zkontroluje formátování textu 
            int id = 0;
            foreach(char c in calc_Text)
            {
                // když najde znak '%' změní string pro výpočet aby fungoval
                if (c == '%')
                {
                    calc_Text = FormatPercent(ref id); // zformátuje 'calc_Text' pro správný výpočet
                    calc_Text = calc_Text.Replace(',', '.');    // nahradí znak ',' znakem '.' aby fungoval výpočet
                    Trace.WriteLine(calc_Text);
                }
                id++;   // zvýší hodnotu id
                
            }
        }

        public void SetCalculationToNull()
        {
            // nastaví na výchozí nulové hodnoty
            main_Text = "";
            calc_Text = "";
            result = 0;
        }

        public void AddValue(char c)
        {
            CheckCharAndAdd(c);
            SetCalcText();
            Calculate();
        }

        public void AddValue(string s)
        {

            foreach(char c in s)
            {
                AddValue(c);
            }
        }
    }
}
