using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Koryagin_Windows_Forms
{
    public partial class Form1 : Form
    {
        List<string> List_Perem = new List<string>();
        string Main_String = "";
        double[] Perem_Value;
        int Perem(string _str)
        {
            Regex regex = new Regex(@"^[A-Za-z]{1}[A-Za-z0-7]*$");
            Match match = regex.Match(_str);
            if (match.Success)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        int Uel(string _str)
        {
            Regex regex = new Regex(@"^[0-7]+$");
            Match match = regex.Match(_str);
            if (match.Success) {return 0;}
            else {return 1;}
        }
        double B4(string _str)
        {
            if (Perem(_str) == 0)
            {
                if (List_Perem.Contains(_str))
                {
                    if (Perem_Value[List_Perem.IndexOf(_str)] != -21038135135){
                        return Perem_Value[List_Perem.IndexOf(_str)];}
                    else {return -200000000.124;}
                }
                else {return -200000000.1245;}
            }
            else
            {
                if(Uel(_str) == 0)
                {
                    try
                    {return Convert.ToDouble(_str);}
                    catch {
                        FormatException ex = new FormatException("?");
                        return -200000000.125; }
                }
                else {return -200000000.1246;}
            }
        }
        double B3(string _str)
        {
            List<double> res_B3 = new List<double>();
            List<int> tr_B3 = new List<int>();
            List<string> func = new List<string>();
            string sr = "";  double a;
            Regex regex = new Regex(@"^(sin|cos|abs)([0-7]+|[A-Za-z]{1}[A-Za-z0-7]*)$");
            Match match = regex.Match(_str);
            if (match.Success)
            {
                for (int i = 0; i < _str.Length - 2; i++)
                {
                    sr = sr + _str[i] + _str[i + 1] + _str[i + 2];
                    if (sr == "sin") {func.Add("sin");}
                    if (sr == "cos") {func.Add("cos");}
                    if (sr == "abs") {func.Add("abs");}
                    sr = "";
                }
                string[] strs = _str.Split(new string[] { "sin", "cos", "abs" }, StringSplitOptions.RemoveEmptyEntries);
                if (B4(strs[0]) < -200000000) {Errors(_str, strs[0], B4(strs[0])); return -200000000.127;}
                else
                {
                    a = B4(strs[0]);
                    for (int i = func.Count - 1; i >= 0; i--)
                    {
                        if (func[i] == "sin") {a = Math.Sin(a * (Math.PI / 180));}
                        if (func[i] == "cos") {a = Math.Cos(a * (Math.PI / 180));}
                        if (func[i] == "abs") {a = Math.Abs(a);}
                    }
                    return a;
                }
            }
            else {return -200000000.126;}
        }
        double B2(string _str)
        {
            double a = 0;
            List<double> res_B2 = new List<double>();
            List<int> tr_B2 = new List<int>();
            for (int i = 0; i < _str.Length; i++) {if (_str[i] == '^') {tr_B2.Add(i);}}
            string[] strs = _str.Split(new char[] { '^' });
            foreach (string s in strs)
            {
                if (s.Contains("sin") || s.Contains("cos") || s.Contains("abs"))
                {
                    if (B3(s) < -200000000) {Errors(_str, s, B3(s)); return -200000000.128;}
                    else {res_B2.Add(B3(s));}
                }
                else
                {
                    if (B4(s) < -200000000) {Errors(_str, s, B4(s)); return -200000000.129;}
                    else {res_B2.Add(B4(s));}
                }
            }
            if (res_B2.Count > 1)
            {
                a = res_B2[tr_B2.Count];
                for (int i = tr_B2.Count; i > 0; i--) {a = Math.Pow(res_B2[i - 1], a);}
                return a;
            }
            else {return res_B2[0];}
        }
        double B1(string _str)
        {
            double a = 0;
            List<double> res_B1 = new List<double>();
            List<int> tr_B1 = new List<int>();
            for (int i = 0; i < _str.Length; i++)
            {
                if (_str[i] == '*' || _str[i] == '/') {tr_B1.Add(i);}
            }
            string[] strs = _str.Split(new char[] { '*', '/' });
            foreach (string s in strs)
            {
                if (s.Contains('^'))
                {
                    if (B2(s) < -200000000) {Errors(_str, s, B2(s));return -200000000.130;}
                    else {res_B1.Add(B2(s));}
                }
                else
                {
                    if (s.Contains("sin") || s.Contains("cos") || s.Contains("abs"))
                    {
                        if (B3(s) < -200000000) {Errors(_str, s, B3(s));return -200000000.131;}
                        else {res_B1.Add(B3(s));}
                    }
                    else
                    {
                        if (B4(s) < -200000000) {Errors(_str, s, B4(s));return -200000000.132;}
                        else {res_B1.Add(B4(s));}
                    }
                }
            }
            if (res_B1.Count > 1)
            {
                a = res_B1[0];
                for (int i = 0; i < tr_B1.Count; i++)
                {
                    if (_str[tr_B1[i]] == '*') { a = a * res_B1[i + 1]; }
                    else
                    {
                        if (_str[tr_B1[i]] == '/')
                        {
                            if (res_B1[i + 1] != 0) { a = a / res_B1[i + 1]; }
                            else { return -200000000.137; }
                        }
                    }
                }
                return a;
            }
            else { return (res_B1[0]);}
        }
        double PrCh(string _str)
        {
            List<int> Zn = new List<int>();
            int t = 0;
            for (int i = 0; i < _str.Length; i++)
            {
                if (_str[i] == '+' || _str[i] == '-' || _str[i] == '*' || _str[i] == '/' || _str[i] == '^')
                {Zn.Add(i);}
            }

            for (int i = 0; i < Zn.Count - 1; i++)
            {
                if ((Zn[i] + 1) == Zn[i + 1]) {t++;}
            }
            if (t > 0) {Errors(_str, _str, -200000000.138);return -200000000.138;}
            else
            {
                double a = 0;
                List<double> res_PrCh = new List<double>();
                List<int> tr_PrCh = new List<int>();
                for (int i = 0; i < _str.Length; i++)
                {
                    if (_str[i] == '+' || _str[i] == '-') { tr_PrCh.Add(i); }
                }

                if (tr_PrCh.Count > 0)
                {
                    if (tr_PrCh[0] == 0 && (_str[tr_PrCh[0]] == '-' || _str[tr_PrCh[0]] == '+'))
                    {
                        tr_PrCh.Clear();
                        _str = "0" + _str;
                        for (int i = 0; i < _str.Length; i++)
                        {
                            if (_str[i] == '+' || _str[i] == '-') { tr_PrCh.Add(i); }
                        }
                    }
                }
                string[] strs = _str.Split(new char[] { '+', '-' });
                foreach (string s in strs)
                {
                    if (s.Contains('*') || s.Contains('/'))
                    {
                        if (B1(s) < -200000000) { Errors(_str, s, B1(s)); return -200000000.133; }
                        else { res_PrCh.Add(B1(s)); }
                    }
                    else
                    {
                        if (s.Contains('^'))
                        {
                            if (B2(s) < -200000000) { Errors(_str, s, B2(s)); return -200000000.134; }
                            else { res_PrCh.Add(B2(s)); }
                        }
                        else
                        {
                            if (s.Contains("sin") || s.Contains("cos") || s.Contains("abs"))
                            {
                                if (B3(s) < -200000000) { Errors(_str, s, B3(s)); return -200000000.135; }
                                else { res_PrCh.Add(B3(s)); }
                            }
                            else
                            {
                                if (B4(s) < -200000000) { Errors(_str, s, B4(s)); return -200000000.136; }
                                else { res_PrCh.Add(B4(s)); }
                            }
                        }
                    }
                }
                a = res_PrCh[0];
                for (int i = 0; i < tr_PrCh.Count; i++)
                {
                    if (_str[tr_PrCh[i]] == '+') { a = a + res_PrCh[i + 1]; }
                    else
                    {
                        if (_str[tr_PrCh[i]] == '-') { a = a - res_PrCh[i + 1]; }
                    }
                }
                return a;
            }
        }
        bool Oper(string _str)
        {
            List<string> Opers = new List<string>();
            Perem_Value = new double[List_Perem.Count];
            for (int i = 0; i < Perem_Value.Length; i++)
            {
                Perem_Value[i] = -21038135135;
            }
            Regex regex = new Regex(@"\s*[0-7]+\s*:");
            MatchCollection matches = regex.Matches(_str);
            if (matches.Count > 0)
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    if (matches.Count == i + 1)
                    {
                        Opers.Add(_str.Substring(matches[i].Index, _str.Length - matches[i].Index).Trim());
                    }
                    else
                    {
                        Opers.Add((_str.Substring(matches[i].Index, matches[i + 1].Index - matches[i].Index)).Trim());
                    }
                }
            }
            else
            {
                label1.Text = "wat?";
                return false;
            }
            for (int i = 0; i < Opers.Count; i++)
            {
                Opers[i] = Opers[i].Replace(" ", "");
                string[] U = Opers[i].Split(new string[] { ":" }, StringSplitOptions.None);
                if (U[0] != "")
                {
                    if (U[1] != "")
                    {
                        string[] P = U[1].Split(new string[] { "=" }, StringSplitOptions.None);
                        if (P[0] != "")
                        {
                            if (P[1] != "")
                            {
                                if (Perem(P[0]) == 0)
                                {
                                    if (List_Perem.Contains(P[0]))
                                    {
                                        if (PrCh(P[1]) > -200000000)
                                        {
                                            Perem_Value[List_Perem.IndexOf(P[0])] = PrCh(P[1]);
                                        }
                                        else { return false; }
                                    }
                                    else
                                    {
                                        Errors(P[0], P[0], -200000000.1245);
                                        return false;
                                    }
                                }
                                else
                                {
                                    Errors(P[0], P[0], -200000000.202);
                                    return false;
                                }
                            }
                            else
                            {
                                Errors(P[0] + " =", "", -200000000.203);
                                Errors(P[0] + "=", "", -200000000.203);
                                return false;
                            }

                        }
                        else
                        {
                            Errors(": =", "", -200000000.204);
                            Errors(":=", "", -200000000.204);
                            return false;
                        }
                    }
                    else
                    {
                        Errors(U[0] + " :", "", -200000000.205);
                        Errors(U[0] + ":", "", -200000000.205);
                        return false;
                    }
                }
                else
                {
                    Errors(_str, "", -200000000.206);
                    return false;
                }
            }
            return true;
        }
        bool Last(string _str)
        {
            _str = _str.Replace(" ", "");
            string[] srt = _str.Split(new char[] { ';' }, StringSplitOptions.None);
            foreach (string s in srt)
            {
                if (s != "")
                {
                    if (Perem(s) == 0)
                    {
                        if (List_Perem.Contains(s))
                        {
                            Errors(_str, s, -200000000.208);
                            return false;
                        }
                        else { List_Perem.Add(s); }
                    }
                    else
                    {
                        Errors(_str, s, -200000000.209);
                        return false;
                    }
                }
                else
                {
                    Errors(";;", "", -200000000.210);
                    Errors("; ;", "", -200000000.210);
                    return false;
                }
            }
            return true;
        }
        bool Zveno(string _str)
        {
            List<string> strs_for_analize = new List<string>();
            List<int> possition_of_F_or_S = new List<int>();
            string[] sw = _str.Split(new string[] { "First", "Second" }, StringSplitOptions.None);
            foreach (string s in sw) { strs_for_analize.Add(s.Trim()); }
            for (int i = 0; i < _str.Length - 5; i++)
            {
                if (_str[i] == 'F' && _str[i + 1] == 'i' && _str[i + 2] == 'r' && _str[i + 3] == 's' && _str[i + 4] == 't')
                {
                    possition_of_F_or_S.Add(1);
                }
                if (_str[i] == 'S' && _str[i + 1] == 'e' && _str[i + 2] == 'c' && _str[i + 3] == 'o' && _str[i + 4] == 'n' && _str[i + 5] == 'd')
                {
                    possition_of_F_or_S.Add(2);
                }
            }
            for (int i = 0; i < possition_of_F_or_S.Count; i++)
            {
                if (possition_of_F_or_S[i] == 1)
                {
                    if (strs_for_analize[i + 1] != "")
                    {
                        strs_for_analize[i + 1] = strs_for_analize[i + 1].Replace(" ", "");
                        string[] r = strs_for_analize[i + 1].Split(',');
                        for (int m = 0; m < r.Length; m++)
                        {
                            if (Uel(r[m]) != 0)
                            {
                                Errors(_str, r[m], -200000000.211);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        Errors(_str, "", -200000000.212);
                        return false;
                    }
                }
                else
                {
                    if (strs_for_analize[i + 1] != "")
                    {
                        string[] r = strs_for_analize[i + 1].Split(new string[] { " " }, StringSplitOptions.None);
                        for (int n = 0; n < r.Length; n++)
                        {
                            if (Perem(r[n]) == 0)
                            {
                                if (List_Perem.Contains(r[n]))
                                {
                                    Errors(strs_for_analize[i + 1], r[n], -200000000.213);
                                    return false;
                                }
                                else { List_Perem.Add(r[n]); }
                            }
                            else
                            {
                                Errors(strs_for_analize[i + 1], r[n], -200000000.214);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        Errors(_str, "", -200000000.215);
                        return false;
                    }
                }
            }
            return true;
        }
        bool Splt(string _str)
        {
            _str = _str.TrimStart().TrimEnd();
            List<int> fs = new List<int>();
            List<string> fss = new List<string>();
            int a = 0;
            int b = 0; 
            int mat = 0;
            string toZveno = "";
            string toLast = "";
            string toOper = "";
            if (_str.Contains("First") || _str.Contains("Second"))
            {
                a = Math.Min(_str.IndexOf("First"), _str.IndexOf("Second"));
                if (a == 0)
                {
                    Regex regex_if_First_Is_In_Last_Zveno = new Regex(@"\s*[A-Za-z]{1}[A-Za-z0-9]*\s*;\s*");// 3 a2; a3; ...
                    Match match_if_First_Is_In_Last_Zveno = regex_if_First_Is_In_Last_Zveno.Match(_str);
                    Regex regex_if_Second_Is_In_Last_Zveno = new Regex(@"\s+[A-Za-z]{1}[A-Za-z0-9]*\s*;\s*");// a1 a2;a3 ...
                    Match match_if_Second_Is_In_Last_Zveno = regex_if_Second_Is_In_Last_Zveno.Match(_str);

                    if (match_if_First_Is_In_Last_Zveno.Success || match_if_Second_Is_In_Last_Zveno.Success)
                    {
                        if (match_if_First_Is_In_Last_Zveno.Success)
                        {
                            mat = match_if_First_Is_In_Last_Zveno.Index;
                        }
                        else
                        {
                            if (match_if_Second_Is_In_Last_Zveno.Success)
                            {
                                mat = match_if_Second_Is_In_Last_Zveno.Index;
                            }
                            else { return false; }
                        }
                        toZveno = _str.Remove(mat).TrimEnd();
                        if (Zveno(toZveno))
                        {
                            Regex regex_for_Last = new Regex(@"\s*[0-7]+:");//5:a2=...
                            Match match_for_Last = regex_for_Last.Match(_str);
                            if (match_for_Last.Success)
                            {
                                toLast = _str.Remove(match_for_Last.Index);
                                toLast = toLast.Remove(0, mat).Trim();
                                if (Last(toLast))
                                {
                                    toOper = _str.Remove(0, match_for_Last.Index).Trim();

                                    if (Oper(toOper)) { return true; }
                                    else { return false; }
                                }
                                else { return false; }
                            }
                            else { Errors("", "", -200000000.216); return false; }
                        }
                        else { return false; }
                    }
                    else { Errors("", "", -200000000.217); return false; }
                }
                else { Errors("", "", -200000000.218); return false; }
            }
            else { Errors("", "", -200000000.219); return false; }
        }
        bool _language(string _str)
        {
            _str = _str.Trim();

            if (_str.Contains("Begin"))
            {
                if (_str.IndexOf("Begin") == 0)
                {
                    if (_str.LastIndexOf("Begin") == 0)
                    {
                        if (_str.Contains("End"))
                        {
                            if (_str.LastIndexOf("End") == _str.Length - 3)
                            {
                                if (_str.IndexOf("End") == _str.Length - 3)
                                {
                                    _str = _str.Remove(0, _str.IndexOf("Begin") + 5);
                                    _str = _str.Remove(_str.Length - 3, 3);

                                    if (Splt(_str)) { return true; }
                                    else { return false; }
                                }
                                else
                                {
                                    Errors("End", "", -200000000.220);
                                    return false;
                                }
                            }
                            else
                            {
                                Errors("End", "", -200000000.221);
                                return false;
                            }
                        }
                        else { Errors("", "", -200000000.222); return false; }
                    }
                    else { Errors("", "", -200000000.223); return false; }
                }
                else { Errors("", "", -200000000.224); return false; }
            }
            else { Errors("", "", -200000000.225); return false; }
        }
        void Errors(string _str, string _str_err, double er_code)
        {
            switch (er_code)
            {
                case -200000000.123:
                    label1.Text = "Пустая строка";
                    if(Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.124:
                    label1.Text = "Использована переменаня, которое не присвоено значение " + _str_err;
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.125:
                    break;
                case -200000000.1245:
                    label1.Text = "Использована не обозначенная ранее переменаня " + _str_err;
                    if(Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.1246:
                    label1.Text = "Неизвестный текст " + _str_err;
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.126:
                    label1.Text = "Неправильно написана функция " + _str_err;
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case 200000000.127:
                    label1.Text = "? " + _str_err;
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.137:
                    label1.Text = "Деление нa 0";
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.138:
                    label1.Text = "Два знака подряд";
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.202:
                    label1.Text = "Не переменная " + _str_err;
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.203:
                    label1.Text = "Пропущена правая часть";
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.204:
                    label1.Text = "Пропущена переменная";
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.205:
                    label1.Text = "Пропущена переменная и правая часть";
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.206:
                    label1.Text = "Пропущена \"Метка\"";
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.207:
                    label1.Text = "Встечено два равно одном операторе " + _str_err;
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.208:
                    label1.Text = "Переменная в \"Последнем\" " + _str_err + " уже была объявлена";
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.209:
                    label1.Text = "Не переменная в \"Последнем\": " + _str_err;
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.210:
                    label1.Text = "Пропущена переменная в \"Последнем\" " + _str_err;
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.211:
                    label1.Text = "Нецелое число после First " + _str_err;
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.212:
                    label1.Text = "Пустая строка после First";
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.213:
                    label1.Text = "Переменная перед Second " + _str_err + " уже была объявлена";
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.214:
                    label1.Text = "Не переменная после Second: " + _str_err;
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.215:
                    label1.Text = "Пустая строка после Second";
                    break;
                case -200000000.216:
                    label1.Text = "Отсутствует \"Оператор\"";
                    break;
                case -200000000.217:
                    label1.Text = "Отсутствует \"Последнее\"";
                    break;
                case -200000000.218:
                    label1.Text = "Между Begin и Firts или Second есть что-то, кроме пробелов";
                    break;
                case -200000000.219:
                    label1.Text = "В строке нет словa Firts и Second";
                    break;
                case -200000000.220:
                    label1.Text = "Слово End встречено два раза";
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.221:
                    label1.Text = "Слово End не на последнем месте";
                    if (Main_String.LastIndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.222:
                    label1.Text = "Слово End встречено два раза";
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.223:
                    label1.Text = "Слово Begin встречено два раза";
                    break;
                case -200000000.224:
                    label1.Text = "Слово Begin не на первом месте";
                    if (Main_String.IndexOf(_str) > -1)
                    {
                        richTextBox1.SelectionStart = Main_String.IndexOf(_str);
                        richTextBox1.SelectionLength = _str.Length;
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    break;
                case -200000000.225:
                    label1.Text = "Не встречено ключевое слово Begin";
                    break;

                default:
                    break;
            }
        }
        public Form1() { InitializeComponent(); }

        private void button1_Click(object sender, EventArgs e)
        {
            List_Perem.Clear();
            Perem_Value = new double[0];
            label1.Text = "";
            string str;
            str = richTextBox1.Text;
            Main_String = str;
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = str.Length;
            richTextBox1.SelectionColor = Color.Black;
            _language(str);
        }
    }
}
